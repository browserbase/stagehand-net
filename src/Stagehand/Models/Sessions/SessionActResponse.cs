using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionActResponse, SessionActResponseFromRaw>))]
public sealed record class SessionActResponse : JsonModel
{
    public required SessionActResponseData Data
    {
        get { return JsonModel.GetNotNullClass<SessionActResponseData>(this.RawData, "data"); }
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

    public SessionActResponse() { }

    public SessionActResponse(SessionActResponse sessionActResponse)
        : base(sessionActResponse) { }

    public SessionActResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionActResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<Result>(this.RawData, "result"); }
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
        this.Result.Validate();
        _ = this.ActionID;
    }

    public SessionActResponseData() { }

    public SessionActResponseData(SessionActResponseData sessionActResponseData)
        : base(sessionActResponseData) { }

    public SessionActResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionActResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "actionDescription"); }
        init { JsonModel.Set(this._rawData, "actionDescription", value); }
    }

    /// <summary>
    /// List of actions that were executed
    /// </summary>
    public required IReadOnlyList<Action> Actions
    {
        get { return JsonModel.GetNotNullClass<List<Action>>(this.RawData, "actions"); }
        init { JsonModel.Set(this._rawData, "actions", value); }
    }

    /// <summary>
    /// Human-readable result message
    /// </summary>
    public required string Message
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "message"); }
        init { JsonModel.Set(this._rawData, "message", value); }
    }

    /// <summary>
    /// Whether the action completed successfully
    /// </summary>
    public required bool Success
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
