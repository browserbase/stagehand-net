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

[JsonConverter(typeof(ModelConfigConverter))]
public record class ModelConfig : ModelBase
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

    public string ModelName
    {
        get
        {
            return Match(
                vertexModelConfigObject: (x) => x.ModelName,
                genericModelConfigObject: (x) => x.ModelName
            );
        }
    }

    public string? ApiKey
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ApiKey,
                genericModelConfigObject: (x) => x.ApiKey
            );
        }
    }

    public string? BaseUrl
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.BaseUrl,
                genericModelConfigObject: (x) => x.BaseUrl
            );
        }
    }

    public ModelConfig(ModelConfigVertexModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ModelConfig(ModelConfigGenericModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ModelConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfigVertexModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexModelConfigObject(out var value)) {
    ///     // `value` is of type `ModelConfigVertexModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexModelConfigObject(
        [NotNullWhen(true)] out ModelConfigVertexModelConfigObject? value
    )
    {
        value = this.Value as ModelConfigVertexModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfigGenericModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGenericModelConfigObject(out var value)) {
    ///     // `value` is of type `ModelConfigGenericModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGenericModelConfigObject(
        [NotNullWhen(true)] out ModelConfigGenericModelConfigObject? value
    )
    {
        value = this.Value as ModelConfigGenericModelConfigObject;
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
    ///     (ModelConfigVertexModelConfigObject value) =&gt; {...},
    ///     (ModelConfigGenericModelConfigObject value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ModelConfigVertexModelConfigObject> vertexModelConfigObject,
        System::Action<ModelConfigGenericModelConfigObject> genericModelConfigObject
    )
    {
        switch (this.Value)
        {
            case ModelConfigVertexModelConfigObject value:
                vertexModelConfigObject(value);
                break;
            case ModelConfigGenericModelConfigObject value:
                genericModelConfigObject(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ModelConfig"
                );
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
    ///     (ModelConfigVertexModelConfigObject value) =&gt; {...},
    ///     (ModelConfigGenericModelConfigObject value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ModelConfigVertexModelConfigObject, T> vertexModelConfigObject,
        System::Func<ModelConfigGenericModelConfigObject, T> genericModelConfigObject
    )
    {
        return this.Value switch
        {
            ModelConfigVertexModelConfigObject value => vertexModelConfigObject(value),
            ModelConfigGenericModelConfigObject value => genericModelConfigObject(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfig"
            ),
        };
    }

    public static implicit operator ModelConfig(ModelConfigVertexModelConfigObject value) =>
        new(value);

    public static implicit operator ModelConfig(ModelConfigGenericModelConfigObject value) =>
        new(value);

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
            throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfig"
            );
        }
        this.Switch(
            (vertexModelConfigObject) => vertexModelConfigObject.Validate(),
            (genericModelConfigObject) => genericModelConfigObject.Validate()
        );
    }

    public virtual bool Equals(ModelConfig? other) =>
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
            ModelConfigVertexModelConfigObject _ => 0,
            ModelConfigGenericModelConfigObject _ => 1,
            _ => -1,
        };
    }
}

sealed class ModelConfigConverter : JsonConverter<ModelConfig>
{
    public override ModelConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ModelConfigVertexModelConfigObject>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ModelConfigGenericModelConfigObject>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigVertexModelConfigObject,
        ModelConfigVertexModelConfigObjectFromRaw
    >)
)]
public sealed record class ModelConfigVertexModelConfigObject : JsonModel
{
    /// <summary>
    /// Vertex provider authentication configuration
    /// </summary>
    public required ModelConfigVertexModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModelConfigVertexModelConfigObjectAuth>("auth");
        }
        init { this._rawData.Set("auth", value); }
    }

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
    /// Vertex AI model provider
    /// </summary>
    public JsonElement Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Vertex provider-specific model configuration
    /// </summary>
    public required ModelConfigVertexModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModelConfigVertexModelConfigObjectProviderOptions>(
                "providerOptions"
            );
        }
        init { this._rawData.Set("providerOptions", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Auth.Validate();
        _ = this.ModelName;
        if (!JsonElement.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("vertex")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        this.ProviderOptions.Validate();
        _ = this.ApiKey;
        _ = this.BaseUrl;
        _ = this.Headers;
    }

    public ModelConfigVertexModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObject(
        ModelConfigVertexModelConfigObject modelConfigVertexModelConfigObject
    )
        : base(modelConfigVertexModelConfigObject) { }
#pragma warning restore CS8618

    public ModelConfigVertexModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigVertexModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigVertexModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static ModelConfigVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigVertexModelConfigObjectFromRaw : IFromRawJson<ModelConfigVertexModelConfigObject>
{
    /// <inheritdoc/>
    public ModelConfigVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigVertexModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigVertexModelConfigObjectAuth,
        ModelConfigVertexModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class ModelConfigVertexModelConfigObjectAuth : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public required ModelConfigVertexModelConfigObjectAuthCredentials Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModelConfigVertexModelConfigObjectAuthCredentials>(
                "credentials"
            );
        }
        init { this._rawData.Set("credentials", value); }
    }

    /// <summary>
    /// Use inline Google Cloud service account credentials for provider authentication
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
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
    public ModelConfigVertexModelConfigObjectAuthScopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelConfigVertexModelConfigObjectAuthScopes>(
                "scopes"
            );
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
        this.Credentials.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("googleServiceAccount")
            )
        )
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        _ = this.ProjectID;
        this.Scopes?.Validate();
        _ = this.UniverseDomain;
    }

    public ModelConfigVertexModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObjectAuth(
        ModelConfigVertexModelConfigObjectAuth modelConfigVertexModelConfigObjectAuth
    )
        : base(modelConfigVertexModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public ModelConfigVertexModelConfigObjectAuth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigVertexModelConfigObjectAuth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigVertexModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static ModelConfigVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObjectAuth(
        ModelConfigVertexModelConfigObjectAuthCredentials credentials
    )
        : this()
    {
        this.Credentials = credentials;
    }
}

class ModelConfigVertexModelConfigObjectAuthFromRaw
    : IFromRawJson<ModelConfigVertexModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public ModelConfigVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigVertexModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigVertexModelConfigObjectAuthCredentials,
        ModelConfigVertexModelConfigObjectAuthCredentialsFromRaw
    >)
)]
public sealed record class ModelConfigVertexModelConfigObjectAuthCredentials : JsonModel
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

    public ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ModelConfigVertexModelConfigObjectAuthCredentialsType>
            >("type");
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

    public ModelConfigVertexModelConfigObjectAuthCredentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObjectAuthCredentials(
        ModelConfigVertexModelConfigObjectAuthCredentials modelConfigVertexModelConfigObjectAuthCredentials
    )
        : base(modelConfigVertexModelConfigObjectAuthCredentials) { }
#pragma warning restore CS8618

    public ModelConfigVertexModelConfigObjectAuthCredentials(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigVertexModelConfigObjectAuthCredentials(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigVertexModelConfigObjectAuthCredentialsFromRaw.FromRawUnchecked"/>
    public static ModelConfigVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigVertexModelConfigObjectAuthCredentialsFromRaw
    : IFromRawJson<ModelConfigVertexModelConfigObjectAuthCredentials>
{
    /// <inheritdoc/>
    public ModelConfigVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigVertexModelConfigObjectAuthCredentials.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConfigVertexModelConfigObjectAuthCredentialsTypeConverter))]
public enum ModelConfigVertexModelConfigObjectAuthCredentialsType
{
    ServiceAccount,
}

sealed class ModelConfigVertexModelConfigObjectAuthCredentialsTypeConverter
    : JsonConverter<ModelConfigVertexModelConfigObjectAuthCredentialsType>
{
    public override ModelConfigVertexModelConfigObjectAuthCredentialsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" =>
                ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            _ => (ModelConfigVertexModelConfigObjectAuthCredentialsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfigVertexModelConfigObjectAuthCredentialsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelConfigVertexModelConfigObjectAuthCredentialsType.ServiceAccount =>
                    "service_account",
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
[JsonConverter(typeof(ModelConfigVertexModelConfigObjectAuthScopesConverter))]
public record class ModelConfigVertexModelConfigObjectAuthScopes : ModelBase
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

    public ModelConfigVertexModelConfigObjectAuthScopes(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ModelConfigVertexModelConfigObjectAuthScopes(
        IReadOnlyList<string> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ModelConfigVertexModelConfigObjectAuthScopes(JsonElement element)
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
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ModelConfigVertexModelConfigObjectAuthScopes"
                );
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
                "Data did not match any variant of ModelConfigVertexModelConfigObjectAuthScopes"
            ),
        };
    }

    public static implicit operator ModelConfigVertexModelConfigObjectAuthScopes(string value) =>
        new(value);

    public static implicit operator ModelConfigVertexModelConfigObjectAuthScopes(
        List<string> value
    ) => new((IReadOnlyList<string>)value);

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
            throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfigVertexModelConfigObjectAuthScopes"
            );
        }
    }

    public virtual bool Equals(ModelConfigVertexModelConfigObjectAuthScopes? other) =>
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

sealed class ModelConfigVertexModelConfigObjectAuthScopesConverter
    : JsonConverter<ModelConfigVertexModelConfigObjectAuthScopes>
{
    public override ModelConfigVertexModelConfigObjectAuthScopes? Read(
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

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfigVertexModelConfigObjectAuthScopes value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Vertex provider-specific model configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigVertexModelConfigObjectProviderOptions,
        ModelConfigVertexModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class ModelConfigVertexModelConfigObjectProviderOptions : JsonModel
{
    /// <summary>
    /// Vertex AI provider-specific settings
    /// </summary>
    public required ModelConfigVertexModelConfigObjectProviderOptionsVertex Vertex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModelConfigVertexModelConfigObjectProviderOptionsVertex>(
                "vertex"
            );
        }
        init { this._rawData.Set("vertex", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Vertex.Validate();
    }

    public ModelConfigVertexModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObjectProviderOptions(
        ModelConfigVertexModelConfigObjectProviderOptions modelConfigVertexModelConfigObjectProviderOptions
    )
        : base(modelConfigVertexModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public ModelConfigVertexModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigVertexModelConfigObjectProviderOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigVertexModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static ModelConfigVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObjectProviderOptions(
        ModelConfigVertexModelConfigObjectProviderOptionsVertex vertex
    )
        : this()
    {
        this.Vertex = vertex;
    }
}

class ModelConfigVertexModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<ModelConfigVertexModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public ModelConfigVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigVertexModelConfigObjectProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex AI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigVertexModelConfigObjectProviderOptionsVertex,
        ModelConfigVertexModelConfigObjectProviderOptionsVertexFromRaw
    >)
)]
public sealed record class ModelConfigVertexModelConfigObjectProviderOptionsVertex : JsonModel
{
    /// <summary>
    /// Google Cloud location for Vertex AI models
    /// </summary>
    public required string Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("location");
        }
        init { this._rawData.Set("location", value); }
    }

    /// <summary>
    /// Google Cloud project ID for Vertex AI models
    /// </summary>
    public required string Project
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project");
        }
        init { this._rawData.Set("project", value); }
    }

    /// <summary>
    /// Base URL for the Vertex AI provider
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
    /// Custom headers sent with every request to the Vertex AI provider
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Location;
        _ = this.Project;
        _ = this.BaseUrl;
        _ = this.Headers;
    }

    public ModelConfigVertexModelConfigObjectProviderOptionsVertex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigVertexModelConfigObjectProviderOptionsVertex(
        ModelConfigVertexModelConfigObjectProviderOptionsVertex modelConfigVertexModelConfigObjectProviderOptionsVertex
    )
        : base(modelConfigVertexModelConfigObjectProviderOptionsVertex) { }
#pragma warning restore CS8618

    public ModelConfigVertexModelConfigObjectProviderOptionsVertex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigVertexModelConfigObjectProviderOptionsVertex(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigVertexModelConfigObjectProviderOptionsVertexFromRaw.FromRawUnchecked"/>
    public static ModelConfigVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigVertexModelConfigObjectProviderOptionsVertexFromRaw
    : IFromRawJson<ModelConfigVertexModelConfigObjectProviderOptionsVertex>
{
    /// <inheritdoc/>
    public ModelConfigVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigVertexModelConfigObjectProviderOptionsVertex.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigGenericModelConfigObject,
        ModelConfigGenericModelConfigObjectFromRaw
    >)
)]
public sealed record class ModelConfigGenericModelConfigObject : JsonModel
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
    /// AI provider for the model (or provide a baseURL endpoint instead)
    /// </summary>
    public ApiEnum<string, ModelConfigGenericModelConfigObjectProvider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ModelConfigGenericModelConfigObjectProvider>
            >("provider");
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
        _ = this.Headers;
        this.Provider?.Validate();
    }

    public ModelConfigGenericModelConfigObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigGenericModelConfigObject(
        ModelConfigGenericModelConfigObject modelConfigGenericModelConfigObject
    )
        : base(modelConfigGenericModelConfigObject) { }
#pragma warning restore CS8618

    public ModelConfigGenericModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigGenericModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigGenericModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static ModelConfigGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfigGenericModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class ModelConfigGenericModelConfigObjectFromRaw : IFromRawJson<ModelConfigGenericModelConfigObject>
{
    /// <inheritdoc/>
    public ModelConfigGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigGenericModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(ModelConfigGenericModelConfigObjectProviderConverter))]
public enum ModelConfigGenericModelConfigObjectProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class ModelConfigGenericModelConfigObjectProviderConverter
    : JsonConverter<ModelConfigGenericModelConfigObjectProvider>
{
    public override ModelConfigGenericModelConfigObjectProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => ModelConfigGenericModelConfigObjectProvider.OpenAI,
            "anthropic" => ModelConfigGenericModelConfigObjectProvider.Anthropic,
            "google" => ModelConfigGenericModelConfigObjectProvider.Google,
            "microsoft" => ModelConfigGenericModelConfigObjectProvider.Microsoft,
            "bedrock" => ModelConfigGenericModelConfigObjectProvider.Bedrock,
            _ => (ModelConfigGenericModelConfigObjectProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfigGenericModelConfigObjectProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelConfigGenericModelConfigObjectProvider.OpenAI => "openai",
                ModelConfigGenericModelConfigObjectProvider.Anthropic => "anthropic",
                ModelConfigGenericModelConfigObjectProvider.Google => "google",
                ModelConfigGenericModelConfigObjectProvider.Microsoft => "microsoft",
                ModelConfigGenericModelConfigObjectProvider.Bedrock => "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
