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

    public SessionObserveParamsOptionsModel(ModelConfig value, JsonElement? element = null)
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
                "Data did not match any variant of SessionObserveParamsOptionsModel"
            ),
        };
    }

    public static implicit operator SessionObserveParamsOptionsModel(ModelConfig value) =>
        new(value);

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
        this.Switch((config) => config.Validate(), (_) => { });
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
            ModelConfig _ => 0,
            string _ => 1,
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
        SessionObserveParamsOptionsModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
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
