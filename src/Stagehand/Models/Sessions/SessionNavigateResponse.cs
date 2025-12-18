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
        get { return JsonModel.GetNotNullClass<SessionNavigateResponseData>(this.RawData, "data"); }
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
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "result"); }
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
        _ = this.Result;
        _ = this.ActionID;
    }

    public SessionNavigateResponseData() { }

    public SessionNavigateResponseData(SessionNavigateResponseData sessionNavigateResponseData)
        : base(sessionNavigateResponseData) { }

    public SessionNavigateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
