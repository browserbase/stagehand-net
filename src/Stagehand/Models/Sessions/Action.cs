using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Action object returned by observe and used by act
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Action, ActionFromRaw>))]
public sealed record class Action : JsonModel
{
    /// <summary>
    /// Human-readable description of the action
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// CSS selector or XPath for the element
    /// </summary>
    public required string Selector
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("selector");
        }
        init { this._rawData.Set("selector", value); }
    }

    /// <summary>
    /// Arguments to pass to the method
    /// </summary>
    public IReadOnlyList<string>? Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("arguments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "arguments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Backend node ID for the element
    /// </summary>
    public double? BackendNodeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("backendNodeId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("backendNodeId", value);
        }
    }

    /// <summary>
    /// The method to execute (click, fill, etc.)
    /// </summary>
    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Selector;
        _ = this.Arguments;
        _ = this.BackendNodeID;
        _ = this.Method;
    }

    public Action() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Action(Action action)
        : base(action) { }
#pragma warning restore CS8618

    public Action(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Action(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActionFromRaw.FromRawUnchecked"/>
    public static Action FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActionFromRaw : IFromRawJson<Action>
{
    /// <inheritdoc/>
    public Action FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Action.FromRawUnchecked(rawData);
}
