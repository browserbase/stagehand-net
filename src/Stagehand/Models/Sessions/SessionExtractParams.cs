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
/// Extracts structured data from the current page using AI-powered analysis.
/// </summary>
public sealed record class SessionExtractParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Target frame ID for the extraction
    /// </summary>
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

    /// <summary>
    /// Natural language instruction for what to extract
    /// </summary>
    public string? Instruction
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "instruction"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "instruction", value);
        }
    }

    public SessionExtractParamsOptions? Options
    {
        get
        {
            return ModelBase.GetNullableClass<SessionExtractParamsOptions>(
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

    /// <summary>
    /// JSON Schema defining the structure of data to extract
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Schema
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "schema"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "schema", value);
        }
    }

    /// <summary>
    /// Client SDK language
    /// </summary>
    public ApiEnum<string, SessionExtractParamsXLanguage>? XLanguage
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SessionExtractParamsXLanguage>>(
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
    public ApiEnum<string, SessionExtractParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SessionExtractParamsXStreamResponse>>(
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

    public SessionExtractParams() { }

    public SessionExtractParams(SessionExtractParams sessionExtractParams)
        : base(sessionExtractParams)
    {
        this._rawBodyData = [.. sessionExtractParams._rawBodyData];
    }

    public SessionExtractParams(
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
    SessionExtractParams(
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
    public static SessionExtractParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/sessions/{0}/extract", this.ID)
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
    typeof(ModelConverter<SessionExtractParamsOptions, SessionExtractParamsOptionsFromRaw>)
)]
public sealed record class SessionExtractParamsOptions : ModelBase
{
    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano', 'anthropic/claude-4.5-opus')
    /// </summary>
    public ModelConfig? Model
    {
        get { return ModelBase.GetNullableClass<ModelConfig>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "model", value);
        }
    }

    /// <summary>
    /// CSS selector to scope extraction to a specific element
    /// </summary>
    public string? Selector
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "selector"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "selector", value);
        }
    }

    /// <summary>
    /// Timeout in ms for the extraction
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model?.Validate();
        _ = this.Selector;
        _ = this.Timeout;
    }

    public SessionExtractParamsOptions() { }

    public SessionExtractParamsOptions(SessionExtractParamsOptions sessionExtractParamsOptions)
        : base(sessionExtractParamsOptions) { }

    public SessionExtractParamsOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsFromRaw : IFromRaw<SessionExtractParamsOptions>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Client SDK language
/// </summary>
[JsonConverter(typeof(SessionExtractParamsXLanguageConverter))]
public enum SessionExtractParamsXLanguage
{
    Typescript,
    Python,
    Playground,
}

sealed class SessionExtractParamsXLanguageConverter : JsonConverter<SessionExtractParamsXLanguage>
{
    public override SessionExtractParamsXLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "typescript" => SessionExtractParamsXLanguage.Typescript,
            "python" => SessionExtractParamsXLanguage.Python,
            "playground" => SessionExtractParamsXLanguage.Playground,
            _ => (SessionExtractParamsXLanguage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExtractParamsXLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExtractParamsXLanguage.Typescript => "typescript",
                SessionExtractParamsXLanguage.Python => "python",
                SessionExtractParamsXLanguage.Playground => "playground",
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
[JsonConverter(typeof(SessionExtractParamsXStreamResponseConverter))]
public enum SessionExtractParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionExtractParamsXStreamResponseConverter
    : JsonConverter<SessionExtractParamsXStreamResponse>
{
    public override SessionExtractParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionExtractParamsXStreamResponse.True,
            "false" => SessionExtractParamsXStreamResponse.False,
            _ => (SessionExtractParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExtractParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExtractParamsXStreamResponse.True => "true",
                SessionExtractParamsXStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
