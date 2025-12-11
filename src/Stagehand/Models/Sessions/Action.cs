using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<Action, ActionFromRaw>))]
public sealed record class Action : ModelBase
{
    /// <summary>
    /// Arguments for the method
    /// </summary>
    public required IReadOnlyList<string> Arguments
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "arguments"); }
        init { ModelBase.Set(this._rawData, "arguments", value); }
    }

    /// <summary>
    /// Human-readable description of the action
    /// </summary>
    public required string Description
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Method to execute (e.g., "click", "fill")
    /// </summary>
    public required string Method
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "method"); }
        init { ModelBase.Set(this._rawData, "method", value); }
    }

    /// <summary>
    /// CSS or XPath selector for the element
    /// </summary>
    public required string Selector
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "selector"); }
        init { ModelBase.Set(this._rawData, "selector", value); }
    }

    /// <summary>
    /// CDP backend node ID
    /// </summary>
    public long? BackendNodeID
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "backendNodeId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "backendNodeId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Arguments;
        _ = this.Description;
        _ = this.Method;
        _ = this.Selector;
        _ = this.BackendNodeID;
    }

    public Action() { }

    public Action(Action action)
        : base(action) { }

    public Action(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Action(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActionFromRaw.FromRawUnchecked"/>
    public static Action FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActionFromRaw : IFromRaw<Action>
{
    /// <inheritdoc/>
    public Action FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Action.FromRawUnchecked(rawData);
}
