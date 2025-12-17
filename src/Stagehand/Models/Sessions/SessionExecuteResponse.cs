using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionExecuteResponse, SessionExecuteResponseFromRaw>))]
public sealed record class SessionExecuteResponse : ModelBase
{
    public required SessionExecuteResponseData Data
    {
        get { return ModelBase.GetNotNullClass<SessionExecuteResponseData>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public required bool Success
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SessionExecuteResponseFromRaw : IFromRaw<SessionExecuteResponse>
{
    /// <inheritdoc/>
    public SessionExecuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<SessionExecuteResponseData, SessionExecuteResponseDataFromRaw>)
)]
public sealed record class SessionExecuteResponseData : ModelBase
{
    public required SessionExecuteResponseDataResult Result
    {
        get
        {
            return ModelBase.GetNotNullClass<SessionExecuteResponseDataResult>(
                this.RawData,
                "result"
            );
        }
        init { ModelBase.Set(this._rawData, "result", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SessionExecuteResponseDataFromRaw : IFromRaw<SessionExecuteResponseData>
{
    /// <inheritdoc/>
    public SessionExecuteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        SessionExecuteResponseDataResult,
        SessionExecuteResponseDataResultFromRaw
    >)
)]
public sealed record class SessionExecuteResponseDataResult : ModelBase
{
    public required IReadOnlyList<SessionExecuteResponseDataResultAction> Actions
    {
        get
        {
            return ModelBase.GetNotNullClass<List<SessionExecuteResponseDataResultAction>>(
                this.RawData,
                "actions"
            );
        }
        init { ModelBase.Set(this._rawData, "actions", value); }
    }

    /// <summary>
    /// Whether the agent finished its task
    /// </summary>
    public required bool Completed
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "completed"); }
        init { ModelBase.Set(this._rawData, "completed", value); }
    }

    /// <summary>
    /// Summary of what the agent accomplished
    /// </summary>
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    /// <summary>
    /// Whether the agent completed successfully
    /// </summary>
    public required bool Success
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "metadata", value);
        }
    }

    public Usage? Usage
    {
        get { return ModelBase.GetNullableClass<Usage>(this.RawData, "usage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "usage", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponseDataResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SessionExecuteResponseDataResultFromRaw : IFromRaw<SessionExecuteResponseDataResult>
{
    /// <inheritdoc/>
    public SessionExecuteResponseDataResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponseDataResult.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        SessionExecuteResponseDataResultAction,
        SessionExecuteResponseDataResultActionFromRaw
    >)
)]
public sealed record class SessionExecuteResponseDataResultAction : ModelBase
{
    /// <summary>
    /// Type of action taken
    /// </summary>
    public required string Type
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public string? Action
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "action"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "action", value);
        }
    }

    public string? Instruction
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "instruction"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "instruction", value);
        }
    }

    public string? PageText
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "pageText"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "pageText", value);
        }
    }

    public string? PageURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "pageUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "pageUrl", value);
        }
    }

    /// <summary>
    /// Agent's reasoning for taking this action
    /// </summary>
    public string? Reasoning
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reasoning"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "reasoning", value);
        }
    }

    public bool? TaskCompleted
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "taskCompleted"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "taskCompleted", value);
        }
    }

    /// <summary>
    /// Time taken for this action in ms
    /// </summary>
    public double? TimeMs
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "timeMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "timeMs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Action;
        _ = this.Instruction;
        _ = this.PageText;
        _ = this.PageURL;
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteResponseDataResultAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    : IFromRaw<SessionExecuteResponseDataResultAction>
{
    /// <inheritdoc/>
    public SessionExecuteResponseDataResultAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteResponseDataResultAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : ModelBase
{
    public required double InferenceTimeMs
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "inference_time_ms"); }
        init { ModelBase.Set(this._rawData, "inference_time_ms", value); }
    }

    public required double InputTokens
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "input_tokens"); }
        init { ModelBase.Set(this._rawData, "input_tokens", value); }
    }

    public required double OutputTokens
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "output_tokens"); }
        init { ModelBase.Set(this._rawData, "output_tokens", value); }
    }

    public double? CachedInputTokens
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "cached_input_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cached_input_tokens", value);
        }
    }

    public double? ReasoningTokens
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "reasoning_tokens"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "reasoning_tokens", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRaw<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
