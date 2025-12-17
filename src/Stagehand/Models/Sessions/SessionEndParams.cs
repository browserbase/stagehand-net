using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Terminates the browser session and releases all associated resources.
/// </summary>
public sealed record class SessionEndParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Client SDK language
    /// </summary>
    public ApiEnum<string, SessionEndParamsXLanguage>? XLanguage
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SessionEndParamsXLanguage>>(
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
    public ApiEnum<string, SessionEndParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SessionEndParamsXStreamResponse>>(
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

    public SessionEndParams() { }

    public SessionEndParams(SessionEndParams sessionEndParams)
        : base(sessionEndParams) { }

    public SessionEndParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionEndParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SessionEndParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/sessions/{0}/end", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
/// Client SDK language
/// </summary>
[JsonConverter(typeof(SessionEndParamsXLanguageConverter))]
public enum SessionEndParamsXLanguage
{
    Typescript,
    Python,
    Playground,
}

sealed class SessionEndParamsXLanguageConverter : JsonConverter<SessionEndParamsXLanguage>
{
    public override SessionEndParamsXLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "typescript" => SessionEndParamsXLanguage.Typescript,
            "python" => SessionEndParamsXLanguage.Python,
            "playground" => SessionEndParamsXLanguage.Playground,
            _ => (SessionEndParamsXLanguage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionEndParamsXLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionEndParamsXLanguage.Typescript => "typescript",
                SessionEndParamsXLanguage.Python => "python",
                SessionEndParamsXLanguage.Playground => "playground",
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
[JsonConverter(typeof(SessionEndParamsXStreamResponseConverter))]
public enum SessionEndParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionEndParamsXStreamResponseConverter
    : JsonConverter<SessionEndParamsXStreamResponse>
{
    public override SessionEndParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionEndParamsXStreamResponse.True,
            "false" => SessionEndParamsXStreamResponse.False,
            _ => (SessionEndParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionEndParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionEndParamsXStreamResponse.True => "true",
                SessionEndParamsXStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
