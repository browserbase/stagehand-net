using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StagehandSdk.Core;
using StagehandSdk.Exceptions;
using System = System;

namespace StagehandSdk.Models.Sessions;

/// <summary>
/// Runs an autonomous AI agent that can perform complex multi-step browser tasks.
/// </summary>
public sealed record class SessionExecuteParams : ParamsBase
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("frameId", value);
        }
    }

    /// <summary>
    /// ISO timestamp when request was sent
    /// </summary>
    public System::DateTimeOffset? XSentAt
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<System::DateTimeOffset>("x-sent-at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-sent-at", value);
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

    public SessionExecuteParams(SessionExecuteParams sessionExecuteParams)
        : base(sessionExecuteParams)
    {
        this.ID = sessionExecuteParams.ID;

        this._rawBodyData = new(sessionExecuteParams._rawBodyData);
    }

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
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano', 'anthropic/claude-4.5-opus')
    /// </summary>
    public ModelConfig? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelConfig>("model");
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

    public AgentConfig(AgentConfig agentConfig)
        : base(agentConfig) { }

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

    public ExecuteOptions(ExecuteOptions executeOptions)
        : base(executeOptions) { }

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
