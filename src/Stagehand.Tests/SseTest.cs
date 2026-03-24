using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;
using Stagehand.Exceptions;

namespace Stagehand.Tests;

public class SseTest : TestBase
{
    static readonly TheoryData<string, string[]> _data = new()
    {
        // event and data
        { "event: starting\n" + "data: {\"foo\":true}\n\n", new[] { "{\"foo\": true}" } },
        // event missing data
        { "event: starting\n" + "\n", [] },
        // multiple events and data
        {
            "event: starting\n"
                + "data: {\"foo\":true}\n\n"
                + "event: connected\n"
                + "data: {\"bar\": false}\n\n",
            new[] { "{\"foo\": true}", "{\"bar\": false}" }
        },
        // multiple events missing data
        { "event: starting\n" + "\n" + "event: connected\n" + "\n", [] },
        // json-escaped double newline
        {
            "event: starting\n" + "data: {\ndata: \"foo\":\ndata: true }\n\n\n",
            new[] { "{ \"foo\":\ntrue }" }
        },
        // multiple data lines
        {
            "event: starting\n" + "data: { \ndata: \"foo\":\ndata: true }\n\n\n",
            new[] { "{ \"foo\":\ntrue }" }
        },
        // special newline character
        {
            "event: starting\n"
                + "data: {\"content\": \" culpa\"}\n\n"
                + "event: connected\n"
                + "data: {\"content\": \" \u2028\"}\n\n"
                + "event: starting\n"
                + "data: {\"content\": \"foo\"}\n\n",
            new[]
            {
                "{\"content\": \" culpa\"}",
                "{\"content\": \" \u2028\"}",
                "{\"content\": \"foo\"}",
            }
        },
        // multi-byte character
        {
            "event: starting\n"
                + "data: {\"content\": "
                + "\"\u0438\u0437\u0432\u0435\u0441\u0442\u043d\u0438\"}\n\n}",
            new[] { "{\"content\":\"известни\"}" }
        },
    };

    public static TheoryData<string, string[]> Data
    {
        get { return _data; }
    }

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Sse_Works(
        string events,
        string[] expectedMessageStrings,
        CancellationToken cancellationToken = default
    )
    {
        var expectedMessages = new List<JsonElement>();
        foreach (var message in expectedMessageStrings)
        {
            expectedMessages.Add(JsonSerializer.Deserialize<JsonElement>(message));
        }

        var resp = new HttpResponseMessage() { Content = new StringContent(events) };

        var actualMessages = new List<JsonElement>();
        await foreach (var message in Sse.Enumerate<JsonElement>(resp, cancellationToken))
        {
            actualMessages.Add(message);
        }

        Assert.Equal(expectedMessages.Count, actualMessages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedMessages[i], actualMessages[i]));
        }
    }

    [Fact]
    public async Task SseEventError_Works()
    {
        var resp = new HttpResponseMessage()
        {
            Content = new StringContent("event: error\ndata: unspecified error\n\n"),
        };

        var exception = await Assert.ThrowsAsync<StagehandSseException>(async () =>
        {
            await foreach (
                var message in Sse.Enumerate<JsonElement>(
                    resp,
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        Assert.Equal("SSE error returned from server: 'unspecified error'", exception.Message);
    }
}
