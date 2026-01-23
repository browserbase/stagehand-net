using System.Collections.Frozen;
using System.Collections.Generic;
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
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SessionExecuteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
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
    /// Enable Computer Use Agent mode
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
    public ApiEnum<string, Provider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>("provider");
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

    public AgentConfigModel(ModelConfig value, JsonElement? element = null)
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
    /// type <see cref="ModelConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConfig(out var value)) {
    ///     // `value` is of type `ModelConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConfig([NotNullWhen(true)] out ModelConfig? value)
    {
        value = this.Value as ModelConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (ModelConfig value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<ModelConfig> config, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case ModelConfig value:
                config(value);
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (ModelConfig value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<ModelConfig, T> config, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            ModelConfig value => config(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of AgentConfigModel"
            ),
        };
    }

    public static implicit operator AgentConfigModel(ModelConfig value) => new(value);

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
        this.Switch((config) => config.Validate(), (_) => { });
    }

    public virtual bool Equals(AgentConfigModel? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
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
            var deserialized = JsonSerializer.Deserialize<ModelConfig>(element, options);
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

/// <summary>
/// AI provider for the agent (legacy, use model: openai/gpt-5-nano instead)
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => Provider.OpenAI,
            "anthropic" => Provider.Anthropic,
            "google" => Provider.Google,
            "microsoft" => Provider.Microsoft,
            _ => (Provider)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Provider value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Provider.OpenAI => "openai",
                Provider.Anthropic => "anthropic",
                Provider.Google => "google",
                Provider.Microsoft => "microsoft",
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Instruction;
        _ = this.HighlightCursor;
        _ = this.MaxSteps;
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
