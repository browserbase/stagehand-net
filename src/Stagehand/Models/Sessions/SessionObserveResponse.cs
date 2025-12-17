using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionObserveResponse, SessionObserveResponseFromRaw>))]
public sealed record class SessionObserveResponse : ModelBase
{
    public required SessionObserveResponseData Data
    {
        get { return ModelBase.GetNotNullClass<SessionObserveResponseData>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required ApiEnum<bool, SessionObserveResponseSuccess> Success
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<bool, SessionObserveResponseSuccess>>(
                this.RawData,
                "success"
            );
        }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Success.Validate();
    }

    public SessionObserveResponse() { }

    public SessionObserveResponse(SessionObserveResponse sessionObserveResponse)
        : base(sessionObserveResponse) { }

    public SessionObserveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveResponseFromRaw.FromRawUnchecked"/>
    public static SessionObserveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionObserveResponseFromRaw : IFromRaw<SessionObserveResponse>
{
    /// <inheritdoc/>
    public SessionObserveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<SessionObserveResponseData, SessionObserveResponseDataFromRaw>)
)]
public sealed record class SessionObserveResponseData : ModelBase
{
    public required IReadOnlyList<Action> Result
    {
        get { return ModelBase.GetNotNullClass<List<Action>>(this.RawData, "result"); }
        init { ModelBase.Set(this._rawData, "result", value); }
    }

    /// <summary>
    /// Action ID for tracking
    /// </summary>
    public string? ActionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "actionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "actionId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        _ = this.ActionID;
    }

    public SessionObserveResponseData() { }

    public SessionObserveResponseData(SessionObserveResponseData sessionObserveResponseData)
        : base(sessionObserveResponseData) { }

    public SessionObserveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionObserveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionObserveResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionObserveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionObserveResponseData(List<Action> result)
        : this()
    {
        this.Result = result;
    }
}

class SessionObserveResponseDataFromRaw : IFromRaw<SessionObserveResponseData>
{
    /// <inheritdoc/>
    public SessionObserveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionObserveResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SessionObserveResponseSuccessConverter))]
public enum SessionObserveResponseSuccess
{
    True,
}

sealed class SessionObserveResponseSuccessConverter : JsonConverter<SessionObserveResponseSuccess>
{
    public override SessionObserveResponseSuccess Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => SessionObserveResponseSuccess.True,
            _ => (SessionObserveResponseSuccess)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionObserveResponseSuccess value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionObserveResponseSuccess.True => true,
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
