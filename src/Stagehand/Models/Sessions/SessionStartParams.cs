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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionStartParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Model name to use for AI operations
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("modelName");
        }
        init { this._rawBodyData.Set("modelName", value); }
    }

    /// <summary>
    /// Timeout in ms for act operations (deprecated, v2 only)
    /// </summary>
    public double? ActTimeoutMs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("actTimeoutMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("actTimeoutMs", value);
        }
    }

    public Browser? Browser
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Browser>("browser");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("browser", value);
        }
    }

    public BrowserbaseSessionCreateParams? BrowserbaseSessionCreateParams
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BrowserbaseSessionCreateParams>(
                "browserbaseSessionCreateParams"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("browserbaseSessionCreateParams", value);
        }
    }

    /// <summary>
    /// Existing Browserbase session ID to resume
    /// </summary>
    public string? BrowserbaseSessionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("browserbaseSessionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("browserbaseSessionID", value);
        }
    }

    /// <summary>
    /// Timeout in ms to wait for DOM to settle
    /// </summary>
    public double? DomSettleTimeoutMs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("domSettleTimeoutMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("domSettleTimeoutMs", value);
        }
    }

    public bool? Experimental
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("experimental");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("experimental", value);
        }
    }

    /// <summary>
    /// Enable self-healing for failed actions
    /// </summary>
    public bool? SelfHeal
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("selfHeal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("selfHeal", value);
        }
    }

    /// <summary>
    /// Custom system prompt for AI operations
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("systemPrompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("systemPrompt", value);
        }
    }

    /// <summary>
    /// Logging verbosity level (0=quiet, 1=normal, 2=debug)
    /// </summary>
    public ApiEnum<double, Verbose>? Verbose
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<double, Verbose>>("verbose");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("verbose", value);
        }
    }

    /// <summary>
    /// Wait for captcha solves (deprecated, v2 only)
    /// </summary>
    public bool? WaitForCaptchaSolves
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("waitForCaptchaSolves");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("waitForCaptchaSolves", value);
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public ApiEnum<string, SessionStartParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<
                ApiEnum<string, SessionStartParamsXStreamResponse>
            >("x-stream-response");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-stream-response", value);
        }
    }

    public SessionStartParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionStartParams(SessionStartParams sessionStartParams)
        : base(sessionStartParams)
    {
        this._rawBodyData = new(sessionStartParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SessionStartParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStartParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SessionStartParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<Browser, BrowserFromRaw>))]
public sealed record class Browser : JsonModel
{
    /// <summary>
    /// Chrome DevTools Protocol URL for connecting to existing browser
    /// </summary>
    public string? CdpUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cdpUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cdpUrl", value);
        }
    }

    public LaunchOptions? LaunchOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LaunchOptions>("launchOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("launchOptions", value);
        }
    }

    /// <summary>
    /// Browser type to use
    /// </summary>
    public ApiEnum<string, global::Stagehand.Models.Sessions.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Stagehand.Models.Sessions.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CdpUrl;
        this.LaunchOptions?.Validate();
        this.Type?.Validate();
    }

    public Browser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Browser(Browser browser)
        : base(browser) { }
#pragma warning restore CS8618

    public Browser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFromRaw.FromRawUnchecked"/>
    public static Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFromRaw : IFromRawJson<Browser>
{
    /// <inheritdoc/>
    public Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browser.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LaunchOptions, LaunchOptionsFromRaw>))]
public sealed record class LaunchOptions : JsonModel
{
    public bool? AcceptDownloads
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("acceptDownloads");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("acceptDownloads", value);
        }
    }

    public IReadOnlyList<string>? Args
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("args");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "args",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyDictionary<string, string>? CdpHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("cdpHeaders");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "cdpHeaders",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? CdpUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cdpUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cdpUrl", value);
        }
    }

    public bool? ChromiumSandbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("chromiumSandbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chromiumSandbox", value);
        }
    }

    public double? ConnectTimeoutMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("connectTimeoutMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectTimeoutMs", value);
        }
    }

    public double? DeviceScaleFactor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("deviceScaleFactor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deviceScaleFactor", value);
        }
    }

    public bool? Devtools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("devtools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("devtools", value);
        }
    }

    public string? DownloadsPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("downloadsPath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("downloadsPath", value);
        }
    }

    public string? ExecutablePath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("executablePath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("executablePath", value);
        }
    }

    public bool? HasTouch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasTouch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasTouch", value);
        }
    }

    public bool? Headless
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("headless");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headless", value);
        }
    }

    public IgnoreDefaultArgs? IgnoreDefaultArgs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IgnoreDefaultArgs>("ignoreDefaultArgs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ignoreDefaultArgs", value);
        }
    }

    public bool? IgnoreHttpsErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ignoreHTTPSErrors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ignoreHTTPSErrors", value);
        }
    }

    public string? Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locale", value);
        }
    }

    public double? Port
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("port");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("port", value);
        }
    }

    public bool? PreserveUserDataDir
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserveUserDataDir");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preserveUserDataDir", value);
        }
    }

    public Proxy? Proxy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Proxy>("proxy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("proxy", value);
        }
    }

    public string? UserDataDir
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userDataDir");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userDataDir", value);
        }
    }

    public Viewport? Viewport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Viewport>("viewport");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("viewport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptDownloads;
        _ = this.Args;
        _ = this.CdpHeaders;
        _ = this.CdpUrl;
        _ = this.ChromiumSandbox;
        _ = this.ConnectTimeoutMs;
        _ = this.DeviceScaleFactor;
        _ = this.Devtools;
        _ = this.DownloadsPath;
        _ = this.ExecutablePath;
        _ = this.HasTouch;
        _ = this.Headless;
        this.IgnoreDefaultArgs?.Validate();
        _ = this.IgnoreHttpsErrors;
        _ = this.Locale;
        _ = this.Port;
        _ = this.PreserveUserDataDir;
        this.Proxy?.Validate();
        _ = this.UserDataDir;
        this.Viewport?.Validate();
    }

    public LaunchOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LaunchOptions(LaunchOptions launchOptions)
        : base(launchOptions) { }
#pragma warning restore CS8618

    public LaunchOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LaunchOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LaunchOptionsFromRaw.FromRawUnchecked"/>
    public static LaunchOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LaunchOptionsFromRaw : IFromRawJson<LaunchOptions>
{
    /// <inheritdoc/>
    public LaunchOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LaunchOptions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IgnoreDefaultArgsConverter))]
public record class IgnoreDefaultArgs : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IgnoreDefaultArgs(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IgnoreDefaultArgs(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public IgnoreDefaultArgs(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
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
            case IReadOnlyList<string> value:
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException(
                "Data did not match any variant of IgnoreDefaultArgs"
            );
        }
    }

    public virtual bool Equals(IgnoreDefaultArgs? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            bool _ => 0,
            IReadOnlyList<string> _ => 1,
            _ => -1,
        };
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
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

[JsonConverter(typeof(JsonModelConverter<Proxy, ProxyFromRaw>))]
public sealed record class Proxy : JsonModel
{
    public required string Server
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server");
        }
        init { this._rawData.Set("server", value); }
    }

    public string? Bypass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bypass");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bypass", value);
        }
    }

    public string? Password
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("password");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("password", value);
        }
    }

    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Proxy(Proxy proxy)
        : base(proxy) { }
#pragma warning restore CS8618

    public Proxy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Proxy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ProxyFromRaw : IFromRawJson<Proxy>
{
    /// <inheritdoc/>
    public Proxy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Proxy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Viewport, ViewportFromRaw>))]
public sealed record class Viewport : JsonModel
{
    public required double Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    public required double Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
    }

    public Viewport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Viewport(Viewport viewport)
        : base(viewport) { }
#pragma warning restore CS8618

    public Viewport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Viewport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ViewportFromRaw.FromRawUnchecked"/>
    public static Viewport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ViewportFromRaw : IFromRawJson<Viewport>
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
    typeof(JsonModelConverter<
        BrowserbaseSessionCreateParams,
        BrowserbaseSessionCreateParamsFromRaw
    >)
)]
public sealed record class BrowserbaseSessionCreateParams : JsonModel
{
    public BrowserSettings? BrowserSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserSettings>("browserSettings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("browserSettings", value);
        }
    }

    public string? ExtensionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("extensionId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extensionId", value);
        }
    }

    public bool? KeepAlive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("keepAlive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("keepAlive", value);
        }
    }

    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("projectId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("projectId", value);
        }
    }

    public Proxies? Proxies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Proxies>("proxies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("proxies", value);
        }
    }

    public ApiEnum<string, Region>? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Region>>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    public double? Timeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("timeout");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeout", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? UserMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "userMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "userMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserbaseSessionCreateParams(
        BrowserbaseSessionCreateParams browserbaseSessionCreateParams
    )
        : base(browserbaseSessionCreateParams) { }
#pragma warning restore CS8618

    public BrowserbaseSessionCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserbaseSessionCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BrowserbaseSessionCreateParamsFromRaw : IFromRawJson<BrowserbaseSessionCreateParams>
{
    /// <inheritdoc/>
    public BrowserbaseSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserbaseSessionCreateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BrowserSettings, BrowserSettingsFromRaw>))]
public sealed record class BrowserSettings : JsonModel
{
    public bool? AdvancedStealth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("advancedStealth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("advancedStealth", value);
        }
    }

    public bool? BlockAds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("blockAds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blockAds", value);
        }
    }

    public Context? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Context>("context");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("context", value);
        }
    }

    public string? ExtensionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("extensionId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extensionId", value);
        }
    }

    public Fingerprint? Fingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Fingerprint>("fingerprint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fingerprint", value);
        }
    }

    public bool? LogSession
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("logSession");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logSession", value);
        }
    }

    public bool? RecordSession
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("recordSession");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recordSession", value);
        }
    }

    public bool? SolveCaptchas
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("solveCaptchas");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("solveCaptchas", value);
        }
    }

    public BrowserSettingsViewport? Viewport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserSettingsViewport>("viewport");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("viewport", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserSettings(BrowserSettings browserSettings)
        : base(browserSettings) { }
#pragma warning restore CS8618

    public BrowserSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserSettingsFromRaw.FromRawUnchecked"/>
    public static BrowserSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserSettingsFromRaw : IFromRawJson<BrowserSettings>
{
    /// <inheritdoc/>
    public BrowserSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserSettings.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Context, ContextFromRaw>))]
public sealed record class Context : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public bool? Persist
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("persist");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("persist", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Persist;
    }

    public Context() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Context(Context context)
        : base(context) { }
#pragma warning restore CS8618

    public Context(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Context(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ContextFromRaw : IFromRawJson<Context>
{
    /// <inheritdoc/>
    public Context FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Context.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Fingerprint, FingerprintFromRaw>))]
public sealed record class Fingerprint : JsonModel
{
    public IReadOnlyList<ApiEnum<string, FingerprintBrowser>>? Browsers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, FingerprintBrowser>>
            >("browsers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, FingerprintBrowser>>?>(
                "browsers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ApiEnum<string, Device>>? Devices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Device>>>(
                "devices"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Device>>?>(
                "devices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, HttpVersion>? HttpVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HttpVersion>>("httpVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("httpVersion", value);
        }
    }

    public IReadOnlyList<string>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("locales");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "locales",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ApiEnum<string, OperatingSystem>>? OperatingSystems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, OperatingSystem>>
            >("operatingSystems");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, OperatingSystem>>?>(
                "operatingSystems",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Screen? Screen
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Screen>("screen");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("screen", value);
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
        this.HttpVersion?.Validate();
        _ = this.Locales;
        foreach (var item in this.OperatingSystems ?? [])
        {
            item.Validate();
        }
        this.Screen?.Validate();
    }

    public Fingerprint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Fingerprint(Fingerprint fingerprint)
        : base(fingerprint) { }
#pragma warning restore CS8618

    public Fingerprint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Fingerprint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FingerprintFromRaw.FromRawUnchecked"/>
    public static Fingerprint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FingerprintFromRaw : IFromRawJson<Fingerprint>
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

[JsonConverter(typeof(HttpVersionConverter))]
public enum HttpVersion
{
    V1,
    V2,
}

sealed class HttpVersionConverter : JsonConverter<HttpVersion>
{
    public override HttpVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1" => HttpVersion.V1,
            "2" => HttpVersion.V2,
            _ => (HttpVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HttpVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HttpVersion.V1 => "1",
                HttpVersion.V2 => "2",
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

[JsonConverter(typeof(JsonModelConverter<Screen, ScreenFromRaw>))]
public sealed record class Screen : JsonModel
{
    public double? MaxHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxHeight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxHeight", value);
        }
    }

    public double? MaxWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxWidth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxWidth", value);
        }
    }

    public double? MinHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("minHeight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minHeight", value);
        }
    }

    public double? MinWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("minWidth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minWidth", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Screen(Screen screen)
        : base(screen) { }
#pragma warning restore CS8618

    public Screen(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Screen(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScreenFromRaw.FromRawUnchecked"/>
    public static Screen FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScreenFromRaw : IFromRawJson<Screen>
{
    /// <inheritdoc/>
    public Screen FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Screen.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BrowserSettingsViewport, BrowserSettingsViewportFromRaw>))]
public sealed record class BrowserSettingsViewport : JsonModel
{
    public double? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    public double? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
    }

    public BrowserSettingsViewport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserSettingsViewport(BrowserSettingsViewport browserSettingsViewport)
        : base(browserSettingsViewport) { }
#pragma warning restore CS8618

    public BrowserSettingsViewport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserSettingsViewport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BrowserSettingsViewportFromRaw : IFromRawJson<BrowserSettingsViewport>
{
    /// <inheritdoc/>
    public BrowserSettingsViewport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserSettingsViewport.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProxiesConverter))]
public record class Proxies : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Proxies(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Proxies(IReadOnlyList<ProxyConfig> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Proxies(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ProxyConfig</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProxyConfigList(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ProxyConfig&gt;`
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ProxyConfig&gt; value) =&gt; {...}
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
            case IReadOnlyList<ProxyConfig> value:
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;ProxyConfig&gt; value) =&gt; {...}
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException("Data did not match any variant of Proxies");
        }
        this.Switch(
            (_) => { },
            (proxyConfigList) =>
            {
                foreach (var item in proxyConfigList)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(Proxies? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            bool _ => 0,
            IReadOnlyList<ProxyConfig> _ => 1,
            _ => -1,
        };
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ProxyConfig>>(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Proxies value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ProxyConfigConverter))]
public record class ProxyConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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

    public ProxyConfig(Browserbase value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ProxyConfig(External value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ProxyConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Browserbase"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (Browserbase value) =&gt; {...},
    ///     (External value) =&gt; {...}
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (Browserbase value) =&gt; {...},
    ///     (External value) =&gt; {...}
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException(
                "Data did not match any variant of ProxyConfig"
            );
        }
        this.Switch((browserbase) => browserbase.Validate(), (external) => external.Validate());
    }

    public virtual bool Equals(ProxyConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Browserbase _ => 0,
            External _ => 1,
            _ => -1,
        };
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<Browserbase>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "external":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<External>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ProxyConfig(element);
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

[JsonConverter(typeof(JsonModelConverter<Browserbase, BrowserbaseFromRaw>))]
public sealed record class Browserbase : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? DomainPattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("domainPattern");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("domainPattern", value);
        }
    }

    public Geolocation? Geolocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geolocation>("geolocation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("geolocation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("browserbase")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        _ = this.DomainPattern;
        this.Geolocation?.Validate();
    }

    public Browserbase()
    {
        this.Type = JsonSerializer.SerializeToElement("browserbase");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Browserbase(Browserbase browserbase)
        : base(browserbase) { }
#pragma warning restore CS8618

    public Browserbase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("browserbase");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browserbase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserbaseFromRaw.FromRawUnchecked"/>
    public static Browserbase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserbaseFromRaw : IFromRawJson<Browserbase>
{
    /// <inheritdoc/>
    public Browserbase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browserbase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Geolocation, GeolocationFromRaw>))]
public sealed record class Geolocation : JsonModel
{
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Geolocation(Geolocation geolocation)
        : base(geolocation) { }
#pragma warning restore CS8618

    public Geolocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Geolocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class GeolocationFromRaw : IFromRawJson<Geolocation>
{
    /// <inheritdoc/>
    public Geolocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Geolocation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<External, ExternalFromRaw>))]
public sealed record class External : JsonModel
{
    public required string Server
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server");
        }
        init { this._rawData.Set("server", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? DomainPattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("domainPattern");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("domainPattern", value);
        }
    }

    public string? Password
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("password");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("password", value);
        }
    }

    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Server;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("external")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        _ = this.DomainPattern;
        _ = this.Password;
        _ = this.Username;
    }

    public External()
    {
        this.Type = JsonSerializer.SerializeToElement("external");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public External(External external)
        : base(external) { }
#pragma warning restore CS8618

    public External(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    External(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ExternalFromRaw : IFromRawJson<External>
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
/// Logging verbosity level (0=quiet, 1=normal, 2=debug)
/// </summary>
[JsonConverter(typeof(VerboseConverter))]
public enum Verbose
{
    V0,
    V1,
    V2,
}

sealed class VerboseConverter : JsonConverter<Verbose>
{
    public override Verbose Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<double>(ref reader, options) switch
        {
            0 => Verbose.V0,
            1 => Verbose.V1,
            2 => Verbose.V2,
            _ => (Verbose)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Verbose value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Verbose.V0 => 0,
                Verbose.V1 => 1,
                Verbose.V2 => 2,
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
