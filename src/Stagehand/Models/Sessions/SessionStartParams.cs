using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Creates a new browser session with the specified configuration. Returns a session
/// ID used for all subsequent operations.
/// </summary>
public sealed record class SessionStartParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Model name to use for AI operations
    /// </summary>
    public required string ModelName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "modelName"); }
        init { ModelBase.Set(this._rawBodyData, "modelName", value); }
    }

    /// <summary>
    /// Timeout in ms for act operations
    /// </summary>
    public double? ActTimeoutMs
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawBodyData, "actTimeoutMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "actTimeoutMs", value);
        }
    }

    public Browser? Browser
    {
        get { return ModelBase.GetNullableClass<Browser>(this.RawBodyData, "browser"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "browser", value);
        }
    }

    public BrowserbaseSessionCreateParams? BrowserbaseSessionCreateParams
    {
        get
        {
            return ModelBase.GetNullableClass<BrowserbaseSessionCreateParams>(
                this.RawBodyData,
                "browserbaseSessionCreateParams"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "browserbaseSessionCreateParams", value);
        }
    }

    /// <summary>
    /// Existing Browserbase session ID to resume
    /// </summary>
    public string? BrowserbaseSessionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "browserbaseSessionID"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "browserbaseSessionID", value);
        }
    }

    public bool? DebugDom
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "debugDom"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "debugDom", value);
        }
    }

    /// <summary>
    /// Timeout in ms to wait for DOM to settle
    /// </summary>
    public double? DomSettleTimeoutMs
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawBodyData, "domSettleTimeoutMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "domSettleTimeoutMs", value);
        }
    }

    public bool? Experimental
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "experimental"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "experimental", value);
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
    /// Custom system prompt for AI operations
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
    /// Logging verbosity level (0=quiet, 1=normal, 2=debug)
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

    public bool? WaitForCaptchaSolves
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "waitForCaptchaSolves"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "waitForCaptchaSolves", value);
        }
    }

    /// <summary>
    /// Client SDK language
    /// </summary>
    public ApiEnum<string, SessionStartParamsXLanguage>? XLanguage
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SessionStartParamsXLanguage>>(
                this.RawHeaderData,
                "x-language"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawHeaderData, "x-language", value);
        }
    }

    /// <summary>
    /// Version of the Stagehand SDK
    /// </summary>
    public string? XSDKVersion
    {
        get { return ModelBase.GetNullableClass<string>(this.RawHeaderData, "x-sdk-version"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawHeaderData, "x-sdk-version", value);
        }
    }

    /// <summary>
    /// ISO timestamp when request was sent
    /// </summary>
    public System::DateTimeOffset? XSentAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawHeaderData,
                "x-sent-at"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawHeaderData, "x-sent-at", value);
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public ApiEnum<string, SessionStartParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SessionStartParamsXStreamResponse>>(
                this.RawHeaderData,
                "x-stream-response"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawHeaderData, "x-stream-response", value);
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/sessions/start"
        )
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

[JsonConverter(typeof(ModelConverter<Browser, BrowserFromRaw>))]
public sealed record class Browser : ModelBase
{
    /// <summary>
    /// Chrome DevTools Protocol URL for connecting to existing browser
    /// </summary>
    public string? CdpURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "cdpUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cdpUrl", value);
        }
    }

    public LaunchOptions? LaunchOptions
    {
        get { return ModelBase.GetNullableClass<LaunchOptions>(this.RawData, "launchOptions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "launchOptions", value);
        }
    }

    /// <summary>
    /// Browser type to use
    /// </summary>
    public ApiEnum<string, global::Stagehand.Models.Sessions.Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, global::Stagehand.Models.Sessions.Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CdpURL;
        this.LaunchOptions?.Validate();
        this.Type?.Validate();
    }

    public Browser() { }

    public Browser(Browser browser)
        : base(browser) { }

    public Browser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFromRaw.FromRawUnchecked"/>
    public static Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFromRaw : IFromRaw<Browser>
{
    /// <inheritdoc/>
    public Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browser.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<LaunchOptions, LaunchOptionsFromRaw>))]
public sealed record class LaunchOptions : ModelBase
{
    public bool? AcceptDownloads
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "acceptDownloads"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "acceptDownloads", value);
        }
    }

    public IReadOnlyList<string>? Args
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "args"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "args", value);
        }
    }

    public string? CdpURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "cdpUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cdpUrl", value);
        }
    }

    public bool? ChromiumSandbox
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "chromiumSandbox"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "chromiumSandbox", value);
        }
    }

    public double? ConnectTimeoutMs
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "connectTimeoutMs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "connectTimeoutMs", value);
        }
    }

    public double? DeviceScaleFactor
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "deviceScaleFactor"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "deviceScaleFactor", value);
        }
    }

    public bool? Devtools
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "devtools"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "devtools", value);
        }
    }

    public string? DownloadsPath
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "downloadsPath"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "downloadsPath", value);
        }
    }

    public string? ExecutablePath
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "executablePath"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "executablePath", value);
        }
    }

    public bool? HasTouch
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "hasTouch"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "hasTouch", value);
        }
    }

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

    public IgnoreDefaultArgs? IgnoreDefaultArgs
    {
        get
        {
            return ModelBase.GetNullableClass<IgnoreDefaultArgs>(this.RawData, "ignoreDefaultArgs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "ignoreDefaultArgs", value);
        }
    }

    public bool? IgnoreHTTPSErrors
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "ignoreHTTPSErrors"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "ignoreHTTPSErrors", value);
        }
    }

    public string? Locale
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "locale"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "locale", value);
        }
    }

    public bool? PreserveUserDataDir
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "preserveUserDataDir"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "preserveUserDataDir", value);
        }
    }

    public Proxy? Proxy
    {
        get { return ModelBase.GetNullableClass<Proxy>(this.RawData, "proxy"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "proxy", value);
        }
    }

    public string? UserDataDir
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "userDataDir"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "userDataDir", value);
        }
    }

    public Viewport? Viewport
    {
        get { return ModelBase.GetNullableClass<Viewport>(this.RawData, "viewport"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "viewport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptDownloads;
        _ = this.Args;
        _ = this.CdpURL;
        _ = this.ChromiumSandbox;
        _ = this.ConnectTimeoutMs;
        _ = this.DeviceScaleFactor;
        _ = this.Devtools;
        _ = this.DownloadsPath;
        _ = this.ExecutablePath;
        _ = this.HasTouch;
        _ = this.Headless;
        this.IgnoreDefaultArgs?.Validate();
        _ = this.IgnoreHTTPSErrors;
        _ = this.Locale;
        _ = this.PreserveUserDataDir;
        this.Proxy?.Validate();
        _ = this.UserDataDir;
        this.Viewport?.Validate();
    }

    public LaunchOptions() { }

    public LaunchOptions(LaunchOptions launchOptions)
        : base(launchOptions) { }

    public LaunchOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LaunchOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LaunchOptionsFromRaw.FromRawUnchecked"/>
    public static LaunchOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LaunchOptionsFromRaw : IFromRaw<LaunchOptions>
{
    /// <inheritdoc/>
    public LaunchOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LaunchOptions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IgnoreDefaultArgsConverter))]
public record class IgnoreDefaultArgs
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public IgnoreDefaultArgs(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public IgnoreDefaultArgs(IReadOnlyList<string> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public IgnoreDefaultArgs(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<string>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<string>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (bool value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<bool> @bool, System::Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case bool value:
                @bool(value);
                break;
            case List<string> value:
                strings(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of IgnoreDefaultArgs"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (bool value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<bool, T> @bool, System::Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            bool value => @bool(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of IgnoreDefaultArgs"
            ),
        };
    }

    public static implicit operator IgnoreDefaultArgs(bool value) => new(value);

    public static implicit operator IgnoreDefaultArgs(List<string> value) =>
        new((IReadOnlyList<string>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException(
                "Data did not match any variant of IgnoreDefaultArgs"
            );
        }
    }

    public virtual bool Equals(IgnoreDefaultArgs? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class IgnoreDefaultArgsConverter : JsonConverter<IgnoreDefaultArgs>
{
    public override IgnoreDefaultArgs? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        IgnoreDefaultArgs value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Proxy, ProxyFromRaw>))]
public sealed record class Proxy : ModelBase
{
    public required string Server
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "server"); }
        init { ModelBase.Set(this._rawData, "server", value); }
    }

    public string? Bypass
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "bypass"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "bypass", value);
        }
    }

    public string? Password
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "password"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "password", value);
        }
    }

    public string? Username
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "username"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Server;
        _ = this.Bypass;
        _ = this.Password;
        _ = this.Username;
    }

    public Proxy() { }

    public Proxy(Proxy proxy)
        : base(proxy) { }

    public Proxy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Proxy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProxyFromRaw.FromRawUnchecked"/>
    public static Proxy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Proxy(string server)
        : this()
    {
        this.Server = server;
    }
}

class ProxyFromRaw : IFromRaw<Proxy>
{
    /// <inheritdoc/>
    public Proxy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Proxy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Viewport, ViewportFromRaw>))]
public sealed record class Viewport : ModelBase
{
    public required double Height
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "height"); }
        init { ModelBase.Set(this._rawData, "height", value); }
    }

    public required double Width
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "width"); }
        init { ModelBase.Set(this._rawData, "width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
    }

    public Viewport() { }

    public Viewport(Viewport viewport)
        : base(viewport) { }

    public Viewport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Viewport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewportFromRaw.FromRawUnchecked"/>
    public static Viewport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewportFromRaw : IFromRaw<Viewport>
{
    /// <inheritdoc/>
    public Viewport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Viewport.FromRawUnchecked(rawData);
}

/// <summary>
/// Browser type to use
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Local,
    Browserbase,
}

sealed class TypeConverter : JsonConverter<global::Stagehand.Models.Sessions.Type>
{
    public override global::Stagehand.Models.Sessions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local" => global::Stagehand.Models.Sessions.Type.Local,
            "browserbase" => global::Stagehand.Models.Sessions.Type.Browserbase,
            _ => (global::Stagehand.Models.Sessions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stagehand.Models.Sessions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stagehand.Models.Sessions.Type.Local => "local",
                global::Stagehand.Models.Sessions.Type.Browserbase => "browserbase",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<BrowserbaseSessionCreateParams, BrowserbaseSessionCreateParamsFromRaw>)
)]
public sealed record class BrowserbaseSessionCreateParams : ModelBase
{
    public BrowserSettings? BrowserSettings
    {
        get { return ModelBase.GetNullableClass<BrowserSettings>(this.RawData, "browserSettings"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "browserSettings", value);
        }
    }

    public string? ExtensionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "extensionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "extensionId", value);
        }
    }

    public bool? KeepAlive
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "keepAlive"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "keepAlive", value);
        }
    }

    public string? ProjectID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "projectId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "projectId", value);
        }
    }

    public Proxies? Proxies
    {
        get { return ModelBase.GetNullableClass<Proxies>(this.RawData, "proxies"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "proxies", value);
        }
    }

    public ApiEnum<string, Region>? Region
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Region>>(this.RawData, "region"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "region", value);
        }
    }

    public double? Timeout
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "timeout"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "timeout", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? UserMetadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "userMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "userMetadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BrowserSettings?.Validate();
        _ = this.ExtensionID;
        _ = this.KeepAlive;
        _ = this.ProjectID;
        this.Proxies?.Validate();
        this.Region?.Validate();
        _ = this.Timeout;
        _ = this.UserMetadata;
    }

    public BrowserbaseSessionCreateParams() { }

    public BrowserbaseSessionCreateParams(
        BrowserbaseSessionCreateParams browserbaseSessionCreateParams
    )
        : base(browserbaseSessionCreateParams) { }

    public BrowserbaseSessionCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserbaseSessionCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserbaseSessionCreateParamsFromRaw.FromRawUnchecked"/>
    public static BrowserbaseSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserbaseSessionCreateParamsFromRaw : IFromRaw<BrowserbaseSessionCreateParams>
{
    /// <inheritdoc/>
    public BrowserbaseSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserbaseSessionCreateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<BrowserSettings, BrowserSettingsFromRaw>))]
public sealed record class BrowserSettings : ModelBase
{
    public bool? AdvancedStealth
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "advancedStealth"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "advancedStealth", value);
        }
    }

    public bool? BlockAds
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "blockAds"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "blockAds", value);
        }
    }

    public Context? Context
    {
        get { return ModelBase.GetNullableClass<Context>(this.RawData, "context"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "context", value);
        }
    }

    public string? ExtensionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "extensionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "extensionId", value);
        }
    }

    public Fingerprint? Fingerprint
    {
        get { return ModelBase.GetNullableClass<Fingerprint>(this.RawData, "fingerprint"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "fingerprint", value);
        }
    }

    public bool? LogSession
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "logSession"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "logSession", value);
        }
    }

    public bool? RecordSession
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "recordSession"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "recordSession", value);
        }
    }

    public bool? SolveCaptchas
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "solveCaptchas"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "solveCaptchas", value);
        }
    }

    public BrowserSettingsViewport? Viewport
    {
        get
        {
            return ModelBase.GetNullableClass<BrowserSettingsViewport>(this.RawData, "viewport");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "viewport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdvancedStealth;
        _ = this.BlockAds;
        this.Context?.Validate();
        _ = this.ExtensionID;
        this.Fingerprint?.Validate();
        _ = this.LogSession;
        _ = this.RecordSession;
        _ = this.SolveCaptchas;
        this.Viewport?.Validate();
    }

    public BrowserSettings() { }

    public BrowserSettings(BrowserSettings browserSettings)
        : base(browserSettings) { }

    public BrowserSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserSettingsFromRaw.FromRawUnchecked"/>
    public static BrowserSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserSettingsFromRaw : IFromRaw<BrowserSettings>
{
    /// <inheritdoc/>
    public BrowserSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserSettings.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Context, ContextFromRaw>))]
public sealed record class Context : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public bool? Persist
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "persist"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "persist", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Persist;
    }

    public Context() { }

    public Context(Context context)
        : base(context) { }

    public Context(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Context(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContextFromRaw.FromRawUnchecked"/>
    public static Context FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Context(string id)
        : this()
    {
        this.ID = id;
    }
}

class ContextFromRaw : IFromRaw<Context>
{
    /// <inheritdoc/>
    public Context FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Context.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Fingerprint, FingerprintFromRaw>))]
public sealed record class Fingerprint : ModelBase
{
    public IReadOnlyList<ApiEnum<string, FingerprintBrowser>>? Browsers
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, FingerprintBrowser>>>(
                this.RawData,
                "browsers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "browsers", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, Device>>? Devices
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, Device>>>(
                this.RawData,
                "devices"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "devices", value);
        }
    }

    public ApiEnum<string, HTTPVersion>? HTTPVersion
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, HTTPVersion>>(
                this.RawData,
                "httpVersion"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "httpVersion", value);
        }
    }

    public IReadOnlyList<string>? Locales
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "locales"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "locales", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, OperatingSystem>>? OperatingSystems
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, OperatingSystem>>>(
                this.RawData,
                "operatingSystems"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "operatingSystems", value);
        }
    }

    public Screen? Screen
    {
        get { return ModelBase.GetNullableClass<Screen>(this.RawData, "screen"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "screen", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Browsers ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Devices ?? [])
        {
            item.Validate();
        }
        this.HTTPVersion?.Validate();
        _ = this.Locales;
        foreach (var item in this.OperatingSystems ?? [])
        {
            item.Validate();
        }
        this.Screen?.Validate();
    }

    public Fingerprint() { }

    public Fingerprint(Fingerprint fingerprint)
        : base(fingerprint) { }

    public Fingerprint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Fingerprint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FingerprintFromRaw.FromRawUnchecked"/>
    public static Fingerprint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FingerprintFromRaw : IFromRaw<Fingerprint>
{
    /// <inheritdoc/>
    public Fingerprint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Fingerprint.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FingerprintBrowserConverter))]
public enum FingerprintBrowser
{
    Chrome,
    Edge,
    Firefox,
    Safari,
}

sealed class FingerprintBrowserConverter : JsonConverter<FingerprintBrowser>
{
    public override FingerprintBrowser Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chrome" => FingerprintBrowser.Chrome,
            "edge" => FingerprintBrowser.Edge,
            "firefox" => FingerprintBrowser.Firefox,
            "safari" => FingerprintBrowser.Safari,
            _ => (FingerprintBrowser)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FingerprintBrowser value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FingerprintBrowser.Chrome => "chrome",
                FingerprintBrowser.Edge => "edge",
                FingerprintBrowser.Firefox => "firefox",
                FingerprintBrowser.Safari => "safari",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DeviceConverter))]
public enum Device
{
    Desktop,
    Mobile,
}

sealed class DeviceConverter : JsonConverter<Device>
{
    public override Device Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "desktop" => Device.Desktop,
            "mobile" => Device.Mobile,
            _ => (Device)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Device value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Device.Desktop => "desktop",
                Device.Mobile => "mobile",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(HTTPVersionConverter))]
public enum HTTPVersion
{
    V1,
    V2,
}

sealed class HTTPVersionConverter : JsonConverter<HTTPVersion>
{
    public override HTTPVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1" => HTTPVersion.V1,
            "2" => HTTPVersion.V2,
            _ => (HTTPVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HTTPVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HTTPVersion.V1 => "1",
                HTTPVersion.V2 => "2",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OperatingSystemConverter))]
public enum OperatingSystem
{
    Android,
    Ios,
    Linux,
    Macos,
    Windows,
}

sealed class OperatingSystemConverter : JsonConverter<OperatingSystem>
{
    public override OperatingSystem Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "android" => OperatingSystem.Android,
            "ios" => OperatingSystem.Ios,
            "linux" => OperatingSystem.Linux,
            "macos" => OperatingSystem.Macos,
            "windows" => OperatingSystem.Windows,
            _ => (OperatingSystem)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OperatingSystem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OperatingSystem.Android => "android",
                OperatingSystem.Ios => "ios",
                OperatingSystem.Linux => "linux",
                OperatingSystem.Macos => "macos",
                OperatingSystem.Windows => "windows",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Screen, ScreenFromRaw>))]
public sealed record class Screen : ModelBase
{
    public double? MaxHeight
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "maxHeight"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "maxHeight", value);
        }
    }

    public double? MaxWidth
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "maxWidth"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "maxWidth", value);
        }
    }

    public double? MinHeight
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "minHeight"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "minHeight", value);
        }
    }

    public double? MinWidth
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "minWidth"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "minWidth", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxHeight;
        _ = this.MaxWidth;
        _ = this.MinHeight;
        _ = this.MinWidth;
    }

    public Screen() { }

    public Screen(Screen screen)
        : base(screen) { }

    public Screen(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Screen(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScreenFromRaw.FromRawUnchecked"/>
    public static Screen FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScreenFromRaw : IFromRaw<Screen>
{
    /// <inheritdoc/>
    public Screen FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Screen.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<BrowserSettingsViewport, BrowserSettingsViewportFromRaw>))]
public sealed record class BrowserSettingsViewport : ModelBase
{
    public double? Height
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "height"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "height", value);
        }
    }

    public double? Width
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "width"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
    }

    public BrowserSettingsViewport() { }

    public BrowserSettingsViewport(BrowserSettingsViewport browserSettingsViewport)
        : base(browserSettingsViewport) { }

    public BrowserSettingsViewport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserSettingsViewport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserSettingsViewportFromRaw.FromRawUnchecked"/>
    public static BrowserSettingsViewport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserSettingsViewportFromRaw : IFromRaw<BrowserSettingsViewport>
{
    /// <inheritdoc/>
    public BrowserSettingsViewport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserSettingsViewport.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProxiesConverter))]
public record class Proxies
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Proxies(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Proxies(IReadOnlyList<ProxyConfig> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public Proxies(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<ProxyConfig>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProxyConfigList(out var value)) {
    ///     // `value` is of type `IReadOnlyList<ProxyConfig>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickProxyConfigList([NotNullWhen(true)] out IReadOnlyList<ProxyConfig>? value)
    {
        value = this.Value as IReadOnlyList<ProxyConfig>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (bool value) => {...},
    ///     (IReadOnlyList<ProxyConfig> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<bool> @bool,
        System::Action<IReadOnlyList<ProxyConfig>> proxyConfigList
    )
    {
        switch (this.Value)
        {
            case bool value:
                @bool(value);
                break;
            case List<ProxyConfig> value:
                proxyConfigList(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of Proxies"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (bool value) => {...},
    ///     (IReadOnlyList<ProxyConfig> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<bool, T> @bool,
        System::Func<IReadOnlyList<ProxyConfig>, T> proxyConfigList
    )
    {
        return this.Value switch
        {
            bool value => @bool(value),
            IReadOnlyList<ProxyConfig> value => proxyConfigList(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of Proxies"
            ),
        };
    }

    public static implicit operator Proxies(bool value) => new(value);

    public static implicit operator Proxies(List<ProxyConfig> value) =>
        new((IReadOnlyList<ProxyConfig>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException("Data did not match any variant of Proxies");
        }
    }

    public virtual bool Equals(Proxies? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ProxiesConverter : JsonConverter<Proxies>
{
    public override Proxies? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ProxyConfig>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Proxies value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ProxyConfigConverter))]
public record class ProxyConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(browserbase: (x) => x.Type, external: (x) => x.Type); }
    }

    public string? DomainPattern
    {
        get
        {
            return Match<string?>(
                browserbase: (x) => x.DomainPattern,
                external: (x) => x.DomainPattern
            );
        }
    }

    public ProxyConfig(Browserbase value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ProxyConfig(External value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ProxyConfig(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Browserbase"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBrowserbase(out var value)) {
    ///     // `value` is of type `Browserbase`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBrowserbase([NotNullWhen(true)] out Browserbase? value)
    {
        value = this.Value as Browserbase;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="External"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExternal(out var value)) {
    ///     // `value` is of type `External`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExternal([NotNullWhen(true)] out External? value)
    {
        value = this.Value as External;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Browserbase value) => {...},
    ///     (External value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<Browserbase> browserbase, System::Action<External> external)
    {
        switch (this.Value)
        {
            case Browserbase value:
                browserbase(value);
                break;
            case External value:
                external(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ProxyConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Browserbase value) => {...},
    ///     (External value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Browserbase, T> browserbase, System::Func<External, T> external)
    {
        return this.Value switch
        {
            Browserbase value => browserbase(value),
            External value => external(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ProxyConfig"
            ),
        };
    }

    public static implicit operator ProxyConfig(Browserbase value) => new(value);

    public static implicit operator ProxyConfig(External value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException(
                "Data did not match any variant of ProxyConfig"
            );
        }
        this.Switch((browserbase) => browserbase.Validate(), (external) => external.Validate());
    }

    public virtual bool Equals(ProxyConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ProxyConfigConverter : JsonConverter<ProxyConfig>
{
    public override ProxyConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "browserbase":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Browserbase>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is StagehandInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "external":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<External>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is StagehandInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ProxyConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProxyConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Browserbase, BrowserbaseFromRaw>))]
public sealed record class Browserbase : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public string? DomainPattern
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "domainPattern"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "domainPattern", value);
        }
    }

    public Geolocation? Geolocation
    {
        get { return ModelBase.GetNullableClass<Geolocation>(this.RawData, "geolocation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "geolocation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"browserbase\"")
            )
        )
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        _ = this.DomainPattern;
        this.Geolocation?.Validate();
    }

    public Browserbase()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"browserbase\"");
    }

    public Browserbase(Browserbase browserbase)
        : base(browserbase) { }

    public Browserbase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"browserbase\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browserbase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserbaseFromRaw.FromRawUnchecked"/>
    public static Browserbase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserbaseFromRaw : IFromRaw<Browserbase>
{
    /// <inheritdoc/>
    public Browserbase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browserbase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Geolocation, GeolocationFromRaw>))]
public sealed record class Geolocation : ModelBase
{
    public required string Country
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "country"); }
        init { ModelBase.Set(this._rawData, "country", value); }
    }

    public string? City
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "city"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "city", value);
        }
    }

    public string? State
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.City;
        _ = this.State;
    }

    public Geolocation() { }

    public Geolocation(Geolocation geolocation)
        : base(geolocation) { }

    public Geolocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Geolocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeolocationFromRaw.FromRawUnchecked"/>
    public static Geolocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Geolocation(string country)
        : this()
    {
        this.Country = country;
    }
}

class GeolocationFromRaw : IFromRaw<Geolocation>
{
    /// <inheritdoc/>
    public Geolocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Geolocation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<External, ExternalFromRaw>))]
public sealed record class External : ModelBase
{
    public required string Server
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "server"); }
        init { ModelBase.Set(this._rawData, "server", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public string? DomainPattern
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "domainPattern"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "domainPattern", value);
        }
    }

    public string? Password
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "password"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "password", value);
        }
    }

    public string? Username
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "username"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Server;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"external\"")
            )
        )
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        _ = this.DomainPattern;
        _ = this.Password;
        _ = this.Username;
    }

    public External()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"external\"");
    }

    public External(External external)
        : base(external) { }

    public External(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"external\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    External(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalFromRaw.FromRawUnchecked"/>
    public static External FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public External(string server)
        : this()
    {
        this.Server = server;
    }
}

class ExternalFromRaw : IFromRaw<External>
{
    /// <inheritdoc/>
    public External FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        External.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RegionConverter))]
public enum Region
{
    UsWest2,
    UsEast1,
    EuCentral1,
    ApSoutheast1,
}

sealed class RegionConverter : JsonConverter<Region>
{
    public override Region Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-west-2" => Region.UsWest2,
            "us-east-1" => Region.UsEast1,
            "eu-central-1" => Region.EuCentral1,
            "ap-southeast-1" => Region.ApSoutheast1,
            _ => (Region)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Region value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Region.UsWest2 => "us-west-2",
                Region.UsEast1 => "us-east-1",
                Region.EuCentral1 => "eu-central-1",
                Region.ApSoutheast1 => "ap-southeast-1",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Client SDK language
/// </summary>
[JsonConverter(typeof(SessionStartParamsXLanguageConverter))]
public enum SessionStartParamsXLanguage
{
    Typescript,
    Python,
    Playground,
}

sealed class SessionStartParamsXLanguageConverter : JsonConverter<SessionStartParamsXLanguage>
{
    public override SessionStartParamsXLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "typescript" => SessionStartParamsXLanguage.Typescript,
            "python" => SessionStartParamsXLanguage.Python,
            "playground" => SessionStartParamsXLanguage.Playground,
            _ => (SessionStartParamsXLanguage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionStartParamsXLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionStartParamsXLanguage.Typescript => "typescript",
                SessionStartParamsXLanguage.Python => "python",
                SessionStartParamsXLanguage.Playground => "playground",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether to stream the response via SSE
/// </summary>
[JsonConverter(typeof(SessionStartParamsXStreamResponseConverter))]
public enum SessionStartParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionStartParamsXStreamResponseConverter
    : JsonConverter<SessionStartParamsXStreamResponse>
{
    public override SessionStartParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionStartParamsXStreamResponse.True,
            "false" => SessionStartParamsXStreamResponse.False,
            _ => (SessionStartParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionStartParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionStartParamsXStreamResponse.True => "true",
                SessionStartParamsXStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
