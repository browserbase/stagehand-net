using System.Text.Json;
using Stagehand.Exceptions;

namespace Stagehand.Core;

/// <summary>
/// Helper class for deserializing &lt;c&gt;MultipartJsonElement&lt;/c&gt; objects.
/// This handles edge-cases around nullability and reference/value types.
/// </summary>
sealed class WrappedMultipartJsonSerializer
{
    public static T GetNotNullClass<T>(MultipartJsonElement element, string name)
        where T : class
    {
        T deserialized;
        try
        {
            deserialized =
                MultipartJsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
                ?? throw new StagehandInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T GetNotNullStruct<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        T deserialized;
        try
        {
            deserialized =
                MultipartJsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
                ?? throw new StagehandInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableClass<T>(MultipartJsonElement element, string name)
        where T : class
    {
        T? deserialized;
        try
        {
            deserialized = MultipartJsonSerializer.Deserialize<T?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableStruct<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        T? deserialized;
        try
        {
            deserialized = MultipartJsonSerializer.Deserialize<T?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        catch (JsonException e)
        {
            throw new StagehandInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }
}
