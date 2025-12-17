using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionNavigateResponse, SessionNavigateResponseFromRaw>))]
public sealed record class SessionNavigateResponse : ModelBase
{
    public required SessionNavigateResponseData Data
    {
        get { return ModelBase.GetNotNullClass<SessionNavigateResponseData>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required ApiEnum<bool, SessionNavigateResponseSuccess> Success
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<bool, SessionNavigateResponseSuccess>>(
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

    public SessionNavigateResponse() { }

    public SessionNavigateResponse(SessionNavigateResponse sessionNavigateResponse)
        : base(sessionNavigateResponse) { }

    public SessionNavigateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionNavigateResponseFromRaw.FromRawUnchecked"/>
    public static SessionNavigateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionNavigateResponseFromRaw : IFromRaw<SessionNavigateResponse>
{
    /// <inheritdoc/>
    public SessionNavigateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionNavigateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<SessionNavigateResponseData, SessionNavigateResponseDataFromRaw>)
)]
public sealed record class SessionNavigateResponseData : ModelBase
{
    /// <summary>
    /// Navigation response (Playwright Response object or null)
    /// </summary>
    public required JsonElement Result
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "result"); }
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
        _ = this.Result;
        _ = this.ActionID;
    }

    public SessionNavigateResponseData() { }

    public SessionNavigateResponseData(SessionNavigateResponseData sessionNavigateResponseData)
        : base(sessionNavigateResponseData) { }

    public SessionNavigateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionNavigateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionNavigateResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionNavigateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SessionNavigateResponseData(JsonElement result)
        : this()
    {
        this.Result = result;
    }
}

class SessionNavigateResponseDataFromRaw : IFromRaw<SessionNavigateResponseData>
{
    /// <inheritdoc/>
    public SessionNavigateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionNavigateResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SessionNavigateResponseSuccessConverter))]
public enum SessionNavigateResponseSuccess
{
    True,
}

sealed class SessionNavigateResponseSuccessConverter : JsonConverter<SessionNavigateResponseSuccess>
{
    public override SessionNavigateResponseSuccess Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => SessionNavigateResponseSuccess.True,
            _ => (SessionNavigateResponseSuccess)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionNavigateResponseSuccess value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SessionNavigateResponseSuccess.True => true,
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
