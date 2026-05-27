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
/// Identifies and returns available actions on the current page that match the given instruction.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionObserveParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Target frame ID for the observation
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
    /// Natural language instruction for what actions to find
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

    public SessionObserveParamsOptions? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SessionObserveParamsOptions>("options");
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
    public ApiEnum<string, SessionObserveParamsXStreamResponse>? XStreamResponse
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<
                ApiEnum<string, SessionObserveParamsXStreamResponse>
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

    public SessionObserveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParams(SessionObserveParams sessionObserveParams)
        : base(sessionObserveParams)
    {
        this.ID = sessionObserveParams.ID;

        this._rawBodyData = new(sessionObserveParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SessionObserveParams(
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
    SessionObserveParams(
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
    public static SessionObserveParams FromRawUnchecked(
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

    public virtual bool Equals(SessionObserveParams? other)
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
                + string.Format("/v1/sessions/{0}/observe", this.ID)
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
    typeof(JsonModelConverter<SessionObserveParamsOptions, SessionObserveParamsOptionsFromRaw>)
)]
public sealed record class SessionObserveParamsOptions : JsonModel
{
    /// <summary>
    /// Selectors for elements and subtrees that should be excluded from observation
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
    public SessionObserveParamsOptionsModel? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionObserveParamsOptionsModel>("model");
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
    /// CSS selector to scope observation to a specific element
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
    /// Timeout in ms for the observation
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
    /// Variables whose names are exposed to the model so observe() returns %variableName%
    /// placeholders in suggested action arguments instead of literal values. Accepts
    /// flat primitives or { value, description? } objects.
    /// </summary>
    public IReadOnlyDictionary<string, SessionObserveParamsOptionsVariable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, SessionObserveParamsOptionsVariable>
            >("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, SessionObserveParamsOptionsVariable>?>(
                "variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IgnoreSelectors;
        this.Model?.Validate();
        _ = this.Selector;
        _ = this.Timeout;
        if (this.Variables != null)
        {
            foreach (var item in this.Variables.Values)
            {
                item.Validate();
            }
        }
    }

    public SessionObserveParamsOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptions(SessionObserveParamsOptions sessionObserveParamsOptions)
        : base(sessionObserveParamsOptions) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveParamsOptionsFromRaw : IFromRawJson<SessionObserveParamsOptions>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveParamsOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
/// </summary>
[JsonConverter(typeof(SessionObserveParamsOptionsModelConverter))]
public record class SessionObserveParamsOptionsModel : ModelBase
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
                genericModelConfigObject: (x) => x.BaseUrl,
                @string: (_) => null
            );
        }
    }

    public SessionObserveParamsOptionsModel(
        SessionObserveParamsOptionsModelVertexModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsModel(
        SessionObserveParamsOptionsModelGenericModelConfigObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsModel(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsModel(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SessionObserveParamsOptionsModelVertexModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexModelConfigObject(out var value)) {
    ///     // `value` is of type `SessionObserveParamsOptionsModelVertexModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexModelConfigObject(
        [NotNullWhen(true)] out SessionObserveParamsOptionsModelVertexModelConfigObject? value
    )
    {
        value = this.Value as SessionObserveParamsOptionsModelVertexModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SessionObserveParamsOptionsModelGenericModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGenericModelConfigObject(out var value)) {
    ///     // `value` is of type `SessionObserveParamsOptionsModelGenericModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGenericModelConfigObject(
        [NotNullWhen(true)] out SessionObserveParamsOptionsModelGenericModelConfigObject? value
    )
    {
        value = this.Value as SessionObserveParamsOptionsModelGenericModelConfigObject;
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
    ///     (SessionObserveParamsOptionsModelVertexModelConfigObject value) =&gt; {...},
    ///     (SessionObserveParamsOptionsModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SessionObserveParamsOptionsModelVertexModelConfigObject> vertexModelConfigObject,
        System::Action<SessionObserveParamsOptionsModelGenericModelConfigObject> genericModelConfigObject,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case SessionObserveParamsOptionsModelVertexModelConfigObject value:
                vertexModelConfigObject(value);
                break;
            case SessionObserveParamsOptionsModelGenericModelConfigObject value:
                genericModelConfigObject(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of SessionObserveParamsOptionsModel"
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
    ///     (SessionObserveParamsOptionsModelVertexModelConfigObject value) =&gt; {...},
    ///     (SessionObserveParamsOptionsModelGenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            SessionObserveParamsOptionsModelVertexModelConfigObject,
            T
        > vertexModelConfigObject,
        System::Func<
            SessionObserveParamsOptionsModelGenericModelConfigObject,
            T
        > genericModelConfigObject,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            SessionObserveParamsOptionsModelVertexModelConfigObject value =>
                vertexModelConfigObject(value),
            SessionObserveParamsOptionsModelGenericModelConfigObject value =>
                genericModelConfigObject(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionObserveParamsOptionsModel"
            ),
        };
    }

    public static implicit operator SessionObserveParamsOptionsModel(
        SessionObserveParamsOptionsModelVertexModelConfigObject value
    ) => new(value);

    public static implicit operator SessionObserveParamsOptionsModel(
        SessionObserveParamsOptionsModelGenericModelConfigObject value
    ) => new(value);

    public static implicit operator SessionObserveParamsOptionsModel(string value) => new(value);

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
                "Data did not match any variant of SessionObserveParamsOptionsModel"
            );
        }
        this.Switch(
            (vertexModelConfigObject) => vertexModelConfigObject.Validate(),
            (genericModelConfigObject) => genericModelConfigObject.Validate(),
            (_) => { }
        );
    }

    public virtual bool Equals(SessionObserveParamsOptionsModel? other) =>
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
            SessionObserveParamsOptionsModelVertexModelConfigObject _ => 0,
            SessionObserveParamsOptionsModelGenericModelConfigObject _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class SessionObserveParamsOptionsModelConverter
    : JsonConverter<SessionObserveParamsOptionsModel>
{
    public override SessionObserveParamsOptionsModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<SessionObserveParamsOptionsModelVertexModelConfigObject>(
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
                JsonSerializer.Deserialize<SessionObserveParamsOptionsModelGenericModelConfigObject>(
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
        SessionObserveParamsOptionsModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveParamsOptionsModelVertexModelConfigObject,
        SessionObserveParamsOptionsModelVertexModelConfigObjectFromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsModelVertexModelConfigObject : JsonModel
{
    /// <summary>
    /// Vertex provider authentication configuration
    /// </summary>
    public required SessionObserveParamsOptionsModelVertexModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionObserveParamsOptionsModelVertexModelConfigObjectAuth>(
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
    public required SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions>(
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

    public SessionObserveParamsOptionsModelVertexModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObject(
        SessionObserveParamsOptionsModelVertexModelConfigObject sessionObserveParamsOptionsModelVertexModelConfigObject
    )
        : base(sessionObserveParamsOptionsModelVertexModelConfigObject) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsModelVertexModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsModelVertexModelConfigObject(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsModelVertexModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveParamsOptionsModelVertexModelConfigObjectFromRaw
    : IFromRawJson<SessionObserveParamsOptionsModelVertexModelConfigObject>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsModelVertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveParamsOptionsModelVertexModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuth,
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsModelVertexModelConfigObjectAuth : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public required SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials>(
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
    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes>(
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

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuth(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuth sessionObserveParamsOptionsModelVertexModelConfigObjectAuth
    )
        : base(sessionObserveParamsOptionsModelVertexModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuth(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsModelVertexModelConfigObjectAuth(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsModelVertexModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuth(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials credentials
    )
        : this()
    {
        this.Credentials = credentials;
    }
}

class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthFromRaw
    : IFromRawJson<SessionObserveParamsOptionsModelVertexModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveParamsOptionsModelVertexModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials,
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsFromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
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
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
    >? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
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

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials sessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials
    )
        : base(sessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsFromRaw
    : IFromRawJson<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentials.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsTypeConverter)
)]
public enum SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType
{
    ServiceAccount,
}

sealed class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsTypeConverter
    : JsonConverter<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType>
{
    public override SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" =>
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
            _ => (SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionObserveParamsOptionsModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount =>
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
[JsonConverter(typeof(SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopesConverter))]
public record class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes : ModelBase
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

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes(
        IReadOnlyList<string> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes(JsonElement element)
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
                    "Data did not match any variant of SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes"
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
                "Data did not match any variant of SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes"
            ),
        };
    }

    public static implicit operator SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes(
        string value
    ) => new(value);

    public static implicit operator SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes(
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
                "Data did not match any variant of SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes"
            );
        }
    }

    public virtual bool Equals(
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes? other
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

sealed class SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopesConverter
    : JsonConverter<SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes>
{
    public override SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes? Read(
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
        SessionObserveParamsOptionsModelVertexModelConfigObjectAuthScopes value,
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
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions,
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
    : JsonModel
{
    /// <summary>
    /// Vertex AI provider-specific settings
    /// </summary>
    public required SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex Vertex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>(
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

    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions(
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions sessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions
    )
        : base(sessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions(
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex vertex
    )
        : this()
    {
        this.Vertex = vertex;
    }
}

class SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Vertex AI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex,
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
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

    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex(
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex sessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex
    )
        : base(sessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertexFromRaw
    : IFromRawJson<SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SessionObserveParamsOptionsModelVertexModelConfigObjectProviderOptionsVertex.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveParamsOptionsModelGenericModelConfigObject,
        SessionObserveParamsOptionsModelGenericModelConfigObjectFromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsModelGenericModelConfigObject : JsonModel
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
    /// AI provider for the model (or provide a baseURL endpoint instead)
    /// </summary>
    public ApiEnum<
        string,
        SessionObserveParamsOptionsModelGenericModelConfigObjectProvider
    >? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SessionObserveParamsOptionsModelGenericModelConfigObjectProvider>
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
        this.Provider?.Validate();
    }

    public SessionObserveParamsOptionsModelGenericModelConfigObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelGenericModelConfigObject(
        SessionObserveParamsOptionsModelGenericModelConfigObject sessionObserveParamsOptionsModelGenericModelConfigObject
    )
        : base(sessionObserveParamsOptionsModelGenericModelConfigObject) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsModelGenericModelConfigObject(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsModelGenericModelConfigObject(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsModelGenericModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionObserveParamsOptionsModelGenericModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class SessionObserveParamsOptionsModelGenericModelConfigObjectFromRaw
    : IFromRawJson<SessionObserveParamsOptionsModelGenericModelConfigObject>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsModelGenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveParamsOptionsModelGenericModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(SessionObserveParamsOptionsModelGenericModelConfigObjectProviderConverter))]
public enum SessionObserveParamsOptionsModelGenericModelConfigObjectProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class SessionObserveParamsOptionsModelGenericModelConfigObjectProviderConverter
    : JsonConverter<SessionObserveParamsOptionsModelGenericModelConfigObjectProvider>
{
    public override SessionObserveParamsOptionsModelGenericModelConfigObjectProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI,
            "anthropic" =>
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Anthropic,
            "google" => SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Google,
            "microsoft" =>
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Microsoft,
            "bedrock" => SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Bedrock,
            _ => (SessionObserveParamsOptionsModelGenericModelConfigObjectProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionObserveParamsOptionsModelGenericModelConfigObjectProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.OpenAI => "openai",
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Anthropic =>
                    "anthropic",
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Google => "google",
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Microsoft =>
                    "microsoft",
                SessionObserveParamsOptionsModelGenericModelConfigObjectProvider.Bedrock =>
                    "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SessionObserveParamsOptionsVariableConverter))]
public record class SessionObserveParamsOptionsVariable : ModelBase
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

    public SessionObserveParamsOptionsVariable(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariable(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariable(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariable(
        SessionObserveParamsOptionsVariableUnionMember3 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariable(JsonElement element)
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
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
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
    /// type <see cref="SessionObserveParamsOptionsVariableUnionMember3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionObserveParamsOptionsVariableUnionMember3(out var value)) {
    ///     // `value` is of type `SessionObserveParamsOptionsVariableUnionMember3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionObserveParamsOptionsVariableUnionMember3(
        [NotNullWhen(true)] out SessionObserveParamsOptionsVariableUnionMember3? value
    )
    {
        value = this.Value as SessionObserveParamsOptionsVariableUnionMember3;
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (SessionObserveParamsOptionsVariableUnionMember3 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<SessionObserveParamsOptionsVariableUnionMember3> sessionObserveParamsOptionsVariableUnionMember3
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case SessionObserveParamsOptionsVariableUnionMember3 value:
                sessionObserveParamsOptionsVariableUnionMember3(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of SessionObserveParamsOptionsVariable"
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (SessionObserveParamsOptionsVariableUnionMember3 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<
            SessionObserveParamsOptionsVariableUnionMember3,
            T
        > sessionObserveParamsOptionsVariableUnionMember3
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            SessionObserveParamsOptionsVariableUnionMember3 value =>
                sessionObserveParamsOptionsVariableUnionMember3(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionObserveParamsOptionsVariable"
            ),
        };
    }

    public static implicit operator SessionObserveParamsOptionsVariable(string value) => new(value);

    public static implicit operator SessionObserveParamsOptionsVariable(double value) => new(value);

    public static implicit operator SessionObserveParamsOptionsVariable(bool value) => new(value);

    public static implicit operator SessionObserveParamsOptionsVariable(
        SessionObserveParamsOptionsVariableUnionMember3 value
    ) => new(value);

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
                "Data did not match any variant of SessionObserveParamsOptionsVariable"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (sessionObserveParamsOptionsVariableUnionMember3) =>
                sessionObserveParamsOptionsVariableUnionMember3.Validate()
        );
    }

    public virtual bool Equals(SessionObserveParamsOptionsVariable? other) =>
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
            double _ => 1,
            bool _ => 2,
            SessionObserveParamsOptionsVariableUnionMember3 _ => 3,
            _ => -1,
        };
    }
}

sealed class SessionObserveParamsOptionsVariableConverter
    : JsonConverter<SessionObserveParamsOptionsVariable>
{
    public override SessionObserveParamsOptionsVariable? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3>(
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

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionObserveParamsOptionsVariable value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SessionObserveParamsOptionsVariableUnionMember3,
        SessionObserveParamsOptionsVariableUnionMember3FromRaw
    >)
)]
public sealed record class SessionObserveParamsOptionsVariableUnionMember3 : JsonModel
{
    public required SessionObserveParamsOptionsVariableUnionMember3Value Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionObserveParamsOptionsVariableUnionMember3Value>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Value.Validate();
        _ = this.Description;
    }

    public SessionObserveParamsOptionsVariableUnionMember3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionObserveParamsOptionsVariableUnionMember3(
        SessionObserveParamsOptionsVariableUnionMember3 sessionObserveParamsOptionsVariableUnionMember3
    )
        : base(sessionObserveParamsOptionsVariableUnionMember3) { }
#pragma warning restore CS8618

    public SessionObserveParamsOptionsVariableUnionMember3(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveParamsOptionsVariableUnionMember3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveParamsOptionsVariableUnionMember3FromRaw.FromRawUnchecked"/>
    public static SessionObserveParamsOptionsVariableUnionMember3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionObserveParamsOptionsVariableUnionMember3(
        SessionObserveParamsOptionsVariableUnionMember3Value value
    )
        : this()
    {
        this.Value = value;
    }
}

class SessionObserveParamsOptionsVariableUnionMember3FromRaw
    : IFromRawJson<SessionObserveParamsOptionsVariableUnionMember3>
{
    /// <inheritdoc/>
    public SessionObserveParamsOptionsVariableUnionMember3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveParamsOptionsVariableUnionMember3.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SessionObserveParamsOptionsVariableUnionMember3ValueConverter))]
public record class SessionObserveParamsOptionsVariableUnionMember3Value : ModelBase
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

    public SessionObserveParamsOptionsVariableUnionMember3Value(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariableUnionMember3Value(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariableUnionMember3Value(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SessionObserveParamsOptionsVariableUnionMember3Value(JsonElement element)
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
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of SessionObserveParamsOptionsVariableUnionMember3Value"
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
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionObserveParamsOptionsVariableUnionMember3Value"
            ),
        };
    }

    public static implicit operator SessionObserveParamsOptionsVariableUnionMember3Value(
        string value
    ) => new(value);

    public static implicit operator SessionObserveParamsOptionsVariableUnionMember3Value(
        double value
    ) => new(value);

    public static implicit operator SessionObserveParamsOptionsVariableUnionMember3Value(
        bool value
    ) => new(value);

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
                "Data did not match any variant of SessionObserveParamsOptionsVariableUnionMember3Value"
            );
        }
    }

    public virtual bool Equals(SessionObserveParamsOptionsVariableUnionMember3Value? other) =>
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
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class SessionObserveParamsOptionsVariableUnionMember3ValueConverter
    : JsonConverter<SessionObserveParamsOptionsVariableUnionMember3Value>
{
    public override SessionObserveParamsOptionsVariableUnionMember3Value? Read(
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionObserveParamsOptionsVariableUnionMember3Value value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Whether to stream the response via SSE
/// </summary>
[JsonConverter(typeof(SessionObserveParamsXStreamResponseConverter))]
public enum SessionObserveParamsXStreamResponse
{
    True,
    False,
}

sealed class SessionObserveParamsXStreamResponseConverter
    : JsonConverter<SessionObserveParamsXStreamResponse>
{
    public override SessionObserveParamsXStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => SessionObserveParamsXStreamResponse.True,
            "false" => SessionObserveParamsXStreamResponse.False,
            _ => (SessionObserveParamsXStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionObserveParamsXStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionObserveParamsXStreamResponse.True => "true",
                SessionObserveParamsXStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
