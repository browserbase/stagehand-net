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
/// </summary>
public sealed record class SessionExecuteParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public required AgentConfig AgentConfig
    {
        get { return JsonModel.GetNotNullClass<AgentConfig>(this.RawBodyData, "agentConfig"); }
        init { JsonModel.Set(this._rawBodyData, "agentConfig", value); }
    }

    public required ExecuteOptions ExecuteOptions
    {
        get
        {
            return JsonModel.GetNotNullClass<ExecuteOptions>(this.RawBodyData, "executeOptions");
        }
        init { JsonModel.Set(this._rawBodyData, "executeOptions", value); }
    }

    /// <summary>
    /// Target frame ID for the agent
    /// </summary>
    public string? FrameID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "frameId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "frameId", value);
        }
    }

    /// <summary>
    /// Client SDK language
    /// </summary>
    public ApiEnum<string, SessionExecuteParamsXLanguage>? XLanguage
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, SessionExecuteParamsXLanguage>>(
                this.RawHeaderData,
                "x-language"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawHeaderData, "x-language", value);
        }
    }

    /// <summary>
    /// Version of the Stagehand SDK
    /// </summary>
    public string? XSDKVersion
    {
        get { return JsonModel.GetNullableClass<string>(this.RawHeaderData, "x-sdk-version"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawHeaderData, "x-sdk-version", value);
        }
    }

    /// <summary>
    /// ISO timestamp when request was sent
    /// </summary>
    public System::DateTimeOffset? XSentAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawHeaderData,
                "x-sent-at"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawHeaderData, "x-sent-at", value);
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public ApiEnum<string, SessionExecuteParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, SessionExecuteParamsXStreamResponse>>(
                this.RawHeaderData,
                "x-stream-response"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawHeaderData, "x-stream-response", value);
        }
    }

    public SessionExecuteParams() { }

    public SessionExecuteParams(SessionExecuteParams sessionExecuteParams)
        : base(sessionExecuteParams)
    {
        this._rawBodyData = [.. sessionExecuteParams._rawBodyData];
    }

    public SessionExecuteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
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
            JsonSerializer.Serialize(this.RawBodyData),
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "cua"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "cua", value);
        }
    }

    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano', 'anthropic/claude-4.5-opus')
    /// </summary>
    public ModelConfig? Model
    {
        get { return JsonModel.GetNullableClass<ModelConfig>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "model", value);
        }
    }

    /// <summary>
    /// AI provider for the agent (legacy, use model: openai/gpt-5-nano instead)
    /// </summary>
    public ApiEnum<string, Provider>? Provider
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Provider>>(this.RawData, "provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "provider", value);
        }
    }

    /// <summary>
    /// Custom system prompt for the agent
    /// </summary>
    public string? SystemPrompt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "systemPrompt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "systemPrompt", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "instruction"); }
        init { JsonModel.Set(this._rawData, "instruction", value); }
    }

    /// <summary>
    /// Whether to visually highlight the cursor during execution
    /// </summary>
    public bool? HighlightCursor
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "highlightCursor"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "highlightCursor", value);
        }
    }

    /// <summary>
    /// Maximum number of steps the agent can take
    /// </summary>
    public double? MaxSteps
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "maxSteps"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "maxSteps", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecuteOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
/// Client SDK language
/// </summary>
[JsonConverter(typeof(SessionExecuteParamsXLanguageConverter))]
public enum SessionExecuteParamsXLanguage
{
    Typescript,
    Python,
    Playground,
}

sealed class SessionExecuteParamsXLanguageConverter : JsonConverter<SessionExecuteParamsXLanguage>
{
    public override SessionExecuteParamsXLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "typescript" => SessionExecuteParamsXLanguage.Typescript,
            "python" => SessionExecuteParamsXLanguage.Python,
            "playground" => SessionExecuteParamsXLanguage.Playground,
            _ => (SessionExecuteParamsXLanguage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExecuteParamsXLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExecuteParamsXLanguage.Typescript => "typescript",
                SessionExecuteParamsXLanguage.Python => "python",
                SessionExecuteParamsXLanguage.Playground => "playground",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
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
