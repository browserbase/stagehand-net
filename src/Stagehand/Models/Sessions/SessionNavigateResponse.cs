using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Navigation response (may be null)
/// </summary>
[JsonConverter(typeof(ModelConverter<SessionNavigateResponse, SessionNavigateResponseFromRaw>))]
public sealed record class SessionNavigateResponse : ModelBase
{
    public bool? Ok
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "ok"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "ok", value);
        }
    }

    public long? Status
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    public string? URL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ok;
        _ = this.Status;
        _ = this.URL;
    }

    public SessionNavigateResponse() { }

    public SessionNavigateResponse(SessionNavigateResponse sessionNavigateResponse)
        : base(sessionNavigateResponse) { }

    public SessionNavigateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionNavigateResponseFromRaw.FromRawUnchecked"/>
    public static SessionNavigateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionNavigateResponseFromRaw : IFromRaw<SessionNavigateResponse>
{
    /// <inheritdoc/>
    public SessionNavigateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionNavigateResponse.FromRawUnchecked(rawData);
}
