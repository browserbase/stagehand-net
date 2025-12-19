using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionObserveResponse, SessionObserveResponseFromRaw>))]
public sealed record class SessionObserveResponse : JsonModel
{
    public required SessionObserveResponseData Data
    {
        get { return JsonModel.GetNotNullClass<SessionObserveResponseData>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public required bool Success
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        _ = this.Success;
    }

    public SessionObserveResponse() { }

    public SessionObserveResponse(SessionObserveResponse sessionObserveResponse)
        : base(sessionObserveResponse) { }

    public SessionObserveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveResponseFromRaw.FromRawUnchecked"/>
    public static SessionObserveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveResponseFromRaw : IFromRawJson<SessionObserveResponse>
{
    /// <inheritdoc/>
    public SessionObserveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SessionObserveResponseData, SessionObserveResponseDataFromRaw>)
)]
public sealed record class SessionObserveResponseData : JsonModel
{
    public required IReadOnlyList<SessionObserveResponseDataResult> Result
    {
        get
        {
            return JsonModel.GetNotNullClass<List<SessionObserveResponseDataResult>>(
                this.RawData,
                "result"
            );
        }
        init { JsonModel.Set(this._rawData, "result", value); }
    }

    /// <summary>
    /// Action ID for tracking
    /// </summary>
    public string? ActionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "actionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "actionId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        _ = this.ActionID;
    }

    public SessionObserveResponseData() { }

    public SessionObserveResponseData(SessionObserveResponseData sessionObserveResponseData)
        : base(sessionObserveResponseData) { }

    public SessionObserveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionObserveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionObserveResponseData(List<SessionObserveResponseDataResult> result)
        : this()
    {
        this.Result = result;
    }
}

class SessionObserveResponseDataFromRaw : IFromRawJson<SessionObserveResponseData>
{
    /// <inheritdoc/>
    public SessionObserveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Action object returned by observe and used by act
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveResponseDataResult,
        SessionObserveResponseDataResultFromRaw
    >)
)]
public sealed record class SessionObserveResponseDataResult : JsonModel
{
    /// <summary>
    /// Human-readable description of the action
    /// </summary>
    public required string Description
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// CSS selector or XPath for the element
    /// </summary>
    public required string Selector
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "selector"); }
        init { JsonModel.Set(this._rawData, "selector", value); }
    }

    /// <summary>
    /// Arguments to pass to the method
    /// </summary>
    public IReadOnlyList<string>? Arguments
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "arguments"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "arguments", value);
        }
    }

    /// <summary>
    /// Backend node ID for the element
    /// </summary>
    public double? BackendNodeID
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "backendNodeId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "backendNodeId", value);
        }
    }

    /// <summary>
    /// The method to execute (click, fill, etc.)
    /// </summary>
    public string? Method
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "method"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Selector;
        _ = this.Arguments;
        _ = this.BackendNodeID;
        _ = this.Method;
    }

    public SessionObserveResponseDataResult() { }

    public SessionObserveResponseDataResult(
        SessionObserveResponseDataResult sessionObserveResponseDataResult
    )
        : base(sessionObserveResponseDataResult) { }

    public SessionObserveResponseDataResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponseDataResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveResponseDataResultFromRaw.FromRawUnchecked"/>
    public static SessionObserveResponseDataResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveResponseDataResultFromRaw : IFromRawJson<SessionObserveResponseDataResult>
{
    /// <inheritdoc/>
    public SessionObserveResponseDataResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponseDataResult.FromRawUnchecked(rawData);
}
