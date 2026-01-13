using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionExecuteResponse, SessionExecuteResponseFromRaw>))]
public sealed record class SessionExecuteResponse : JsonModel
{
    public required SessionExecuteResponseData Data
    {
        get { return this._rawData.GetNotNullClass<SessionExecuteResponseData>("data"); }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public required bool Success
    {
        get { return this._rawData.GetNotNullStruct<bool>("success"); }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        _ = this.Success;
    }

    public SessionExecuteResponse() { }

    public SessionExecuteResponse(SessionExecuteResponse sessionExecuteResponse)
        : base(sessionExecuteResponse) { }

    public SessionExecuteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExecuteResponseFromRaw.FromRawUnchecked"/>
    public static SessionExecuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExecuteResponseFromRaw : IFromRawJson<SessionExecuteResponse>
{
    /// <inheritdoc/>
    public SessionExecuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SessionExecuteResponseData, SessionExecuteResponseDataFromRaw>)
)]
public sealed record class SessionExecuteResponseData : JsonModel
{
    public required SessionExecuteResponseDataResult Result
    {
        get { return this._rawData.GetNotNullClass<SessionExecuteResponseDataResult>("result"); }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
    }

    public SessionExecuteResponseData() { }

    public SessionExecuteResponseData(SessionExecuteResponseData sessionExecuteResponseData)
        : base(sessionExecuteResponseData) { }

    public SessionExecuteResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExecuteResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionExecuteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExecuteResponseData(SessionExecuteResponseDataResult result)
        : this()
    {
        this.Result = result;
    }
}

class SessionExecuteResponseDataFromRaw : IFromRawJson<SessionExecuteResponseData>
{
    /// <inheritdoc/>
    public SessionExecuteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionExecuteResponseDataResult,
        SessionExecuteResponseDataResultFromRaw
    >)
)]
public sealed record class SessionExecuteResponseDataResult : JsonModel
{
    public required IReadOnlyList<SessionExecuteResponseDataResultAction> Actions
    {
        get
        {
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SessionExecuteResponseDataResultAction>
            >("actions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SessionExecuteResponseDataResultAction>>(
                "actions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the agent finished its task
    /// </summary>
    public required bool Completed
    {
        get { return this._rawData.GetNotNullStruct<bool>("completed"); }
        init { this._rawData.Set("completed", value); }
    }

    /// <summary>
    /// Summary of what the agent accomplished
    /// </summary>
    public required string Message
    {
        get { return this._rawData.GetNotNullClass<string>("message"); }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Whether the agent completed successfully
    /// </summary>
    public required bool Success
    {
        get { return this._rawData.GetNotNullStruct<bool>("success"); }
        init { this._rawData.Set("success", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public Usage? Usage
    {
        get { return this._rawData.GetNullableClass<Usage>("usage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Actions)
        {
            item.Validate();
        }
        _ = this.Completed;
        _ = this.Message;
        _ = this.Success;
        _ = this.Metadata;
        this.Usage?.Validate();
    }

    public SessionExecuteResponseDataResult() { }

    public SessionExecuteResponseDataResult(
        SessionExecuteResponseDataResult sessionExecuteResponseDataResult
    )
        : base(sessionExecuteResponseDataResult) { }

    public SessionExecuteResponseDataResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponseDataResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExecuteResponseDataResultFromRaw.FromRawUnchecked"/>
    public static SessionExecuteResponseDataResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExecuteResponseDataResultFromRaw : IFromRawJson<SessionExecuteResponseDataResult>
{
    /// <inheritdoc/>
    public SessionExecuteResponseDataResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponseDataResult.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionExecuteResponseDataResultAction,
        SessionExecuteResponseDataResultActionFromRaw
    >)
)]
public sealed record class SessionExecuteResponseDataResultAction : JsonModel
{
    /// <summary>
    /// Type of action taken
    /// </summary>
    public required string Type
    {
        get { return this._rawData.GetNotNullClass<string>("type"); }
        init { this._rawData.Set("type", value); }
    }

    public string? Action
    {
        get { return this._rawData.GetNullableClass<string>("action"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public string? Instruction
    {
        get { return this._rawData.GetNullableClass<string>("instruction"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instruction", value);
        }
    }

    public string? PageText
    {
        get { return this._rawData.GetNullableClass<string>("pageText"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageText", value);
        }
    }

    public string? PageUrl
    {
        get { return this._rawData.GetNullableClass<string>("pageUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pageUrl", value);
        }
    }

    /// <summary>
    /// Agent's reasoning for taking this action
    /// </summary>
    public string? Reasoning
    {
        get { return this._rawData.GetNullableClass<string>("reasoning"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reasoning", value);
        }
    }

    public bool? TaskCompleted
    {
        get { return this._rawData.GetNullableStruct<bool>("taskCompleted"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("taskCompleted", value);
        }
    }

    /// <summary>
    /// Time taken for this action in ms
    /// </summary>
    public double? TimeMs
    {
        get { return this._rawData.GetNullableStruct<double>("timeMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeMs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Action;
        _ = this.Instruction;
        _ = this.PageText;
        _ = this.PageUrl;
        _ = this.Reasoning;
        _ = this.TaskCompleted;
        _ = this.TimeMs;
    }

    public SessionExecuteResponseDataResultAction() { }

    public SessionExecuteResponseDataResultAction(
        SessionExecuteResponseDataResultAction sessionExecuteResponseDataResultAction
    )
        : base(sessionExecuteResponseDataResultAction) { }

    public SessionExecuteResponseDataResultAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponseDataResultAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExecuteResponseDataResultActionFromRaw.FromRawUnchecked"/>
    public static SessionExecuteResponseDataResultAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExecuteResponseDataResultAction(string type)
        : this()
    {
        this.Type = type;
    }
}

class SessionExecuteResponseDataResultActionFromRaw
    : IFromRawJson<SessionExecuteResponseDataResultAction>
{
    /// <inheritdoc/>
    public SessionExecuteResponseDataResultAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponseDataResultAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    public required double InferenceTimeMs
    {
        get { return this._rawData.GetNotNullStruct<double>("inference_time_ms"); }
        init { this._rawData.Set("inference_time_ms", value); }
    }

    public required double InputTokens
    {
        get { return this._rawData.GetNotNullStruct<double>("input_tokens"); }
        init { this._rawData.Set("input_tokens", value); }
    }

    public required double OutputTokens
    {
        get { return this._rawData.GetNotNullStruct<double>("output_tokens"); }
        init { this._rawData.Set("output_tokens", value); }
    }

    public double? CachedInputTokens
    {
        get { return this._rawData.GetNullableStruct<double>("cached_input_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cached_input_tokens", value);
        }
    }

    public double? ReasoningTokens
    {
        get { return this._rawData.GetNullableStruct<double>("reasoning_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reasoning_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InferenceTimeMs;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        _ = this.CachedInputTokens;
        _ = this.ReasoningTokens;
    }

    public Usage() { }

    public Usage(Usage usage)
        : base(usage) { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
