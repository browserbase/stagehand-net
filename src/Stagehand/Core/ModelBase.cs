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
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, StreamEventType>(),
            new ApiEnumConverter<string, XLanguage>(),
            new ApiEnumConverter<string, XStreamResponse>(),
            new ApiEnumConverter<string, SessionEndParamsXLanguage>(),
            new ApiEnumConverter<string, SessionEndParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionExecuteParamsXLanguage>(),
            new ApiEnumConverter<string, SessionExecuteParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionExtractParamsXLanguage>(),
            new ApiEnumConverter<string, SessionExtractParamsXStreamResponse>(),
            new ApiEnumConverter<string, WaitUntil>(),
            new ApiEnumConverter<string, SessionNavigateParamsXLanguage>(),
            new ApiEnumConverter<string, SessionNavigateParamsXStreamResponse>(),
            new ApiEnumConverter<string, SessionObserveParamsXLanguage>(),
            new ApiEnumConverter<string, SessionObserveParamsXStreamResponse>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, FingerprintBrowser>(),
            new ApiEnumConverter<string, Device>(),
            new ApiEnumConverter<string, HTTPVersion>(),
            new ApiEnumConverter<string, OperatingSystem>(),
            new ApiEnumConverter<string, Region>(),
            new ApiEnumConverter<string, SessionStartParamsXLanguage>(),
            new ApiEnumConverter<string, SessionStartParamsXStreamResponse>(),
        },
    };

    private protected static readonly JsonSerializerOptions ToStringSerializerOptions = new(
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
