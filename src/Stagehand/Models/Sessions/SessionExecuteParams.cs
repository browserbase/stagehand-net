using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Runs an autonomous AI agent that can perform complex multi-step browser tasks.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionExecuteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public required AgentConfig AgentConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<AgentConfig>("agentConfig");
        }
        init { this._rawBodyData.Set("agentConfig", value); }
    }

    public required ExecuteOptions ExecuteOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ExecuteOptions>("executeOptions");
        }
        init { this._rawBodyData.Set("executeOptions", value); }
    }

    /// <summary>
    /// Target frame ID for the agent
    /// </summary>
    public string? FrameID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("frameId");
        }
        init { this._rawBodyData.Set("frameId", value); }
    }

    /// <summary>
    /// If true, the server captures a cache entry and returns it to the client
    /// </summary>
    public bool? ShouldCache
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("shouldCache");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("shouldCache", value);
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public ApiEnum<string, SessionExecuteParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<
                ApiEnum<string, SessionExecuteParamsXStreamResponse>
            >("x-stream-response");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-stream-response", value);
        }
    }

    public SessionExecuteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExecuteParams(SessionExecuteParams sessionExecuteParams)
        : base(sessionExecuteParams)
    {
        this.ID = sessionExecuteParams.ID;

        this._rawBodyData = new(sessionExecuteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SessionExecuteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionExecuteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SessionExecuteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/sessions/{0}/agentExecute", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<AgentConfig, AgentConfigFromRaw>))]
public sealed record class AgentConfig : JsonModel
{
    /// <summary>
    /// Deprecated. Use mode: 'cua' instead. If both are provided, mode takes precedence.
    /// </summary>
    public bool? Cua
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cua");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cua", value);
        }
    }

    /// <summary>
    /// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
    /// for tool execution (observe/act calls within agent tools). If not specified,
    /// inherits from the main model configuration.
    /// </summary>
    public ExecutionModel? ExecutionModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExecutionModel>("executionModel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("executionModel", value);
        }
    }

    /// <summary>
    /// Tool mode for the agent (dom, hybrid, cua). If set, overrides cua.
    /// </summary>
    public ApiEnum<string, Mode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Mode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public AgentConfigModel? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentConfigModel>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// AI provider for the agent (legacy, use model: openai/gpt-5-nano instead)
    /// </summary>
    public ApiEnum<string, AgentConfigProvider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AgentConfigProvider>>("provider");
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
    /// Custom system prompt for the agent
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("systemPrompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("systemPrompt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cua;
        this.ExecutionModel?.Validate();
        this.Mode?.Validate();
        this.Model?.Validate();
        this.Provider?.Validate();
        _ = this.SystemPrompt;
    }

    public AgentConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfig(AgentConfig agentConfig)
        : base(agentConfig) { }
#pragma warning restore CS8618

    public AgentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigFromRaw.FromRawUnchecked"/>
    public static AgentConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentConfigFromRaw : IFromRawJson<AgentConfig>
{
    /// <inheritdoc/>
    public AgentConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Model configuration object or model name string (e.g., 'openai/gpt-5-nano') for
/// tool execution (observe/act calls within agent tools). If not specified, inherits
/// from the main model configuration.
/// </summary>
[JsonConverter(typeof(ExecutionModelConverter))]
public record class ExecutionModel : ModelBase
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

    public string? ModelName
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ModelName,
                genericModelConfigObject: (x) => x.ModelName,
                @string: (_) => null
            );
        }
    }

    public string? ApiKey
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ApiKey,
                genericModelConfigObject: (x) => x.ApiKey,
                @string: (_) => null
            );
        }
    }

    public string? BaseUrl
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.BaseUrl,
                genericModelConfigObject: (x) => x.BaseUrl,
                @string: (_) => null
            );
        }
    }

    public ExecutionModel(ExecutionModelVertexModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecutionModel(ExecutionModelGenericModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecutionModel(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecutionModel(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExecutionModelVertexModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexModelConfigObject(out var value)) {
    ///     // `value` is of type `ExecutionModelVertexModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexModelConfigObject(
        [NotNullWhen(true)] out ExecutionModelVertexModelConfigObject? value
    )
    {
        value = this.Value as ExecutionModelVertexModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExecutionModelGenericModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGenericModelConfigObject(out var value)) {
    ///     // `value` is of type `ExecutionModelGenericModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGenericModelConfigObject(
        [NotNullWhen(true)] out ExecutionModelGenericModelConfigObject? value
    )
    {
        value = this.Value as ExecutionModelGenericModelConfigObject;
        return value != null;
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
    ///     (ExecutionModelVertexModelConfigObject value) =&gt; {...},
    ///     (ExecutionModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ExecutionModelVertexModelConfigObject> vertexModelConfigObject,
        System::Action<ExecutionModelGenericModelConfigObject> genericModelConfigObject,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case ExecutionModelVertexModelConfigObject value:
                vertexModelConfigObject(value);
                break;
            case ExecutionModelGenericModelConfigObject value:
                genericModelConfigObject(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ExecutionModel"
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
    ///     (ExecutionModelVertexModelConfigObject value) =&gt; {...},
    ///     (ExecutionModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ExecutionModelVertexModelConfigObject, T> vertexModelConfigObject,
        System::Func<ExecutionModelGenericModelConfigObject, T> genericModelConfigObject,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            ExecutionModelVertexModelConfigObject value => vertexModelConfigObject(value),
            ExecutionModelGenericModelConfigObject value => genericModelConfigObject(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ExecutionModel"
            ),
        };
    }

    public static implicit operator ExecutionModel(ExecutionModelVertexModelConfigObject value) =>
        new(value);

    public static implicit operator ExecutionModel(ExecutionModelGenericModelConfigObject value) =>
        new(value);

    public static implicit operator ExecutionModel(string value) => new(value);

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
                "Data did not match any variant of ExecutionModel"
            );
        }
        this.Switch(
            (vertexModelConfigObject) => vertexModelConfigObject.Validate(),
            (genericModelConfigObject) => genericModelConfigObject.Validate(),
            (_) => { }
        );
    }

    public virtual bool Equals(ExecutionModel? other) =>
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
            ExecutionModelVertexModelConfigObject _ => 0,
            ExecutionModelGenericModelConfigObject _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class ExecutionModelConverter : JsonConverter<ExecutionModel>
{
    public override ExecutionModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ExecutionModelVertexModelConfigObject>(
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
            var deserialized = JsonSerializer.Deserialize<ExecutionModelGenericModelConfigObject>(
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecutionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExecutionModelVertexModelConfigObject,
        ExecutionModelVertexModelConfigObjectFromRaw
    >)
)]
public sealed record class ExecutionModelVertexModelConfigObject : JsonModel
{
    /// <summary>
    /// Vertex provider authentication configuration
    /// </summary>
    public required ExecutionModelVertexModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExecutionModelVertexModelConfigObjectAuth>("auth");
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
    public required ExecutionModelVertexModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExecutionModelVertexModelConfigObjectProviderOptions>(
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

    public ExecutionModelVertexModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObject(
        ExecutionModelVertexModelConfigObject executionModelVertexModelConfigObject
    )
        : base(executionModelVertexModelConfigObject) { }
#pragma warning restore CS8618

    public ExecutionModelVertexModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionModelVertexModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionModelVertexModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static ExecutionModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutionModelVertexModelConfigObjectFromRaw
    : IFromRawJson<ExecutionModelVertexModelConfigObject>
{
    /// <inheritdoc/>
    public ExecutionModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionModelVertexModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExecutionModelVertexModelConfigObjectAuth,
        ExecutionModelVertexModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class ExecutionModelVertexModelConfigObjectAuth : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public required ExecutionModelVertexModelConfigObjectAuthCredentials Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExecutionModelVertexModelConfigObjectAuthCredentials>(
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
    public ExecutionModelVertexModelConfigObjectAuthScopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExecutionModelVertexModelConfigObjectAuthScopes>(
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

    public ExecutionModelVertexModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObjectAuth(
        ExecutionModelVertexModelConfigObjectAuth executionModelVertexModelConfigObjectAuth
    )
        : base(executionModelVertexModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public ExecutionModelVertexModelConfigObjectAuth(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionModelVertexModelConfigObjectAuth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionModelVertexModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static ExecutionModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObjectAuth(
        ExecutionModelVertexModelConfigObjectAuthCredentials credentials
    )
        : this()
    {
        this.Credentials = credentials;
    }
}

class ExecutionModelVertexModelConfigObjectAuthFromRaw
    : IFromRawJson<ExecutionModelVertexModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public ExecutionModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionModelVertexModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExecutionModelVertexModelConfigObjectAuthCredentials,
        ExecutionModelVertexModelConfigObjectAuthCredentialsFromRaw
    >)
)]
public sealed record class ExecutionModelVertexModelConfigObjectAuthCredentials : JsonModel
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

    public ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ExecutionModelVertexModelConfigObjectAuthCredentialsType>
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

    public ExecutionModelVertexModelConfigObjectAuthCredentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObjectAuthCredentials(
        ExecutionModelVertexModelConfigObjectAuthCredentials executionModelVertexModelConfigObjectAuthCredentials
    )
        : base(executionModelVertexModelConfigObjectAuthCredentials) { }
#pragma warning restore CS8618

    public ExecutionModelVertexModelConfigObjectAuthCredentials(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionModelVertexModelConfigObjectAuthCredentials(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionModelVertexModelConfigObjectAuthCredentialsFromRaw.FromRawUnchecked"/>
    public static ExecutionModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutionModelVertexModelConfigObjectAuthCredentialsFromRaw
    : IFromRawJson<ExecutionModelVertexModelConfigObjectAuthCredentials>
{
    /// <inheritdoc/>
    public ExecutionModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionModelVertexModelConfigObjectAuthCredentials.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExecutionModelVertexModelConfigObjectAuthCredentialsTypeConverter))]
public enum ExecutionModelVertexModelConfigObjectAuthCredentialsType
{
    ServiceAccount,
}

sealed class ExecutionModelVertexModelConfigObjectAuthCredentialsTypeConverter
    : JsonConverter<ExecutionModelVertexModelConfigObjectAuthCredentialsType>
{
    public override ExecutionModelVertexModelConfigObjectAuthCredentialsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" =>
                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            _ => (ExecutionModelVertexModelConfigObjectAuthCredentialsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecutionModelVertexModelConfigObjectAuthCredentialsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount =>
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
[JsonConverter(typeof(ExecutionModelVertexModelConfigObjectAuthScopesConverter))]
public record class ExecutionModelVertexModelConfigObjectAuthScopes : ModelBase
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

    public ExecutionModelVertexModelConfigObjectAuthScopes(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExecutionModelVertexModelConfigObjectAuthScopes(
        IReadOnlyList<string> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ExecutionModelVertexModelConfigObjectAuthScopes(JsonElement element)
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
                    "Data did not match any variant of ExecutionModelVertexModelConfigObjectAuthScopes"
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
                "Data did not match any variant of ExecutionModelVertexModelConfigObjectAuthScopes"
            ),
        };
    }

    public static implicit operator ExecutionModelVertexModelConfigObjectAuthScopes(string value) =>
        new(value);

    public static implicit operator ExecutionModelVertexModelConfigObjectAuthScopes(
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
                "Data did not match any variant of ExecutionModelVertexModelConfigObjectAuthScopes"
            );
        }
    }

    public virtual bool Equals(ExecutionModelVertexModelConfigObjectAuthScopes? other) =>
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

sealed class ExecutionModelVertexModelConfigObjectAuthScopesConverter
    : JsonConverter<ExecutionModelVertexModelConfigObjectAuthScopes>
{
    public override ExecutionModelVertexModelConfigObjectAuthScopes? Read(
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
        ExecutionModelVertexModelConfigObjectAuthScopes value,
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
        ExecutionModelVertexModelConfigObjectProviderOptions,
        ExecutionModelVertexModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class ExecutionModelVertexModelConfigObjectProviderOptions : JsonModel
{
    /// <summary>
    /// Vertex AI provider-specific settings
    /// </summary>
    public required ExecutionModelVertexModelConfigObjectProviderOptionsVertex Vertex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExecutionModelVertexModelConfigObjectProviderOptionsVertex>(
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

    public ExecutionModelVertexModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObjectProviderOptions(
        ExecutionModelVertexModelConfigObjectProviderOptions executionModelVertexModelConfigObjectProviderOptions
    )
        : base(executionModelVertexModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public ExecutionModelVertexModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionModelVertexModelConfigObjectProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionModelVertexModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static ExecutionModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObjectProviderOptions(
        ExecutionModelVertexModelConfigObjectProviderOptionsVertex vertex
    )
        : this()
    {
        this.Vertex = vertex;
    }
}

class ExecutionModelVertexModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<ExecutionModelVertexModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public ExecutionModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionModelVertexModelConfigObjectProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex AI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExecutionModelVertexModelConfigObjectProviderOptionsVertex,
        ExecutionModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    >)
)]
public sealed record class ExecutionModelVertexModelConfigObjectProviderOptionsVertex : JsonModel
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

    public ExecutionModelVertexModelConfigObjectProviderOptionsVertex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionModelVertexModelConfigObjectProviderOptionsVertex(
        ExecutionModelVertexModelConfigObjectProviderOptionsVertex executionModelVertexModelConfigObjectProviderOptionsVertex
    )
        : base(executionModelVertexModelConfigObjectProviderOptionsVertex) { }
#pragma warning restore CS8618

    public ExecutionModelVertexModelConfigObjectProviderOptionsVertex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionModelVertexModelConfigObjectProviderOptionsVertex(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionModelVertexModelConfigObjectProviderOptionsVertexFromRaw.FromRawUnchecked"/>
    public static ExecutionModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutionModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    : IFromRawJson<ExecutionModelVertexModelConfigObjectProviderOptionsVertex>
{
    /// <inheritdoc/>
    public ExecutionModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionModelVertexModelConfigObjectProviderOptionsVertex.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExecutionModelGenericModelConfigObject,
        ExecutionModelGenericModelConfigObjectFromRaw
    >)
)]
public sealed record class ExecutionModelGenericModelConfigObject : JsonModel
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
    public ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ExecutionModelGenericModelConfigObjectProvider>
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

    public ExecutionModelGenericModelConfigObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionModelGenericModelConfigObject(
        ExecutionModelGenericModelConfigObject executionModelGenericModelConfigObject
    )
        : base(executionModelGenericModelConfigObject) { }
#pragma warning restore CS8618

    public ExecutionModelGenericModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionModelGenericModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionModelGenericModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static ExecutionModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionModelGenericModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class ExecutionModelGenericModelConfigObjectFromRaw
    : IFromRawJson<ExecutionModelGenericModelConfigObject>
{
    /// <inheritdoc/>
    public ExecutionModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionModelGenericModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(ExecutionModelGenericModelConfigObjectProviderConverter))]
public enum ExecutionModelGenericModelConfigObjectProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class ExecutionModelGenericModelConfigObjectProviderConverter
    : JsonConverter<ExecutionModelGenericModelConfigObjectProvider>
{
    public override ExecutionModelGenericModelConfigObjectProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => ExecutionModelGenericModelConfigObjectProvider.OpenAI,
            "anthropic" => ExecutionModelGenericModelConfigObjectProvider.Anthropic,
            "google" => ExecutionModelGenericModelConfigObjectProvider.Google,
            "microsoft" => ExecutionModelGenericModelConfigObjectProvider.Microsoft,
            "bedrock" => ExecutionModelGenericModelConfigObjectProvider.Bedrock,
            _ => (ExecutionModelGenericModelConfigObjectProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecutionModelGenericModelConfigObjectProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExecutionModelGenericModelConfigObjectProvider.OpenAI => "openai",
                ExecutionModelGenericModelConfigObjectProvider.Anthropic => "anthropic",
                ExecutionModelGenericModelConfigObjectProvider.Google => "google",
                ExecutionModelGenericModelConfigObjectProvider.Microsoft => "microsoft",
                ExecutionModelGenericModelConfigObjectProvider.Bedrock => "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tool mode for the agent (dom, hybrid, cua). If set, overrides cua.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Dom,
    Hybrid,
    Cua,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dom" => Mode.Dom,
            "hybrid" => Mode.Hybrid,
            "cua" => Mode.Cua,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Dom => "dom",
                Mode.Hybrid => "hybrid",
                Mode.Cua => "cua",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
/// </summary>
[JsonConverter(typeof(AgentConfigModelConverter))]
public record class AgentConfigModel : ModelBase
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

    public string? ModelName
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ModelName,
                genericModelConfigObject: (x) => x.ModelName,
                @string: (_) => null
            );
        }
    }

    public string? ApiKey
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ApiKey,
                genericModelConfigObject: (x) => x.ApiKey,
                @string: (_) => null
            );
        }
    }

    public string? BaseUrl
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.BaseUrl,
                genericModelConfigObject: (x) => x.BaseUrl,
                @string: (_) => null
            );
        }
    }

    public AgentConfigModel(
        AgentConfigModelVertexModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentConfigModel(
        AgentConfigModelGenericModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentConfigModel(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentConfigModel(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AgentConfigModelVertexModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexModelConfigObject(out var value)) {
    ///     // `value` is of type `AgentConfigModelVertexModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexModelConfigObject(
        [NotNullWhen(true)] out AgentConfigModelVertexModelConfigObject? value
    )
    {
        value = this.Value as AgentConfigModelVertexModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AgentConfigModelGenericModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGenericModelConfigObject(out var value)) {
    ///     // `value` is of type `AgentConfigModelGenericModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGenericModelConfigObject(
        [NotNullWhen(true)] out AgentConfigModelGenericModelConfigObject? value
    )
    {
        value = this.Value as AgentConfigModelGenericModelConfigObject;
        return value != null;
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
    ///     (AgentConfigModelVertexModelConfigObject value) =&gt; {...},
    ///     (AgentConfigModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<AgentConfigModelVertexModelConfigObject> vertexModelConfigObject,
        System::Action<AgentConfigModelGenericModelConfigObject> genericModelConfigObject,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case AgentConfigModelVertexModelConfigObject value:
                vertexModelConfigObject(value);
                break;
            case AgentConfigModelGenericModelConfigObject value:
                genericModelConfigObject(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of AgentConfigModel"
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
    ///     (AgentConfigModelVertexModelConfigObject value) =&gt; {...},
    ///     (AgentConfigModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<AgentConfigModelVertexModelConfigObject, T> vertexModelConfigObject,
        System::Func<AgentConfigModelGenericModelConfigObject, T> genericModelConfigObject,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            AgentConfigModelVertexModelConfigObject value => vertexModelConfigObject(value),
            AgentConfigModelGenericModelConfigObject value => genericModelConfigObject(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of AgentConfigModel"
            ),
        };
    }

    public static implicit operator AgentConfigModel(
        AgentConfigModelVertexModelConfigObject value
    ) => new(value);

    public static implicit operator AgentConfigModel(
        AgentConfigModelGenericModelConfigObject value
    ) => new(value);

    public static implicit operator AgentConfigModel(string value) => new(value);

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
                "Data did not match any variant of AgentConfigModel"
            );
        }
        this.Switch(
            (vertexModelConfigObject) => vertexModelConfigObject.Validate(),
            (genericModelConfigObject) => genericModelConfigObject.Validate(),
            (_) => { }
        );
    }

    public virtual bool Equals(AgentConfigModel? other) =>
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
            AgentConfigModelVertexModelConfigObject _ => 0,
            AgentConfigModelGenericModelConfigObject _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentConfigModelConverter : JsonConverter<AgentConfigModel>
{
    public override AgentConfigModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AgentConfigModelVertexModelConfigObject>(
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
            var deserialized = JsonSerializer.Deserialize<AgentConfigModelGenericModelConfigObject>(
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentConfigModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        AgentConfigModelVertexModelConfigObject,
        AgentConfigModelVertexModelConfigObjectFromRaw
    >)
)]
public sealed record class AgentConfigModelVertexModelConfigObject : JsonModel
{
    /// <summary>
    /// Vertex provider authentication configuration
    /// </summary>
    public required AgentConfigModelVertexModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentConfigModelVertexModelConfigObjectAuth>(
                "auth"
            );
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
    public required AgentConfigModelVertexModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentConfigModelVertexModelConfigObjectProviderOptions>(
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

    public AgentConfigModelVertexModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObject(
        AgentConfigModelVertexModelConfigObject agentConfigModelVertexModelConfigObject
    )
        : base(agentConfigModelVertexModelConfigObject) { }
#pragma warning restore CS8618

    public AgentConfigModelVertexModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfigModelVertexModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigModelVertexModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static AgentConfigModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentConfigModelVertexModelConfigObjectFromRaw
    : IFromRawJson<AgentConfigModelVertexModelConfigObject>
{
    /// <inheritdoc/>
    public AgentConfigModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentConfigModelVertexModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AgentConfigModelVertexModelConfigObjectAuth,
        AgentConfigModelVertexModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class AgentConfigModelVertexModelConfigObjectAuth : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public required AgentConfigModelVertexModelConfigObjectAuthCredentials Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentConfigModelVertexModelConfigObjectAuthCredentials>(
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
    public AgentConfigModelVertexModelConfigObjectAuthScopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentConfigModelVertexModelConfigObjectAuthScopes>(
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

    public AgentConfigModelVertexModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObjectAuth(
        AgentConfigModelVertexModelConfigObjectAuth agentConfigModelVertexModelConfigObjectAuth
    )
        : base(agentConfigModelVertexModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public AgentConfigModelVertexModelConfigObjectAuth(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfigModelVertexModelConfigObjectAuth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigModelVertexModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static AgentConfigModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObjectAuth(
        AgentConfigModelVertexModelConfigObjectAuthCredentials credentials
    )
        : this()
    {
        this.Credentials = credentials;
    }
}

class AgentConfigModelVertexModelConfigObjectAuthFromRaw
    : IFromRawJson<AgentConfigModelVertexModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public AgentConfigModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentConfigModelVertexModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AgentConfigModelVertexModelConfigObjectAuthCredentials,
        AgentConfigModelVertexModelConfigObjectAuthCredentialsFromRaw
    >)
)]
public sealed record class AgentConfigModelVertexModelConfigObjectAuthCredentials : JsonModel
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

    public ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AgentConfigModelVertexModelConfigObjectAuthCredentialsType>
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

    public AgentConfigModelVertexModelConfigObjectAuthCredentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObjectAuthCredentials(
        AgentConfigModelVertexModelConfigObjectAuthCredentials agentConfigModelVertexModelConfigObjectAuthCredentials
    )
        : base(agentConfigModelVertexModelConfigObjectAuthCredentials) { }
#pragma warning restore CS8618

    public AgentConfigModelVertexModelConfigObjectAuthCredentials(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfigModelVertexModelConfigObjectAuthCredentials(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigModelVertexModelConfigObjectAuthCredentialsFromRaw.FromRawUnchecked"/>
    public static AgentConfigModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentConfigModelVertexModelConfigObjectAuthCredentialsFromRaw
    : IFromRawJson<AgentConfigModelVertexModelConfigObjectAuthCredentials>
{
    /// <inheritdoc/>
    public AgentConfigModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentConfigModelVertexModelConfigObjectAuthCredentials.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AgentConfigModelVertexModelConfigObjectAuthCredentialsTypeConverter))]
public enum AgentConfigModelVertexModelConfigObjectAuthCredentialsType
{
    ServiceAccount,
}

sealed class AgentConfigModelVertexModelConfigObjectAuthCredentialsTypeConverter
    : JsonConverter<AgentConfigModelVertexModelConfigObjectAuthCredentialsType>
{
    public override AgentConfigModelVertexModelConfigObjectAuthCredentialsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" =>
                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            _ => (AgentConfigModelVertexModelConfigObjectAuthCredentialsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentConfigModelVertexModelConfigObjectAuthCredentialsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount =>
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
[JsonConverter(typeof(AgentConfigModelVertexModelConfigObjectAuthScopesConverter))]
public record class AgentConfigModelVertexModelConfigObjectAuthScopes : ModelBase
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

    public AgentConfigModelVertexModelConfigObjectAuthScopes(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentConfigModelVertexModelConfigObjectAuthScopes(
        IReadOnlyList<string> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public AgentConfigModelVertexModelConfigObjectAuthScopes(JsonElement element)
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
                    "Data did not match any variant of AgentConfigModelVertexModelConfigObjectAuthScopes"
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
                "Data did not match any variant of AgentConfigModelVertexModelConfigObjectAuthScopes"
            ),
        };
    }

    public static implicit operator AgentConfigModelVertexModelConfigObjectAuthScopes(
        string value
    ) => new(value);

    public static implicit operator AgentConfigModelVertexModelConfigObjectAuthScopes(
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
                "Data did not match any variant of AgentConfigModelVertexModelConfigObjectAuthScopes"
            );
        }
    }

    public virtual bool Equals(AgentConfigModelVertexModelConfigObjectAuthScopes? other) =>
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

sealed class AgentConfigModelVertexModelConfigObjectAuthScopesConverter
    : JsonConverter<AgentConfigModelVertexModelConfigObjectAuthScopes>
{
    public override AgentConfigModelVertexModelConfigObjectAuthScopes? Read(
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
        AgentConfigModelVertexModelConfigObjectAuthScopes value,
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
        AgentConfigModelVertexModelConfigObjectProviderOptions,
        AgentConfigModelVertexModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class AgentConfigModelVertexModelConfigObjectProviderOptions : JsonModel
{
    /// <summary>
    /// Vertex AI provider-specific settings
    /// </summary>
    public required AgentConfigModelVertexModelConfigObjectProviderOptionsVertex Vertex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentConfigModelVertexModelConfigObjectProviderOptionsVertex>(
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

    public AgentConfigModelVertexModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObjectProviderOptions(
        AgentConfigModelVertexModelConfigObjectProviderOptions agentConfigModelVertexModelConfigObjectProviderOptions
    )
        : base(agentConfigModelVertexModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public AgentConfigModelVertexModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfigModelVertexModelConfigObjectProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigModelVertexModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static AgentConfigModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObjectProviderOptions(
        AgentConfigModelVertexModelConfigObjectProviderOptionsVertex vertex
    )
        : this()
    {
        this.Vertex = vertex;
    }
}

class AgentConfigModelVertexModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<AgentConfigModelVertexModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public AgentConfigModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentConfigModelVertexModelConfigObjectProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex AI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AgentConfigModelVertexModelConfigObjectProviderOptionsVertex,
        AgentConfigModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    >)
)]
public sealed record class AgentConfigModelVertexModelConfigObjectProviderOptionsVertex : JsonModel
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

    public AgentConfigModelVertexModelConfigObjectProviderOptionsVertex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfigModelVertexModelConfigObjectProviderOptionsVertex(
        AgentConfigModelVertexModelConfigObjectProviderOptionsVertex agentConfigModelVertexModelConfigObjectProviderOptionsVertex
    )
        : base(agentConfigModelVertexModelConfigObjectProviderOptionsVertex) { }
#pragma warning restore CS8618

    public AgentConfigModelVertexModelConfigObjectProviderOptionsVertex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfigModelVertexModelConfigObjectProviderOptionsVertex(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigModelVertexModelConfigObjectProviderOptionsVertexFromRaw.FromRawUnchecked"/>
    public static AgentConfigModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentConfigModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    : IFromRawJson<AgentConfigModelVertexModelConfigObjectProviderOptionsVertex>
{
    /// <inheritdoc/>
    public AgentConfigModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentConfigModelVertexModelConfigObjectProviderOptionsVertex.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AgentConfigModelGenericModelConfigObject,
        AgentConfigModelGenericModelConfigObjectFromRaw
    >)
)]
public sealed record class AgentConfigModelGenericModelConfigObject : JsonModel
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
    public ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AgentConfigModelGenericModelConfigObjectProvider>
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

    public AgentConfigModelGenericModelConfigObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfigModelGenericModelConfigObject(
        AgentConfigModelGenericModelConfigObject agentConfigModelGenericModelConfigObject
    )
        : base(agentConfigModelGenericModelConfigObject) { }
#pragma warning restore CS8618

    public AgentConfigModelGenericModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfigModelGenericModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigModelGenericModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static AgentConfigModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentConfigModelGenericModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class AgentConfigModelGenericModelConfigObjectFromRaw
    : IFromRawJson<AgentConfigModelGenericModelConfigObject>
{
    /// <inheritdoc/>
    public AgentConfigModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentConfigModelGenericModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(AgentConfigModelGenericModelConfigObjectProviderConverter))]
public enum AgentConfigModelGenericModelConfigObjectProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class AgentConfigModelGenericModelConfigObjectProviderConverter
    : JsonConverter<AgentConfigModelGenericModelConfigObjectProvider>
{
    public override AgentConfigModelGenericModelConfigObjectProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => AgentConfigModelGenericModelConfigObjectProvider.OpenAI,
            "anthropic" => AgentConfigModelGenericModelConfigObjectProvider.Anthropic,
            "google" => AgentConfigModelGenericModelConfigObjectProvider.Google,
            "microsoft" => AgentConfigModelGenericModelConfigObjectProvider.Microsoft,
            "bedrock" => AgentConfigModelGenericModelConfigObjectProvider.Bedrock,
            _ => (AgentConfigModelGenericModelConfigObjectProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentConfigModelGenericModelConfigObjectProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentConfigModelGenericModelConfigObjectProvider.OpenAI => "openai",
                AgentConfigModelGenericModelConfigObjectProvider.Anthropic => "anthropic",
                AgentConfigModelGenericModelConfigObjectProvider.Google => "google",
                AgentConfigModelGenericModelConfigObjectProvider.Microsoft => "microsoft",
                AgentConfigModelGenericModelConfigObjectProvider.Bedrock => "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// AI provider for the agent (legacy, use model: openai/gpt-5-nano instead)
/// </summary>
[JsonConverter(typeof(AgentConfigProviderConverter))]
public enum AgentConfigProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class AgentConfigProviderConverter : JsonConverter<AgentConfigProvider>
{
    public override AgentConfigProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => AgentConfigProvider.OpenAI,
            "anthropic" => AgentConfigProvider.Anthropic,
            "google" => AgentConfigProvider.Google,
            "microsoft" => AgentConfigProvider.Microsoft,
            "bedrock" => AgentConfigProvider.Bedrock,
            _ => (AgentConfigProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentConfigProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentConfigProvider.OpenAI => "openai",
                AgentConfigProvider.Anthropic => "anthropic",
                AgentConfigProvider.Google => "google",
                AgentConfigProvider.Microsoft => "microsoft",
                AgentConfigProvider.Bedrock => "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ExecuteOptions, ExecuteOptionsFromRaw>))]
public sealed record class ExecuteOptions : JsonModel
{
    /// <summary>
    /// Natural language instruction for the agent
    /// </summary>
    public required string Instruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("instruction");
        }
        init { this._rawData.Set("instruction", value); }
    }

    /// <summary>
    /// Whether to visually highlight the cursor during execution
    /// </summary>
    public bool? HighlightCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("highlightCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("highlightCursor", value);
        }
    }

    /// <summary>
    /// Maximum number of steps the agent can take
    /// </summary>
    public double? MaxSteps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxSteps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxSteps", value);
        }
    }

    /// <summary>
    /// Timeout in milliseconds for each agent tool call
    /// </summary>
    public double? ToolTimeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("toolTimeout");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toolTimeout", value);
        }
    }

    /// <summary>
    /// Whether to enable the web search tool powered by Browserbase Search API
    /// </summary>
    public bool? UseSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("useSearch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("useSearch", value);
        }
    }

    /// <summary>
    /// Variables available to the agent via %variableName% syntax in supported tools
    /// </summary>
    public IReadOnlyDictionary<string, ExecuteOptionsVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ExecuteOptionsVariable>>(
                "variables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, ExecuteOptionsVariable>?>(
                "variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Instruction;
        _ = this.HighlightCursor;
        _ = this.MaxSteps;
        _ = this.ToolTimeout;
        _ = this.UseSearch;
        if (this.Variables != null)
        {
            foreach (var item in this.Variables.Values)
            {
                item.Validate();
            }
        }
    }

    public ExecuteOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecuteOptions(ExecuteOptions executeOptions)
        : base(executeOptions) { }
#pragma warning restore CS8618

    public ExecuteOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecuteOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecuteOptionsFromRaw.FromRawUnchecked"/>
    public static ExecuteOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecuteOptions(string instruction)
        : this()
    {
        this.Instruction = instruction;
    }
}

class ExecuteOptionsFromRaw : IFromRawJson<ExecuteOptions>
{
    /// <inheritdoc/>
    public ExecuteOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecuteOptions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExecuteOptionsVariableConverter))]
public record class ExecuteOptionsVariable : ModelBase
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

    public ExecuteOptionsVariable(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariable(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariable(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariable(
        ExecuteOptionsVariableUnionMember3 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariable(JsonElement element)
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
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExecuteOptionsVariableUnionMember3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExecuteOptionsVariableUnionMember3(out var value)) {
    ///     // `value` is of type `ExecuteOptionsVariableUnionMember3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExecuteOptionsVariableUnionMember3(
        [NotNullWhen(true)] out ExecuteOptionsVariableUnionMember3? value
    )
    {
        value = this.Value as ExecuteOptionsVariableUnionMember3;
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (ExecuteOptionsVariableUnionMember3 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<ExecuteOptionsVariableUnionMember3> executeOptionsVariableUnionMember3
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case ExecuteOptionsVariableUnionMember3 value:
                executeOptionsVariableUnionMember3(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ExecuteOptionsVariable"
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (ExecuteOptionsVariableUnionMember3 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<ExecuteOptionsVariableUnionMember3, T> executeOptionsVariableUnionMember3
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            ExecuteOptionsVariableUnionMember3 value => executeOptionsVariableUnionMember3(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ExecuteOptionsVariable"
            ),
        };
    }

    public static implicit operator ExecuteOptionsVariable(string value) => new(value);

    public static implicit operator ExecuteOptionsVariable(double value) => new(value);

    public static implicit operator ExecuteOptionsVariable(bool value) => new(value);

    public static implicit operator ExecuteOptionsVariable(
        ExecuteOptionsVariableUnionMember3 value
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
                "Data did not match any variant of ExecuteOptionsVariable"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (executeOptionsVariableUnionMember3) => executeOptionsVariableUnionMember3.Validate()
        );
    }

    public virtual bool Equals(ExecuteOptionsVariable? other) =>
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
            double _ => 1,
            bool _ => 2,
            ExecuteOptionsVariableUnionMember3 _ => 3,
            _ => -1,
        };
    }
}

sealed class ExecuteOptionsVariableConverter : JsonConverter<ExecuteOptionsVariable>
{
    public override ExecuteOptionsVariable? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ExecuteOptionsVariableUnionMember3>(
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecuteOptionsVariable value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ExecuteOptionsVariableUnionMember3,
        ExecuteOptionsVariableUnionMember3FromRaw
    >)
)]
public sealed record class ExecuteOptionsVariableUnionMember3 : JsonModel
{
    public required ExecuteOptionsVariableUnionMember3Value Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExecuteOptionsVariableUnionMember3Value>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Value.Validate();
        _ = this.Description;
    }

    public ExecuteOptionsVariableUnionMember3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecuteOptionsVariableUnionMember3(
        ExecuteOptionsVariableUnionMember3 executeOptionsVariableUnionMember3
    )
        : base(executeOptionsVariableUnionMember3) { }
#pragma warning restore CS8618

    public ExecuteOptionsVariableUnionMember3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecuteOptionsVariableUnionMember3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecuteOptionsVariableUnionMember3FromRaw.FromRawUnchecked"/>
    public static ExecuteOptionsVariableUnionMember3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecuteOptionsVariableUnionMember3(ExecuteOptionsVariableUnionMember3Value value)
        : this()
    {
        this.Value = value;
    }
}

class ExecuteOptionsVariableUnionMember3FromRaw : IFromRawJson<ExecuteOptionsVariableUnionMember3>
{
    /// <inheritdoc/>
    public ExecuteOptionsVariableUnionMember3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecuteOptionsVariableUnionMember3.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExecuteOptionsVariableUnionMember3ValueConverter))]
public record class ExecuteOptionsVariableUnionMember3Value : ModelBase
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

    public ExecuteOptionsVariableUnionMember3Value(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariableUnionMember3Value(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariableUnionMember3Value(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExecuteOptionsVariableUnionMember3Value(JsonElement element)
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
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ExecuteOptionsVariableUnionMember3Value"
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ExecuteOptionsVariableUnionMember3Value"
            ),
        };
    }

    public static implicit operator ExecuteOptionsVariableUnionMember3Value(string value) =>
        new(value);

    public static implicit operator ExecuteOptionsVariableUnionMember3Value(double value) =>
        new(value);

    public static implicit operator ExecuteOptionsVariableUnionMember3Value(bool value) =>
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
                "Data did not match any variant of ExecuteOptionsVariableUnionMember3Value"
            );
        }
    }

    public virtual bool Equals(ExecuteOptionsVariableUnionMember3Value? other) =>
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
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class ExecuteOptionsVariableUnionMember3ValueConverter
    : JsonConverter<ExecuteOptionsVariableUnionMember3Value>
{
    public override ExecuteOptionsVariableUnionMember3Value? Read(
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecuteOptionsVariableUnionMember3Value value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Whether to stream the response via SSE
/// </summary>
[JsonConverter(typeof(SessionExecuteParamsXStreamResponseConverter))]
public enum SessionExecuteParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionExecuteParamsXStreamResponseConverter
    : JsonConverter<SessionExecuteParamsXStreamResponse>
{
    public override SessionExecuteParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionExecuteParamsXStreamResponse.True,
            "false" => SessionExecuteParamsXStreamResponse.False,
            _ => (SessionExecuteParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExecuteParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExecuteParamsXStreamResponse.True => "true",
                SessionExecuteParamsXStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
