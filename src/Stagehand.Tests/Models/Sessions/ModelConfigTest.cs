using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void NameValidationWorks()
    {
        ModelConfig value = "openai/gpt-5-nano";
        value.Validate();
    }

    [Fact]
    public void ObjectValidationWorks()
    {
        ModelConfig value = new ModelConfigObject()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigObjectProvider.OpenAI,
        };
        value.Validate();
    }

    [Fact]
    public void NameSerializationRoundtripWorks()
    {
        ModelConfig value = "openai/gpt-5-nano";
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ObjectSerializationRoundtripWorks()
    {
        ModelConfig value = new ModelConfigObject()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigObjectProvider.OpenAI,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(element);

        Assert.Equal(value, deserialized);
    }
}

public class ModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigObjectProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5-nano";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        ApiEnum<string, ModelConfigObjectProvider> expectedProvider =
            ModelConfigObjectProvider.OpenAI;

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigObjectProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelConfigObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigObjectProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelConfigObject>(element);
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5-nano";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        ApiEnum<string, ModelConfigObjectProvider> expectedProvider =
            ModelConfigObjectProvider.OpenAI;

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigObjectProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigObject { ModelName = "openai/gpt-5-nano" };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfigObject { ModelName = "openai/gpt-5-nano" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "openai/gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Provider = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "openai/gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Provider = null,
        };

        model.Validate();
    }
}

public class ModelConfigObjectProviderTest : TestBase
{
    [Theory]
    [InlineData(ModelConfigObjectProvider.OpenAI)]
    [InlineData(ModelConfigObjectProvider.Anthropic)]
    [InlineData(ModelConfigObjectProvider.Google)]
    [InlineData(ModelConfigObjectProvider.Microsoft)]
    public void Validation_Works(ModelConfigObjectProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigObjectProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigObjectProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelConfigObjectProvider.OpenAI)]
    [InlineData(ModelConfigObjectProvider.Anthropic)]
    [InlineData(ModelConfigObjectProvider.Google)]
    [InlineData(ModelConfigObjectProvider.Microsoft)]
    public void SerializationRoundtrip_Works(ModelConfigObjectProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigObjectProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigObjectProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigObjectProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigObjectProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
