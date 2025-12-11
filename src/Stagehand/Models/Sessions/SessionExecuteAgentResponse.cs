using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(
    typeof(ModelConverter<SessionExecuteAgentResponse, SessionExecuteAgentResponseFromRaw>)
)]
public sealed record class SessionExecuteAgentResponse : ModelBase
{
    /// <summary>
    /// Final message from the agent
    /// </summary>
    public string? Message
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "message", value);
        }
    }

    /// <summary>
    /// Steps taken by the agent
    /// </summary>
    public IReadOnlyList<JsonElement>? Steps
    {
        get { return ModelBase.GetNullableClass<List<JsonElement>>(this.RawData, "steps"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "steps", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Steps;
    }

    public SessionExecuteAgentResponse() { }

    public SessionExecuteAgentResponse(SessionExecuteAgentResponse sessionExecuteAgentResponse)
        : base(sessionExecuteAgentResponse) { }

    public SessionExecuteAgentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExecuteAgentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExecuteAgentResponseFromRaw.FromRawUnchecked"/>
    public static SessionExecuteAgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExecuteAgentResponseFromRaw : IFromRaw<SessionExecuteAgentResponse>
{
    /// <inheritdoc/>
    public SessionExecuteAgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExecuteAgentResponse.FromRawUnchecked(rawData);
}
