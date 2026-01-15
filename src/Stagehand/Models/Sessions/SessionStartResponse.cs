using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionStartResponse, SessionStartResponseFromRaw>))]
public sealed record class SessionStartResponse : JsonModel
{
    public required SessionStartResponseData Data
    {
        get { return JsonModel.GetNotNullClass<SessionStartResponseData>(this.RawData, "data"); }
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

    public SessionStartResponse() { }

    public SessionStartResponse(SessionStartResponse sessionStartResponse)
        : base(sessionStartResponse) { }

    public SessionStartResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStartResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionStartResponseFromRaw.FromRawUnchecked"/>
    public static SessionStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionStartResponseFromRaw : IFromRawJson<SessionStartResponse>
{
    /// <inheritdoc/>
    public SessionStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionStartResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SessionStartResponseData, SessionStartResponseDataFromRaw>)
)]
public sealed record class SessionStartResponseData : JsonModel
{
    public required bool Available
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "available"); }
        init { JsonModel.Set(this._rawData, "available", value); }
    }

    /// <summary>
    /// CDP WebSocket URL for connecting to the Browserbase cloud browser
    /// </summary>
    public required string ConnectURL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "connectUrl"); }
        init { JsonModel.Set(this._rawData, "connectUrl", value); }
    }

    /// <summary>
    /// Unique Browserbase session identifier
    /// </summary>
    public required string SessionID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "sessionId"); }
        init { JsonModel.Set(this._rawData, "sessionId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Available;
        _ = this.ConnectURL;
        _ = this.SessionID;
    }

    public SessionStartResponseData() { }

    public SessionStartResponseData(SessionStartResponseData sessionStartResponseData)
        : base(sessionStartResponseData) { }

    public SessionStartResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStartResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionStartResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionStartResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionStartResponseDataFromRaw : IFromRawJson<SessionStartResponseData>
{
    /// <inheritdoc/>
    public SessionStartResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionStartResponseData.FromRawUnchecked(rawData);
}
