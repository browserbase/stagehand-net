using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using StagehandSDK.Core;
using StagehandSDK.Exceptions;

namespace StagehandSDK.Models.Sessions;

/// <summary>
/// Navigates the browser to the specified URL and waits for page load.
/// </summary>
public sealed record class SessionNavigateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SessionID { get; init; }

    /// <summary>
    /// URL to navigate to
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "url"); }
        init { ModelBase.Set(this._rawBodyData, "url", value); }
    }

    public string? FrameID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "frameId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "frameId", value);
        }
    }

    public SessionNavigateParamsOptions? Options
    {
        get
        {
            return ModelBase.GetNullableClass<SessionNavigateParamsOptions>(
                this.RawBodyData,
                "options"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "options", value);
        }
    }

    public ApiEnum<string, SessionNavigateParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, SessionNavigateParamsXStreamResponse>
            >(this.RawHeaderData, "x-stream-response");
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

    public SessionNavigateParams() { }

    public SessionNavigateParams(SessionNavigateParams sessionNavigateParams)
        : base(sessionNavigateParams)
    {
        this._rawBodyData = [.. sessionNavigateParams._rawBodyData];
    }

    public SessionNavigateParams(
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
    SessionNavigateParams(
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
    public static SessionNavigateParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/sessions/{0}/navigate", this.SessionID)
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

[JsonConverter(
    typeof(ModelConverter<SessionNavigateParamsOptions, SessionNavigateParamsOptionsFromRaw>)
)]
public sealed record class SessionNavigateParamsOptions : ModelBase
{
    /// <summary>
    /// When to consider navigation complete
    /// </summary>
    public ApiEnum<string, WaitUntil>? WaitUntil
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, WaitUntil>>(
                this.RawData,
                "waitUntil"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "waitUntil", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.WaitUntil?.Validate();
    }

    public SessionNavigateParamsOptions() { }

    public SessionNavigateParamsOptions(SessionNavigateParamsOptions sessionNavigateParamsOptions)
        : base(sessionNavigateParamsOptions) { }

    public SessionNavigateParamsOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateParamsOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionNavigateParamsOptionsFromRaw.FromRawUnchecked"/>
    public static SessionNavigateParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionNavigateParamsOptionsFromRaw : IFromRaw<SessionNavigateParamsOptions>
{
    /// <inheritdoc/>
    public SessionNavigateParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionNavigateParamsOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// When to consider navigation complete
/// </summary>
[JsonConverter(typeof(WaitUntilConverter))]
public enum WaitUntil
{
    Load,
    Domcontentloaded,
    Networkidle,
}

sealed class WaitUntilConverter : JsonConverter<WaitUntil>
{
    public override WaitUntil Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "load" => WaitUntil.Load,
            "domcontentloaded" => WaitUntil.Domcontentloaded,
            "networkidle" => WaitUntil.Networkidle,
            _ => (WaitUntil)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WaitUntil value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WaitUntil.Load => "load",
                WaitUntil.Domcontentloaded => "domcontentloaded",
                WaitUntil.Networkidle => "networkidle",
                _ => throw new BrowserbaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SessionNavigateParamsXStreamResponseConverter))]
public enum SessionNavigateParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionNavigateParamsXStreamResponseConverter
    : JsonConverter<SessionNavigateParamsXStreamResponse>
{
    public override SessionNavigateParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionNavigateParamsXStreamResponse.True,
            "false" => SessionNavigateParamsXStreamResponse.False,
            _ => (SessionNavigateParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionNavigateParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionNavigateParamsXStreamResponse.True => "true",
                SessionNavigateParamsXStreamResponse.False => "false",
                _ => throw new BrowserbaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
