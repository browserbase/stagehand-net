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
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5.4-mini",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    GoogleAuthOptions = new()
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
                            Type = CredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    Provider = ModelConfigProvider.OpenAI,
                },
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
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                GoogleAuthOptions = new()
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
                        Type = CredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Location = "us-central1",
                Project = "my-gcp-project",
                Provider = ModelConfigProvider.OpenAI,
            },
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
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5.4-mini",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    GoogleAuthOptions = new()
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
                            Type = CredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    Provider = ModelConfigProvider.OpenAI,
                },
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
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5.4-mini",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    GoogleAuthOptions = new()
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
                            Type = CredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    Provider = ModelConfigProvider.OpenAI,
                },
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
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5.4-mini",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    GoogleAuthOptions = new()
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
                            Type = CredentialsType.ServiceAccount,
                            UniverseDomain = "universe_domain",
                        },
                        ProjectID = "projectId",
                        Scopes = "string",
                        UniverseDomain = "universeDomain",
                    },
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Location = "us-central1",
                    Project = "my-gcp-project",
                    Provider = ModelConfigProvider.OpenAI,
                },
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
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                GoogleAuthOptions = new()
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
                        Type = CredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Location = "us-central1",
                Project = "my-gcp-project",
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "#main-content",
            Timeout = 30000,
        };

        List<string> expectedIgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"];
        SessionExtractParamsOptionsModel expectedModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            GoogleAuthOptions = new()
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
                    Type = CredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Location = "us-central1",
            Project = "my-gcp-project",
            Provider = ModelConfigProvider.OpenAI,
        };
        string expectedSelector = "#main-content";
        double expectedTimeout = 30000;

        Assert.NotNull(model.IgnoreSelectors);
        Assert.Equal(expectedIgnoreSelectors.Count, model.IgnoreSelectors.Count);
        for (int i = 0; i < expectedIgnoreSelectors.Count; i++)
        {
            Assert.Equal(expectedIgnoreSelectors[i], model.IgnoreSelectors[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                GoogleAuthOptions = new()
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
                        Type = CredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Location = "us-central1",
                Project = "my-gcp-project",
                Provider = ModelConfigProvider.OpenAI,
            },
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
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                GoogleAuthOptions = new()
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
                        Type = CredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Location = "us-central1",
                Project = "my-gcp-project",
                Provider = ModelConfigProvider.OpenAI,
            },
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
        SessionExtractParamsOptionsModel expectedModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            GoogleAuthOptions = new()
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
                    Type = CredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Location = "us-central1",
            Project = "my-gcp-project",
            Provider = ModelConfigProvider.OpenAI,
        };
        string expectedSelector = "#main-content";
        double expectedTimeout = 30000;

        Assert.NotNull(deserialized.IgnoreSelectors);
        Assert.Equal(expectedIgnoreSelectors.Count, deserialized.IgnoreSelectors.Count);
        for (int i = 0; i < expectedIgnoreSelectors.Count; i++)
        {
            Assert.Equal(expectedIgnoreSelectors[i], deserialized.IgnoreSelectors[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExtractParamsOptions
        {
            IgnoreSelectors = ["nav", ".cookie-banner", "#sidebar-ads"],
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                GoogleAuthOptions = new()
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
                        Type = CredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Location = "us-central1",
                Project = "my-gcp-project",
                Provider = ModelConfigProvider.OpenAI,
            },
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
            Selector = null,
            Timeout = null,
        };

        Assert.Null(model.IgnoreSelectors);
        Assert.False(model.RawData.ContainsKey("ignoreSelectors"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
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
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5.4-mini",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                GoogleAuthOptions = new()
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
                        Type = CredentialsType.ServiceAccount,
                        UniverseDomain = "universe_domain",
                    },
                    ProjectID = "projectId",
                    Scopes = "string",
                    UniverseDomain = "universeDomain",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Location = "us-central1",
                Project = "my-gcp-project",
                Provider = ModelConfigProvider.OpenAI,
            },
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
    public void ConfigValidationWorks()
    {
        SessionExtractParamsOptionsModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            GoogleAuthOptions = new()
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
                    Type = CredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Location = "us-central1",
            Project = "my-gcp-project",
            Provider = ModelConfigProvider.OpenAI,
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
    public void ConfigSerializationRoundtripWorks()
    {
        SessionExtractParamsOptionsModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            GoogleAuthOptions = new()
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
                    Type = CredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Location = "us-central1",
            Project = "my-gcp-project",
            Provider = ModelConfigProvider.OpenAI,
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
