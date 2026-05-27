using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionObserveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedFrameID = "frameId";
        string expectedInstruction = "Find all clickable navigation links";
        SessionObserveParamsOptions expectedOptions = new()
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };
        ApiEnum<string, SessionObserveParamsXStreamResponse> expectedXStreamResponse =
            SessionObserveParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedInstruction, parameters.Instruction);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
        };

        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",

            // Null should be interpreted as omitted for these properties
            Instruction = null,
            Options = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,

            FrameID = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.True(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionObserveParams parameters = new() { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

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
                    "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/observe"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionObserveParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
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
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        SessionObserveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SessionObserveParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        List<string> expectedIgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"];
        SessionObserveParamsOptionsModel expectedModel =
            new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        string expectedSelector = "nav";
        double expectedTimeout = 30000;
        Dictionary<string, SessionObserveParamsOptionsVariable> expectedVariables = new()
        {
            {
                "username",
                new SessionObserveParamsOptionsVariableUnionMember3()
                {
                    Value = "john@example.com",
                    Description = "The login email",
                }
            },
            { "rememberMe", true },
        };

        Assert.NotNull(model.IgnoreSelectors);
        Assert.Equal(expectedIgnoreSelectors.Count, model.IgnoreSelectors.Count);
        for (int i = 0; i < expectedIgnoreSelectors.Count; i++)
        {
            Assert.Equal(expectedIgnoreSelectors[i], model.IgnoreSelectors[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
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
        var model = new SessionObserveParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedIgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"];
        SessionObserveParamsOptionsModel expectedModel =
            new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        string expectedSelector = "nav";
        double expectedTimeout = 30000;
        Dictionary<string, SessionObserveParamsOptionsVariable> expectedVariables = new()
        {
            {
                "username",
                new SessionObserveParamsOptionsVariableUnionMember3()
                {
                    Value = "john@example.com",
                    Description = "The login email",
                }
            },
            { "rememberMe", true },
        };

        Assert.NotNull(deserialized.IgnoreSelectors);
        Assert.Equal(expectedIgnoreSelectors.Count, deserialized.IgnoreSelectors.Count);
        for (int i = 0; i < expectedIgnoreSelectors.Count; i++)
        {
            Assert.Equal(expectedIgnoreSelectors[i], deserialized.IgnoreSelectors[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
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
        var model = new SessionObserveParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptions { };

        Assert.Null(model.IgnoreSelectors);
        Assert.False(model.RawData.ContainsKey("ignoreSelectors"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionObserveParamsOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            IgnoreSelectors = null,
            Model = null,
            Selector = null,
            Timeout = null,
            Variables = null,
        };

        Assert.Null(model.IgnoreSelectors);
        Assert.False(model.RawData.ContainsKey("ignoreSelectors"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            IgnoreSelectors = null,
            Model = null,
            Selector = null,
            Timeout = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        SessionObserveParamsOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelTest : TestBase
{
    [Fact]
    public void VertexModelConfigObjectValidationWorks()
    {
        SessionObserveParamsOptionsModel value =
            new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
    public void GenericModelConfigObjectValidationWorks()
    {
        SessionObserveParamsOptionsModel value =
            new SessionObserveParamsOptionsModelGenericModelConfigObject()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
            };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsModel value = "string";
        value.Validate();
    }

    [Fact]
    public void VertexModelConfigObjectSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModel value =
            new SessionObserveParamsOptionsModelVertexModelConfigObject()
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
                            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GenericModelConfigObjectSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModel value =
            new SessionObserveParamsOptionsModelGenericModelConfigObject()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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

        SessionObserveParamsOptionsModelVertexModelConfigObjectAuth expectedAuth = new()
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions expectedProviderOptions =
            new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObject>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObject>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionObserveParamsOptionsModelVertexModelConfigObjectAuth expectedAuth = new()
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions expectedProviderOptions =
            new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObject
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
                        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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

        SessionObserveParamsOptionsModelVertexModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials expectedCredentials =
            new()
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectAuth>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectAuth>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials expectedCredentials =
            new()
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        SessionObserveParamsOptionsModelVertexModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        ApiEnum<
            string,
            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > expectedType =
            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials>(
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
        ApiEnum<
            string,
            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > expectedType =
            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount
    )]
    public void Validation_Works(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount
    )]
    public void SerializationRoundtrip_Works(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex expectedVertex =
            new()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
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
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
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
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex expectedVertex =
            new()
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>(
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelGenericModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<
            string,
            SessionObserveParamsOptionsModelGenericModelConfigObjectProvider
        > expectedProvider =
            SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelGenericModelConfigObject>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsModelGenericModelConfigObject>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<
            string,
            SessionObserveParamsOptionsModelGenericModelConfigObjectProvider
        > expectedProvider =
            SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
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
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
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
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
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
        var model = new SessionObserveParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        SessionObserveParamsOptionsModelGenericModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelGenericModelConfigObjectProviderTest : TestBase
{
    [Theory]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Google)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Bedrock)]
    public void Validation_Works(
        SessionObserveParamsOptionsModelGenericModelConfigObjectProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Google)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Bedrock)]
    public void SerializationRoundtrip_Works(
        SessionObserveParamsOptionsModelGenericModelConfigObjectProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsVariableTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsVariable value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SessionObserveParamsOptionsVariable value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SessionObserveParamsOptionsVariable value = true;
        value.Validate();
    }

    [Fact]
    public void SessionObserveParamsOptionsVariableUnionMember3ValidationWorks()
    {
        SessionObserveParamsOptionsVariable value =
            new SessionObserveParamsOptionsVariableUnionMember3()
            {
                Value = "string",
                Description = "description",
            };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionObserveParamsOptionsVariableUnionMember3SerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value =
            new SessionObserveParamsOptionsVariableUnionMember3()
            {
                Value = "string",
                Description = "description",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsVariableUnionMember3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        SessionObserveParamsOptionsVariableUnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionObserveParamsOptionsVariableUnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3 { Value = "string" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3 { Value = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
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
        var model = new SessionObserveParamsOptionsVariableUnionMember3
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
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        SessionObserveParamsOptionsVariableUnionMember3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsVariableUnionMember3ValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3Value>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3Value>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3Value>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionObserveParamsXStreamResponse.True)]
    [InlineData(SessionObserveParamsXStreamResponse.False)]
    public void Validation_Works(SessionObserveParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionObserveParamsXStreamResponse.True)]
    [InlineData(SessionObserveParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionObserveParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
