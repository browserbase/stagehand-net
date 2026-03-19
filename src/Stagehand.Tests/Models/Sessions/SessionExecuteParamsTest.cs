using System;
using System.Net.Http;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExecuteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionExecuteParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            FrameID = "frameId",
            ShouldCache = true,
            XStreamResponse = SessionExecuteParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        AgentConfig expectedAgentConfig = new()
        {
            Cua = true,
            ExecutionModel = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Mode = Mode.Cua,
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Provider = Provider.OpenAI,
            SystemPrompt = "systemPrompt",
        };
        ExecuteOptions expectedExecuteOptions = new()
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
            ToolTimeout = 30000,
            UseSearch = true,
        };
        string expectedFrameID = "frameId";
        bool expectedShouldCache = true;
        ApiEnum<string, SessionExecuteParamsXStreamResponse> expectedXStreamResponse =
            SessionExecuteParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAgentConfig, parameters.AgentConfig);
        Assert.Equal(expectedExecuteOptions, parameters.ExecuteOptions);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedShouldCache, parameters.ShouldCache);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionExecuteParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            FrameID = "frameId",
        };

        Assert.Null(parameters.ShouldCache);
        Assert.False(parameters.RawBodyData.ContainsKey("shouldCache"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionExecuteParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            FrameID = "frameId",

            // Null should be interpreted as omitted for these properties
            ShouldCache = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.ShouldCache);
        Assert.False(parameters.RawBodyData.ContainsKey("shouldCache"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionExecuteParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            ShouldCache = true,
            XStreamResponse = SessionExecuteParamsXStreamResponse.True,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SessionExecuteParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            ShouldCache = true,
            XStreamResponse = SessionExecuteParamsXStreamResponse.True,

            FrameID = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.True(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionExecuteParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
        };

        var url = parameters.Url(
            new()
            {
                BrowserbaseApiKey = "My Browserbase API Key",
                BrowserbaseProjectID = "My Browserbase Project ID",
                ModelApiKey = "My Model API Key",
            }
        );

        Assert.Equal(
            new Uri(
                "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/agentExecute"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionExecuteParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            XStreamResponse = SessionExecuteParamsXStreamResponse.True,
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new()
            {
                BrowserbaseApiKey = "My Browserbase API Key",
                BrowserbaseProjectID = "My Browserbase Project ID",
                ModelApiKey = "My Model API Key",
            }
        );

        Assert.Equal(["true"], requestMessage.Headers.GetValues("x-stream-response"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SessionExecuteParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            AgentConfig = new()
            {
                Cua = true,
                ExecutionModel = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Mode = Mode.Cua,
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Provider = ModelConfigProvider.OpenAI,
                },
                Provider = Provider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            ExecuteOptions = new()
            {
                Instruction =
                    "Log in with username 'demo' and password 'test123', then navigate to settings",
                HighlightCursor = true,
                MaxSteps = 20,
                ToolTimeout = 30000,
                UseSearch = true,
            },
            FrameID = "frameId",
            ShouldCache = true,
            XStreamResponse = SessionExecuteParamsXStreamResponse.True,
        };

        SessionExecuteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            ExecutionModel = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Mode = Mode.Cua,
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Provider = Provider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        bool expectedCua = true;
        ExecutionModel expectedExecutionModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        ApiEnum<string, Mode> expectedMode = Mode.Cua;
        AgentConfigModel expectedModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        ApiEnum<string, Provider> expectedProvider = Provider.OpenAI;
        string expectedSystemPrompt = "systemPrompt";

        Assert.Equal(expectedCua, model.Cua);
        Assert.Equal(expectedExecutionModel, model.ExecutionModel);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            ExecutionModel = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Mode = Mode.Cua,
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Provider = Provider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            ExecutionModel = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Mode = Mode.Cua,
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Provider = Provider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCua = true;
        ExecutionModel expectedExecutionModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        ApiEnum<string, Mode> expectedMode = Mode.Cua;
        AgentConfigModel expectedModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        ApiEnum<string, Provider> expectedProvider = Provider.OpenAI;
        string expectedSystemPrompt = "systemPrompt";

        Assert.Equal(expectedCua, deserialized.Cua);
        Assert.Equal(expectedExecutionModel, deserialized.ExecutionModel);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            ExecutionModel = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Mode = Mode.Cua,
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Provider = Provider.OpenAI,
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
        Assert.Null(model.ExecutionModel);
        Assert.False(model.RawData.ContainsKey("executionModel"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
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
            ExecutionModel = null,
            Mode = null,
            Model = null,
            Provider = null,
            SystemPrompt = null,
        };

        Assert.Null(model.Cua);
        Assert.False(model.RawData.ContainsKey("cua"));
        Assert.Null(model.ExecutionModel);
        Assert.False(model.RawData.ContainsKey("executionModel"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
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
            ExecutionModel = null,
            Mode = null,
            Model = null,
            Provider = null,
            SystemPrompt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfig
        {
            Cua = true,
            ExecutionModel = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Mode = Mode.Cua,
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Provider = ModelConfigProvider.OpenAI,
            },
            Provider = Provider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        AgentConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelTest : TestBase
{
    [Fact]
    public void ModelConfigValidationWorks()
    {
        ExecutionModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ExecutionModel value = "string";
        value.Validate();
    }

    [Fact]
    public void ModelConfigSerializationRoundtripWorks()
    {
        ExecutionModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExecutionModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Dom)]
    [InlineData(Mode.Hybrid)]
    [InlineData(Mode.Cua)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.Dom)]
    [InlineData(Mode.Hybrid)]
    [InlineData(Mode.Cua)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentConfigModelTest : TestBase
{
    [Fact]
    public void ConfigValidationWorks()
    {
        AgentConfigModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentConfigModel value = "string";
        value.Validate();
    }

    [Fact]
    public void ConfigSerializationRoundtripWorks()
    {
        AgentConfigModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Provider = ModelConfigProvider.OpenAI,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentConfigModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProviderTest : TestBase
{
    [Theory]
    [InlineData(Provider.OpenAI)]
    [InlineData(Provider.Anthropic)]
    [InlineData(Provider.Google)]
    [InlineData(Provider.Microsoft)]
    [InlineData(Provider.Bedrock)]
    public void Validation_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Provider.OpenAI)]
    [InlineData(Provider.Anthropic)]
    [InlineData(Provider.Google)]
    [InlineData(Provider.Microsoft)]
    [InlineData(Provider.Bedrock)]
    public void SerializationRoundtrip_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
            ToolTimeout = 30000,
            UseSearch = true,
        };

        string expectedInstruction =
            "Log in with username 'demo' and password 'test123', then navigate to settings";
        bool expectedHighlightCursor = true;
        double expectedMaxSteps = 20;
        double expectedToolTimeout = 30000;
        bool expectedUseSearch = true;

        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.Equal(expectedHighlightCursor, model.HighlightCursor);
        Assert.Equal(expectedMaxSteps, model.MaxSteps);
        Assert.Equal(expectedToolTimeout, model.ToolTimeout);
        Assert.Equal(expectedUseSearch, model.UseSearch);
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
            ToolTimeout = 30000,
            UseSearch = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptions>(
            json,
            ModelBase.SerializerOptions
        );

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
            ToolTimeout = 30000,
            UseSearch = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInstruction =
            "Log in with username 'demo' and password 'test123', then navigate to settings";
        bool expectedHighlightCursor = true;
        double expectedMaxSteps = 20;
        double expectedToolTimeout = 30000;
        bool expectedUseSearch = true;

        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.Equal(expectedHighlightCursor, deserialized.HighlightCursor);
        Assert.Equal(expectedMaxSteps, deserialized.MaxSteps);
        Assert.Equal(expectedToolTimeout, deserialized.ToolTimeout);
        Assert.Equal(expectedUseSearch, deserialized.UseSearch);
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
            ToolTimeout = 30000,
            UseSearch = true,
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
        Assert.Null(model.ToolTimeout);
        Assert.False(model.RawData.ContainsKey("toolTimeout"));
        Assert.Null(model.UseSearch);
        Assert.False(model.RawData.ContainsKey("useSearch"));
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
            ToolTimeout = null,
            UseSearch = null,
        };

        Assert.Null(model.HighlightCursor);
        Assert.False(model.RawData.ContainsKey("highlightCursor"));
        Assert.Null(model.MaxSteps);
        Assert.False(model.RawData.ContainsKey("maxSteps"));
        Assert.Null(model.ToolTimeout);
        Assert.False(model.RawData.ContainsKey("toolTimeout"));
        Assert.Null(model.UseSearch);
        Assert.False(model.RawData.ContainsKey("useSearch"));
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
            ToolTimeout = null,
            UseSearch = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
            ToolTimeout = 30000,
            UseSearch = true,
        };

        ExecuteOptions copied = new(model);

        Assert.Equal(model, copied);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExecuteParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
