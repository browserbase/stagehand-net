using System.Text.Json;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, ModelConfigProvider>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, StreamEventType>(),
            new ApiEnumConverter<string, XStreamResponse>(),
            new ApiEnumConverter<string, SessionEndParamsXStreamResponse>(),
            new ApiEnumConverter<string, Mode>(),
            new ApiEnumConverter<string, Provider>(),
            new ApiEnumConverter<string, SessionExecuteParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionExtractParamsXStreamResponse>(),
            new ApiEnumConverter<string, WaitUntil>(),
            new ApiEnumConverter<string, SessionNavigateParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionObserveParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionReplayParamsXStreamResponse>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, FingerprintBrowser>(),
            new ApiEnumConverter<string, Device>(),
            new ApiEnumConverter<string, HttpVersion>(),
            new ApiEnumConverter<string, OperatingSystem>(),
            new ApiEnumConverter<string, Region>(),
            new ApiEnumConverter<double, Verbose>(),
            new ApiEnumConverter<string, SessionStartParamsXStreamResponse>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

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
