using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StagehandSDK.Core;

namespace StagehandSDK.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionEndResponse, SessionEndResponseFromRaw>))]
public sealed record class SessionEndResponse : ModelBase
{
    public bool? Success
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "success"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
    }

    public SessionEndResponse() { }

    public SessionEndResponse(SessionEndResponse sessionEndResponse)
        : base(sessionEndResponse) { }

    public SessionEndResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionEndResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionEndResponseFromRaw.FromRawUnchecked"/>
    public static SessionEndResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionEndResponseFromRaw : IFromRaw<SessionEndResponse>
{
    /// <inheritdoc/>
    public SessionEndResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SessionEndResponse.FromRawUnchecked(rawData);
}
