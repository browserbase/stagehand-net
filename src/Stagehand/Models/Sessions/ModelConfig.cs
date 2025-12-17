using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

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

    public ModelConfig(UnionMember1 value, JsonElement? json = null)
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
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
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
    ///     (UnionMember1 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<UnionMember1> unionMember1)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
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
    ///     (UnionMember1 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<UnionMember1, T> unionMember1)
    {
        return this.Value switch
        {
            string value => @string(value),
            UnionMember1 value => unionMember1(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of ModelConfig"
            ),
        };
    }

    public static implicit operator ModelConfig(string value) => new(value);

    public static implicit operator ModelConfig(UnionMember1 value) => new(value);

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
        this.Switch((_) => { }, (unionMember1) => unionMember1.Validate());
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
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(json, options);
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

[JsonConverter(typeof(ModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : ModelBase
{
    public required string ModelName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "modelName"); }
        init { ModelBase.Set(this._rawData, "modelName", value); }
    }

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

    public UnionMember1() { }

    public UnionMember1(UnionMember1 unionMember1)
        : base(unionMember1) { }

    public UnionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnionMember1(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class UnionMember1FromRaw : IFromRaw<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember1.FromRawUnchecked(rawData);
}
