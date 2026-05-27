using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExtractParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Extract all product names and prices from the page",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Screenshot = false,
                Selector = "#main-content",
                Timeout = 30000,
            },
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            XStreamResponse = SessionExtractParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedFrameID = "frameId";
        string expectedInstruction = "Extract all product names and prices from the page";
        SessionExtractParamsOptions expectedOptions = new()
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Screenshot = false,
            Selector = "#main-content",
            Timeout = 30000,
        };
        Dictionary<string, JsonElement> expectedSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, SessionExtractParamsXStreamResponse> expectedXStreamResponse =
            SessionExtractParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedInstruction, parameters.Instruction);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.NotNull(parameters.Schema);
        Assert.Equal(expectedSchema.Count, parameters.Schema.Count);
        foreach (var item in expectedSchema)
        {
            Assert.True(parameters.Schema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Schema[item.Key]));
        }
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
        };

        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.Schema);
        Assert.False(parameters.RawBodyData.ContainsKey("schema"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",

            // Null should be interpreted as omitted for these properties
            Instruction = null,
            Options = null,
            Schema = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.Schema);
        Assert.False(parameters.RawBodyData.ContainsKey("schema"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Instruction = "Extract all product names and prices from the page",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Screenshot = false,
                Selector = "#main-content",
                Timeout = 30000,
            },
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            XStreamResponse = SessionExtractParamsXStreamResponse.True,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Instruction = "Extract all product names and prices from the page",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Screenshot = false,
                Selector = "#main-content",
                Timeout = 30000,
            },
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            XStreamResponse = SessionExtractParamsXStreamResponse.True,

            FrameID = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.True(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionExtractParams parameters = new() { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

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
                    "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/extract"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionExtractParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            XStreamResponse = SessionExtractParamsXStreamResponse.True,
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
        var parameters = new SessionExtractParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Extract all product names and prices from the page",
            Options = new()
            {
                IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
                Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    ModelName = "openai/gpt-5.4-mini",
                    ProviderOptions = new(
                        new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
                Screenshot = false,
                Selector = "#main-content",
                Timeout = 30000,
            },
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            XStreamResponse = SessionExtractParamsXStreamResponse.True,
        };

        SessionExtractParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SessionExtractParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Screenshot = false,
            Selector = "#main-content",
            Timeout = 30000,
        };

        List<string> expectedIgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"];
        SessionExtractParamsOptionsModel expectedModel =
            new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        bool expectedScreenshot = false;
        string expectedSelector = "#main-content";
        double expectedTimeout = 30000;

        Assert.NotNull(model.IgnoreSelectors);
        Assert.Equal(expectedIgnoreSelectors.Count, model.IgnoreSelectors.Count);
        for (int i = 0; i < expectedIgnoreSelectors.Count; i++)
        {
            Assert.Equal(expectedIgnoreSelectors[i], model.IgnoreSelectors[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedScreenshot, model.Screenshot);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Screenshot = false,
            Selector = "#main-content",
            Timeout = 30000,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Screenshot = false,
            Selector = "#main-content",
            Timeout = 30000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedIgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"];
        SessionExtractParamsOptionsModel expectedModel =
            new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        bool expectedScreenshot = false;
        string expectedSelector = "#main-content";
        double expectedTimeout = 30000;

        Assert.NotNull(deserialized.IgnoreSelectors);
        Assert.Equal(expectedIgnoreSelectors.Count, deserialized.IgnoreSelectors.Count);
        for (int i = 0; i < expectedIgnoreSelectors.Count; i++)
        {
            Assert.Equal(expectedIgnoreSelectors[i], deserialized.IgnoreSelectors[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedScreenshot, deserialized.Screenshot);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Screenshot = false,
            Selector = "#main-content",
            Timeout = 30000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptions { };

        Assert.Null(model.IgnoreSelectors);
        Assert.False(model.RawData.ContainsKey("ignoreSelectors"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Screenshot);
        Assert.False(model.RawData.ContainsKey("screenshot"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionExtractParamsOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            IgnoreSelectors = null,
            Model = null,
            Screenshot = null,
            Selector = null,
            Timeout = null,
        };

        Assert.Null(model.IgnoreSelectors);
        Assert.False(model.RawData.ContainsKey("ignoreSelectors"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Screenshot);
        Assert.False(model.RawData.ContainsKey("screenshot"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            IgnoreSelectors = null,
            Model = null,
            Screenshot = null,
            Selector = null,
            Timeout = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            Screenshot = false,
            Selector = "#main-content",
            Timeout = 30000,
        };

        SessionExtractParamsOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelTest : TestBase
{
    [Fact]
    public void VertexModelConfigObjectValidationWorks()
    {
        SessionExtractParamsOptionsModel value =
            new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        SessionExtractParamsOptionsModel value =
            new SessionExtractParamsOptionsModelGenericModelConfigObject()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
            };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        SessionExtractParamsOptionsModel value = "string";
        value.Validate();
    }

    [Fact]
    public void VertexModelConfigObjectSerializationRoundtripWorks()
    {
        SessionExtractParamsOptionsModel value =
            new SessionExtractParamsOptionsModelVertexModelConfigObject()
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
                            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                ModelName = "openai/gpt-5.4-mini",
                ProviderOptions = new(
                    new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GenericModelConfigObjectSerializationRoundtripWorks()
    {
        SessionExtractParamsOptionsModel value =
            new SessionExtractParamsOptionsModelGenericModelConfigObject()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionExtractParamsOptionsModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExtractParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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

        SessionExtractParamsOptionsModelVertexModelConfigObjectAuth expectedAuth = new()
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions expectedProviderOptions =
            new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObject>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObject>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionExtractParamsOptionsModelVertexModelConfigObjectAuth expectedAuth = new()
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions expectedProviderOptions =
            new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObject
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
                        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex()
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

        SessionExtractParamsOptionsModelVertexModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials expectedCredentials =
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectAuth>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectAuth>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials expectedCredentials =
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes expectedScopes = "string";
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuth
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
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        SessionExtractParamsOptionsModelVertexModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > expectedType =
            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials>(
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
            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > expectedType =
            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount
    )]
    public void Validation_Works(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount
    )]
    public void SerializationRoundtrip_Works(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
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
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex expectedVertex =
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
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
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
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
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex expectedVertex =
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>(
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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
        var model = new SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelGenericModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<
            string,
            SessionExtractParamsOptionsModelGenericModelConfigObjectProvider
        > expectedProvider =
            SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelGenericModelConfigObject>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionExtractParamsOptionsModelGenericModelConfigObject>(
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
            SessionExtractParamsOptionsModelGenericModelConfigObjectProvider
        > expectedProvider =
            SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI;

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
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
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
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
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
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
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
        var model = new SessionExtractParamsOptionsModelGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
        };

        SessionExtractParamsOptionsModelGenericModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionExtractParamsOptionsModelGenericModelConfigObjectProviderTest : TestBase
{
    [Theory]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Google)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Bedrock)]
    public void Validation_Works(
        SessionExtractParamsOptionsModelGenericModelConfigObjectProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Google)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Bedrock)]
    public void SerializationRoundtrip_Works(
        SessionExtractParamsOptionsModelGenericModelConfigObjectProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionExtractParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionExtractParamsXStreamResponse.True)]
    [InlineData(SessionExtractParamsXStreamResponse.False)]
    public void Validation_Works(SessionExtractParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExtractParamsXStreamResponse.True)]
    [InlineData(SessionExtractParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionExtractParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionExtractParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionExtractParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
