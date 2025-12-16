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
/// Default extraction result
/// </summary>
[JsonConverter(typeof(SessionExtractResponseConverter))]
public record class SessionExtractResponse
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SessionExtractResponse(Extraction value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SessionExtractResponse(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? json = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._json = json;
    }

    public SessionExtractResponse(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Extraction"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtraction(out var value)) {
    ///     // `value` is of type `Extraction`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtraction([NotNullWhen(true)] out Extraction? value)
    {
        value = this.Value as Extraction;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyDictionary<string, JsonElement>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary<string, JsonElement>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
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
    ///     (Extraction value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Extraction> extraction,
        System::Action<IReadOnlyDictionary<string, JsonElement>> custom
    )
    {
        switch (this.Value)
        {
            case Extraction value:
                extraction(value);
                break;
            case Dictionary<string, JsonElement> value:
                custom(value);
                break;
            default:
                throw new StagehandInvalidDataException(
                    "Data did not match any variant of SessionExtractResponse"
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
    ///     (Extraction value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Extraction, T> extraction,
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> custom
    )
    {
        return this.Value switch
        {
            Extraction value => extraction(value),
            IReadOnlyDictionary<string, JsonElement> value => custom(value),
            _ => throw new StagehandInvalidDataException(
                "Data did not match any variant of SessionExtractResponse"
            ),
        };
    }

    public static implicit operator SessionExtractResponse(Extraction value) => new(value);

    public static implicit operator SessionExtractResponse(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

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
                "Data did not match any variant of SessionExtractResponse"
            );
        }
        this.Switch((extraction) => extraction.Validate(), (_) => { });
    }

    public virtual bool Equals(SessionExtractResponse? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SessionExtractResponseConverter : JsonConverter<SessionExtractResponse>
{
    public override SessionExtractResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Extraction>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                json,
                options
            );
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
        SessionExtractResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Default extraction result
/// </summary>
[JsonConverter(typeof(ModelConverter<Extraction, ExtractionFromRaw>))]
public sealed record class Extraction : ModelBase
{
    public string? ExtractionValue
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "extraction"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "extraction", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExtractionValue;
    }

    public Extraction() { }

    public Extraction(Extraction extraction)
        : base(extraction) { }

    public Extraction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Extraction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionFromRaw.FromRawUnchecked"/>
    public static Extraction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionFromRaw : IFromRaw<Extraction>
{
    /// <inheritdoc/>
    public Extraction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Extraction.FromRawUnchecked(rawData);
}
