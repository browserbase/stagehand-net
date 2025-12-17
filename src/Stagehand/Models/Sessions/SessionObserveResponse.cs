using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionObserveResponse, SessionObserveResponseFromRaw>))]
public sealed record class SessionObserveResponse : ModelBase
{
    public required SessionObserveResponseData Data
    {
        get { return ModelBase.GetNotNullClass<SessionObserveResponseData>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public required bool Success
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SessionObserveResponseFromRaw : IFromRaw<SessionObserveResponse>
{
    /// <inheritdoc/>
    public SessionObserveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<SessionObserveResponseData, SessionObserveResponseDataFromRaw>)
)]
public sealed record class SessionObserveResponseData : ModelBase
{
    public required IReadOnlyList<Action> Result
    {
        get { return ModelBase.GetNotNullClass<List<Action>>(this.RawData, "result"); }
        init { ModelBase.Set(this._rawData, "result", value); }
    }

    /// <summary>
    /// Action ID for tracking
    /// </summary>
    public string? ActionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "actionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "actionId", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public SessionObserveResponseData(List<Action> result)
        : this()
    {
        this.Result = result;
    }
}

class SessionObserveResponseDataFromRaw : IFromRaw<SessionObserveResponseData>
{
    /// <inheritdoc/>
    public SessionObserveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponseData.FromRawUnchecked(rawData);
}
