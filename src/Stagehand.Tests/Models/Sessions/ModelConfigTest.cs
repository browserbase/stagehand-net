using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfig
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

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        GoogleAuthOptions expectedGoogleAuthOptions = new()
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
        };
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;

        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.Equal(expectedGoogleAuthOptions, model.GoogleAuthOptions);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedProject, model.Project);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfig
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfig
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5.4-mini";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        GoogleAuthOptions expectedGoogleAuthOptions = new()
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
        };
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;

        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.Equal(expectedGoogleAuthOptions, deserialized.GoogleAuthOptions);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedProject, deserialized.Project);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfig
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfig { ModelName = "openai/gpt-5.4-mini" };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.GoogleAuthOptions);
        Assert.False(model.RawData.ContainsKey("googleAuthOptions"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.Project);
        Assert.False(model.RawData.ContainsKey("project"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfig { ModelName = "openai/gpt-5.4-mini" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5.4-mini",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            GoogleAuthOptions = null,
            Headers = null,
            Location = null,
            Project = null,
            Provider = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.GoogleAuthOptions);
        Assert.False(model.RawData.ContainsKey("googleAuthOptions"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.Project);
        Assert.False(model.RawData.ContainsKey("project"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5.4-mini",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            GoogleAuthOptions = null,
            Headers = null,
            Location = null,
            Project = null,
            Provider = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfig
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

        ModelConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleAuthOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleAuthOptions
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
        };

        Credentials expectedCredentials = new()
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
        };
        string expectedProjectID = "projectId";
        Scopes expectedScopes = "string";
        string expectedUniverseDomain = "universeDomain";

        Assert.Equal(expectedCredentials, model.Credentials);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedScopes, model.Scopes);
        Assert.Equal(expectedUniverseDomain, model.UniverseDomain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleAuthOptions
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleAuthOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleAuthOptions
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleAuthOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Credentials expectedCredentials = new()
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
        };
        string expectedProjectID = "projectId";
        Scopes expectedScopes = "string";
        string expectedUniverseDomain = "universeDomain";

        Assert.Equal(expectedCredentials, deserialized.Credentials);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedScopes, deserialized.Scopes);
        Assert.Equal(expectedUniverseDomain, deserialized.UniverseDomain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleAuthOptions
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleAuthOptions { };

        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
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
        var model = new GoogleAuthOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleAuthOptions
        {
            // Null should be interpreted as omitted for these properties
            Credentials = null,
            ProjectID = null,
            Scopes = null,
            UniverseDomain = null,
        };

        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
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
        var model = new GoogleAuthOptions
        {
            // Null should be interpreted as omitted for these properties
            Credentials = null,
            ProjectID = null,
            Scopes = null,
            UniverseDomain = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleAuthOptions
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
        };

        GoogleAuthOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CredentialsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credentials
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
        ApiEnum<string, CredentialsType> expectedType = CredentialsType.ServiceAccount;
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
        var model = new Credentials
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credentials
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials>(
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
        ApiEnum<string, CredentialsType> expectedType = CredentialsType.ServiceAccount;
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
        var model = new Credentials
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credentials { ClientEmail = "client_email", PrivateKey = "private_key" };

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
        var model = new Credentials { ClientEmail = "client_email", PrivateKey = "private_key" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Credentials
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
        var model = new Credentials
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
        var model = new Credentials
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
        };

        Credentials copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CredentialsTypeTest : TestBase
{
    [Theory]
    [InlineData(CredentialsType.ServiceAccount)]
    public void Validation_Works(CredentialsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CredentialsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CredentialsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CredentialsType.ServiceAccount)]
    public void SerializationRoundtrip_Works(CredentialsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CredentialsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CredentialsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CredentialsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CredentialsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScopesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Scopes value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Scopes value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Scopes value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scopes>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Scopes value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scopes>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ModelConfigProviderTest : TestBase
{
    [Theory]
    [InlineData(ModelConfigProvider.OpenAI)]
    [InlineData(ModelConfigProvider.Anthropic)]
    [InlineData(ModelConfigProvider.Google)]
    [InlineData(ModelConfigProvider.Microsoft)]
    [InlineData(ModelConfigProvider.Bedrock)]
    [InlineData(ModelConfigProvider.Vertex)]
    public void Validation_Works(ModelConfigProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelConfigProvider.OpenAI)]
    [InlineData(ModelConfigProvider.Anthropic)]
    [InlineData(ModelConfigProvider.Google)]
    [InlineData(ModelConfigProvider.Microsoft)]
    [InlineData(ModelConfigProvider.Bedrock)]
    [InlineData(ModelConfigProvider.Vertex)]
    public void SerializationRoundtrip_Works(ModelConfigProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelConfigProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelConfigProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
