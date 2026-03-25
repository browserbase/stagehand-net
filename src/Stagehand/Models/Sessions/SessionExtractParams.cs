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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionExtractParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
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
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("frameId");
        }
        init { this._rawBodyData.Set("frameId", value); }
    }

    /// <summary>
    /// Natural language instruction for what to extract
    /// </summary>
    public string? Instruction
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instruction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instruction", value);
        }
    }

    public SessionExtractParamsOptions? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SessionExtractParamsOptions>("options");
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
    /// JSON Schema defining the structure of data to extract
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Schema
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "schema"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to stream the response via SSE
    /// </summary>
    public ApiEnum<string, SessionExtractParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<
                ApiEnum<string, SessionExtractParamsXStreamResponse>
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

    public SessionExtractParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParams(SessionExtractParams sessionExtractParams)
        : base(sessionExtractParams)
    {
        this.ID = sessionExtractParams.ID;

        this._rawBodyData = new(sessionExtractParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SessionExtractParams(
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
    SessionExtractParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionExtractParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(SessionExtractParams? other)
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
                + string.Format("/v1/sessions/{0}/extract", this.ID)
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
    typeof(JsonModelConverter<SessionExtractParamsOptions, SessionExtractParamsOptionsFromRaw>)
)]
public sealed record class SessionExtractParamsOptions : JsonModel
{
    /// <summary>
    /// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public SessionExtractParamsOptionsModel? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionExtractParamsOptionsModel>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// CSS selector to scope extraction to a specific element
    /// </summary>
    public string? Selector
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("selector");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("selector", value);
        }
    }

    /// <summary>
    /// Timeout in ms for the extraction
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model?.Validate();
        _ = this.Selector;
        _ = this.Timeout;
    }

    public SessionExtractParamsOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptions(SessionExtractParamsOptions sessionExtractParamsOptions)
        : base(sessionExtractParamsOptions) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class SessionExtractParamsOptionsFromRaw : IFromRawJson<SessionExtractParamsOptions>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
/// </summary>
[JsonConverter(typeof(SessionExtractParamsOptionsModelConverter))]
public record class SessionExtractParamsOptionsModel : ModelBase
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

    public SessionExtractParamsOptionsModel(ModelConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SessionExtractParamsOptionsModel(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SessionExtractParamsOptionsModel(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConfig(out var value)) {
    ///     // `value` is of type `ModelConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConfig([NotNullWhen(true)] out ModelConfig? value)
    {
        value = this.Value as ModelConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
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
    ///     (ModelConfig value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<ModelConfig> config, System::Action<string> @string)
    {
        switch (this.Value)
        {
            case ModelConfig value:
                config(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of SessionExtractParamsOptionsModel"
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
    ///     (ModelConfig value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<ModelConfig, T> config, System::Func<string, T> @string)
    {
        return this.Value switch
        {
            ModelConfig value => config(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionExtractParamsOptionsModel"
            ),
        };
    }

    public static implicit operator SessionExtractParamsOptionsModel(ModelConfig value) =>
        new(value);

    public static implicit operator SessionExtractParamsOptionsModel(string value) => new(value);

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
                "Data did not match any variant of SessionExtractParamsOptionsModel"
            );
        }
        this.Switch((config) => config.Validate(), (_) => { });
    }

    public virtual bool Equals(SessionExtractParamsOptionsModel? other) =>
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
            ModelConfig _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class SessionExtractParamsOptionsModelConverter
    : JsonConverter<SessionExtractParamsOptionsModel>
{
    public override SessionExtractParamsOptionsModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ModelConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
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
        SessionExtractParamsOptionsModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
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
