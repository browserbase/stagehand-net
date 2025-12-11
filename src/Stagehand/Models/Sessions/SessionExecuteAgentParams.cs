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
/// Runs an autonomous agent that can perform multiple actions to complete a complex
/// task.
/// </summary>
public sealed record class SessionExecuteAgentParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SessionID { get; init; }

    public required AgentConfig AgentConfig
    {
        get { return ModelBase.GetNotNullClass<AgentConfig>(this.RawBodyData, "agentConfig"); }
        init { ModelBase.Set(this._rawBodyData, "agentConfig", value); }
    }

    public required ExecuteOptions ExecuteOptions
    {
        get
        {
            return ModelBase.GetNotNullClass<ExecuteOptions>(this.RawBodyData, "executeOptions");
        }
        init { ModelBase.Set(this._rawBodyData, "executeOptions", value); }
    }

    public string? FrameID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "frameId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "frameId", value);
        }
    }

    public ApiEnum<string, SessionExecuteAgentParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, SessionExecuteAgentParamsXStreamResponse>
            >(this.RawHeaderData, "x-stream-response");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawHeaderData, "x-stream-response", value);
        }
    }

    public SessionExecuteAgentParams() { }

    public SessionExecuteAgentParams(SessionExecuteAgentParams sessionExecuteAgentParams)
        : base(sessionExecuteAgentParams)
    {
        this._rawBodyData = [.. sessionExecuteAgentParams._rawBodyData];
    }

    public SessionExecuteAgentParams(
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
    SessionExecuteAgentParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SessionExecuteAgentParams FromRawUnchecked(
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
                + string.Format("/sessions/{0}/agentExecute", this.SessionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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

[JsonConverter(typeof(ModelConverter<AgentConfig, AgentConfigFromRaw>))]
public sealed record class AgentConfig : ModelBase
{
    /// <summary>
    /// Enable Computer Use Agent mode
    /// </summary>
    public bool? Cua
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "cua"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cua", value);
        }
    }

    public Model? Model
    {
        get { return ModelBase.GetNullableClass<Model>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "model", value);
        }
    }

    public ApiEnum<string, Provider>? Provider
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Provider>>(this.RawData, "provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "provider", value);
        }
    }

    public string? SystemPrompt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "systemPrompt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "systemPrompt", value);
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

class AgentConfigFromRaw : IFromRaw<AgentConfig>
{
    /// <inheritdoc/>
    public AgentConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter1))]
public record class Model
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Model(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Model(ModelConfig value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Model(JsonElement json)
    {
        this._json = json;
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
    ///     (string value) => {...},
    ///     (ModelConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<ModelConfig> config)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case ModelConfig value:
                config(value);
                break;
            default:
                throw new StagehandInvalidDataException("Data did not match any variant of Model");
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
    ///     (string value) => {...},
    ///     (ModelConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<ModelConfig, T> config)
    {
        return this.Value switch
        {
            string value => @string(value),
            ModelConfig value => config(value),
            _ => throw new StagehandInvalidDataException("Data did not match any variant of Model"),
        };
    }

    public static implicit operator Model(string value) => new(value);

    public static implicit operator Model(ModelConfig value) => new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException("Data did not match any variant of Model");
        }
        this.Switch((_) => { }, (config) => config.Validate());
    }

    public virtual bool Equals(Model? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ModelConverter1 : JsonConverter<Model>
{
    public override Model? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ModelConfig>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    OpenAI,
    Anthropic,
    Google,
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
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<ExecuteOptions, ExecuteOptionsFromRaw>))]
public sealed record class ExecuteOptions : ModelBase
{
    /// <summary>
    /// Task for the agent to complete
    /// </summary>
    public required string Instruction
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "instruction"); }
        init { ModelBase.Set(this._rawData, "instruction", value); }
    }

    /// <summary>
    /// Visually highlight the cursor during actions
    /// </summary>
    public bool? HighlightCursor
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "highlightCursor"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "highlightCursor", value);
        }
    }

    /// <summary>
    /// Maximum number of steps the agent can take
    /// </summary>
    public long? MaxSteps
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "maxSteps"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "maxSteps", value);
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

class ExecuteOptionsFromRaw : IFromRaw<ExecuteOptions>
{
    /// <inheritdoc/>
    public ExecuteOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecuteOptions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SessionExecuteAgentParamsXStreamResponseConverter))]
public enum SessionExecuteAgentParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionExecuteAgentParamsXStreamResponseConverter
    : JsonConverter<SessionExecuteAgentParamsXStreamResponse>
{
    public override SessionExecuteAgentParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionExecuteAgentParamsXStreamResponse.True,
            "false" => SessionExecuteAgentParamsXStreamResponse.False,
            _ => (SessionExecuteAgentParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExecuteAgentParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExecuteAgentParamsXStreamResponse.True => "true",
                SessionExecuteAgentParamsXStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
