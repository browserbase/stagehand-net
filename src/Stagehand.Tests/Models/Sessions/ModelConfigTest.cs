using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void NameValidationWorks()
    {
        ModelConfig value = new("openai/gpt-5-nano");
        value.Validate();
    }

    [Fact]
    public void ObjectValidationWorks()
    {
        ModelConfig value = new(
            new ModelConfigObject()
            {
                ModelName = "gpt-5-nano",
                APIKey = "sk-some-openai-api-key",
                BaseURL = "https://api.openai.com/v1",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NameSerializationRoundtripWorks()
    {
        ModelConfig value = new("openai/gpt-5-nano");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ObjectSerializationRoundtripWorks()
    {
        ModelConfig value = new(
            new ModelConfigObject()
            {
                ModelName = "gpt-5-nano",
                APIKey = "sk-some-openai-api-key",
                BaseURL = "https://api.openai.com/v1",
            }
        );
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
            ModelName = "gpt-5-nano",
            APIKey = "sk-some-openai-api-key",
            BaseURL = "https://api.openai.com/v1",
        };

        string expectedModelName = "gpt-5-nano";
        string expectedAPIKey = "sk-some-openai-api-key";
        string expectedBaseURL = "https://api.openai.com/v1";

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedAPIKey, model.APIKey);
        Assert.Equal(expectedBaseURL, model.BaseURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "gpt-5-nano",
            APIKey = "sk-some-openai-api-key",
            BaseURL = "https://api.openai.com/v1",
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
            ModelName = "gpt-5-nano",
            APIKey = "sk-some-openai-api-key",
            BaseURL = "https://api.openai.com/v1",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelConfigObject>(element);
        Assert.NotNull(deserialized);

        string expectedModelName = "gpt-5-nano";
        string expectedAPIKey = "sk-some-openai-api-key";
        string expectedBaseURL = "https://api.openai.com/v1";

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedAPIKey, deserialized.APIKey);
        Assert.Equal(expectedBaseURL, deserialized.BaseURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "gpt-5-nano",
            APIKey = "sk-some-openai-api-key",
            BaseURL = "https://api.openai.com/v1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigObject { ModelName = "gpt-5-nano" };

        Assert.Null(model.APIKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseURL);
        Assert.False(model.RawData.ContainsKey("baseURL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfigObject { ModelName = "gpt-5-nano" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            APIKey = null,
            BaseURL = null,
        };

        Assert.Null(model.APIKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseURL);
        Assert.False(model.RawData.ContainsKey("baseURL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfigObject
        {
            ModelName = "gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            APIKey = null,
            BaseURL = null,
        };

        model.Validate();
    }
}
