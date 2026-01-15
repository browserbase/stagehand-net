using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionObserveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SessionObserveResponseDataResult>>(
                "result"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SessionObserveResponseDataResult>>(
                "result",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Action ID for tracking
    /// </summary>
    public string? ActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("actionId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("actionId", value);
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public SessionObserveResponseData(IReadOnlyList<SessionObserveResponseDataResult> result)
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// CSS selector or XPath for the element
    /// </summary>
    public required string Selector
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("selector");
        }
        init { this._rawData.Set("selector", value); }
    }

    /// <summary>
    /// Arguments to pass to the method
    /// </summary>
    public IReadOnlyList<string>? Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("arguments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "arguments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Backend node ID for the element
    /// </summary>
    public double? BackendNodeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("backendNodeId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("backendNodeId", value);
        }
    }

    /// <summary>
    /// The method to execute (click, fill, etc.)
    /// </summary>
    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponseDataResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
