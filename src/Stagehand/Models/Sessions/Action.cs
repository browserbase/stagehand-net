using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Action object returned by observe and used by act
/// </summary>
[JsonConverter(typeof(ModelConverter<Action, ActionFromRaw>))]
public sealed record class Action : ModelBase
{
    /// <summary>
    /// Human-readable description of the action
    /// </summary>
    public required string Description
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// CSS selector or XPath for the element
    /// </summary>
    public required string Selector
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "selector"); }
        init { ModelBase.Set(this._rawData, "selector", value); }
    }

    /// <summary>
    /// Arguments to pass to the method
    /// </summary>
    public IReadOnlyList<string>? Arguments
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "arguments"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "arguments", value);
        }
    }

    /// <summary>
    /// The method to execute (click, fill, etc.)
    /// </summary>
    public string? Method
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "method"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Selector;
        _ = this.Arguments;
        _ = this.Method;
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
