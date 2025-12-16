using System.Text.Json;
using StagehandSDK.Core;
using StagehandSDK.Exceptions;
using StagehandSDK.Models.Sessions;

namespace StagehandSDK.Tests.Models.Sessions;

public class SessionObserveParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "selector",
            Timeout = 0,
        };

        ModelConfig expectedModel = new()
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };
        string expectedSelector = "selector";
        long expectedTimeout = 0;

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "selector",
            Timeout = 0,
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
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "selector",
            Timeout = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(json);
        Assert.NotNull(deserialized);

        ModelConfig expectedModel = new()
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };
        string expectedSelector = "selector";
        long expectedTimeout = 0;

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "selector",
            Timeout = 0,
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
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<BrowserbaseInvalidDataException>(() => value.Validate());
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
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
