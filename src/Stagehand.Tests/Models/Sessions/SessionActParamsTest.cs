using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class InputTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        Input value = new("string");
        value.Validate();
    }

    [Fact]
    public void actionValidation_Works()
    {
        Input value = new(
            new Action()
            {
                Arguments = ["string"],
                Description = "description",
                Method = "method",
                Selector = "selector",
                BackendNodeID = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void stringSerializationRoundtrip_Works()
    {
        Input value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Input>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void actionSerializationRoundtrip_Works()
    {
        Input value = new(
            new Action()
            {
                Arguments = ["string"],
                Description = "description",
                Method = "method",
                Selector = "selector",
                BackendNodeID = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Input>(json);

        Assert.Equal(value, deserialized);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Timeout = 0,
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ModelConfig expectedModel = new()
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };
        long expectedTimeout = 0;
        Dictionary<string, string> expectedVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedTimeout, model.Timeout);
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
        var model = new Options
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Timeout = 0,
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Timeout = 0,
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);
        Assert.NotNull(deserialized);

        ModelConfig expectedModel = new()
        {
            APIKey = "apiKey",
            BaseURL = "https://example.com",
            Model = "model",
            Provider = ModelConfigProvider.OpenAI,
        };
        long expectedTimeout = 0;
        Dictionary<string, string> expectedVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
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
        var model = new Options
        {
            Model = new()
            {
                APIKey = "apiKey",
                BaseURL = "https://example.com",
                Model = "model",
                Provider = ModelConfigProvider.OpenAI,
            },
            Timeout = 0,
            Variables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

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
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
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
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Timeout = null,
            Variables = null,
        };

        model.Validate();
    }
}

public class XStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(XStreamResponse.True)]
    [InlineData(XStreamResponse.False)]
    public void Validation_Works(XStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<BrowserbaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(XStreamResponse.True)]
    [InlineData(XStreamResponse.False)]
    public void SerializationRoundtrip_Works(XStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XStreamResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XStreamResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
