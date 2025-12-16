using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;

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
    /// Environment to run the browser in
    /// </summary>
    public required ApiEnum<string, Env> Env
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Env>>(this.RawBodyData, "env"); }
        init { ModelBase.Set(this._rawBodyData, "env", value); }
    }

    /// <summary>
    /// API key for Browserbase (required when env=BROWSERBASE)
    /// </summary>
    public string? APIKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "apiKey"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "apiKey", value);
        }
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
    /// Options for local browser launch
    /// </summary>
    public LocalBrowserLaunchOptions? LocalBrowserLaunchOptions
    {
        get
        {
            return ModelBase.GetNullableClass<LocalBrowserLaunchOptions>(
                this.RawBodyData,
                "localBrowserLaunchOptions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "localBrowserLaunchOptions", value);
        }
    }

    /// <summary>
    /// AI model to use for actions
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
    /// Project ID for Browserbase (required when env=BROWSERBASE)
    /// </summary>
    public string? ProjectID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "projectId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "projectId", value);
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

/// <summary>
/// Environment to run the browser in
/// </summary>
[JsonConverter(typeof(EnvConverter))]
public enum Env
{
    Local,
    Browserbase,
}

sealed class EnvConverter : JsonConverter<Env>
{
    public override Env Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LOCAL" => Env.Local,
            "BROWSERBASE" => Env.Browserbase,
            _ => (Env)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Env value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Env.Local => "LOCAL",
                Env.Browserbase => "BROWSERBASE",
                _ => throw new BrowserbaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Options for local browser launch
/// </summary>
[JsonConverter(typeof(ModelConverter<LocalBrowserLaunchOptions, LocalBrowserLaunchOptionsFromRaw>))]
public sealed record class LocalBrowserLaunchOptions : ModelBase
{
    public bool? Headless
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "headless"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "headless", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Headless;
    }

    public LocalBrowserLaunchOptions() { }

    public LocalBrowserLaunchOptions(LocalBrowserLaunchOptions localBrowserLaunchOptions)
        : base(localBrowserLaunchOptions) { }

    public LocalBrowserLaunchOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalBrowserLaunchOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocalBrowserLaunchOptionsFromRaw.FromRawUnchecked"/>
    public static LocalBrowserLaunchOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocalBrowserLaunchOptionsFromRaw : IFromRaw<LocalBrowserLaunchOptions>
{
    /// <inheritdoc/>
    public LocalBrowserLaunchOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LocalBrowserLaunchOptions.FromRawUnchecked(rawData);
}
