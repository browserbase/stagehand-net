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
/// Executes a browser action using natural language instructions or a predefined
/// Action object.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionActParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Natural language instruction or Action object
    /// </summary>
    public required Input Input
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Input>("input");
        }
        init { this._rawBodyData.Set("input", value); }
    }

    /// <summary>
    /// Target frame ID for the action
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

    public Options? Options
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Options>("options");
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
    public ApiEnum<string, XStreamResponse>? XStreamResponse
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<ApiEnum<string, XStreamResponse>>(
                "x-stream-response"
            );
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

    public SessionActParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionActParams(SessionActParams sessionActParams)
        : base(sessionActParams)
    {
        this.ID = sessionActParams.ID;

        this._rawBodyData = new(sessionActParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SessionActParams(
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
    SessionActParams(
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
    public static SessionActParams FromRawUnchecked(
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

    public virtual bool Equals(SessionActParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/sessions/{0}/act", this.ID)
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

/// <summary>
/// Natural language instruction or Action object
/// </summary>
[JsonConverter(typeof(InputConverter))]
public record class Input : ModelBase
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

    public Input(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(Action value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(JsonElement element)
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
    /// type <see cref="Action"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAction(out var value)) {
    ///     // `value` is of type `Action`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAction([NotNullWhen(true)] out Action? value)
    {
        value = this.Value as Action;
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
    ///     (Action value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<Action> action)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Action value:
                action(value);
                break;
            default:
                throw new StagehandInvalidDataException("Data did not match any variant of Input");
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
    ///     (Action value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<Action, T> action)
    {
        return this.Value switch
        {
            string value => @string(value),
            Action value => action(value),
            _ => throw new StagehandInvalidDataException("Data did not match any variant of Input"),
        };
    }

    public static implicit operator Input(string value) => new(value);

    public static implicit operator Input(Action value) => new(value);

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
            throw new StagehandInvalidDataException("Data did not match any variant of Input");
        }
        this.Switch((_) => { }, (action) => action.Validate());
    }

    public virtual bool Equals(Input? other) =>
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
            Action _ => 1,
            _ => -1,
        };
    }
}

sealed class InputConverter : JsonConverter<Input>
{
    public override Input? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Action>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Input value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public Model? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Model>("model");
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
    /// Timeout in ms for the action
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
    /// Variables to substitute in the action instruction. Accepts flat primitives
    /// or { value, description? } objects.
    /// </summary>
    public IReadOnlyDictionary<string, Variable>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Variable>>("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, Variable>?>(
                "variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model?.Validate();
        _ = this.Timeout;
        if (this.Variables != null)
        {
            foreach (var item in this.Variables.Values)
            {
                item.Validate();
            }
        }
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

/// <summary>
/// Model configuration object or model name string (e.g., 'openai/gpt-5-nano')
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public record class Model : ModelBase
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

    public Model(VertexModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(AzureEntraModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(AzureApiKeyModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(GenericModelConfigObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VertexModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVertexModelConfigObject(out var value)) {
    ///     // `value` is of type `VertexModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVertexModelConfigObject(
        [NotNullWhen(true)] out VertexModelConfigObject? value
    )
    {
        value = this.Value as VertexModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AzureEntraModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureEntraModelConfigObject(out var value)) {
    ///     // `value` is of type `AzureEntraModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureEntraModelConfigObject(
        [NotNullWhen(true)] out AzureEntraModelConfigObject? value
    )
    {
        value = this.Value as AzureEntraModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AzureApiKeyModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureApiKeyModelConfigObject(out var value)) {
    ///     // `value` is of type `AzureApiKeyModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureApiKeyModelConfigObject(
        [NotNullWhen(true)] out AzureApiKeyModelConfigObject? value
    )
    {
        value = this.Value as AzureApiKeyModelConfigObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GenericModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGenericModelConfigObject(out var value)) {
    ///     // `value` is of type `GenericModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGenericModelConfigObject(
        [NotNullWhen(true)] out GenericModelConfigObject? value
    )
    {
        value = this.Value as GenericModelConfigObject;
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
    ///     (VertexModelConfigObject value) =&gt; {...},
    ///     (AzureEntraModelConfigObject value) =&gt; {...},
    ///     (AzureApiKeyModelConfigObject value) =&gt; {...},
    ///     (GenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<VertexModelConfigObject> vertexModelConfigObject,
        System::Action<AzureEntraModelConfigObject> azureEntraModelConfigObject,
        System::Action<AzureApiKeyModelConfigObject> azureApiKeyModelConfigObject,
        System::Action<GenericModelConfigObject> genericModelConfigObject,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case VertexModelConfigObject value:
                vertexModelConfigObject(value);
                break;
            case AzureEntraModelConfigObject value:
                azureEntraModelConfigObject(value);
                break;
            case AzureApiKeyModelConfigObject value:
                azureApiKeyModelConfigObject(value);
                break;
            case GenericModelConfigObject value:
                genericModelConfigObject(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new StagehandInvalidDataException("Data did not match any variant of Model");
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
    ///     (VertexModelConfigObject value) =&gt; {...},
    ///     (AzureEntraModelConfigObject value) =&gt; {...},
    ///     (AzureApiKeyModelConfigObject value) =&gt; {...},
    ///     (GenericModelConfigObject value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<VertexModelConfigObject, T> vertexModelConfigObject,
        System::Func<AzureEntraModelConfigObject, T> azureEntraModelConfigObject,
        System::Func<AzureApiKeyModelConfigObject, T> azureApiKeyModelConfigObject,
        System::Func<GenericModelConfigObject, T> genericModelConfigObject,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            VertexModelConfigObject value => vertexModelConfigObject(value),
            AzureEntraModelConfigObject value => azureEntraModelConfigObject(value),
            AzureApiKeyModelConfigObject value => azureApiKeyModelConfigObject(value),
            GenericModelConfigObject value => genericModelConfigObject(value),
            string value => @string(value),
            _ => throw new StagehandInvalidDataException("Data did not match any variant of Model"),
        };
    }

    public static implicit operator Model(VertexModelConfigObject value) => new(value);

    public static implicit operator Model(AzureEntraModelConfigObject value) => new(value);

    public static implicit operator Model(AzureApiKeyModelConfigObject value) => new(value);

    public static implicit operator Model(GenericModelConfigObject value) => new(value);

    public static implicit operator Model(string value) => new(value);

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
            throw new StagehandInvalidDataException("Data did not match any variant of Model");
        }
        this.Switch(
            (vertexModelConfigObject) => vertexModelConfigObject.Validate(),
            (azureEntraModelConfigObject) => azureEntraModelConfigObject.Validate(),
            (azureApiKeyModelConfigObject) => azureApiKeyModelConfigObject.Validate(),
            (genericModelConfigObject) => genericModelConfigObject.Validate(),
            (_) => { }
        );
    }

    public virtual bool Equals(Model? other) =>
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
            VertexModelConfigObject _ => 0,
            AzureEntraModelConfigObject _ => 1,
            AzureApiKeyModelConfigObject _ => 2,
            GenericModelConfigObject _ => 3,
            string _ => 4,
            _ => -1,
        };
    }
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<VertexModelConfigObject>(
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
            var deserialized = JsonSerializer.Deserialize<AzureEntraModelConfigObject>(
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
            var deserialized = JsonSerializer.Deserialize<AzureApiKeyModelConfigObject>(
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
            var deserialized = JsonSerializer.Deserialize<GenericModelConfigObject>(
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

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<VertexModelConfigObject, VertexModelConfigObjectFromRaw>))]
public sealed record class VertexModelConfigObject : JsonModel
{
    /// <summary>
    /// Vertex provider authentication configuration
    /// </summary>
    public required Auth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Auth>("auth");
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
    public required ProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProviderOptions>("providerOptions");
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

    public VertexModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VertexModelConfigObject(VertexModelConfigObject vertexModelConfigObject)
        : base(vertexModelConfigObject) { }
#pragma warning restore CS8618

    public VertexModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("vertex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VertexModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VertexModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static VertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VertexModelConfigObjectFromRaw : IFromRawJson<VertexModelConfigObject>
{
    /// <inheritdoc/>
    public VertexModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VertexModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex provider authentication configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Auth, AuthFromRaw>))]
public sealed record class Auth : JsonModel
{
    /// <summary>
    /// Google Cloud service account credentials
    /// </summary>
    public required Credentials Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Credentials>("credentials");
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
    public Scopes? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Scopes>("scopes");
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

    public Auth()
    {
        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Auth(Auth auth)
        : base(auth) { }
#pragma warning restore CS8618

    public Auth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("googleServiceAccount");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Auth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthFromRaw.FromRawUnchecked"/>
    public static Auth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Auth(Credentials credentials)
        : this()
    {
        this.Credentials = credentials;
    }
}

class AuthFromRaw : IFromRawJson<Auth>
{
    /// <inheritdoc/>
    public Auth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Auth.FromRawUnchecked(rawData);
}

/// <summary>
/// Google Cloud service account credentials
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credentials, CredentialsFromRaw>))]
public sealed record class Credentials : JsonModel
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

    public Credentials() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Credentials(Credentials credentials)
        : base(credentials) { }
#pragma warning restore CS8618

    public Credentials(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Credentials(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CredentialsFromRaw.FromRawUnchecked"/>
    public static Credentials FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CredentialsFromRaw : IFromRawJson<Credentials>
{
    /// <inheritdoc/>
    public Credentials FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Credentials.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ServiceAccount,
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
            "service_account" => global::Stagehand.Models.Sessions.Type.ServiceAccount,
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
                global::Stagehand.Models.Sessions.Type.ServiceAccount => "service_account",
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
[JsonConverter(typeof(ScopesConverter))]
public record class Scopes : ModelBase
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

    public Scopes(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scopes(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Scopes(JsonElement element)
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
                throw new StagehandInvalidDataException("Data did not match any variant of Scopes");
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
                "Data did not match any variant of Scopes"
            ),
        };
    }

    public static implicit operator Scopes(string value) => new(value);

    public static implicit operator Scopes(List<string> value) => new((IReadOnlyList<string>)value);

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
            throw new StagehandInvalidDataException("Data did not match any variant of Scopes");
        }
    }

    public virtual bool Equals(Scopes? other) =>
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

sealed class ScopesConverter : JsonConverter<Scopes>
{
    public override Scopes? Read(
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

    public override void Write(Utf8JsonWriter writer, Scopes value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Vertex provider-specific model configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProviderOptions, ProviderOptionsFromRaw>))]
public sealed record class ProviderOptions : JsonModel
{
    /// <summary>
    /// Vertex AI provider-specific settings
    /// </summary>
    public required Vertex Vertex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Vertex>("vertex");
        }
        init { this._rawData.Set("vertex", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Vertex.Validate();
    }

    public ProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProviderOptions(ProviderOptions providerOptions)
        : base(providerOptions) { }
#pragma warning restore CS8618

    public ProviderOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProviderOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProviderOptionsFromRaw.FromRawUnchecked"/>
    public static ProviderOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProviderOptions(Vertex vertex)
        : this()
    {
        this.Vertex = vertex;
    }
}

class ProviderOptionsFromRaw : IFromRawJson<ProviderOptions>
{
    /// <inheritdoc/>
    public ProviderOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Vertex AI provider-specific settings
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Vertex, VertexFromRaw>))]
public sealed record class Vertex : JsonModel
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

    public Vertex() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Vertex(Vertex vertex)
        : base(vertex) { }
#pragma warning restore CS8618

    public Vertex(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Vertex(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VertexFromRaw.FromRawUnchecked"/>
    public static Vertex FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VertexFromRaw : IFromRawJson<Vertex>
{
    /// <inheritdoc/>
    public Vertex FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Vertex.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AzureEntraModelConfigObject, AzureEntraModelConfigObjectFromRaw>)
)]
public sealed record class AzureEntraModelConfigObject : JsonModel
{
    /// <summary>
    /// Azure provider authentication configuration
    /// </summary>
    public required AzureEntraModelConfigObjectAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AzureEntraModelConfigObjectAuth>("auth");
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
    public required AzureEntraModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AzureEntraModelConfigObjectProviderOptions>(
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

    public AzureEntraModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureEntraModelConfigObject(AzureEntraModelConfigObject azureEntraModelConfigObject)
        : base(azureEntraModelConfigObject) { }
#pragma warning restore CS8618

    public AzureEntraModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureEntraModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureEntraModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static AzureEntraModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureEntraModelConfigObjectFromRaw : IFromRawJson<AzureEntraModelConfigObject>
{
    /// <inheritdoc/>
    public AzureEntraModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureEntraModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure provider authentication configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AzureEntraModelConfigObjectAuth,
        AzureEntraModelConfigObjectAuthFromRaw
    >)
)]
public sealed record class AzureEntraModelConfigObjectAuth : JsonModel
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

    public AzureEntraModelConfigObjectAuth()
    {
        this.Type = JsonSerializer.SerializeToElement("azureEntraId");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureEntraModelConfigObjectAuth(
        AzureEntraModelConfigObjectAuth azureEntraModelConfigObjectAuth
    )
        : base(azureEntraModelConfigObjectAuth) { }
#pragma warning restore CS8618

    public AzureEntraModelConfigObjectAuth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("azureEntraId");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureEntraModelConfigObjectAuth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureEntraModelConfigObjectAuthFromRaw.FromRawUnchecked"/>
    public static AzureEntraModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AzureEntraModelConfigObjectAuth(string token)
        : this()
    {
        this.Token = token;
    }
}

class AzureEntraModelConfigObjectAuthFromRaw : IFromRawJson<AzureEntraModelConfigObjectAuth>
{
    /// <inheritdoc/>
    public AzureEntraModelConfigObjectAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureEntraModelConfigObjectAuth.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure provider-specific model configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AzureEntraModelConfigObjectProviderOptions,
        AzureEntraModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class AzureEntraModelConfigObjectProviderOptions : JsonModel
{
    /// <summary>
    /// Azure OpenAI provider-specific settings
    /// </summary>
    public required Azure Azure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Azure>("azure");
        }
        init { this._rawData.Set("azure", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Azure.Validate();
    }

    public AzureEntraModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureEntraModelConfigObjectProviderOptions(
        AzureEntraModelConfigObjectProviderOptions azureEntraModelConfigObjectProviderOptions
    )
        : base(azureEntraModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public AzureEntraModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureEntraModelConfigObjectProviderOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureEntraModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static AzureEntraModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AzureEntraModelConfigObjectProviderOptions(Azure azure)
        : this()
    {
        this.Azure = azure;
    }
}

class AzureEntraModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<AzureEntraModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public AzureEntraModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureEntraModelConfigObjectProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure OpenAI provider-specific settings
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Azure, AzureFromRaw>))]
public sealed record class Azure : JsonModel
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

    public Azure() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Azure(Azure azure)
        : base(azure) { }
#pragma warning restore CS8618

    public Azure(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Azure(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureFromRaw.FromRawUnchecked"/>
    public static Azure FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureFromRaw : IFromRawJson<Azure>
{
    /// <inheritdoc/>
    public Azure FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Azure.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AzureApiKeyModelConfigObject, AzureApiKeyModelConfigObjectFromRaw>)
)]
public sealed record class AzureApiKeyModelConfigObject : JsonModel
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
    public required AzureApiKeyModelConfigObjectProviderOptions ProviderOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AzureApiKeyModelConfigObjectProviderOptions>(
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

    public AzureApiKeyModelConfigObject()
    {
        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureApiKeyModelConfigObject(AzureApiKeyModelConfigObject azureApiKeyModelConfigObject)
        : base(azureApiKeyModelConfigObject) { }
#pragma warning restore CS8618

    public AzureApiKeyModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureApiKeyModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureApiKeyModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static AzureApiKeyModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureApiKeyModelConfigObjectFromRaw : IFromRawJson<AzureApiKeyModelConfigObject>
{
    /// <inheritdoc/>
    public AzureApiKeyModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureApiKeyModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure provider-specific model configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AzureApiKeyModelConfigObjectProviderOptions,
        AzureApiKeyModelConfigObjectProviderOptionsFromRaw
    >)
)]
public sealed record class AzureApiKeyModelConfigObjectProviderOptions : JsonModel
{
    /// <summary>
    /// Azure OpenAI provider-specific settings
    /// </summary>
    public required AzureApiKeyModelConfigObjectProviderOptionsAzure Azure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AzureApiKeyModelConfigObjectProviderOptionsAzure>(
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

    public AzureApiKeyModelConfigObjectProviderOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureApiKeyModelConfigObjectProviderOptions(
        AzureApiKeyModelConfigObjectProviderOptions azureApiKeyModelConfigObjectProviderOptions
    )
        : base(azureApiKeyModelConfigObjectProviderOptions) { }
#pragma warning restore CS8618

    public AzureApiKeyModelConfigObjectProviderOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureApiKeyModelConfigObjectProviderOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureApiKeyModelConfigObjectProviderOptionsFromRaw.FromRawUnchecked"/>
    public static AzureApiKeyModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AzureApiKeyModelConfigObjectProviderOptions(
        AzureApiKeyModelConfigObjectProviderOptionsAzure azure
    )
        : this()
    {
        this.Azure = azure;
    }
}

class AzureApiKeyModelConfigObjectProviderOptionsFromRaw
    : IFromRawJson<AzureApiKeyModelConfigObjectProviderOptions>
{
    /// <inheritdoc/>
    public AzureApiKeyModelConfigObjectProviderOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureApiKeyModelConfigObjectProviderOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure OpenAI provider-specific settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AzureApiKeyModelConfigObjectProviderOptionsAzure,
        AzureApiKeyModelConfigObjectProviderOptionsAzureFromRaw
    >)
)]
public sealed record class AzureApiKeyModelConfigObjectProviderOptionsAzure : JsonModel
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

    public AzureApiKeyModelConfigObjectProviderOptionsAzure() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureApiKeyModelConfigObjectProviderOptionsAzure(
        AzureApiKeyModelConfigObjectProviderOptionsAzure azureApiKeyModelConfigObjectProviderOptionsAzure
    )
        : base(azureApiKeyModelConfigObjectProviderOptionsAzure) { }
#pragma warning restore CS8618

    public AzureApiKeyModelConfigObjectProviderOptionsAzure(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureApiKeyModelConfigObjectProviderOptionsAzure(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureApiKeyModelConfigObjectProviderOptionsAzureFromRaw.FromRawUnchecked"/>
    public static AzureApiKeyModelConfigObjectProviderOptionsAzure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureApiKeyModelConfigObjectProviderOptionsAzureFromRaw
    : IFromRawJson<AzureApiKeyModelConfigObjectProviderOptionsAzure>
{
    /// <inheritdoc/>
    public AzureApiKeyModelConfigObjectProviderOptionsAzure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureApiKeyModelConfigObjectProviderOptionsAzure.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<GenericModelConfigObject, GenericModelConfigObjectFromRaw>)
)]
public sealed record class GenericModelConfigObject : JsonModel
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
    public ApiEnum<string, Provider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>("provider");
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

    public GenericModelConfigObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GenericModelConfigObject(GenericModelConfigObject genericModelConfigObject)
        : base(genericModelConfigObject) { }
#pragma warning restore CS8618

    public GenericModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GenericModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GenericModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static GenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GenericModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class GenericModelConfigObjectFromRaw : IFromRawJson<GenericModelConfigObject>
{
    /// <inheritdoc/>
    public GenericModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GenericModelConfigObject.FromRawUnchecked(rawData);
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => Provider.OpenAI,
            "anthropic" => Provider.Anthropic,
            "google" => Provider.Google,
            "microsoft" => Provider.Microsoft,
            "bedrock" => Provider.Bedrock,
            _ => (Provider)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Provider value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Provider.OpenAI => "openai",
                Provider.Anthropic => "anthropic",
                Provider.Google => "google",
                Provider.Microsoft => "microsoft",
                Provider.Bedrock => "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(VariableConverter))]
public record class Variable : ModelBase
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

    public Variable(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Variable(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Variable(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Variable(UnionMember3 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Variable(JsonElement element)
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
    /// type <see cref="UnionMember3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember3(out var value)) {
    ///     // `value` is of type `UnionMember3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember3([NotNullWhen(true)] out UnionMember3? value)
    {
        value = this.Value as UnionMember3;
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
    ///     (UnionMember3 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<UnionMember3> unionMember3
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
            case UnionMember3 value:
                unionMember3(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of Variable"
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
    ///     (UnionMember3 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<UnionMember3, T> unionMember3
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            UnionMember3 value => unionMember3(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of Variable"
            ),
        };
    }

    public static implicit operator Variable(string value) => new(value);

    public static implicit operator Variable(double value) => new(value);

    public static implicit operator Variable(bool value) => new(value);

    public static implicit operator Variable(UnionMember3 value) => new(value);

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
            throw new StagehandInvalidDataException("Data did not match any variant of Variable");
        }
        this.Switch((_) => { }, (_) => { }, (_) => { }, (unionMember3) => unionMember3.Validate());
    }

    public virtual bool Equals(Variable? other) =>
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
            UnionMember3 _ => 3,
            _ => -1,
        };
    }
}

sealed class VariableConverter : JsonConverter<Variable>
{
    public override Variable? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember3>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Variable value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionMember3, UnionMember3FromRaw>))]
public sealed record class UnionMember3 : JsonModel
{
    public required UnionMember3Value Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnionMember3Value>("value");
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

    public UnionMember3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember3(UnionMember3 unionMember3)
        : base(unionMember3) { }
#pragma warning restore CS8618

    public UnionMember3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember3FromRaw.FromRawUnchecked"/>
    public static UnionMember3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember3(UnionMember3Value value)
        : this()
    {
        this.Value = value;
    }
}

class UnionMember3FromRaw : IFromRawJson<UnionMember3>
{
    /// <inheritdoc/>
    public UnionMember3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember3.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember3ValueConverter))]
public record class UnionMember3Value : ModelBase
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

    public UnionMember3Value(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnionMember3Value(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnionMember3Value(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnionMember3Value(JsonElement element)
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
                    "Data did not match any variant of UnionMember3Value"
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
                "Data did not match any variant of UnionMember3Value"
            ),
        };
    }

    public static implicit operator UnionMember3Value(string value) => new(value);

    public static implicit operator UnionMember3Value(double value) => new(value);

    public static implicit operator UnionMember3Value(bool value) => new(value);

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
                "Data did not match any variant of UnionMember3Value"
            );
        }
    }

    public virtual bool Equals(UnionMember3Value? other) =>
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

sealed class UnionMember3ValueConverter : JsonConverter<UnionMember3Value>
{
    public override UnionMember3Value? Read(
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
        UnionMember3Value value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Whether to stream the response via SSE
/// </summary>
[JsonConverter(typeof(XStreamResponseConverter))]
public enum XStreamResponse
{
    True,
    False,
}

sealed class XStreamResponseConverter : JsonConverter<XStreamResponse>
{
    public override XStreamResponse Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => XStreamResponse.True,
            "false" => XStreamResponse.False,
            _ => (XStreamResponse)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XStreamResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XStreamResponse.True => "true",
                XStreamResponse.False => "false",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
