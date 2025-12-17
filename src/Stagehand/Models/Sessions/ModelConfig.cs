using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

/// <summary>
/// Model name string with provider prefix (e.g., 'openai/gpt-5-nano', 'anthropic/claude-4.5-opus')
/// </summary>
[JsonConverter(typeof(ModelConfigConverter))]
public record class ModelConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ModelConfig(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ModelConfig(ModelConfigObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ModelConfig(JsonElement json)
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
    /// if (instance.TryPickName(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickName([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ModelConfigObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickObject(out var value)) {
    ///     // `value` is of type `ModelConfigObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickObject([NotNullWhen(true)] out ModelConfigObject? value)
    {
        value = this.Value as ModelConfigObject;
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
    ///     (ModelConfigObject value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @modelName, System::Action<ModelConfigObject> object1)
    {
        switch (this.Value)
        {
            case string value:
                @modelName(value);
                break;
            case ModelConfigObject value:
                object1(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of ModelConfig"
                );
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
    ///     (ModelConfigObject value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @modelName,
        System::Func<ModelConfigObject, T> object1
    )
    {
        return this.Value switch
        {
            string value => @modelName(value),
            ModelConfigObject value => object1(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfig"
            ),
        };
    }

    public static implicit operator ModelConfig(string value) => new(value);

    public static implicit operator ModelConfig(ModelConfigObject value) => new(value);

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
            throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfig"
            );
        }
        this.Switch((_) => { }, (object1) => object1.Validate());
    }

    public virtual bool Equals(ModelConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ModelConfigConverter : JsonConverter<ModelConfig>
{
    public override ModelConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ModelConfigObject>(json, options);
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

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<ModelConfigObject, ModelConfigObjectFromRaw>))]
public sealed record class ModelConfigObject : ModelBase
{
    /// <summary>
    /// Model name string without prefix (e.g., 'gpt-5-nano', 'claude-4.5-opus')
    /// </summary>
    public required string ModelName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "modelName"); }
        init { ModelBase.Set(this._rawData, "modelName", value); }
    }

    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? APIKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "apiKey"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "apiKey", value);
        }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "baseURL"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "baseURL", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ModelName;
        _ = this.APIKey;
        _ = this.BaseURL;
    }

    public ModelConfigObject() { }

    public ModelConfigObject(ModelConfigObject modelConfigObject)
        : base(modelConfigObject) { }

    public ModelConfigObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfigObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigObjectFromRaw.FromRawUnchecked"/>
    public static ModelConfigObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfigObject(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class ModelConfigObjectFromRaw : IFromRaw<ModelConfigObject>
{
    /// <inheritdoc/>
    public ModelConfigObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelConfigObject.FromRawUnchecked(rawData);
}
