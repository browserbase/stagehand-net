using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionStartResponse, SessionStartResponseFromRaw>))]
public sealed record class SessionStartResponse : ModelBase
{
    /// <summary>
    /// Whether the session is ready to use
    /// </summary>
    public required bool Available
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "available"); }
        init { ModelBase.Set(this._rawData, "available", value); }
    }

    /// <summary>
    /// Unique identifier for the session
    /// </summary>
    public required string SessionID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "sessionId"); }
        init { ModelBase.Set(this._rawData, "sessionId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Available;
        _ = this.SessionID;
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

class SessionStartResponseFromRaw : IFromRaw<SessionStartResponse>
{
    /// <inheritdoc/>
    public SessionStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionStartResponse.FromRawUnchecked(rawData);
}
