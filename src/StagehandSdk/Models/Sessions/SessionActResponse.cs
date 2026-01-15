using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StagehandSdk.Core;

namespace StagehandSdk.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionActResponse, SessionActResponseFromRaw>))]
public sealed record class SessionActResponse : JsonModel
{
    public required SessionActResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionActResponseData>("data");
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

    public SessionActResponse() { }

    public SessionActResponse(SessionActResponse sessionActResponse)
        : base(sessionActResponse) { }

    public SessionActResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionActResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionActResponseFromRaw.FromRawUnchecked"/>
    public static SessionActResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionActResponseFromRaw : IFromRawJson<SessionActResponse>
{
    /// <inheritdoc/>
    public SessionActResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SessionActResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SessionActResponseData, SessionActResponseDataFromRaw>))]
public sealed record class SessionActResponseData : JsonModel
{
    public required Result Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Result>("result");
        }
        init { this._rawData.Set("result", value); }
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
        this.Result.Validate();
        _ = this.ActionID;
    }

    public SessionActResponseData() { }

    public SessionActResponseData(SessionActResponseData sessionActResponseData)
        : base(sessionActResponseData) { }

    public SessionActResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionActResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionActResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionActResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionActResponseData(Result result)
        : this()
    {
        this.Result = result;
    }
}

class SessionActResponseDataFromRaw : IFromRawJson<SessionActResponseData>
{
    /// <inheritdoc/>
    public SessionActResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionActResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Description of the action that was performed
    /// </summary>
    public required string ActionDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("actionDescription");
        }
        init { this._rawData.Set("actionDescription", value); }
    }

    /// <summary>
    /// List of actions that were executed
    /// </summary>
    public required IReadOnlyList<ResultAction> Actions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ResultAction>>("actions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ResultAction>>(
                "actions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Human-readable result message
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Whether the action completed successfully
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
        _ = this.ActionDescription;
        foreach (var item in this.Actions)
        {
            item.Validate();
        }
        _ = this.Message;
        _ = this.Success;
    }

    public Result() { }

    public Result(Result result)
        : base(result) { }

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Action object returned by observe and used by act
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ResultAction, ResultActionFromRaw>))]
public sealed record class ResultAction : JsonModel
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

    public ResultAction() { }

    public ResultAction(ResultAction resultAction)
        : base(resultAction) { }

    public ResultAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultActionFromRaw.FromRawUnchecked"/>
    public static ResultAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultActionFromRaw : IFromRawJson<ResultAction>
{
    /// <inheritdoc/>
    public ResultAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResultAction.FromRawUnchecked(rawData);
}
