using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        ModelConfig value = new("string");
        value.Validate();
    }

    [Fact]
    public void UnionMember1Validation_Works()
    {
        ModelConfig value = new(
            new UnionMember1()
            {
                ModelName = "modelName",
                APIKey = "apiKey",
                BaseURL = "https://example.com",
            }
        );
        value.Validate();
    }

    [Fact]
    public void stringSerializationRoundtrip_Works()
    {
        ModelConfig value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtrip_Works()
    {
        ModelConfig value = new(
            new UnionMember1()
            {
                ModelName = "modelName",
                APIKey = "apiKey",
                BaseURL = "https://example.com",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            ModelName = "modelName",
            APIKey = "apiKey",
            BaseURL = "https://example.com",
        };

        string expectedModelName = "modelName";
        string expectedAPIKey = "apiKey";
        string expectedBaseURL = "https://example.com";

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedAPIKey, model.APIKey);
        Assert.Equal(expectedBaseURL, model.BaseURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            ModelName = "modelName",
            APIKey = "apiKey",
            BaseURL = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember1
        {
            ModelName = "modelName",
            APIKey = "apiKey",
            BaseURL = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(json);
        Assert.NotNull(deserialized);

        string expectedModelName = "modelName";
        string expectedAPIKey = "apiKey";
        string expectedBaseURL = "https://example.com";

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedAPIKey, deserialized.APIKey);
        Assert.Equal(expectedBaseURL, deserialized.BaseURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember1
        {
            ModelName = "modelName",
            APIKey = "apiKey",
            BaseURL = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1 { ModelName = "modelName" };

        Assert.Null(model.APIKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseURL);
        Assert.False(model.RawData.ContainsKey("baseURL"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1 { ModelName = "modelName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            ModelName = "modelName",

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
        var model = new UnionMember1
        {
            ModelName = "modelName",

            // Null should be interpreted as omitted for these properties
            APIKey = null,
            BaseURL = null,
        };

        model.Validate();
    }
}
