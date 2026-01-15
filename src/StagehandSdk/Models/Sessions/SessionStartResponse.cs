using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StagehandSdk.Core;

namespace StagehandSdk.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionStartResponse, SessionStartResponseFromRaw>))]
public sealed record class SessionStartResponse : JsonModel
{
    public required SessionStartResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionStartResponseData>("data");
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

    public SessionStartResponse() { }

    public SessionStartResponse(SessionStartResponse sessionStartResponse)
        : base(sessionStartResponse) { }

    public SessionStartResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStartResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("available");
        }
        init { this._rawData.Set("available", value); }
    }

    /// <summary>
    /// Unique Browserbase session identifier
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sessionId");
        }
        init { this._rawData.Set("sessionId", value); }
    }

    /// <summary>
    /// CDP WebSocket URL for connecting to the Browserbase cloud browser (present
    /// when available)
    /// </summary>
    public string? CdpUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cdpUrl");
        }
        init { this._rawData.Set("cdpUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Available;
        _ = this.SessionID;
        _ = this.CdpUrl;
    }

    public SessionStartResponseData() { }

    public SessionStartResponseData(SessionStartResponseData sessionStartResponseData)
        : base(sessionStartResponseData) { }

    public SessionStartResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStartResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
