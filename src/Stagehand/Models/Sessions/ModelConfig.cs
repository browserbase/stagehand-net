using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<ModelConfig, ModelConfigFromRaw>))]
public sealed record class ModelConfig : JsonModel
{
    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelName");
        }
        init { this._rawData.Set("modelName", value); }
    }

    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKey", value);
        }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// google-auth-library options used to authenticate Vertex AI models
    /// </summary>
    public GoogleAuthOptions? GoogleAuthOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GoogleAuthOptions>("googleAuthOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("googleAuthOptions", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the model provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Google Cloud location for Vertex AI models
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Google Cloud project ID for Vertex AI models
    /// </summary>
    public string? Project
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("project", value);
        }
    }

    /// <summary>
    /// AI provider for the model (or provide a baseURL endpoint instead)
    /// </summary>
    public ApiEnum<string, ModelConfigProvider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ModelConfigProvider>>("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ModelName;
        _ = this.ApiKey;
        _ = this.BaseUrl;
        this.GoogleAuthOptions?.Validate();
        _ = this.Headers;
        _ = this.Location;
        _ = this.Project;
        this.Provider?.Validate();
    }

    public ModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfig(ModelConfig modelConfig)
        : base(modelConfig) { }
#pragma warning restore CS8618

    public ModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigFromRaw.FromRawUnchecked"/>
    public static ModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfig(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class ModelConfigFromRaw : IFromRawJson<ModelConfig>
{
    /// <inheritdoc/>
    public ModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// google-auth-library options used to authenticate Vertex AI models
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GoogleAuthOptions, GoogleAuthOptionsFromRaw>))]
public sealed record class GoogleAuthOptions : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public Credentials? Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Credentials>("credentials");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("credentials", value);
        }
    }

    /// <summary>
    /// Google Cloud project ID used by google-auth-library
    /// </summary>
    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("projectId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("projectId", value);
        }
    }

    /// <summary>
    /// Google auth scopes for the desired API request
    /// </summary>
    public Scopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Scopes>("scopes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scopes", value);
        }
    }

    /// <summary>
    /// Google Cloud universe domain
    /// </summary>
    public string? UniverseDomain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universeDomain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("universeDomain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Credentials?.Validate();
        _ = this.ProjectID;
        this.Scopes?.Validate();
        _ = this.UniverseDomain;
    }

    public GoogleAuthOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleAuthOptions(GoogleAuthOptions googleAuthOptions)
        : base(googleAuthOptions) { }
#pragma warning restore CS8618

    public GoogleAuthOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleAuthOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleAuthOptionsFromRaw.FromRawUnchecked"/>
    public static GoogleAuthOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleAuthOptionsFromRaw : IFromRawJson<GoogleAuthOptions>
{
    /// <inheritdoc/>
    public GoogleAuthOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleAuthOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credentials, CredentialsFromRaw>))]
public sealed record class Credentials : JsonModel
{
    public required string ClientEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_email");
        }
        init { this._rawData.Set("client_email", value); }
    }

    public required string PrivateKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("private_key");
        }
        init { this._rawData.Set("private_key", value); }
    }

    public string? AuthProviderX509CertUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auth_provider_x509_cert_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auth_provider_x509_cert_url", value);
        }
    }

    public string? AuthUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auth_uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auth_uri", value);
        }
    }

    public string? ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("client_id", value);
        }
    }

    public string? ClientX509CertUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_x509_cert_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("client_x509_cert_url", value);
        }
    }

    public string? PrivateKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("private_key_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("private_key_id", value);
        }
    }

    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("project_id", value);
        }
    }

    public string? TokenUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token_uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("token_uri", value);
        }
    }

    public ApiEnum<string, CredentialsType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CredentialsType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? UniverseDomain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universe_domain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("universe_domain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientEmail;
        _ = this.PrivateKey;
        _ = this.AuthProviderX509CertUrl;
        _ = this.AuthUri;
        _ = this.ClientID;
        _ = this.ClientX509CertUrl;
        _ = this.PrivateKeyID;
        _ = this.ProjectID;
        _ = this.TokenUri;
        this.Type?.Validate();
        _ = this.UniverseDomain;
    }

    public Credentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Credentials(Credentials credentials)
        : base(credentials) { }
#pragma warning restore CS8618

    public Credentials(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Credentials(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CredentialsFromRaw.FromRawUnchecked"/>
    public static Credentials FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CredentialsFromRaw : IFromRawJson<Credentials>
{
    /// <inheritdoc/>
    public Credentials FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Credentials.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CredentialsTypeConverter))]
public enum CredentialsType
{
    ServiceAccount,
}

sealed class CredentialsTypeConverter : JsonConverter<CredentialsType>
{
    public override CredentialsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" => CredentialsType.ServiceAccount,
            _ => (CredentialsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CredentialsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CredentialsType.ServiceAccount => "service_account",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Google auth scopes for the desired API request
/// </summary>
[JsonConverter(typeof(ScopesConverter))]
public record class Scopes : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Scopes(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scopes(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Scopes(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new StagehandInvalidDataException("Data did not match any variant of Scopes");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of Scopes"
            ),
        };
    }

    public static implicit operator Scopes(string value) => new(value);

    public static implicit operator Scopes(List<string> value) => new((IReadOnlyList<string>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException("Data did not match any variant of Scopes");
        }
    }

    public virtual bool Equals(Scopes? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            IReadOnlyList<string> _ => 1,
            _ => -1,
        };
    }
}

sealed class ScopesConverter : JsonConverter<Scopes>
{
    public override Scopes? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Scopes value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(ModelConfigProviderConverter))]
public enum ModelConfigProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
    Vertex,
}

sealed class ModelConfigProviderConverter : JsonConverter<ModelConfigProvider>
{
    public override ModelConfigProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => ModelConfigProvider.OpenAI,
            "anthropic" => ModelConfigProvider.Anthropic,
            "google" => ModelConfigProvider.Google,
            "microsoft" => ModelConfigProvider.Microsoft,
            "bedrock" => ModelConfigProvider.Bedrock,
            "vertex" => ModelConfigProvider.Vertex,
            _ => (ModelConfigProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfigProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelConfigProvider.OpenAI => "openai",
                ModelConfigProvider.Anthropic => "anthropic",
                ModelConfigProvider.Google => "google",
                ModelConfigProvider.Microsoft => "microsoft",
                ModelConfigProvider.Bedrock => "bedrock",
                ModelConfigProvider.Vertex => "vertex",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
