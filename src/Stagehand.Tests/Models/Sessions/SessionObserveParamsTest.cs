using System;
using System.Net.Http;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionObserveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                Model = "openai/gpt-5-nano",
                Selector = "nav",
                Timeout = 30000,
            },
            XSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z"),
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedFrameID = "frameId";
        string expectedInstruction = "Find all clickable navigation links";
        SessionObserveParamsOptions expectedOptions = new()
        {
            Model = "openai/gpt-5-nano",
            Selector = "nav",
            Timeout = 30000,
        };
        DateTimeOffset expectedXSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z");
        ApiEnum<string, SessionObserveParamsXStreamResponse> expectedXStreamResponse =
            SessionObserveParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedInstruction, parameters.Instruction);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedXSentAt, parameters.XSentAt);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionObserveParams { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XSentAt);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sent-at"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",

            // Null should be interpreted as omitted for these properties
            FrameID = null,
            Instruction = null,
            Options = null,
            XSentAt = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XSentAt);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sent-at"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionObserveParams parameters = new() { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

        var url = parameters.Url(
            new()
            {
                BrowserbaseApiKey = "My Browserbase API Key",
                BrowserbaseProjectID = "My Browserbase Project ID",
                ModelApiKey = "My Model API Key",
            }
        );

        Assert.Equal(
            new Uri(
                "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/observe"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionObserveParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            XSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z"),
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new()
            {
                BrowserbaseApiKey = "My Browserbase API Key",
                BrowserbaseProjectID = "My Browserbase Project ID",
                ModelApiKey = "My Model API Key",
            }
        );

        Assert.Equal(["2025-01-15T10:30:00Z"], requestMessage.Headers.GetValues("x-sent-at"));
        Assert.Equal(["true"], requestMessage.Headers.GetValues("x-stream-response"));
    }
}

public class SessionObserveParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "nav",
            Timeout = 30000,
        };

        ModelConfig expectedModel = "openai/gpt-5-nano";
        string expectedSelector = "nav";
        double expectedTimeout = 30000;

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "nav",
            Timeout = 30000,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "nav",
            Timeout = 30000,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(element);
        Assert.NotNull(deserialized);

        ModelConfig expectedModel = "openai/gpt-5-nano";
        string expectedSelector = "nav";
        double expectedTimeout = 30000;

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "nav",
            Timeout = 30000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptions { };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionObserveParamsOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Selector = null,
            Timeout = null,
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Selector = null,
            Timeout = null,
        };

        model.Validate();
    }
}

public class SessionObserveParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionObserveParamsXStreamResponse.True)]
    [InlineData(SessionObserveParamsXStreamResponse.False)]
    public void Validation_Works(SessionObserveParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionObserveParamsXStreamResponse.True)]
    [InlineData(SessionObserveParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionObserveParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
