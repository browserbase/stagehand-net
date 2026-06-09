using System;
using System.Collections.Generic;
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
            },
            FrameID = "frameId",
            ShouldCache = true,
            XStreamResponse = SessionExecuteParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        AgentConfig expectedAgentConfig = new()
        {
            Cua = true,
            ExecutionModel = new ExecutionModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Mode = Mode.Cua,
            Model = new AgentConfigModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Provider = AgentConfigProvider.OpenAI,
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
            Variables = new Dictionary<string, ExecuteOptionsVariable>() { { "foo", "string" } },
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/agentExecute"
                ),
                url
            )
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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
                ExecutionModel = new ExecutionModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Mode = Mode.Cua,
                Model = new AgentConfigModelVertexModelConfigObject()
                {
                    Auth = new()
                    {
                        Credentials = new()
                        {
                            ClientEmail = "client_email",
                            PrivateKey = "private_key",
                            AuthProviderX509CertUrl = "https://example.com",
                            AuthUri = "https://example.com",
                            ClientID = "client_id",
                            ClientX509CertUrl = "https://example.com",
                            PrivateKeyID = "private_key_id",
                            ProjectID = "project_id",
                            TokenUri = "https://example.com",
                            Type =
                                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                        {
                            Location = "us-central1",
                            Project = "my-gcp-project",
                            BaseUrl = "https://example.com",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        }
                    ),
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                },
                Provider = AgentConfigProvider.OpenAI,
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
                Variables = new Dictionary<string, ExecuteOptionsVariable>()
                {
                    { "foo", "string" },
                },
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
            ExecutionModel = new ExecutionModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Mode = Mode.Cua,
            Model = new AgentConfigModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Provider = AgentConfigProvider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        bool expectedCua = true;
        ExecutionModel expectedExecutionModel = new ExecutionModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, Mode> expectedMode = Mode.Cua;
        AgentConfigModel expectedModel = new AgentConfigModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, AgentConfigProvider> expectedProvider = AgentConfigProvider.OpenAI;
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
            ExecutionModel = new ExecutionModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Mode = Mode.Cua,
            Model = new AgentConfigModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Provider = AgentConfigProvider.OpenAI,
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
            ExecutionModel = new ExecutionModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Mode = Mode.Cua,
            Model = new AgentConfigModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Provider = AgentConfigProvider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCua = true;
        ExecutionModel expectedExecutionModel = new ExecutionModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, Mode> expectedMode = Mode.Cua;
        AgentConfigModel expectedModel = new AgentConfigModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, AgentConfigProvider> expectedProvider = AgentConfigProvider.OpenAI;
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
            ExecutionModel = new ExecutionModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Mode = Mode.Cua,
            Model = new AgentConfigModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Provider = AgentConfigProvider.OpenAI,
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
            ExecutionModel = new ExecutionModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Mode = Mode.Cua,
            Model = new AgentConfigModelVertexModelConfigObject()
            {
                Auth = new()
                {
                    Credentials = new()
                    {
                        ClientEmail = "client_email",
                        PrivateKey = "private_key",
                        AuthProviderX509CertUrl = "https://example.com",
                        AuthUri = "https://example.com",
                        ClientID = "client_id",
                        ClientX509CertUrl = "https://example.com",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "https://example.com",
                        Type =
                            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                    {
                        Location = "us-central1",
                        Project = "my-gcp-project",
                        BaseUrl = "https://example.com",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    }
                ),
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            Provider = AgentConfigProvider.OpenAI,
            SystemPrompt = "systemPrompt",
        };

        AgentConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelTest : TestBase
{
    [Fact]
    public void VertexModelConfigObjectValidationWorks()
    {
        ExecutionModel value = new ExecutionModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void AzureEntraModelConfigObjectValidationWorks()
    {
        ExecutionModel value = new ExecutionModelAzureEntraModelConfigObject()
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void AzureApiKeyModelConfigObjectValidationWorks()
    {
        ExecutionModel value = new ExecutionModelAzureApiKeyModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void GenericModelConfigObjectValidationWorks()
    {
        ExecutionModel value = new ExecutionModelGenericModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
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
    public void VertexModelConfigObjectSerializationRoundtripWorks()
    {
        ExecutionModel value = new ExecutionModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureEntraModelConfigObjectSerializationRoundtripWorks()
    {
        ExecutionModel value = new ExecutionModelAzureEntraModelConfigObject()
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureApiKeyModelConfigObjectSerializationRoundtripWorks()
    {
        ExecutionModel value = new ExecutionModelAzureApiKeyModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GenericModelConfigObjectSerializationRoundtripWorks()
    {
        ExecutionModel value = new ExecutionModelGenericModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
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

public class ExecutionModelVertexModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ExecutionModelVertexModelConfigObjectAuth expectedAuth = new()
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        ExecutionModelVertexModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, model.Auth);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider));
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExecutionModelVertexModelConfigObjectAuth expectedAuth = new()
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        ExecutionModelVertexModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, deserialized.Auth);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider));
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ExecutionModelVertexModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelVertexModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        ExecutionModelVertexModelConfigObjectAuthCredentials expectedCredentials = new()
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        ExecutionModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
        string expectedUniverseDomain = "universeDomain";

        Assert.Equal(expectedCredentials, model.Credentials);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedScopes, model.Scopes);
        Assert.Equal(expectedUniverseDomain, model.UniverseDomain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectAuth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectAuth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExecutionModelVertexModelConfigObjectAuthCredentials expectedCredentials = new()
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        ExecutionModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
        string expectedUniverseDomain = "universeDomain";

        Assert.Equal(expectedCredentials, deserialized.Credentials);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedScopes, deserialized.Scopes);
        Assert.Equal(expectedUniverseDomain, deserialized.UniverseDomain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.Scopes);
        Assert.False(model.RawData.ContainsKey("scopes"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universeDomain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },

            // Null should be interpreted as omitted for these properties
            ProjectID = null,
            Scopes = null,
            UniverseDomain = null,
        };

        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.Scopes);
        Assert.False(model.RawData.ContainsKey("scopes"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universeDomain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },

            // Null should be interpreted as omitted for these properties
            ProjectID = null,
            Scopes = null,
            UniverseDomain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        ExecutionModelVertexModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelVertexModelConfigObjectAuthCredentialsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string expectedClientEmail = "client_email";
        string expectedPrivateKey = "private_key";
        string expectedAuthProviderX509CertUrl = "https://example.com";
        string expectedAuthUri = "https://example.com";
        string expectedClientID = "client_id";
        string expectedClientX509CertUrl = "https://example.com";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProjectID = "project_id";
        string expectedTokenUri = "https://example.com";
        ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType> expectedType =
            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
        string expectedUniverseDomain = "universe_domain";

        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedPrivateKey, model.PrivateKey);
        Assert.Equal(expectedAuthProviderX509CertUrl, model.AuthProviderX509CertUrl);
        Assert.Equal(expectedAuthUri, model.AuthUri);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientX509CertUrl, model.ClientX509CertUrl);
        Assert.Equal(expectedPrivateKeyID, model.PrivateKeyID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedTokenUri, model.TokenUri);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUniverseDomain, model.UniverseDomain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectAuthCredentials>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectAuthCredentials>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedClientEmail = "client_email";
        string expectedPrivateKey = "private_key";
        string expectedAuthProviderX509CertUrl = "https://example.com";
        string expectedAuthUri = "https://example.com";
        string expectedClientID = "client_id";
        string expectedClientX509CertUrl = "https://example.com";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProjectID = "project_id";
        string expectedTokenUri = "https://example.com";
        ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType> expectedType =
            ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
        string expectedUniverseDomain = "universe_domain";

        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedPrivateKey, deserialized.PrivateKey);
        Assert.Equal(expectedAuthProviderX509CertUrl, deserialized.AuthProviderX509CertUrl);
        Assert.Equal(expectedAuthUri, deserialized.AuthUri);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientX509CertUrl, deserialized.ClientX509CertUrl);
        Assert.Equal(expectedPrivateKeyID, deserialized.PrivateKeyID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedTokenUri, deserialized.TokenUri);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUniverseDomain, deserialized.UniverseDomain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        Assert.Null(model.AuthProviderX509CertUrl);
        Assert.False(model.RawData.ContainsKey("auth_provider_x509_cert_url"));
        Assert.Null(model.AuthUri);
        Assert.False(model.RawData.ContainsKey("auth_uri"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientX509CertUrl);
        Assert.False(model.RawData.ContainsKey("client_x509_cert_url"));
        Assert.Null(model.PrivateKeyID);
        Assert.False(model.RawData.ContainsKey("private_key_id"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.TokenUri);
        Assert.False(model.RawData.ContainsKey("token_uri"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universe_domain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",

            // Null should be interpreted as omitted for these properties
            AuthProviderX509CertUrl = null,
            AuthUri = null,
            ClientID = null,
            ClientX509CertUrl = null,
            PrivateKeyID = null,
            ProjectID = null,
            TokenUri = null,
            Type = null,
            UniverseDomain = null,
        };

        Assert.Null(model.AuthProviderX509CertUrl);
        Assert.False(model.RawData.ContainsKey("auth_provider_x509_cert_url"));
        Assert.Null(model.AuthUri);
        Assert.False(model.RawData.ContainsKey("auth_uri"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientX509CertUrl);
        Assert.False(model.RawData.ContainsKey("client_x509_cert_url"));
        Assert.Null(model.PrivateKeyID);
        Assert.False(model.RawData.ContainsKey("private_key_id"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.TokenUri);
        Assert.False(model.RawData.ContainsKey("token_uri"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universe_domain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",

            // Null should be interpreted as omitted for these properties
            AuthProviderX509CertUrl = null,
            AuthUri = null,
            ClientID = null,
            ClientX509CertUrl = null,
            PrivateKeyID = null,
            ProjectID = null,
            TokenUri = null,
            Type = null,
            UniverseDomain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        ExecutionModelVertexModelConfigObjectAuthCredentials copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelVertexModelConfigObjectAuthCredentialsTypeTest : TestBase
{
    [Theory]
    [InlineData(ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount)]
    public void Validation_Works(ExecutionModelVertexModelConfigObjectAuthCredentialsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount)]
    public void SerializationRoundtrip_Works(
        ExecutionModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExecutionModelVertexModelConfigObjectAuthScopesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExecutionModelVertexModelConfigObjectAuthScopes value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        ExecutionModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExecutionModelVertexModelConfigObjectAuthScopes value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ExecutionModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExecutionModelVertexModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        ExecutionModelVertexModelConfigObjectProviderOptionsVertex expectedVertex = new()
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Equal(expectedVertex, model.Vertex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ExecutionModelVertexModelConfigObjectProviderOptionsVertex expectedVertex = new()
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Equal(expectedVertex, deserialized.Vertex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        ExecutionModelVertexModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelVertexModelConfigObjectProviderOptionsVertexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedProject, model.Project);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectProviderOptionsVertex>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObjectProviderOptionsVertex>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedProject, deserialized.Project);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ExecutionModelVertexModelConfigObjectProviderOptionsVertex copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureEntraModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ExecutionModelAzureEntraModelConfigObjectAuth expectedAuth = new("x");
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        ExecutionModelAzureEntraModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, model.Auth);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider));
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExecutionModelAzureEntraModelConfigObjectAuth expectedAuth = new("x");
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        ExecutionModelAzureEntraModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, deserialized.Auth);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider));
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ExecutionModelAzureEntraModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureEntraModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectAuth { Token = "x" };

        string expectedToken = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azureEntraId");

        Assert.Equal(expectedToken, model.Token);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectAuth { Token = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObjectAuth>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectAuth { Token = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObjectAuth>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedToken = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azureEntraId");

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectAuth { Token = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectAuth { Token = "x" };

        ExecutionModelAzureEntraModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureEntraModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, model.Azure);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, deserialized.Azure);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        ExecutionModelAzureEntraModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, model.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, model.UseDeploymentBasedUrls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, deserialized.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, deserialized.UseDeploymentBasedUrls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure { };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        ExecutionModelAzureEntraModelConfigObjectProviderOptionsAzure copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureApiKeyModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        ExecutionModelAzureApiKeyModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider));
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelAzureApiKeyModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelAzureApiKeyModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        ExecutionModelAzureApiKeyModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider));
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ExecutionModelAzureApiKeyModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, model.Azure);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureApiKeyModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureApiKeyModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, deserialized.Azure);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        ExecutionModelAzureApiKeyModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, model.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, model.UseDeploymentBasedUrls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, deserialized.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, deserialized.UseDeploymentBasedUrls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure { };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        ExecutionModelAzureApiKeyModelConfigObjectProviderOptionsAzure copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelGenericModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider> expectedProvider =
            ExecutionModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelGenericModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionModelGenericModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider> expectedProvider =
            ExecutionModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
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
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",

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
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",

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
        var model = new ExecutionModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ExecutionModelGenericModelConfigObjectProvider.OpenAI,
        };

        ExecutionModelGenericModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutionModelGenericModelConfigObjectProviderTest : TestBase
{
    [Theory]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Google)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Bedrock)]
    public void Validation_Works(ExecutionModelGenericModelConfigObjectProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Google)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(ExecutionModelGenericModelConfigObjectProvider.Bedrock)]
    public void SerializationRoundtrip_Works(
        ExecutionModelGenericModelConfigObjectProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

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
    public void VertexModelConfigObjectValidationWorks()
    {
        AgentConfigModel value = new AgentConfigModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void AzureEntraModelConfigObjectValidationWorks()
    {
        AgentConfigModel value = new AgentConfigModelAzureEntraModelConfigObject()
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void AzureApiKeyModelConfigObjectValidationWorks()
    {
        AgentConfigModel value = new AgentConfigModelAzureApiKeyModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void GenericModelConfigObjectValidationWorks()
    {
        AgentConfigModel value = new AgentConfigModelGenericModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
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
    public void VertexModelConfigObjectSerializationRoundtripWorks()
    {
        AgentConfigModel value = new AgentConfigModelVertexModelConfigObject()
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureEntraModelConfigObjectSerializationRoundtripWorks()
    {
        AgentConfigModel value = new AgentConfigModelAzureEntraModelConfigObject()
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureApiKeyModelConfigObjectSerializationRoundtripWorks()
    {
        AgentConfigModel value = new AgentConfigModelAzureApiKeyModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GenericModelConfigObjectSerializationRoundtripWorks()
    {
        AgentConfigModel value = new AgentConfigModelGenericModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
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

public class AgentConfigModelVertexModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AgentConfigModelVertexModelConfigObjectAuth expectedAuth = new()
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        AgentConfigModelVertexModelConfigObjectProviderOptions expectedProviderOptions = new(
            new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, model.Auth);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider));
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentConfigModelVertexModelConfigObjectAuth expectedAuth = new()
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        AgentConfigModelVertexModelConfigObjectProviderOptions expectedProviderOptions = new(
            new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, deserialized.Auth);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider));
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObject
        {
            Auth = new()
            {
                Credentials = new()
                {
                    ClientEmail = "client_email",
                    PrivateKey = "private_key",
                    AuthProviderX509CertUrl = "https://example.com",
                    AuthUri = "https://example.com",
                    ClientID = "client_id",
                    ClientX509CertUrl = "https://example.com",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "https://example.com",
                    Type =
                        AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                {
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AgentConfigModelVertexModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelVertexModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        AgentConfigModelVertexModelConfigObjectAuthCredentials expectedCredentials = new()
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        AgentConfigModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
        string expectedUniverseDomain = "universeDomain";

        Assert.Equal(expectedCredentials, model.Credentials);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedScopes, model.Scopes);
        Assert.Equal(expectedUniverseDomain, model.UniverseDomain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectAuth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectAuth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentConfigModelVertexModelConfigObjectAuthCredentials expectedCredentials = new()
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        AgentConfigModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
        string expectedUniverseDomain = "universeDomain";

        Assert.Equal(expectedCredentials, deserialized.Credentials);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedScopes, deserialized.Scopes);
        Assert.Equal(expectedUniverseDomain, deserialized.UniverseDomain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.Scopes);
        Assert.False(model.RawData.ContainsKey("scopes"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universeDomain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },

            // Null should be interpreted as omitted for these properties
            ProjectID = null,
            Scopes = null,
            UniverseDomain = null,
        };

        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.Scopes);
        Assert.False(model.RawData.ContainsKey("scopes"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universeDomain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },

            // Null should be interpreted as omitted for these properties
            ProjectID = null,
            Scopes = null,
            UniverseDomain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuth
        {
            Credentials = new()
            {
                ClientEmail = "client_email",
                PrivateKey = "private_key",
                AuthProviderX509CertUrl = "https://example.com",
                AuthUri = "https://example.com",
                ClientID = "client_id",
                ClientX509CertUrl = "https://example.com",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "https://example.com",
                Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        AgentConfigModelVertexModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelVertexModelConfigObjectAuthCredentialsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string expectedClientEmail = "client_email";
        string expectedPrivateKey = "private_key";
        string expectedAuthProviderX509CertUrl = "https://example.com";
        string expectedAuthUri = "https://example.com";
        string expectedClientID = "client_id";
        string expectedClientX509CertUrl = "https://example.com";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProjectID = "project_id";
        string expectedTokenUri = "https://example.com";
        ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType> expectedType =
            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
        string expectedUniverseDomain = "universe_domain";

        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedPrivateKey, model.PrivateKey);
        Assert.Equal(expectedAuthProviderX509CertUrl, model.AuthProviderX509CertUrl);
        Assert.Equal(expectedAuthUri, model.AuthUri);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientX509CertUrl, model.ClientX509CertUrl);
        Assert.Equal(expectedPrivateKeyID, model.PrivateKeyID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedTokenUri, model.TokenUri);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUniverseDomain, model.UniverseDomain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectAuthCredentials>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectAuthCredentials>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedClientEmail = "client_email";
        string expectedPrivateKey = "private_key";
        string expectedAuthProviderX509CertUrl = "https://example.com";
        string expectedAuthUri = "https://example.com";
        string expectedClientID = "client_id";
        string expectedClientX509CertUrl = "https://example.com";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProjectID = "project_id";
        string expectedTokenUri = "https://example.com";
        ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType> expectedType =
            AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
        string expectedUniverseDomain = "universe_domain";

        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedPrivateKey, deserialized.PrivateKey);
        Assert.Equal(expectedAuthProviderX509CertUrl, deserialized.AuthProviderX509CertUrl);
        Assert.Equal(expectedAuthUri, deserialized.AuthUri);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientX509CertUrl, deserialized.ClientX509CertUrl);
        Assert.Equal(expectedPrivateKeyID, deserialized.PrivateKeyID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedTokenUri, deserialized.TokenUri);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUniverseDomain, deserialized.UniverseDomain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        Assert.Null(model.AuthProviderX509CertUrl);
        Assert.False(model.RawData.ContainsKey("auth_provider_x509_cert_url"));
        Assert.Null(model.AuthUri);
        Assert.False(model.RawData.ContainsKey("auth_uri"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientX509CertUrl);
        Assert.False(model.RawData.ContainsKey("client_x509_cert_url"));
        Assert.Null(model.PrivateKeyID);
        Assert.False(model.RawData.ContainsKey("private_key_id"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.TokenUri);
        Assert.False(model.RawData.ContainsKey("token_uri"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universe_domain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",

            // Null should be interpreted as omitted for these properties
            AuthProviderX509CertUrl = null,
            AuthUri = null,
            ClientID = null,
            ClientX509CertUrl = null,
            PrivateKeyID = null,
            ProjectID = null,
            TokenUri = null,
            Type = null,
            UniverseDomain = null,
        };

        Assert.Null(model.AuthProviderX509CertUrl);
        Assert.False(model.RawData.ContainsKey("auth_provider_x509_cert_url"));
        Assert.Null(model.AuthUri);
        Assert.False(model.RawData.ContainsKey("auth_uri"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientX509CertUrl);
        Assert.False(model.RawData.ContainsKey("client_x509_cert_url"));
        Assert.Null(model.PrivateKeyID);
        Assert.False(model.RawData.ContainsKey("private_key_id"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.TokenUri);
        Assert.False(model.RawData.ContainsKey("token_uri"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UniverseDomain);
        Assert.False(model.RawData.ContainsKey("universe_domain"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",

            // Null should be interpreted as omitted for these properties
            AuthProviderX509CertUrl = null,
            AuthUri = null,
            ClientID = null,
            ClientX509CertUrl = null,
            PrivateKeyID = null,
            ProjectID = null,
            TokenUri = null,
            Type = null,
            UniverseDomain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
            AuthProviderX509CertUrl = "https://example.com",
            AuthUri = "https://example.com",
            ClientID = "client_id",
            ClientX509CertUrl = "https://example.com",
            PrivateKeyID = "private_key_id",
            ProjectID = "project_id",
            TokenUri = "https://example.com",
            Type = AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        AgentConfigModelVertexModelConfigObjectAuthCredentials copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelVertexModelConfigObjectAuthCredentialsTypeTest : TestBase
{
    [Theory]
    [InlineData(AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount)]
    public void Validation_Works(
        AgentConfigModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount)]
    public void SerializationRoundtrip_Works(
        AgentConfigModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AgentConfigModelVertexModelConfigObjectAuthScopesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        AgentConfigModelVertexModelConfigObjectAuthScopes value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        AgentConfigModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentConfigModelVertexModelConfigObjectAuthScopes value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        AgentConfigModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class AgentConfigModelVertexModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        AgentConfigModelVertexModelConfigObjectProviderOptionsVertex expectedVertex = new()
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Equal(expectedVertex, model.Vertex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        AgentConfigModelVertexModelConfigObjectProviderOptionsVertex expectedVertex = new()
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Equal(expectedVertex, deserialized.Vertex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        AgentConfigModelVertexModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelVertexModelConfigObjectProviderOptionsVertexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedProject, model.Project);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectProviderOptionsVertex>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObjectProviderOptionsVertex>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedProject, deserialized.Project);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AgentConfigModelVertexModelConfigObjectProviderOptionsVertex copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureEntraModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AgentConfigModelAzureEntraModelConfigObjectAuth expectedAuth = new("x");
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        AgentConfigModelAzureEntraModelConfigObjectProviderOptions expectedProviderOptions = new(
            new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, model.Auth);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider));
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentConfigModelAzureEntraModelConfigObjectAuth expectedAuth = new("x");
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        AgentConfigModelAzureEntraModelConfigObjectProviderOptions expectedProviderOptions = new(
            new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedAuth, deserialized.Auth);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider));
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObject
        {
            Auth = new("x"),
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AgentConfigModelAzureEntraModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureEntraModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectAuth { Token = "x" };

        string expectedToken = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azureEntraId");

        Assert.Equal(expectedToken, model.Token);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectAuth { Token = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObjectAuth>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectAuth { Token = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObjectAuth>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedToken = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azureEntraId");

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectAuth { Token = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectAuth { Token = "x" };

        AgentConfigModelAzureEntraModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureEntraModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, model.Azure);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, deserialized.Azure);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        AgentConfigModelAzureEntraModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, model.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, model.UseDeploymentBasedUrls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, deserialized.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, deserialized.UseDeploymentBasedUrls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure { };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        AgentConfigModelAzureEntraModelConfigObjectProviderOptionsAzure copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureApiKeyModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions expectedProviderOptions = new(
            new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider));
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelAzureApiKeyModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelAzureApiKeyModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("azure");
        AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions expectedProviderOptions = new(
            new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            }
        );
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider));
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure()
                {
                    ApiVersion = "2024-10-01-preview",
                    BaseUrl = "https://example.com",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceName = "my-azure-openai-resource",
                    UseDeploymentBasedUrls = true,
                }
            ),
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AgentConfigModelAzureApiKeyModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, model.Azure);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure expectedAzure = new()
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        Assert.Equal(expectedAzure, deserialized.Azure);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions
        {
            Azure = new()
            {
                ApiVersion = "2024-10-01-preview",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceName = "my-azure-openai-resource",
                UseDeploymentBasedUrls = true,
            },
        };

        AgentConfigModelAzureApiKeyModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, model.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, model.UseDeploymentBasedUrls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedApiVersion = "2024-10-01-preview";
        string expectedBaseUrl = "https://example.com";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedResourceName = "my-azure-openai-resource";
        bool expectedUseDeploymentBasedUrls = true;

        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedResourceName, deserialized.ResourceName);
        Assert.Equal(expectedUseDeploymentBasedUrls, deserialized.UseDeploymentBasedUrls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure { };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("apiVersion"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.ResourceName);
        Assert.False(model.RawData.ContainsKey("resourceName"));
        Assert.Null(model.UseDeploymentBasedUrls);
        Assert.False(model.RawData.ContainsKey("useDeploymentBasedUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            BaseUrl = null,
            Headers = null,
            ResourceName = null,
            UseDeploymentBasedUrls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure
        {
            ApiVersion = "2024-10-01-preview",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceName = "my-azure-openai-resource",
            UseDeploymentBasedUrls = true,
        };

        AgentConfigModelAzureApiKeyModelConfigObjectProviderOptionsAzure copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelGenericModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider> expectedProvider =
            AgentConfigModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelGenericModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfigModelGenericModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider> expectedProvider =
            AgentConfigModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
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
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",

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
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",

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
        var model = new AgentConfigModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
        };

        AgentConfigModelGenericModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentConfigModelGenericModelConfigObjectProviderTest : TestBase
{
    [Theory]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Google)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Bedrock)]
    public void Validation_Works(AgentConfigModelGenericModelConfigObjectProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Google)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(AgentConfigModelGenericModelConfigObjectProvider.Bedrock)]
    public void SerializationRoundtrip_Works(
        AgentConfigModelGenericModelConfigObjectProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AgentConfigProviderTest : TestBase
{
    [Theory]
    [InlineData(AgentConfigProvider.OpenAI)]
    [InlineData(AgentConfigProvider.Anthropic)]
    [InlineData(AgentConfigProvider.Google)]
    [InlineData(AgentConfigProvider.Microsoft)]
    [InlineData(AgentConfigProvider.Bedrock)]
    public void Validation_Works(AgentConfigProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentConfigProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentConfigProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentConfigProvider.OpenAI)]
    [InlineData(AgentConfigProvider.Anthropic)]
    [InlineData(AgentConfigProvider.Google)]
    [InlineData(AgentConfigProvider.Microsoft)]
    [InlineData(AgentConfigProvider.Bedrock)]
    public void SerializationRoundtrip_Works(AgentConfigProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentConfigProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentConfigProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentConfigProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentConfigProvider>>(
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
            Variables = new Dictionary<string, ExecuteOptionsVariable>() { { "foo", "string" } },
        };

        string expectedInstruction =
            "Log in with username 'demo' and password 'test123', then navigate to settings";
        bool expectedHighlightCursor = true;
        double expectedMaxSteps = 20;
        double expectedToolTimeout = 30000;
        bool expectedUseSearch = true;
        Dictionary<string, ExecuteOptionsVariable> expectedVariables = new()
        {
            { "foo", "string" },
        };

        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.Equal(expectedHighlightCursor, model.HighlightCursor);
        Assert.Equal(expectedMaxSteps, model.MaxSteps);
        Assert.Equal(expectedToolTimeout, model.ToolTimeout);
        Assert.Equal(expectedUseSearch, model.UseSearch);
        Assert.NotNull(model.Variables);
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
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
            ToolTimeout = 30000,
            UseSearch = true,
            Variables = new Dictionary<string, ExecuteOptionsVariable>() { { "foo", "string" } },
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
            Variables = new Dictionary<string, ExecuteOptionsVariable>() { { "foo", "string" } },
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
        Dictionary<string, ExecuteOptionsVariable> expectedVariables = new()
        {
            { "foo", "string" },
        };

        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.Equal(expectedHighlightCursor, deserialized.HighlightCursor);
        Assert.Equal(expectedMaxSteps, deserialized.MaxSteps);
        Assert.Equal(expectedToolTimeout, deserialized.ToolTimeout);
        Assert.Equal(expectedUseSearch, deserialized.UseSearch);
        Assert.NotNull(deserialized.Variables);
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
        var model = new ExecuteOptions
        {
            Instruction =
                "Log in with username 'demo' and password 'test123', then navigate to settings",
            HighlightCursor = true,
            MaxSteps = 20,
            ToolTimeout = 30000,
            UseSearch = true,
            Variables = new Dictionary<string, ExecuteOptionsVariable>() { { "foo", "string" } },
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
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
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
            Variables = null,
        };

        Assert.Null(model.HighlightCursor);
        Assert.False(model.RawData.ContainsKey("highlightCursor"));
        Assert.Null(model.MaxSteps);
        Assert.False(model.RawData.ContainsKey("maxSteps"));
        Assert.Null(model.ToolTimeout);
        Assert.False(model.RawData.ContainsKey("toolTimeout"));
        Assert.Null(model.UseSearch);
        Assert.False(model.RawData.ContainsKey("useSearch"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
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
            Variables = null,
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
            Variables = new Dictionary<string, ExecuteOptionsVariable>() { { "foo", "string" } },
        };

        ExecuteOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecuteOptionsVariableTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExecuteOptionsVariable value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExecuteOptionsVariable value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExecuteOptionsVariable value = true;
        value.Validate();
    }

    [Fact]
    public void ExecuteOptionsVariableUnionMember3ValidationWorks()
    {
        ExecuteOptionsVariable value = new ExecuteOptionsVariableUnionMember3()
        {
            Value = "string",
            Description = "description",
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExecuteOptionsVariable value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExecuteOptionsVariable value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExecuteOptionsVariable value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExecuteOptionsVariableUnionMember3SerializationRoundtripWorks()
    {
        ExecuteOptionsVariable value = new ExecuteOptionsVariableUnionMember3()
        {
            Value = "string",
            Description = "description",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExecuteOptionsVariableUnionMember3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        ExecuteOptionsVariableUnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariableUnionMember3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariableUnionMember3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExecuteOptionsVariableUnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3 { Value = "string" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3 { Value = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecuteOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        ExecuteOptionsVariableUnionMember3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecuteOptionsVariableUnionMember3ValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExecuteOptionsVariableUnionMember3Value value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExecuteOptionsVariableUnionMember3Value value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExecuteOptionsVariableUnionMember3Value value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExecuteOptionsVariableUnionMember3Value value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariableUnionMember3Value>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExecuteOptionsVariableUnionMember3Value value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariableUnionMember3Value>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExecuteOptionsVariableUnionMember3Value value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariableUnionMember3Value>(
            element,
            ModelBase.SerializerOptions
        );

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
