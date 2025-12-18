using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class AgentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            Model = "openai/gpt-5-nano",
            SystemPrompt = "systemPrompt",
        };

        bool expectedCua = true;
        ModelConfig expectedModel = "openai/gpt-5-nano";
        string expectedSystemPrompt = "systemPrompt";

        Assert.Equal(expectedCua, model.Cua);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            Model = "openai/gpt-5-nano",
            SystemPrompt = "systemPrompt",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            Model = "openai/gpt-5-nano",
            SystemPrompt = "systemPrompt",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(element);
        Assert.NotNull(deserialized);

        bool expectedCua = true;
        ModelConfig expectedModel = "openai/gpt-5-nano";
        string expectedSystemPrompt = "systemPrompt";

        Assert.Equal(expectedCua, deserialized.Cua);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            Model = "openai/gpt-5-nano",
            SystemPrompt = "systemPrompt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfig { };

        Assert.Null(model.Cua);
        Assert.False(model.RawData.ContainsKey("cua"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("systemPrompt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfig
        {
            // Null should be interpreted as omitted for these properties
            Cua = null,
            Model = null,
            SystemPrompt = null,
        };

        Assert.Null(model.Cua);
        Assert.False(model.RawData.ContainsKey("cua"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("systemPrompt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfig
        {
            // Null should be interpreted as omitted for these properties
            Cua = null,
            Model = null,
            SystemPrompt = null,
        };

        model.Validate();
    }
}

public class ExecuteOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
        };

        string expectedInstruction =
            "Log in with username 'demo' and password 'test123', then navigate to settings";
        bool expectedHighlightCursor = true;
        double expectedMaxSteps = 20;

        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.Equal(expectedHighlightCursor, model.HighlightCursor);
        Assert.Equal(expectedMaxSteps, model.MaxSteps);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptions>(element);
        Assert.NotNull(deserialized);

        string expectedInstruction =
            "Log in with username 'demo' and password 'test123', then navigate to settings";
        bool expectedHighlightCursor = true;
        double expectedMaxSteps = 20;

        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.Equal(expectedHighlightCursor, deserialized.HighlightCursor);
        Assert.Equal(expectedMaxSteps, deserialized.MaxSteps);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
        };

        Assert.Null(model.HighlightCursor);
        Assert.False(model.RawData.ContainsKey("highlightCursor"));
        Assert.Null(model.MaxSteps);
        Assert.False(model.RawData.ContainsKey("maxSteps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",

            // Null should be interpreted as omitted for these properties
            HighlightCursor = null,
            MaxSteps = null,
        };

        Assert.Null(model.HighlightCursor);
        Assert.False(model.RawData.ContainsKey("highlightCursor"));
        Assert.Null(model.MaxSteps);
        Assert.False(model.RawData.ContainsKey("maxSteps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",

            // Null should be interpreted as omitted for these properties
            HighlightCursor = null,
            MaxSteps = null,
        };

        model.Validate();
    }
}

public class SessionExecuteParamsXLanguageTest : TestBase
{
    [Theory]
    [InlineData(SessionExecuteParamsXLanguage.Typescript)]
    [InlineData(SessionExecuteParamsXLanguage.Python)]
    [InlineData(SessionExecuteParamsXLanguage.Playground)]
    public void Validation_Works(SessionExecuteParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExecuteParamsXLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionExecuteParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExecuteParamsXLanguage.Typescript)]
    [InlineData(SessionExecuteParamsXLanguage.Python)]
    [InlineData(SessionExecuteParamsXLanguage.Playground)]
    public void SerializationRoundtrip_Works(SessionExecuteParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExecuteParamsXLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXLanguage>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionExecuteParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXLanguage>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionExecuteParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionExecuteParamsXStreamResponse.True)]
    [InlineData(SessionExecuteParamsXStreamResponse.False)]
    public void Validation_Works(SessionExecuteParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExecuteParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXStreamResponse>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExecuteParamsXStreamResponse.True)]
    [InlineData(SessionExecuteParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionExecuteParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExecuteParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXStreamResponse>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
