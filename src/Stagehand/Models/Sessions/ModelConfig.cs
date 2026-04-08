using System.Collections.Frozen;
using System.Collections.Generic;
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
    /// Custom headers for the model provider
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

    /// <summary>
    /// Provider-specific options passed through to the AI SDK provider constructor.
    /// For Bedrock: { region, accessKeyId, secretAccessKey, sessionToken }. For Vertex:
    /// { project, location, googleAuthOptions }.
    /// </summary>
    public ModelConfigProviderOptions? ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelConfigProviderOptions>("providerOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("providerOptions", value);
        }
    }

    /// <summary>
    /// When true, hosted sessions will not copy x-model-api-key into model.apiKey.
    /// Use this when auth is carried through providerOptions instead of an API key.
    /// </summary>
    public bool? SkipApiKeyFallback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("skipApiKeyFallback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("skipApiKeyFallback", value);
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
        this.ProviderOptions?.Validate();
        _ = this.SkipApiKeyFallback;
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
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Provider-specific options passed through to the AI SDK provider constructor.
/// For Bedrock: { region, accessKeyId, secretAccessKey, sessionToken }. For Vertex:
/// { project, location, googleAuthOptions }.
/// </summary>
[JsonConverter(typeof(ModelConfigProviderOptionsConverter))]
public record class ModelConfigProviderOptions : ModelBase
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

    public string? Region
    {
        get
        {
            return Match<string?>(
                bedrockApiKey: (x) => x.Region,
                bedrockAwsCredentials: (x) => x.Region,
                googleVertex: (_) => null
            );
        }
    }

    public ModelConfigProviderOptions(
        ModelConfigProviderOptionsBedrockApiKeyProviderOptions value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ModelConfigProviderOptions(
        ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ModelConfigProviderOptions(
        ModelConfigProviderOptionsGoogleVertexProviderOptions value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ModelConfigProviderOptions(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfigProviderOptionsBedrockApiKeyProviderOptions"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBedrockApiKey(out var value)) {
    ///     // `value` is of type `ModelConfigProviderOptionsBedrockApiKeyProviderOptions`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBedrockApiKey(
        [NotNullWhen(true)] out ModelConfigProviderOptionsBedrockApiKeyProviderOptions? value
    )
    {
        value = this.Value as ModelConfigProviderOptionsBedrockApiKeyProviderOptions;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBedrockAwsCredentials(out var value)) {
    ///     // `value` is of type `ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBedrockAwsCredentials(
        [NotNullWhen(true)]
            out ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions? value
    )
    {
        value = this.Value as ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfigProviderOptionsGoogleVertexProviderOptions"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleVertex(out var value)) {
    ///     // `value` is of type `ModelConfigProviderOptionsGoogleVertexProviderOptions`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleVertex(
        [NotNullWhen(true)] out ModelConfigProviderOptionsGoogleVertexProviderOptions? value
    )
    {
        value = this.Value as ModelConfigProviderOptionsGoogleVertexProviderOptions;
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
    ///     (ModelConfigProviderOptionsBedrockApiKeyProviderOptions value) =&gt; {...},
    ///     (ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions value) =&gt; {...},
    ///     (ModelConfigProviderOptionsGoogleVertexProviderOptions value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ModelConfigProviderOptionsBedrockApiKeyProviderOptions> bedrockApiKey,
        System::Action<ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions> bedrockAwsCredentials,
        System::Action<ModelConfigProviderOptionsGoogleVertexProviderOptions> googleVertex
    )
    {
        switch (this.Value)
        {
            case ModelConfigProviderOptionsBedrockApiKeyProviderOptions value:
                bedrockApiKey(value);
                break;
            case ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions value:
                bedrockAwsCredentials(value);
                break;
            case ModelConfigProviderOptionsGoogleVertexProviderOptions value:
                googleVertex(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ModelConfigProviderOptions"
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
    ///     (ModelConfigProviderOptionsBedrockApiKeyProviderOptions value) =&gt; {...},
    ///     (ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions value) =&gt; {...},
    ///     (ModelConfigProviderOptionsGoogleVertexProviderOptions value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ModelConfigProviderOptionsBedrockApiKeyProviderOptions, T> bedrockApiKey,
        System::Func<
            ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions,
            T
        > bedrockAwsCredentials,
        System::Func<ModelConfigProviderOptionsGoogleVertexProviderOptions, T> googleVertex
    )
    {
        return this.Value switch
        {
            ModelConfigProviderOptionsBedrockApiKeyProviderOptions value => bedrockApiKey(value),
            ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions value =>
                bedrockAwsCredentials(value),
            ModelConfigProviderOptionsGoogleVertexProviderOptions value => googleVertex(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfigProviderOptions"
            ),
        };
    }

    public static implicit operator ModelConfigProviderOptions(
        ModelConfigProviderOptionsBedrockApiKeyProviderOptions value
    ) => new(value);

    public static implicit operator ModelConfigProviderOptions(
        ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions value
    ) => new(value);

    public static implicit operator ModelConfigProviderOptions(
        ModelConfigProviderOptionsGoogleVertexProviderOptions value
    ) => new(value);

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
                "Data did not match any variant of ModelConfigProviderOptions"
            );
        }
        this.Switch(
            (bedrockApiKey) => bedrockApiKey.Validate(),
            (bedrockAwsCredentials) => bedrockAwsCredentials.Validate(),
            (googleVertex) => googleVertex.Validate()
        );
    }

    public virtual bool Equals(ModelConfigProviderOptions? other) =>
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
            ModelConfigProviderOptionsBedrockApiKeyProviderOptions _ => 0,
            ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions _ => 1,
            ModelConfigProviderOptionsGoogleVertexProviderOptions _ => 2,
            _ => -1,
        };
    }
}

sealed class ModelConfigProviderOptionsConverter : JsonConverter<ModelConfigProviderOptions>
{
    public override ModelConfigProviderOptions? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<ModelConfigProviderOptionsBedrockApiKeyProviderOptions>(
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
            var deserialized =
                JsonSerializer.Deserialize<ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions>(
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
            var deserialized =
                JsonSerializer.Deserialize<ModelConfigProviderOptionsGoogleVertexProviderOptions>(
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
        ModelConfigProviderOptions value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigProviderOptionsBedrockApiKeyProviderOptions,
        ModelConfigProviderOptionsBedrockApiKeyProviderOptionsFromRaw
    >)
)]
public sealed record class ModelConfigProviderOptionsBedrockApiKeyProviderOptions : JsonModel
{
    /// <summary>
    /// AWS region for Amazon Bedrock
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Region;
    }

    public ModelConfigProviderOptionsBedrockApiKeyProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
        ModelConfigProviderOptionsBedrockApiKeyProviderOptions modelConfigProviderOptionsBedrockApiKeyProviderOptions
    )
        : base(modelConfigProviderOptionsBedrockApiKeyProviderOptions) { }
#pragma warning restore CS8618

    public ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigProviderOptionsBedrockApiKeyProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigProviderOptionsBedrockApiKeyProviderOptionsFromRaw.FromRawUnchecked"/>
    public static ModelConfigProviderOptionsBedrockApiKeyProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfigProviderOptionsBedrockApiKeyProviderOptions(string region)
        : this()
    {
        this.Region = region;
    }
}

class ModelConfigProviderOptionsBedrockApiKeyProviderOptionsFromRaw
    : IFromRawJson<ModelConfigProviderOptionsBedrockApiKeyProviderOptions>
{
    /// <inheritdoc/>
    public ModelConfigProviderOptionsBedrockApiKeyProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigProviderOptionsBedrockApiKeyProviderOptions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions,
        ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptionsFromRaw
    >)
)]
public sealed record class ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
    : JsonModel
{
    /// <summary>
    /// AWS access key ID for Bedrock
    /// </summary>
    public required string AccessKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accessKeyId");
        }
        init { this._rawData.Set("accessKeyId", value); }
    }

    /// <summary>
    /// AWS region for Amazon Bedrock
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// AWS secret access key for Bedrock
    /// </summary>
    public required string SecretAccessKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secretAccessKey");
        }
        init { this._rawData.Set("secretAccessKey", value); }
    }

    /// <summary>
    /// Optional AWS session token for temporary credentials
    /// </summary>
    public string? SessionToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sessionToken");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sessionToken", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessKeyID;
        _ = this.Region;
        _ = this.SecretAccessKey;
        _ = this.SessionToken;
    }

    public ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions(
        ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions modelConfigProviderOptionsBedrockAwsCredentialsProviderOptions
    )
        : base(modelConfigProviderOptionsBedrockAwsCredentialsProviderOptions) { }
#pragma warning restore CS8618

    public ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptionsFromRaw.FromRawUnchecked"/>
    public static ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptionsFromRaw
    : IFromRawJson<ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions>
{
    /// <inheritdoc/>
    public ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigProviderOptionsBedrockAwsCredentialsProviderOptions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigProviderOptionsGoogleVertexProviderOptions,
        ModelConfigProviderOptionsGoogleVertexProviderOptionsFromRaw
    >)
)]
public sealed record class ModelConfigProviderOptionsGoogleVertexProviderOptions : JsonModel
{
    /// <summary>
    /// Optional Google auth options for Vertex AI
    /// </summary>
    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions? GoogleAuthOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions>(
                "googleAuthOptions"
            );
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
    /// Custom headers for Vertex AI requests
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
    /// Google Cloud location for Vertex AI
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
    /// Google Cloud project ID for Vertex AI
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.GoogleAuthOptions?.Validate();
        _ = this.Headers;
        _ = this.Location;
        _ = this.Project;
    }

    public ModelConfigProviderOptionsGoogleVertexProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigProviderOptionsGoogleVertexProviderOptions(
        ModelConfigProviderOptionsGoogleVertexProviderOptions modelConfigProviderOptionsGoogleVertexProviderOptions
    )
        : base(modelConfigProviderOptionsGoogleVertexProviderOptions) { }
#pragma warning restore CS8618

    public ModelConfigProviderOptionsGoogleVertexProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigProviderOptionsGoogleVertexProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigProviderOptionsGoogleVertexProviderOptionsFromRaw.FromRawUnchecked"/>
    public static ModelConfigProviderOptionsGoogleVertexProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigProviderOptionsGoogleVertexProviderOptionsFromRaw
    : IFromRawJson<ModelConfigProviderOptionsGoogleVertexProviderOptions>
{
    /// <inheritdoc/>
    public ModelConfigProviderOptionsGoogleVertexProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelConfigProviderOptionsGoogleVertexProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional Google auth options for Vertex AI
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions,
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsFromRaw
    >)
)]
public sealed record class ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
    : JsonModel
{
    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials? Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials>(
                "credentials"
            );
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Credentials?.Validate();
    }

    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions(
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions modelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions
    )
        : base(modelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions) { }
#pragma warning restore CS8618

    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsFromRaw.FromRawUnchecked"/>
    public static ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsFromRaw
    : IFromRawJson<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions>
{
    /// <inheritdoc/>
    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptions.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials,
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentialsFromRaw
    >)
)]
public sealed record class ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
    : JsonModel
{
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

    public string? ClientEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("client_email", value);
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

    public string? PrivateKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("private_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("private_key", value);
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

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
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
        _ = this.AuthProviderX509CertUrl;
        _ = this.AuthUri;
        _ = this.ClientEmail;
        _ = this.ClientID;
        _ = this.ClientX509CertUrl;
        _ = this.PrivateKey;
        _ = this.PrivateKeyID;
        _ = this.ProjectID;
        _ = this.TokenUri;
        _ = this.Type;
        _ = this.UniverseDomain;
    }

    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials(
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials modelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials
    )
        : base(modelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials)
    { }
#pragma warning restore CS8618

    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentialsFromRaw.FromRawUnchecked"/>
    public static ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentialsFromRaw
    : IFromRawJson<ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials>
{
    /// <inheritdoc/>
    public ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ModelConfigProviderOptionsGoogleVertexProviderOptionsGoogleAuthOptionsCredentials.FromRawUnchecked(
            rawData
        );
}
