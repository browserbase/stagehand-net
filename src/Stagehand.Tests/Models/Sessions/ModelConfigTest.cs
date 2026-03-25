using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5-nano";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5-nano";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfig { ModelName = "openai/gpt-5-nano" };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfig { ModelName = "openai/gpt-5-nano" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
            Provider = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
            Provider = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };

        ModelConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigProviderTest : TestBase
{
    [Theory]
    [InlineData(ModelConfigProvider.OpenAI)]
    [InlineData(ModelConfigProvider.Anthropic)]
    [InlineData(ModelConfigProvider.Google)]
    [InlineData(ModelConfigProvider.Microsoft)]
    [InlineData(ModelConfigProvider.Bedrock)]
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelConfigProvider.OpenAI)]
    [InlineData(ModelConfigProvider.Anthropic)]
    [InlineData(ModelConfigProvider.Google)]
    [InlineData(ModelConfigProvider.Microsoft)]
    [InlineData(ModelConfigProvider.Bedrock)]
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
            JsonSerializer.SerializeToElement("invalid value"),
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
