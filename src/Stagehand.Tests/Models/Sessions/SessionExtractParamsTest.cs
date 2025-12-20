using System;
using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExtractParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Extract all product names and prices from the page",
            Options = new()
            {
                Model = "openai/gpt-5-nano",
                Selector = "#main-content",
                Timeout = 30000,
            },
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            XLanguage = SessionExtractParamsXLanguage.Typescript,
            XSDKVersion = "3.0.6",
            XSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z"),
            XStreamResponse = SessionExtractParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedFrameID = "frameId";
        string expectedInstruction = "Extract all product names and prices from the page";
        SessionExtractParamsOptions expectedOptions = new()
        {
            Model = "openai/gpt-5-nano",
            Selector = "#main-content",
            Timeout = 30000,
        };
        Dictionary<string, JsonElement> expectedSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, SessionExtractParamsXLanguage> expectedXLanguage =
            SessionExtractParamsXLanguage.Typescript;
        string expectedXSDKVersion = "3.0.6";
        DateTimeOffset expectedXSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z");
        ApiEnum<string, SessionExtractParamsXStreamResponse> expectedXStreamResponse =
            SessionExtractParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedInstruction, parameters.Instruction);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.NotNull(parameters.Schema);
        Assert.Equal(expectedSchema.Count, parameters.Schema.Count);
        foreach (var item in expectedSchema)
        {
            Assert.True(parameters.Schema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Schema[item.Key]));
        }
        Assert.Equal(expectedXLanguage, parameters.XLanguage);
        Assert.Equal(expectedXSDKVersion, parameters.XSDKVersion);
        Assert.Equal(expectedXSentAt, parameters.XSentAt);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionExtractParams { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.Schema);
        Assert.False(parameters.RawBodyData.ContainsKey("schema"));
        Assert.Null(parameters.XLanguage);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-language"));
        Assert.Null(parameters.XSDKVersion);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sdk-version"));
        Assert.Null(parameters.XSentAt);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sent-at"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",

            // Null should be interpreted as omitted for these properties
            FrameID = null,
            Instruction = null,
            Options = null,
            Schema = null,
            XLanguage = null,
            XSDKVersion = null,
            XSentAt = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.Schema);
        Assert.False(parameters.RawBodyData.ContainsKey("schema"));
        Assert.Null(parameters.XLanguage);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-language"));
        Assert.Null(parameters.XSDKVersion);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sdk-version"));
        Assert.Null(parameters.XSentAt);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sent-at"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }
}

public class SessionExtractParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "#main-content",
            Timeout = 30000,
        };

        ModelConfig expectedModel = "openai/gpt-5-nano";
        string expectedSelector = "#main-content";
        double expectedTimeout = 30000;

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "#main-content",
            Timeout = 30000,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "#main-content",
            Timeout = 30000,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptions>(element);
        Assert.NotNull(deserialized);

        ModelConfig expectedModel = "openai/gpt-5-nano";
        string expectedSelector = "#main-content";
        double expectedTimeout = 30000;

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            Model = "openai/gpt-5-nano",
            Selector = "#main-content",
            Timeout = 30000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptions { };

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
        var model = new SessionExtractParamsOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptions
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
        var model = new SessionExtractParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Selector = null,
            Timeout = null,
        };

        model.Validate();
    }
}

public class SessionExtractParamsXLanguageTest : TestBase
{
    [Theory]
    [InlineData(SessionExtractParamsXLanguage.Typescript)]
    [InlineData(SessionExtractParamsXLanguage.Python)]
    [InlineData(SessionExtractParamsXLanguage.Playground)]
    public void Validation_Works(SessionExtractParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsXLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionExtractParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExtractParamsXLanguage.Typescript)]
    [InlineData(SessionExtractParamsXLanguage.Python)]
    [InlineData(SessionExtractParamsXLanguage.Playground)]
    public void SerializationRoundtrip_Works(SessionExtractParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsXLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXLanguage>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionExtractParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXLanguage>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionExtractParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionExtractParamsXStreamResponse.True)]
    [InlineData(SessionExtractParamsXStreamResponse.False)]
    public void Validation_Works(SessionExtractParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExtractParamsXStreamResponse.True)]
    [InlineData(SessionExtractParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionExtractParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
