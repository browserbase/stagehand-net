using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Initializes a new Stagehand session with a browser instance. Returns a session
/// ID that must be used for all subsequent requests.
/// </summary>
public sealed record class SessionStartParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// API key for Browserbase Cloud
    /// </summary>
    public required string BrowserbaseAPIKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "BROWSERBASE_API_KEY"); }
        init { ModelBase.Set(this._rawBodyData, "BROWSERBASE_API_KEY", value); }
    }

    /// <summary>
    /// Project ID for Browserbase
    /// </summary>
    public required string BrowserbaseProjectID
    {
        get
        {
            return ModelBase.GetNotNullClass<string>(this.RawBodyData, "BROWSERBASE_PROJECT_ID");
        }
        init { ModelBase.Set(this._rawBodyData, "BROWSERBASE_PROJECT_ID", value); }
    }

    /// <summary>
    /// Timeout in ms to wait for DOM to settle
    /// </summary>
    public long? DomSettleTimeout
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "domSettleTimeout"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "domSettleTimeout", value);
        }
    }

    /// <summary>
    /// AI model to use for actions (must be prefixed with provider/)
    /// </summary>
    public string? Model
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "model", value);
        }
    }

    /// <summary>
    /// Enable self-healing for failed actions
    /// </summary>
    public bool? SelfHeal
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "selfHeal"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "selfHeal", value);
        }
    }

    /// <summary>
    /// Custom system prompt for AI actions
    /// </summary>
    public string? SystemPrompt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "systemPrompt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "systemPrompt", value);
        }
    }

    /// <summary>
    /// Logging verbosity level
    /// </summary>
    public long? Verbose
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "verbose"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "verbose", value);
        }
    }

    public SessionStartParams() { }

    public SessionStartParams(SessionStartParams sessionStartParams)
        : base(sessionStartParams)
    {
        this._rawBodyData = [.. sessionStartParams._rawBodyData];
    }

    public SessionStartParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStartParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SessionStartParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/sessions/start")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
