using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;

namespace Stagehand.Tests;

public class SseTest : TestBase
{
    static readonly TheoryData<string, string[]> _data = new()
    {
        // data missing event
        { "data: {\"foo\":true}\n\n", new[] { "{\"foo\": true}" } },
        // multiple data missing event
        {
            "data: { \"foo\":true}\n\ndata: {\"bar\": false }\n\n",
            new[] { "{ \"foo\": true }", "{ \"bar\": false }" }
        },
        // json-escaped double newline
        { "data: {\ndata: \"foo\":\ndata: true }\n\n\n", new[] { "{ \"foo\":\ntrue }" } },
        // multiple data lines
        { "data: { \ndata: \"foo\":\ndata: true }\n\n\n", new[] { "{ \"foo\":\ntrue }" } },
        // special newline character
        {
            "data: {\"content\": \" culpa\"}\n\n"
                + "data: {\"content\": \" \u2028\"}\n\n"
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
            "data: {\"content\": " + "\"\u0438\u0437\u0432\u0435\u0441\u0442\u043d\u0438\"}\n\n}",
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
}
