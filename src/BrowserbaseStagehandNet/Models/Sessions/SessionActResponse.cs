using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BrowserbaseStagehandNet.Core;

namespace BrowserbaseStagehandNet.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionActResponse, SessionActResponseFromRaw>))]
public sealed record class SessionActResponse : ModelBase
{
    /// <summary>
    /// Actions that were executed
    /// </summary>
    public required IReadOnlyList<Action> Actions
    {
        get { return ModelBase.GetNotNullClass<List<Action>>(this.RawData, "actions"); }
        init { ModelBase.Set(this._rawData, "actions", value); }
    }

    /// <summary>
    /// Result message
    /// </summary>
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    /// <summary>
    /// Whether the action succeeded
    /// </summary>
    public required bool Success
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Actions)
        {
            item.Validate();
        }
        _ = this.Message;
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

class SessionActResponseFromRaw : IFromRaw<SessionActResponse>
{
    /// <inheritdoc/>
    public SessionActResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SessionActResponse.FromRawUnchecked(rawData);
}
