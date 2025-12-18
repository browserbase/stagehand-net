using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionExtractResponse, SessionExtractResponseFromRaw>))]
public sealed record class SessionExtractResponse : JsonModel
{
    public required SessionExtractResponseData Data
    {
        get { return JsonModel.GetNotNullClass<SessionExtractResponseData>(this.RawData, "data"); }
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

    public SessionExtractResponse() { }

    public SessionExtractResponse(SessionExtractResponse sessionExtractResponse)
        : base(sessionExtractResponse) { }

    public SessionExtractResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractResponseFromRaw.FromRawUnchecked"/>
    public static SessionExtractResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractResponseFromRaw : IFromRawJson<SessionExtractResponse>
{
    /// <inheritdoc/>
    public SessionExtractResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SessionExtractResponseData, SessionExtractResponseDataFromRaw>)
)]
public sealed record class SessionExtractResponseData : JsonModel
{
    /// <summary>
    /// Extracted data matching the requested schema
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

    public SessionExtractResponseData() { }

    public SessionExtractResponseData(SessionExtractResponseData sessionExtractResponseData)
        : base(sessionExtractResponseData) { }

    public SessionExtractResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionExtractResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractResponseData(JsonElement result)
        : this()
    {
        this.Result = result;
    }
}

class SessionExtractResponseDataFromRaw : IFromRawJson<SessionExtractResponseData>
{
    /// <inheritdoc/>
    public SessionExtractResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractResponseData.FromRawUnchecked(rawData);
}
