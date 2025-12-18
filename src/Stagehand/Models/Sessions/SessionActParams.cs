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
/// Executes a browser action using natural language instructions or a predefined
/// Action object.
/// </summary>
public sealed record class SessionActParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
        get { return ModelBase.GetNotNullClass<Input>(this.RawBodyData, "input"); }
        init { ModelBase.Set(this._rawBodyData, "input", value); }
    }

    /// <summary>
    /// Target frame ID for the action
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

    public Options? Options
    {
        get { return ModelBase.GetNullableClass<Options>(this.RawBodyData, "options"); }
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
    /// Client SDK language
    /// </summary>
    public ApiEnum<string, XLanguage>? XLanguage
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, XLanguage>>(
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
    public ApiEnum<string, XStreamResponse>? XStreamResponse
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, XStreamResponse>>(
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

    public SessionActParams() { }

    public SessionActParams(SessionActParams sessionActParams)
        : base(sessionActParams)
    {
        this._rawBodyData = [.. sessionActParams._rawBodyData];
    }

    public SessionActParams(
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
    SessionActParams(
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
    public static SessionActParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/sessions/{0}/act", this.ID)
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

/// <summary>
/// Natural language instruction or Action object
/// </summary>
[JsonConverter(typeof(InputConverter))]
public record class Input
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Input(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Input(Action value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Input(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (string value) => {...},
    ///     (Action value) => {...}
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (string value) => {...},
    ///     (Action value) => {...}
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException("Data did not match any variant of Input");
        }
        this.Switch((_) => { }, (action) => action.Validate());
    }

    public virtual bool Equals(Input? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Action>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Input value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : ModelBase
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
    /// Timeout in ms for the action
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

    /// <summary>
    /// Variables to substitute in the action instruction
    /// </summary>
    public IReadOnlyDictionary<string, string>? Variables
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string>>(
                this.RawData,
                "variables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "variables", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model?.Validate();
        _ = this.Timeout;
        _ = this.Variables;
    }

    public Options() { }

    public Options(Options options)
        : base(options) { }

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRaw<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

/// <summary>
/// Client SDK language
/// </summary>
[JsonConverter(typeof(XLanguageConverter))]
public enum XLanguage
{
    Typescript,
    Python,
    Playground,
}

sealed class XLanguageConverter : JsonConverter<XLanguage>
{
    public override XLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "typescript" => XLanguage.Typescript,
            "python" => XLanguage.Python,
            "playground" => XLanguage.Playground,
            _ => (XLanguage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XLanguage.Typescript => "typescript",
                XLanguage.Python => "python",
                XLanguage.Playground => "playground",
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
