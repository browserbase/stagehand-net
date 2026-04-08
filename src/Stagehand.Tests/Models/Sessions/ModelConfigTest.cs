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
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "X-Custom-Header", "value" } },
            Provider = ModelConfigProvider.OpenAI,
            ProviderOptions = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
                "us-east-1"
            ),
            SkipApiKeyFallback = true,
        };

        string expectedModelName = "openai/gpt-5-nano";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "X-Custom-Header", "value" } };
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;
        ModelConfigProviderOptions expectedProviderOptions =
            new ModelConfigProviderOptionsBedrockApiKeyProviderOptions("us-east-1");
        bool expectedSkipApiKeyFallback = true;

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
        Assert.Equal(expectedProviderOptions, model.ProviderOptions);
        Assert.Equal(expectedSkipApiKeyFallback, model.SkipApiKeyFallback);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "X-Custom-Header", "value" } },
            Provider = ModelConfigProvider.OpenAI,
            ProviderOptions = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
                "us-east-1"
            ),
            SkipApiKeyFallback = true,
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
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "X-Custom-Header", "value" } },
            Provider = ModelConfigProvider.OpenAI,
            ProviderOptions = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
                "us-east-1"
            ),
            SkipApiKeyFallback = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModelName = "openai/gpt-5-nano";
        string expectedApiKey = "sk-some-openai-api-key";
        string expectedBaseUrl = "https://api.openai.com/v1";
        Dictionary<string, string> expectedHeaders = new() { { "X-Custom-Header", "value" } };
        ApiEnum<string, ModelConfigProvider> expectedProvider = ModelConfigProvider.OpenAI;
        ModelConfigProviderOptions expectedProviderOptions =
            new ModelConfigProviderOptionsBedrockApiKeyProviderOptions("us-east-1");
        bool expectedSkipApiKeyFallback = true;

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
        Assert.Equal(expectedProviderOptions, deserialized.ProviderOptions);
        Assert.Equal(expectedSkipApiKeyFallback, deserialized.SkipApiKeyFallback);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "X-Custom-Header", "value" } },
            Provider = ModelConfigProvider.OpenAI,
            ProviderOptions = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
                "us-east-1"
            ),
            SkipApiKeyFallback = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfig { ModelName = "openai/gpt-5-nano" };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.ProviderOptions);
        Assert.False(model.RawData.ContainsKey("providerOptions"));
        Assert.Null(model.SkipApiKeyFallback);
        Assert.False(model.RawData.ContainsKey("skipApiKeyFallback"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfig { ModelName = "openai/gpt-5-nano" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
            Provider = null,
            ProviderOptions = null,
            SkipApiKeyFallback = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
        Assert.Null(model.BaseUrl);
        Assert.False(model.RawData.ContainsKey("baseURL"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.ProviderOptions);
        Assert.False(model.RawData.ContainsKey("providerOptions"));
        Assert.Null(model.SkipApiKeyFallback);
        Assert.False(model.RawData.ContainsKey("skipApiKeyFallback"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            BaseUrl = null,
            Headers = null,
            Provider = null,
            ProviderOptions = null,
            SkipApiKeyFallback = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfig
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "X-Custom-Header", "value" } },
            Provider = ModelConfigProvider.OpenAI,
            ProviderOptions = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
                "us-east-1"
            ),
            SkipApiKeyFallback = true,
        };

        ModelConfig copied = new(model);

        Assert.Equal(model, copied);
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

public class ModelConfigProviderOptionsTest : TestBase
{
    [Fact]
    public void BedrockApiKeyValidationWorks()
    {
        ModelConfigProviderOptions value =
            new ModelConfigProviderOptionsBedrockApiKeyProviderOptions("us-east-1");
        value.Validate();
    }

    [Fact]
    public void BedrockAwsCredentialsValidationWorks()
    {
        ModelConfigProviderOptions value =
            new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions()
            {
                AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
                Region = "us-east-1",
                SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
            };
        value.Validate();
    }

    [Fact]
    public void GoogleVertexValidationWorks()
    {
        ModelConfigProviderOptions value =
            new ModelConfigProviderOptionsGoogleVertexProviderOptions()
            {
                GoogleAuthOptions = new()
                {
                    Credentials = new()
                    {
                        AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                        AuthUri = "auth_uri",
                        ClientEmail = "client_email",
                        ClientID = "client_id",
                        ClientX509CertUrl = "client_x509_cert_url",
                        PrivateKey = "private_key",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "token_uri",
                        Type = "type",
                        UniverseDomain = "universe_domain",
                    },
                },
                Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
                Location = "us-central1",
                Project = "my-gcp-project",
            };
        value.Validate();
    }

    [Fact]
    public void BedrockApiKeySerializationRoundtripWorks()
    {
        ModelConfigProviderOptions value =
            new ModelConfigProviderOptionsBedrockApiKeyProviderOptions("us-east-1");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigProviderOptions>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BedrockAwsCredentialsSerializationRoundtripWorks()
    {
        ModelConfigProviderOptions value =
            new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions()
            {
                AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
                Region = "us-east-1",
                SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigProviderOptions>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleVertexSerializationRoundtripWorks()
    {
        ModelConfigProviderOptions value =
            new ModelConfigProviderOptionsGoogleVertexProviderOptions()
            {
                GoogleAuthOptions = new()
                {
                    Credentials = new()
                    {
                        AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                        AuthUri = "auth_uri",
                        ClientEmail = "client_email",
                        ClientID = "client_id",
                        ClientX509CertUrl = "client_x509_cert_url",
                        PrivateKey = "private_key",
                        PrivateKeyID = "private_key_id",
                        ProjectID = "project_id",
                        TokenUri = "token_uri",
                        Type = "type",
                        UniverseDomain = "universe_domain",
                    },
                },
                Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
                Location = "us-central1",
                Project = "my-gcp-project",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelConfigProviderOptions>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModelConfigProviderOptionsBedrockApiKeyProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions
        {
            Region = "us-east-1",
        };

        string expectedRegion = "us-east-1";

        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions
        {
            Region = "us-east-1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsBedrockApiKeyProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions
        {
            Region = "us-east-1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsBedrockApiKeyProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedRegion = "us-east-1";

        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions
        {
            Region = "us-east-1",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockApiKeyProviderOptions
        {
            Region = "us-east-1",
        };

        ModelConfigProviderOptionsBedrockApiKeyProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
        };

        string expectedAccessKeyID = "AKIAIOSFODNN7EXAMPLE";
        string expectedRegion = "us-east-1";
        string expectedSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        string expectedSessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...";

        Assert.Equal(expectedAccessKeyID, model.AccessKeyID);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedSecretAccessKey, model.SecretAccessKey);
        Assert.Equal(expectedSessionToken, model.SessionToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAccessKeyID = "AKIAIOSFODNN7EXAMPLE";
        string expectedRegion = "us-east-1";
        string expectedSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        string expectedSessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...";

        Assert.Equal(expectedAccessKeyID, deserialized.AccessKeyID);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedSecretAccessKey, deserialized.SecretAccessKey);
        Assert.Equal(expectedSessionToken, deserialized.SessionToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        Assert.Null(model.SessionToken);
        Assert.False(model.RawData.ContainsKey("sessionToken"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            SessionToken = null,
        };

        Assert.Null(model.SessionToken);
        Assert.False(model.RawData.ContainsKey("sessionToken"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            SessionToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
        {
            AccessKeyID = "AKIAIOSFODNN7EXAMPLE",
            Region = "us-east-1",
            SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            SessionToken = "IQoJb3JpZ2luX2VjEOr//////////wEaCXVzLXdlc3QtMiJIMEYCIQ...",
        };

        ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigProviderOptionsGoogleVertexProviderOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            GoogleAuthOptions = new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            },
            Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions expectedGoogleAuthOptions =
            new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            };
        Dictionary<string, string> expectedHeaders = new() { { "X-Goog-Priority", "high" } };
        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            GoogleAuthOptions = new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            },
            Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            GoogleAuthOptions = new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            },
            Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions expectedGoogleAuthOptions =
            new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            };
        Dictionary<string, string> expectedHeaders = new() { { "X-Goog-Priority", "high" } };
        string expectedLocation = "us-central1";
        string expectedProject = "my-gcp-project";

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            GoogleAuthOptions = new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            },
            Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions { };

        Assert.Null(model.GoogleAuthOptions);
        Assert.False(model.RawData.ContainsKey("googleAuthOptions"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.Project);
        Assert.False(model.RawData.ContainsKey("project"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            // Null should be interpreted as omitted for these properties
            GoogleAuthOptions = null,
            Headers = null,
            Location = null,
            Project = null,
        };

        Assert.Null(model.GoogleAuthOptions);
        Assert.False(model.RawData.ContainsKey("googleAuthOptions"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.Project);
        Assert.False(model.RawData.ContainsKey("project"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            // Null should be interpreted as omitted for these properties
            GoogleAuthOptions = null,
            Headers = null,
            Location = null,
            Project = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptions
        {
            GoogleAuthOptions = new()
            {
                Credentials = new()
                {
                    AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                    AuthUri = "auth_uri",
                    ClientEmail = "client_email",
                    ClientID = "client_id",
                    ClientX509CertUrl = "client_x509_cert_url",
                    PrivateKey = "private_key",
                    PrivateKeyID = "private_key_id",
                    ProjectID = "project_id",
                    TokenUri = "token_uri",
                    Type = "type",
                    UniverseDomain = "universe_domain",
                },
            },
            Headers = new Dictionary<string, string>() { { "X-Goog-Priority", "high" } },
            Location = "us-central1",
            Project = "my-gcp-project",
        };

        ModelConfigProviderOptionsGoogleVertexProviderOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            Credentials = new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            },
        };

        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials expectedCredentials =
            new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        Assert.Equal(expectedCredentials, model.Credentials);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            Credentials = new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            Credentials = new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials expectedCredentials =
            new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        Assert.Equal(expectedCredentials, deserialized.Credentials);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            Credentials = new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions { };

        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            // Null should be interpreted as omitted for these properties
            Credentials = null,
        };

        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            // Null should be interpreted as omitted for these properties
            Credentials = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
        {
            Credentials = new()
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            },
        };

        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentialsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        string expectedAuthProviderX509CertUrl = "auth_provider_x509_cert_url";
        string expectedAuthUri = "auth_uri";
        string expectedClientEmail = "client_email";
        string expectedClientID = "client_id";
        string expectedClientX509CertUrl = "client_x509_cert_url";
        string expectedPrivateKey = "private_key";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProjectID = "project_id";
        string expectedTokenUri = "token_uri";
        string expectedType = "type";
        string expectedUniverseDomain = "universe_domain";

        Assert.Equal(expectedAuthProviderX509CertUrl, model.AuthProviderX509CertUrl);
        Assert.Equal(expectedAuthUri, model.AuthUri);
        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientX509CertUrl, model.ClientX509CertUrl);
        Assert.Equal(expectedPrivateKey, model.PrivateKey);
        Assert.Equal(expectedPrivateKeyID, model.PrivateKeyID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedTokenUri, model.TokenUri);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUniverseDomain, model.UniverseDomain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAuthProviderX509CertUrl = "auth_provider_x509_cert_url";
        string expectedAuthUri = "auth_uri";
        string expectedClientEmail = "client_email";
        string expectedClientID = "client_id";
        string expectedClientX509CertUrl = "client_x509_cert_url";
        string expectedPrivateKey = "private_key";
        string expectedPrivateKeyID = "private_key_id";
        string expectedProjectID = "project_id";
        string expectedTokenUri = "token_uri";
        string expectedType = "type";
        string expectedUniverseDomain = "universe_domain";

        Assert.Equal(expectedAuthProviderX509CertUrl, deserialized.AuthProviderX509CertUrl);
        Assert.Equal(expectedAuthUri, deserialized.AuthUri);
        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientX509CertUrl, deserialized.ClientX509CertUrl);
        Assert.Equal(expectedPrivateKey, deserialized.PrivateKey);
        Assert.Equal(expectedPrivateKeyID, deserialized.PrivateKeyID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedTokenUri, deserialized.TokenUri);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUniverseDomain, deserialized.UniverseDomain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            { };

        Assert.Null(model.AuthProviderX509CertUrl);
        Assert.False(model.RawData.ContainsKey("auth_provider_x509_cert_url"));
        Assert.Null(model.AuthUri);
        Assert.False(model.RawData.ContainsKey("auth_uri"));
        Assert.Null(model.ClientEmail);
        Assert.False(model.RawData.ContainsKey("client_email"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientX509CertUrl);
        Assert.False(model.RawData.ContainsKey("client_x509_cert_url"));
        Assert.Null(model.PrivateKey);
        Assert.False(model.RawData.ContainsKey("private_key"));
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
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                // Null should be interpreted as omitted for these properties
                AuthProviderX509CertUrl = null,
                AuthUri = null,
                ClientEmail = null,
                ClientID = null,
                ClientX509CertUrl = null,
                PrivateKey = null,
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
        Assert.Null(model.ClientEmail);
        Assert.False(model.RawData.ContainsKey("client_email"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientX509CertUrl);
        Assert.False(model.RawData.ContainsKey("client_x509_cert_url"));
        Assert.Null(model.PrivateKey);
        Assert.False(model.RawData.ContainsKey("private_key"));
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
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                // Null should be interpreted as omitted for these properties
                AuthProviderX509CertUrl = null,
                AuthUri = null,
                ClientEmail = null,
                ClientID = null,
                ClientX509CertUrl = null,
                PrivateKey = null,
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
        var model =
            new ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
            {
                AuthProviderX509CertUrl = "auth_provider_x509_cert_url",
                AuthUri = "auth_uri",
                ClientEmail = "client_email",
                ClientID = "client_id",
                ClientX509CertUrl = "client_x509_cert_url",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                ProjectID = "project_id",
                TokenUri = "token_uri",
                Type = "type",
                UniverseDomain = "universe_domain",
            };

        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
