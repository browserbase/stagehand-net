using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionNavigateResponse, SessionNavigateResponseFromRaw>))]
public sealed record class SessionNavigateResponse : JsonModel
{
    public required SessionNavigateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionNavigateResponseData>("data");
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

    public SessionNavigateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionNavigateResponse(SessionNavigateResponse sessionNavigateResponse)
        : base(sessionNavigateResponse) { }
#pragma warning restore CS8618

    public SessionNavigateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class SessionNavigateResponseFromRaw : IFromRawJson<SessionNavigateResponse>
{
    /// <inheritdoc/>
    public SessionNavigateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionNavigateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SessionNavigateResponseData, SessionNavigateResponseDataFromRaw>)
)]
public sealed record class SessionNavigateResponseData : JsonModel
{
    /// <summary>
    /// Navigation response (Playwright Response object or null)
    /// </summary>
    public required JsonElement Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("result");
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
        _ = this.Result;
        _ = this.ActionID;
    }

    public SessionNavigateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionNavigateResponseData(SessionNavigateResponseData sessionNavigateResponseData)
        : base(sessionNavigateResponseData) { }
#pragma warning restore CS8618

    public SessionNavigateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionNavigateResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionNavigateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionNavigateResponseData(JsonElement result)
        : this()
    {
        this.Result = result;
    }
}

class SessionNavigateResponseDataFromRaw : IFromRawJson<SessionNavigateResponseData>
{
    /// <inheritdoc/>
    public SessionNavigateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionNavigateResponseData.FromRawUnchecked(rawData);
}
