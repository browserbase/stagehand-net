using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionEndResponse, SessionEndResponseFromRaw>))]
public sealed record class SessionEndResponse : ModelBase
{
    public required ApiEnum<bool, SessionEndResponseSuccess> Success
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<bool, SessionEndResponseSuccess>>(
                this.RawData,
                "success"
            );
        }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Success.Validate();
    }

    public SessionEndResponse() { }

    public SessionEndResponse(SessionEndResponse sessionEndResponse)
        : base(sessionEndResponse) { }

    public SessionEndResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionEndResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionEndResponseFromRaw.FromRawUnchecked"/>
    public static SessionEndResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionEndResponse(ApiEnum<bool, SessionEndResponseSuccess> success)
        : this()
    {
        this.Success = success;
    }
}

class SessionEndResponseFromRaw : IFromRaw<SessionEndResponse>
{
    /// <inheritdoc/>
    public SessionEndResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SessionEndResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SessionEndResponseSuccessConverter))]
public enum SessionEndResponseSuccess
{
    True,
}

sealed class SessionEndResponseSuccessConverter : JsonConverter<SessionEndResponseSuccess>
{
    public override SessionEndResponseSuccess Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => SessionEndResponseSuccess.True,
            _ => (SessionEndResponseSuccess)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionEndResponseSuccess value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionEndResponseSuccess.True => true,
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
