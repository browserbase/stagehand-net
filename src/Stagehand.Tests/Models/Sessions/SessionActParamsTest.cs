using System;
using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Sessions = Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionActParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            FrameID = "frameId",
            Options = new()
            {
                Model = "openai/gpt-5-nano",
                Timeout = 30000,
                Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
            },
            XLanguage = Sessions::XLanguage.Typescript,
            XSDKVersion = "3.0.6",
            XSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z"),
            XStreamResponse = Sessions::XStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        Sessions::Input expectedInput = "Click the login button";
        string expectedFrameID = "frameId";
        Sessions::Options expectedOptions = new()
        {
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };
        ApiEnum<string, Sessions::XLanguage> expectedXLanguage = Sessions::XLanguage.Typescript;
        string expectedXSDKVersion = "3.0.6";
        DateTimeOffset expectedXSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z");
        ApiEnum<string, Sessions::XStreamResponse> expectedXStreamResponse =
            Sessions::XStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedXLanguage, parameters.XLanguage);
        Assert.Equal(expectedXSDKVersion, parameters.XSDKVersion);
        Assert.Equal(expectedXSentAt, parameters.XSentAt);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
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
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",

            // Null should be interpreted as omitted for these properties
            FrameID = null,
            Options = null,
            XLanguage = null,
            XSDKVersion = null,
            XSentAt = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
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

public class InputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Sessions::Input value = new("string");
        value.Validate();
    }

    [Fact]
    public void ActionValidationWorks()
    {
        Sessions::Input value = new(
            new Sessions::Action()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                BackendNodeID = 0,
                Method = "click",
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Sessions::Input value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Sessions::Input>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionSerializationRoundtripWorks()
    {
        Sessions::Input value = new(
            new Sessions::Action()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                BackendNodeID = 0,
                Method = "click",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Sessions::Input>(element);

        Assert.Equal(value, deserialized);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sessions::Options
        {
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };

        Sessions::ModelConfig expectedModel = "openai/gpt-5-nano";
        double expectedTimeout = 30000;
        Dictionary<string, string> expectedVariables = new() { { "username", "john_doe" } };

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(model.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Variables[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Sessions::Options
        {
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Sessions::Options>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sessions::Options
        {
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Sessions::Options>(element);
        Assert.NotNull(deserialized);

        Sessions::ModelConfig expectedModel = "openai/gpt-5-nano";
        double expectedTimeout = 30000;
        Dictionary<string, string> expectedVariables = new() { { "username", "john_doe" } };

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(deserialized.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Variables[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Sessions::Options
        {
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sessions::Options { };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sessions::Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Sessions::Options
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Timeout = null,
            Variables = null,
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Sessions::Options
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Timeout = null,
            Variables = null,
        };

        model.Validate();
    }
}

public class XLanguageTest : TestBase
{
    [Theory]
    [InlineData(Sessions::XLanguage.Typescript)]
    [InlineData(Sessions::XLanguage.Python)]
    [InlineData(Sessions::XLanguage.Playground)]
    public void Validation_Works(Sessions::XLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sessions::XLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sessions::XLanguage.Typescript)]
    [InlineData(Sessions::XLanguage.Python)]
    [InlineData(Sessions::XLanguage.Playground)]
    public void SerializationRoundtrip_Works(Sessions::XLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sessions::XLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class XStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(Sessions::XStreamResponse.True)]
    [InlineData(Sessions::XStreamResponse.False)]
    public void Validation_Works(Sessions::XStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sessions::XStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sessions::XStreamResponse.True)]
    [InlineData(Sessions::XStreamResponse.False)]
    public void SerializationRoundtrip_Works(Sessions::XStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sessions::XStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
