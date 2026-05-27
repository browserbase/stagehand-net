using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void VertexModelConfigObjectValidationWorks()
    {
        ModelConfig value = new ModelConfigVertexModelConfigObject()
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        ModelConfig value = new ModelConfigGenericModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };
        value.Validate();
    }

    [Fact]
    public void VertexModelConfigObjectSerializationRoundtripWorks()
    {
        ModelConfig value = new ModelConfigVertexModelConfigObject()
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GenericModelConfigObjectSerializationRoundtripWorks()
    {
        ModelConfig value = new ModelConfigGenericModelConfigObject()
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModelConfigVertexModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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

        ModelConfigVertexModelConfigObjectAuth expectedAuth = new()
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        ModelConfigVertexModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ModelConfigVertexModelConfigObjectAuth expectedAuth = new()
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };
        string expectedModelName = "openai/gpt-5.4-mini";
        JsonElement expectedProvider = JsonSerializer.SerializeToElement("vertex");
        ModelConfigVertexModelConfigObjectProviderOptions expectedProviderOptions = new(
            new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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
        var model = new ModelConfigVertexModelConfigObject
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
                    Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                    UniverseDomain = "universe_domain",
                },
                ProjectID = "projectId",
                Scopes = "string",
                UniverseDomain = "universeDomain",
            },
            ModelName = "openai/gpt-5.4-mini",
            ProviderOptions = new(
                new ModelConfigVertexModelConfigObjectProviderOptionsVertex()
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

        ModelConfigVertexModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigVertexModelConfigObjectAuthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        ModelConfigVertexModelConfigObjectAuthCredentials expectedCredentials = new()
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        ModelConfigVertexModelConfigObjectAuthScopes expectedScopes = "string";
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
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectAuth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectAuth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ModelConfigVertexModelConfigObjectAuthCredentials expectedCredentials = new()
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("googleServiceAccount");
        string expectedProjectID = "projectId";
        ModelConfigVertexModelConfigObjectAuthScopes expectedScopes = "string";
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
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        var model = new ModelConfigVertexModelConfigObjectAuth
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
                Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                UniverseDomain = "universe_domain",
            },
            ProjectID = "projectId",
            Scopes = "string",
            UniverseDomain = "universeDomain",
        };

        ModelConfigVertexModelConfigObjectAuth copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigVertexModelConfigObjectAuthCredentialsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
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
        ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType> expectedType =
            ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
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
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectAuthCredentials>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectAuthCredentials>(
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
        ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType> expectedType =
            ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount;
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
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
        {
            ClientEmail = "client_email",
            PrivateKey = "private_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
        var model = new ModelConfigVertexModelConfigObjectAuthCredentials
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
            Type = ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            UniverseDomain = "universe_domain",
        };

        ModelConfigVertexModelConfigObjectAuthCredentials copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigVertexModelConfigObjectAuthCredentialsTypeTest : TestBase
{
    [Theory]
    [InlineData(ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount)]
    public void Validation_Works(ModelConfigVertexModelConfigObjectAuthCredentialsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount)]
    public void SerializationRoundtrip_Works(
        ModelConfigVertexModelConfigObjectAuthCredentialsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ModelConfigVertexModelConfigObjectAuthScopesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ModelConfigVertexModelConfigObjectAuthScopes value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        ModelConfigVertexModelConfigObjectAuthScopes value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ModelConfigVertexModelConfigObjectAuthScopes value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectAuthScopes>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ModelConfigVertexModelConfigObjectAuthScopes value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectAuthScopes>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModelConfigVertexModelConfigObjectProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        ModelConfigVertexModelConfigObjectProviderOptionsVertex expectedVertex = new()
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptions
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
            JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectProviderOptions
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
            JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ModelConfigVertexModelConfigObjectProviderOptionsVertex expectedVertex = new()
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptions
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptions
        {
            Vertex = new()
            {
                Location = "us-central1",
                Project = "my-gcp-project",
                BaseUrl = "https://example.com",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        ModelConfigVertexModelConfigObjectProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigVertexModelConfigObjectProviderOptionsVertexTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectProviderOptionsVertex>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigVertexModelConfigObjectProviderOptionsVertex>(
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
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
        var model = new ModelConfigVertexModelConfigObjectProviderOptionsVertex
        {
            Location = "us-central1",
            Project = "my-gcp-project",
            BaseUrl = "https://example.com",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ModelConfigVertexModelConfigObjectProviderOptionsVertex copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigGenericModelConfigObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, ModelConfigGenericModelConfigObjectProvider> expectedProvider =
            ModelConfigGenericModelConfigObjectProvider.OpenAI;

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
        var model = new ModelConfigGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigGenericModelConfigObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigGenericModelConfigObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, ModelConfigGenericModelConfigObjectProvider> expectedProvider =
            ModelConfigGenericModelConfigObjectProvider.OpenAI;

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
        var model = new ModelConfigGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigGenericModelConfigObject { ModelName = "openai/gpt-5.4-mini" };

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
        var model = new ModelConfigGenericModelConfigObject { ModelName = "openai/gpt-5.4-mini" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigGenericModelConfigObject
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
        var model = new ModelConfigGenericModelConfigObject
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
        var model = new ModelConfigGenericModelConfigObject
        {
            ModelName = "openai/gpt-5.4-mini",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigGenericModelConfigObjectProvider.OpenAI,
        };

        ModelConfigGenericModelConfigObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigGenericModelConfigObjectProviderTest : TestBase
{
    [Theory]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Google)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Bedrock)]
    public void Validation_Works(ModelConfigGenericModelConfigObjectProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigGenericModelConfigObjectProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.OpenAI)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Anthropic)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Google)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Microsoft)]
    [InlineData(ModelConfigGenericModelConfigObjectProvider.Bedrock)]
    public void SerializationRoundtrip_Works(ModelConfigGenericModelConfigObjectProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigGenericModelConfigObjectProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigGenericModelConfigObjectProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ModelConfigGenericModelConfigObjectProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
