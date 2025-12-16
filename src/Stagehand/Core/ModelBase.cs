using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    protected ModelBase(ModelBase modelBase)
    {
        this._rawData = [.. modelBase._rawData];
    }

    /// <summary>
    /// The backing JSON properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, ModelConfigProvider>(),
            new ApiEnumConverter<string, XStreamResponse>(),
            new ApiEnumConverter<string, Provider>(),
            new ApiEnumConverter<string, SessionExecuteAgentParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionExtractParamsXStreamResponse>(),
            new ApiEnumConverter<string, WaitUntil>(),
            new ApiEnumConverter<string, SessionNavigateParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionObserveParamsXStreamResponse>(),
            new ApiEnumConverter<string, Env>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new StagehandInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new StagehandInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new StagehandInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new StagehandInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StagehandInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
///
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    ///
    /// <para>This method is useful for constructing an instance from already serialized
    /// data or for sending arbitrary data to the API (e.g. for undocumented or not
    /// yet supported properties or values).</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
