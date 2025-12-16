using System.Text.Json;
using StagehandSDK.Core;
using StagehandSDK.Exceptions;
using StagehandSDK.Models.Sessions;

namespace StagehandSDK.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfig
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };

        string expectedAPIKey = "apiKey";
        string expectedBaseURL = "https://example.com";
        string expectedModel = "model";
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;

        Assert.Equal(expectedAPIKey, model.APIKey);
        Assert.Equal(expectedBaseURL, model.BaseURL);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfig
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfig
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(json);
        Assert.NotNull(deserialized);

        string expectedAPIKey = "apiKey";
        string expectedBaseURL = "https://example.com";
        string expectedModel = "model";
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;

        Assert.Equal(expectedAPIKey, deserialized.APIKey);
        Assert.Equal(expectedBaseURL, deserialized.BaseURL);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfig
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfig { };

        Assert.Null(model.APIKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseURL);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfig
        {
            // Null should be interpreted as omitted for these properties
            APIKey = null,
            BaseURL = null,
            Model = null,
            Provider = null,
        };

        Assert.Null(model.APIKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseURL);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfig
        {
            // Null should be interpreted as omitted for these properties
            APIKey = null,
            BaseURL = null,
            Model = null,
            Provider = null,
        };

        model.Validate();
    }
}

public class ModelConfigProviderTest : TestBase
{
    [Theory]
    [InlineData(ModelConfigProvider.OpenAI)]
    [InlineData(ModelConfigProvider.Anthropic)]
    [InlineData(ModelConfigProvider.Google)]
    public void Validation_Works(ModelConfigProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<BrowserbaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelConfigProvider.OpenAI)]
    [InlineData(ModelConfigProvider.Anthropic)]
    [InlineData(ModelConfigProvider.Google)]
    public void SerializationRoundtrip_Works(ModelConfigProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
