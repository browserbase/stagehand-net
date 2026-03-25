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
/// Server-Sent Event emitted during streaming responses. Events are sent as `event:
/// &lt;status&gt;\ndata: &lt;JSON&gt;\n\n`, where the JSON payload has the shape
/// `{ data, type, id }`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StreamEvent, StreamEventFromRaw>))]
public sealed record class StreamEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Type of stream event - system events or log messages
    /// </summary>
    public required ApiEnum<string, StreamEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StreamEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Data.Validate();
        this.Type.Validate();
    }

    public StreamEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamEvent(StreamEvent streamEvent)
        : base(streamEvent) { }
#pragma warning restore CS8618

    public StreamEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StreamEventFromRaw.FromRawUnchecked"/>
    public static StreamEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StreamEventFromRaw : IFromRawJson<StreamEvent>
{
    /// <inheritdoc/>
    public StreamEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StreamEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Data(StreamEventSystemDataOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(StreamEventLogDataOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="StreamEventSystemDataOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStreamEventSystemDataOutput(out var value)) {
    ///     // `value` is of type `StreamEventSystemDataOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStreamEventSystemDataOutput(
        [NotNullWhen(true)] out StreamEventSystemDataOutput? value
    )
    {
        value = this.Value as StreamEventSystemDataOutput;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="StreamEventLogDataOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStreamEventLogDataOutput(out var value)) {
    ///     // `value` is of type `StreamEventLogDataOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStreamEventLogDataOutput(
        [NotNullWhen(true)] out StreamEventLogDataOutput? value
    )
    {
        value = this.Value as StreamEventLogDataOutput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (StreamEventSystemDataOutput value) =&gt; {...},
    ///     (StreamEventLogDataOutput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<StreamEventSystemDataOutput> streamEventSystemDataOutput,
        System::Action<StreamEventLogDataOutput> streamEventLogDataOutput
    )
    {
        switch (this.Value)
        {
            case StreamEventSystemDataOutput value:
                streamEventSystemDataOutput(value);
                break;
            case StreamEventLogDataOutput value:
                streamEventLogDataOutput(value);
                break;
            default:
                throw new StagehandInvalidDataException("Data did not match any variant of Data");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (StreamEventSystemDataOutput value) =&gt; {...},
    ///     (StreamEventLogDataOutput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<StreamEventSystemDataOutput, T> streamEventSystemDataOutput,
        System::Func<StreamEventLogDataOutput, T> streamEventLogDataOutput
    )
    {
        return this.Value switch
        {
            StreamEventSystemDataOutput value => streamEventSystemDataOutput(value),
            StreamEventLogDataOutput value => streamEventLogDataOutput(value),
            _ => throw new StagehandInvalidDataException("Data did not match any variant of Data"),
        };
    }

    public static implicit operator Data(StreamEventSystemDataOutput value) => new(value);

    public static implicit operator Data(StreamEventLogDataOutput value) => new(value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StagehandInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch(
            (streamEventSystemDataOutput) => streamEventSystemDataOutput.Validate(),
            (streamEventLogDataOutput) => streamEventLogDataOutput.Validate()
        );
    }

    public virtual bool Equals(Data? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            StreamEventSystemDataOutput _ => 0,
            StreamEventLogDataOutput _ => 1,
            _ => -1,
        };
    }
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<StreamEventLogDataOutput>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<StreamEventSystemDataOutput>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StagehandInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<StreamEventSystemDataOutput, StreamEventSystemDataOutputFromRaw>)
)]
public sealed record class StreamEventSystemDataOutput : JsonModel
{
    /// <summary>
    /// Current status of the streaming operation
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Error message (present when status is 'error')
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Operation result (present when status is 'finished')
    /// </summary>
    public JsonElement? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("result");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.Error;
        _ = this.Result;
    }

    public StreamEventSystemDataOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamEventSystemDataOutput(StreamEventSystemDataOutput streamEventSystemDataOutput)
        : base(streamEventSystemDataOutput) { }
#pragma warning restore CS8618

    public StreamEventSystemDataOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamEventSystemDataOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StreamEventSystemDataOutputFromRaw.FromRawUnchecked"/>
    public static StreamEventSystemDataOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StreamEventSystemDataOutput(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class StreamEventSystemDataOutputFromRaw : IFromRawJson<StreamEventSystemDataOutput>
{
    /// <inheritdoc/>
    public StreamEventSystemDataOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StreamEventSystemDataOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the streaming operation
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Starting,
    Connected,
    Running,
    Finished,
    Error,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "starting" => Status.Starting,
            "connected" => Status.Connected,
            "running" => Status.Running,
            "finished" => Status.Finished,
            "error" => Status.Error,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Starting => "starting",
                Status.Connected => "connected",
                Status.Running => "running",
                Status.Finished => "finished",
                Status.Error => "error",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<StreamEventLogDataOutput, StreamEventLogDataOutputFromRaw>)
)]
public sealed record class StreamEventLogDataOutput : JsonModel
{
    /// <summary>
    /// Log message from the operation
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public JsonElement Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("running")))
        {
            throw new StagehandInvalidDataException("Invalid value given for constant");
        }
    }

    public StreamEventLogDataOutput()
    {
        this.Status = JsonSerializer.SerializeToElement("running");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamEventLogDataOutput(StreamEventLogDataOutput streamEventLogDataOutput)
        : base(streamEventLogDataOutput) { }
#pragma warning restore CS8618

    public StreamEventLogDataOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Status = JsonSerializer.SerializeToElement("running");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamEventLogDataOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StreamEventLogDataOutputFromRaw.FromRawUnchecked"/>
    public static StreamEventLogDataOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StreamEventLogDataOutput(string message)
        : this()
    {
        this.Message = message;
    }
}

class StreamEventLogDataOutputFromRaw : IFromRawJson<StreamEventLogDataOutput>
{
    /// <inheritdoc/>
    public StreamEventLogDataOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StreamEventLogDataOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of stream event - system events or log messages
/// </summary>
[JsonConverter(typeof(StreamEventTypeConverter))]
public enum StreamEventType
{
    System,
    Log,
}

sealed class StreamEventTypeConverter : JsonConverter<StreamEventType>
{
    public override StreamEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "system" => StreamEventType.System,
            "log" => StreamEventType.Log,
            _ => (StreamEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StreamEventType.System => "system",
                StreamEventType.Log => "log",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
