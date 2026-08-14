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
    /// Selectors for elements and subtrees that should be excluded from extraction
    /// </summary>
    public IReadOnlyList<string>? IgnoreSelectors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("ignoreSelectors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ignoreSelectors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// When true, include a screenshot of the current viewport in the extraction
    /// LLM call. Defaults to false.
    /// </summary>
    public bool? Screenshot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("screenshot");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("screenshot", value);
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
        _ = this.IgnoreSelectors;
        this.Model?.Validate();
        _ = this.Screenshot;
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

    public string? ModelName
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ModelName,
                azureEntraModelConfigObject: (x) => x.ModelName,
                azureApiKeyModelConfigObject: (x) => x.ModelName,
                genericModelConfigObject: (x) => x.ModelName,
                @string: (_) => null
            );
        }
    }

    public string? ApiKey
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.ApiKey,
                azureEntraModelConfigObject: (_) => null,
                azureApiKeyModelConfigObject: (x) => x.ApiKey,
                genericModelConfigObject: (x) => x.ApiKey,
                @string: (_) => null
            );
        }
    }

    public string? BaseUrl
    {
        get
        {
            return Match<string?>(
                vertexModelConfigObject: (x) => x.BaseUrl,
                azureEntraModelConfigObject: (x) => x.BaseUrl,
                azureApiKeyModelConfigObject: (x) => x.BaseUrl,
                genericModelConfigObject: (x) => x.BaseUrl,
                @string: (_) => null
            );
        }
    }

    public SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelVertexModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelGenericModelConfigObject value,
        JsonElement? element = null
    )
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
    /// type <see cref="SessionExtractParamsOptionsModelVertexModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexModelConfigObject(out var value)) {
    ///     // `value` is of type `SessionExtractParamsOptionsModelVertexModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexModelConfigObject(
        [NotNullWhen(true)] out SessionExtractParamsOptionsModelVertexModelConfigObject? value
    )
    {
        value = this.Value as SessionExtractParamsOptionsModelVertexModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SessionExtractParamsOptionsModelAzureEntraModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureEntraModelConfigObject(out var value)) {
    ///     // `value` is of type `SessionExtractParamsOptionsModelAzureEntraModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureEntraModelConfigObject(
        [NotNullWhen(true)] out SessionExtractParamsOptionsModelAzureEntraModelConfigObject? value
    )
    {
        value = this.Value as SessionExtractParamsOptionsModelAzureEntraModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureApiKeyModelConfigObject(out var value)) {
    ///     // `value` is of type `SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureApiKeyModelConfigObject(
        [NotNullWhen(true)] out SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject? value
    )
    {
        value = this.Value as SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SessionExtractParamsOptionsModelGenericModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGenericModelConfigObject(out var value)) {
    ///     // `value` is of type `SessionExtractParamsOptionsModelGenericModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGenericModelConfigObject(
        [NotNullWhen(true)] out SessionExtractParamsOptionsModelGenericModelConfigObject? value
    )
    {
        value = this.Value as SessionExtractParamsOptionsModelGenericModelConfigObject;
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
    ///     (SessionExtractParamsOptionsModelVertexModelConfigObject value) =&gt; {...},
    ///     (SessionExtractParamsOptionsModelAzureEntraModelConfigObject value) =&gt; {...},
    ///     (SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject value) =&gt; {...},
    ///     (SessionExtractParamsOptionsModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SessionExtractParamsOptionsModelVertexModelConfigObject> vertexModelConfigObject,
        System::Action<SessionExtractParamsOptionsModelAzureEntraModelConfigObject> azureEntraModelConfigObject,
        System::Action<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject> azureApiKeyModelConfigObject,
        System::Action<SessionExtractParamsOptionsModelGenericModelConfigObject> genericModelConfigObject,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case SessionExtractParamsOptionsModelVertexModelConfigObject value:
                vertexModelConfigObject(value);
                break;
            case SessionExtractParamsOptionsModelAzureEntraModelConfigObject value:
                azureEntraModelConfigObject(value);
                break;
            case SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject value:
                azureApiKeyModelConfigObject(value);
                break;
            case SessionExtractParamsOptionsModelGenericModelConfigObject value:
                genericModelConfigObject(value);
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
    ///     (SessionExtractParamsOptionsModelVertexModelConfigObject value) =&gt; {...},
    ///     (SessionExtractParamsOptionsModelAzureEntraModelConfigObject value) =&gt; {...},
    ///     (SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject value) =&gt; {...},
    ///     (SessionExtractParamsOptionsModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            SessionExtractParamsOptionsModelVertexModelConfigObject,
            T
        > vertexModelConfigObject,
        System::Func<
            SessionExtractParamsOptionsModelAzureEntraModelConfigObject,
            T
        > azureEntraModelConfigObject,
        System::Func<
            SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject,
            T
        > azureApiKeyModelConfigObject,
        System::Func<
            SessionExtractParamsOptionsModelGenericModelConfigObject,
            T
        > genericModelConfigObject,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            SessionExtractParamsOptionsModelVertexModelConfigObject value =>
                vertexModelConfigObject(value),
            SessionExtractParamsOptionsModelAzureEntraModelConfigObject value =>
                azureEntraModelConfigObject(value),
            SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject value =>
                azureApiKeyModelConfigObject(value),
            SessionExtractParamsOptionsModelGenericModelConfigObject value =>
                genericModelConfigObject(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionExtractParamsOptionsModel"
            ),
        };
    }

    public static implicit operator SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelVertexModelConfigObject value
    ) => new(value);

    public static implicit operator SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObject value
    ) => new(value);

    public static implicit operator SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject value
    ) => new(value);

    public static implicit operator SessionExtractParamsOptionsModel(
        SessionExtractParamsOptionsModelGenericModelConfigObject value
    ) => new(value);

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
        this.Switch(
            (vertexModelConfigObject) => vertexModelConfigObject.Validate(),
            (azureEntraModelConfigObject) => azureEntraModelConfigObject.Validate(),
            (azureApiKeyModelConfigObject) => azureApiKeyModelConfigObject.Validate(),
            (genericModelConfigObject) => genericModelConfigObject.Validate(),
            (_) => { }
        );
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
            SessionExtractParamsOptionsModelVertexModelConfigObject _ => 0,
            SessionExtractParamsOptionsModelAzureEntraModelConfigObject _ => 1,
            SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject _ => 2,
            SessionExtractParamsOptionsModelGenericModelConfigObject _ => 3,
            string _ => 4,
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
            var deserialized =
                JsonSerializer.Deserialize<SessionExtractParamsOptionsModelVertexModelConfigObject>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<SessionExtractParamsOptionsModelAzureEntraModelConfigObject>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject>(
                    element,
                    options
                );
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
            var deserialized =
                JsonSerializer.Deserialize<SessionExtractParamsOptionsModelGenericModelConfigObject>(
                    element,
                    options
                );
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

[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelVertexModelConfigObject,
        SessionExtractParamsOptionsModelVertexModelConfigObjectFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelVertexModelConfigObject : JsonModel
{
    /// <summary>
    /// Vertex provider authentication configuration
    /// </summary>
    public required SessionExtractParamsOptionsModelVertexModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelVertexModelConfigObjectAuth>(
                "auth"
            );
        }
        init { this._rawData.Set("auth", value); }
    }

    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelName");
        }
        init { this._rawData.Set("modelName", value); }
    }

    /// <summary>
    /// Vertex AI model provider
    /// </summary>
    public JsonElement Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Vertex provider-specific model configuration
    /// </summary>
    public required SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions>(
                "providerOptions"
            );
        }
        init { this._rawData.Set("providerOptions", value); }
    }

    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKey", value);
        }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the model provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Auth.Validate();
        _ = this.ModelName;
        if (!JsonElement.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("vertex")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        this.ProviderOptions.Validate();
        _ = this.ApiKey;
        _ = this.BaseUrl;
        _ = this.Headers;
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObject(
        SessionExtractParamsOptionsModelVertexModelConfigObject sessionExtractParamsOptionsModelVertexModelConfigObject
    )
        : base(sessionExtractParamsOptionsModelVertexModelConfigObject) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelVertexModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelVertexModelConfigObject(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelVertexModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelVertexModelConfigObjectFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelVertexModelConfigObject>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptionsModelVertexModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuth,
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelVertexModelConfigObjectAuth : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public required SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials>(
                "credentials"
            );
        }
        init { this._rawData.Set("credentials", value); }
    }

    /// <summary>
    /// Use inline Google Cloud service account credentials for provider authentication
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Google Cloud project ID used by google-auth-library
    /// </summary>
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

    /// <summary>
    /// Google auth scopes for the desired API request
    /// </summary>
    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes>(
                "scopes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scopes", value);
        }
    }

    /// <summary>
    /// Google Cloud universe domain
    /// </summary>
    public string? UniverseDomain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universeDomain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("universeDomain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Credentials.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("googleServiceAccount")
            )
        )
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        _ = this.ProjectID;
        this.Scopes?.Validate();
        _ = this.UniverseDomain;
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuth(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuth sessionExtractParamsOptionsModelVertexModelConfigObjectAuth
    )
        : base(sessionExtractParamsOptionsModelVertexModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuth(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelVertexModelConfigObjectAuth(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelVertexModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuth(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials credentials
    )
        : this()
    {
        this.Credentials = credentials;
    }
}

class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelVertexModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptionsModelVertexModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials,
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
    : JsonModel
{
    public required string ClientEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_email");
        }
        init { this._rawData.Set("client_email", value); }
    }

    public required string PrivateKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("private_key");
        }
        init { this._rawData.Set("private_key", value); }
    }

    public string? AuthProviderX509CertUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auth_provider_x509_cert_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auth_provider_x509_cert_url", value);
        }
    }

    public string? AuthUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auth_uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auth_uri", value);
        }
    }

    public string? ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("client_id", value);
        }
    }

    public string? ClientX509CertUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_x509_cert_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("client_x509_cert_url", value);
        }
    }

    public string? PrivateKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("private_key_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("private_key_id", value);
        }
    }

    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("project_id", value);
        }
    }

    public string? TokenUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token_uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("token_uri", value);
        }
    }

    public ApiEnum<
        string,
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
    >? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
                >
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

    public string? UniverseDomain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("universe_domain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("universe_domain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientEmail;
        _ = this.PrivateKey;
        _ = this.AuthProviderX509CertUrl;
        _ = this.AuthUri;
        _ = this.ClientID;
        _ = this.ClientX509CertUrl;
        _ = this.PrivateKeyID;
        _ = this.ProjectID;
        _ = this.TokenUri;
        this.Type?.Validate();
        _ = this.UniverseDomain;
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials sessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials
    )
        : base(sessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentials.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsTypeConverter)
)]
public enum SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
{
    ServiceAccount,
}

sealed class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsTypeConverter
    : JsonConverter<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType>
{
    public override SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" =>
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            _ => (SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExtractParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount =>
                    "service_account",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Google auth scopes for the desired API request
/// </summary>
[JsonConverter(typeof(SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopesConverter))]
public record class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes : ModelBase
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

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes(
        IReadOnlyList<string> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes(JsonElement element)
    {
        this._element = element;
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes"
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes"
            ),
        };
    }

    public static implicit operator SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes(
        string value
    ) => new(value);

    public static implicit operator SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes(
        List<string> value
    ) => new((IReadOnlyList<string>)value);

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
                "Data did not match any variant of SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes"
            );
        }
    }

    public virtual bool Equals(
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes? other
    ) =>
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
            string _ => 0,
            IReadOnlyList<string> _ => 1,
            _ => -1,
        };
    }
}

sealed class SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopesConverter
    : JsonConverter<SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes>
{
    public override SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
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
        SessionExtractParamsOptionsModelVertexModelConfigObjectAuthScopes value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Vertex provider-specific model configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions,
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
    : JsonModel
{
    /// <summary>
    /// Vertex AI provider-specific settings
    /// </summary>
    public required SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex Vertex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>(
                "vertex"
            );
        }
        init { this._rawData.Set("vertex", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Vertex.Validate();
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions(
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions sessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions
    )
        : base(sessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions(
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex vertex
    )
        : this()
    {
        this.Vertex = vertex;
    }
}

class SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Vertex AI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex,
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
    : JsonModel
{
    /// <summary>
    /// Google Cloud location for Vertex AI models
    /// </summary>
    public required string Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("location");
        }
        init { this._rawData.Set("location", value); }
    }

    /// <summary>
    /// Google Cloud project ID for Vertex AI models
    /// </summary>
    public required string Project
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project");
        }
        init { this._rawData.Set("project", value); }
    }

    /// <summary>
    /// Base URL for the Vertex AI provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the Vertex AI provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Location;
        _ = this.Project;
        _ = this.BaseUrl;
        _ = this.Headers;
    }

    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex(
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex sessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
    )
        : base(sessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureEntraModelConfigObject,
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureEntraModelConfigObject : JsonModel
{
    /// <summary>
    /// Azure provider authentication configuration
    /// </summary>
    public required SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth>(
                "auth"
            );
        }
        init { this._rawData.Set("auth", value); }
    }

    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelName");
        }
        init { this._rawData.Set("modelName", value); }
    }

    /// <summary>
    /// Azure OpenAI model provider
    /// </summary>
    public JsonElement Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Azure provider-specific model configuration
    /// </summary>
    public required SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions>(
                "providerOptions"
            );
        }
        init { this._rawData.Set("providerOptions", value); }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the model provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Auth.Validate();
        _ = this.ModelName;
        if (!JsonElement.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("azure")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        this.ProviderOptions.Validate();
        _ = this.BaseUrl;
        _ = this.Headers;
    }

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObject(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObject sessionExtractParamsOptionsModelAzureEntraModelConfigObject
    )
        : base(sessionExtractParamsOptionsModelAzureEntraModelConfigObject) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureEntraModelConfigObject(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureEntraModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureEntraModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureEntraModelConfigObject>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptionsModelAzureEntraModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth,
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth
    : JsonModel
{
    /// <summary>
    /// Microsoft Entra ID bearer token for Azure OpenAI
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// Use a Microsoft Entra ID bearer token for authentication
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("azureEntraId")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
    }

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("azureEntraId");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth sessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth
    )
        : base(sessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("azureEntraId");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth(string token)
        : this()
    {
        this.Token = token;
    }
}

class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuthFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptionsModelAzureEntraModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure provider-specific model configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions,
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions
    : JsonModel
{
    /// <summary>
    /// Azure OpenAI provider-specific settings
    /// </summary>
    public required SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure Azure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure>(
                "azure"
            );
        }
        init { this._rawData.Set("azure", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Azure.Validate();
    }

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions sessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions
    )
        : base(sessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure azure
    )
        : this()
    {
        this.Azure = azure;
    }
}

class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Azure OpenAI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure,
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzureFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure
    : JsonModel
{
    /// <summary>
    /// Azure OpenAI API version
    /// </summary>
    public string? ApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiVersion", value);
        }
    }

    /// <summary>
    /// Base URL for the Azure OpenAI provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the Azure OpenAI provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Azure OpenAI resource name
    /// </summary>
    public string? ResourceName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resourceName", value);
        }
    }

    /// <summary>
    /// Whether to use deployment-based Azure OpenAI URLs
    /// </summary>
    public bool? UseDeploymentBasedUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("useDeploymentBasedUrls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("useDeploymentBasedUrls", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiVersion;
        _ = this.BaseUrl;
        _ = this.Headers;
        _ = this.ResourceName;
        _ = this.UseDeploymentBasedUrls;
    }

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure(
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure sessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure
    )
        : base(sessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzureFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzureFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelAzureEntraModelConfigObjectProviderOptionsAzure.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject,
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject : JsonModel
{
    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelName");
        }
        init { this._rawData.Set("modelName", value); }
    }

    /// <summary>
    /// Azure OpenAI model provider
    /// </summary>
    public JsonElement Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Azure provider-specific model configuration
    /// </summary>
    public required SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions>(
                "providerOptions"
            );
        }
        init { this._rawData.Set("providerOptions", value); }
    }

    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKey", value);
        }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the model provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ModelName;
        if (!JsonElement.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("azure")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
        this.ProviderOptions.Validate();
        _ = this.ApiKey;
        _ = this.BaseUrl;
        _ = this.Headers;
    }

    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject(
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject sessionExtractParamsOptionsModelAzureApiKeyModelConfigObject
    )
        : base(sessionExtractParamsOptionsModelAzureApiKeyModelConfigObject) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptionsModelAzureApiKeyModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure provider-specific model configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions,
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions
    : JsonModel
{
    /// <summary>
    /// Azure OpenAI provider-specific settings
    /// </summary>
    public required SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure Azure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure>(
                "azure"
            );
        }
        init { this._rawData.Set("azure", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Azure.Validate();
    }

    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions(
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions sessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions
    )
        : base(sessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions(
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure azure
    )
        : this()
    {
        this.Azure = azure;
    }
}

class SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Azure OpenAI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure,
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzureFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure
    : JsonModel
{
    /// <summary>
    /// Azure OpenAI API version
    /// </summary>
    public string? ApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiVersion", value);
        }
    }

    /// <summary>
    /// Base URL for the Azure OpenAI provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the Azure OpenAI provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Azure OpenAI resource name
    /// </summary>
    public string? ResourceName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resourceName", value);
        }
    }

    /// <summary>
    /// Whether to use deployment-based Azure OpenAI URLs
    /// </summary>
    public bool? UseDeploymentBasedUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("useDeploymentBasedUrls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("useDeploymentBasedUrls", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiVersion;
        _ = this.BaseUrl;
        _ = this.Headers;
        _ = this.ResourceName;
        _ = this.UseDeploymentBasedUrls;
    }

    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure(
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure sessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure
    )
        : base(sessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzureFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzureFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionExtractParamsOptionsModelAzureApiKeyModelConfigObjectProviderOptionsAzure.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionExtractParamsOptionsModelGenericModelConfigObject,
        SessionExtractParamsOptionsModelGenericModelConfigObjectFromRaw
    >)
)]
public sealed record class SessionExtractParamsOptionsModelGenericModelConfigObject : JsonModel
{
    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelName");
        }
        init { this._rawData.Set("modelName", value); }
    }

    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKey", value);
        }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the model provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Wire format used by an OpenAI-compatible endpoint. Defaults to the Responses
    /// API; use chat for Chat Completions-only endpoints.
    /// </summary>
    public ApiEnum<
        string,
        SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat
    >? OpenAIEndpointFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat
                >
            >("openaiEndpointFormat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("openaiEndpointFormat", value);
        }
    }

    /// <summary>
    /// AI provider for the model (or provide a baseURL endpoint instead)
    /// </summary>
    public ApiEnum<
        string,
        SessionExtractParamsOptionsModelGenericModelConfigObjectProvider
    >? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SessionExtractParamsOptionsModelGenericModelConfigObjectProvider>
            >("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ModelName;
        _ = this.ApiKey;
        _ = this.BaseUrl;
        _ = this.Headers;
        this.OpenAIEndpointFormat?.Validate();
        this.Provider?.Validate();
    }

    public SessionExtractParamsOptionsModelGenericModelConfigObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelGenericModelConfigObject(
        SessionExtractParamsOptionsModelGenericModelConfigObject sessionExtractParamsOptionsModelGenericModelConfigObject
    )
        : base(sessionExtractParamsOptionsModelGenericModelConfigObject) { }
#pragma warning restore CS8618

    public SessionExtractParamsOptionsModelGenericModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionExtractParamsOptionsModelGenericModelConfigObject(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionExtractParamsOptionsModelGenericModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static SessionExtractParamsOptionsModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionExtractParamsOptionsModelGenericModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class SessionExtractParamsOptionsModelGenericModelConfigObjectFromRaw
    : IFromRawJson<SessionExtractParamsOptionsModelGenericModelConfigObject>
{
    /// <inheritdoc/>
    public SessionExtractParamsOptionsModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionExtractParamsOptionsModelGenericModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Wire format used by an OpenAI-compatible endpoint. Defaults to the Responses API;
/// use chat for Chat Completions-only endpoints.
/// </summary>
[JsonConverter(
    typeof(SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormatConverter)
)]
public enum SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat
{
    Responses,
    Chat,
}

sealed class SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormatConverter
    : JsonConverter<SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat>
{
    public override SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "responses" =>
                SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat.Responses,
            "chat" =>
                SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat.Chat,
            _ => (SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat.Responses =>
                    "responses",
                SessionExtractParamsOptionsModelGenericModelConfigObjectOpenAIEndpointFormat.Chat =>
                    "chat",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(SessionExtractParamsOptionsModelGenericModelConfigObjectProviderConverter))]
public enum SessionExtractParamsOptionsModelGenericModelConfigObjectProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class SessionExtractParamsOptionsModelGenericModelConfigObjectProviderConverter
    : JsonConverter<SessionExtractParamsOptionsModelGenericModelConfigObjectProvider>
{
    public override SessionExtractParamsOptionsModelGenericModelConfigObjectProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
            "anthropic" =>
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Anthropic,
            "google" => SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Google,
            "microsoft" =>
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Microsoft,
            "bedrock" => SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Bedrock,
            _ => (SessionExtractParamsOptionsModelGenericModelConfigObjectProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionExtractParamsOptionsModelGenericModelConfigObjectProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.OpenAI => "openai",
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Anthropic =>
                    "anthropic",
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Google => "google",
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Microsoft =>
                    "microsoft",
                SessionExtractParamsOptionsModelGenericModelConfigObjectProvider.Bedrock =>
                    "bedrock",
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
