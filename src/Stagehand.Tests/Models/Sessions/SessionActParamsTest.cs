using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class InputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Input value = new("string");
        value.Validate();
    }

    [Fact]
    public void ActionValidationWorks()
    {
        Input value = new(
            new Action()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                Method = "click",
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Input value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Input>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionSerializationRoundtripWorks()
    {
        Input value = new(
            new Action()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                Method = "click",
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
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };

        ModelConfig expectedModel = "openai/gpt-5-nano";
        double expectedTimeout = 30000;
        Dictionary<string, string> expectedVariables = new() { { "username", "john_doe" } };

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
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
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
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);
        Assert.NotNull(deserialized);

        ModelConfig expectedModel = "openai/gpt-5-nano";
        double expectedTimeout = 30000;
        Dictionary<string, string> expectedVariables = new() { { "username", "john_doe" } };

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
            Model = "openai/gpt-5-nano",
            Timeout = 30000,
            Variables = new Dictionary<string, string>() { { "username", "john_doe" } },
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

public class XLanguageTest : TestBase
{
    [Theory]
    [InlineData(XLanguage.Typescript)]
    [InlineData(XLanguage.Python)]
    [InlineData(XLanguage.Playground)]
    public void Validation_Works(XLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(XLanguage.Typescript)]
    [InlineData(XLanguage.Python)]
    [InlineData(XLanguage.Playground)]
    public void SerializationRoundtrip_Works(XLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
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
