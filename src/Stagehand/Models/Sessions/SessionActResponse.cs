using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<SessionActResponse, SessionActResponseFromRaw>))]
public sealed record class SessionActResponse : ModelBase
{
    public required Data Data
    {
        get { return ModelBase.GetNotNullClass<Data>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required ApiEnum<bool, Success> Success
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<bool, Success>>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Success.Validate();
    }

    public SessionActResponse() { }

    public SessionActResponse(SessionActResponse sessionActResponse)
        : base(sessionActResponse) { }

    public SessionActResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionActResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionActResponseFromRaw.FromRawUnchecked"/>
    public static SessionActResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionActResponseFromRaw : IFromRaw<SessionActResponse>
{
    /// <inheritdoc/>
    public SessionActResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SessionActResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Data, DataFromRaw>))]
public sealed record class Data : ModelBase
{
    public required Result Result
    {
        get { return ModelBase.GetNotNullClass<Result>(this.RawData, "result"); }
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
        this.Result.Validate();
        _ = this.ActionID;
    }

    public Data() { }

    public Data(Data data)
        : base(data) { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Data(Result result)
        : this()
    {
        this.Result = result;
    }
}

class DataFromRaw : IFromRaw<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : ModelBase
{
    /// <summary>
    /// Description of the action that was performed
    /// </summary>
    public required string ActionDescription
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "actionDescription"); }
        init { ModelBase.Set(this._rawData, "actionDescription", value); }
    }

    /// <summary>
    /// List of actions that were executed
    /// </summary>
    public required IReadOnlyList<Action> Actions
    {
        get { return ModelBase.GetNotNullClass<List<Action>>(this.RawData, "actions"); }
        init { ModelBase.Set(this._rawData, "actions", value); }
    }

    /// <summary>
    /// Human-readable result message
    /// </summary>
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    /// <summary>
    /// Whether the action completed successfully
    /// </summary>
    public required bool Success
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActionDescription;
        foreach (var item in this.Actions)
        {
            item.Validate();
        }
        _ = this.Message;
        _ = this.Success;
    }

    public Result() { }

    public Result(Result result)
        : base(result) { }

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRaw<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SuccessConverter))]
public enum Success
{
    True,
}

sealed class SuccessConverter : JsonConverter<Success>
{
    public override Success Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => Success.True,
            _ => (Success)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Success value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Success.True => true,
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
