using System.Collections.Frozen;
using System.Collections.Generic;
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
/// Navigates the browser to the specified URL.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionNavigateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// URL to navigate to
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("url");
        }
        init { this._rawBodyData.Set("url", value); }
    }

    /// <summary>
    /// Target frame ID for the navigation
    /// </summary>
    public string? FrameID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("frameId");
        }
        init { this._rawBodyData.Set("frameId", value); }
    }

    public SessionNavigateParamsOptions? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SessionNavigateParamsOptions>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("options", value);
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public bool? StreamResponse
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("streamResponse");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("streamResponse", value);
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public ApiEnum<string, SessionNavigateParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<
                ApiEnum<string, SessionNavigateParamsXStreamResponse>
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

    public SessionNavigateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionNavigateParams(SessionNavigateParams sessionNavigateParams)
        : base(sessionNavigateParams)
    {
        this.ID = sessionNavigateParams.ID;

        this._rawBodyData = new(sessionNavigateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SessionNavigateParams(
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
    SessionNavigateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SessionNavigateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/sessions/{0}/navigate", this.ID)
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

[JsonConverter(
    typeof(JsonModelConverter<SessionNavigateParamsOptions, SessionNavigateParamsOptionsFromRaw>)
)]
public sealed record class SessionNavigateParamsOptions : JsonModel
{
    /// <summary>
    /// Referer header to send with the request
    /// </summary>
    public string? Referer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("referer", value);
        }
    }

    /// <summary>
    /// Timeout in ms for the navigation
    /// </summary>
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

    /// <summary>
    /// When to consider navigation complete
    /// </summary>
    public ApiEnum<string, WaitUntil>? WaitUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WaitUntil>>("waitUntil");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("waitUntil", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Referer;
        _ = this.Timeout;
        this.WaitUntil?.Validate();
    }

    public SessionNavigateParamsOptions() { }

    public SessionNavigateParamsOptions(SessionNavigateParamsOptions sessionNavigateParamsOptions)
        : base(sessionNavigateParamsOptions) { }

    public SessionNavigateParamsOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateParamsOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class SessionNavigateParamsOptionsFromRaw : IFromRawJson<SessionNavigateParamsOptions>
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
        System::Type typeToConvert,
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
        System::Type typeToConvert,
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
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
