using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class StreamEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StreamEvent
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Data = new StreamEventSystemDataOutput()
            {
                Status = Status.Starting,
                Error = "error",
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Type = StreamEventType.System,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        Data expectedData = new StreamEventSystemDataOutput()
        {
            Status = Status.Starting,
            Error = "error",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        ApiEnum<string, StreamEventType> expectedType = StreamEventType.System;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StreamEvent
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Data = new StreamEventSystemDataOutput()
            {
                Status = Status.Starting,
                Error = "error",
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Type = StreamEventType.System,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StreamEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StreamEvent
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Data = new StreamEventSystemDataOutput()
            {
                Status = Status.Starting,
                Error = "error",
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Type = StreamEventType.System,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StreamEvent>(json);
        Assert.NotNull(deserialized);

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        Data expectedData = new StreamEventSystemDataOutput()
        {
            Status = Status.Starting,
            Error = "error",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        ApiEnum<string, StreamEventType> expectedType = StreamEventType.System;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StreamEvent
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Data = new StreamEventSystemDataOutput()
            {
                Status = Status.Starting,
                Error = "error",
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
            Type = StreamEventType.System,
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void stream_event_system_data_outputValidation_Works()
    {
        Data value = new(
            new StreamEventSystemDataOutput()
            {
                Status = Status.Starting,
                Error = "error",
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void stream_event_log_data_outputValidation_Works()
    {
        Data value = new(new StreamEventLogDataOutput("message"));
        value.Validate();
    }

    [Fact]
    public void stream_event_system_data_outputSerializationRoundtrip_Works()
    {
        Data value = new(
            new StreamEventSystemDataOutput()
            {
                Status = Status.Starting,
                Error = "error",
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stream_event_log_data_outputSerializationRoundtrip_Works()
    {
        Data value = new(new StreamEventLogDataOutput("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(value, deserialized);
    }
}

public class StreamEventSystemDataOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StreamEventSystemDataOutput
        {
            Status = Status.Starting,
            Error = "error",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ApiEnum<string, Status> expectedStatus = Status.Starting;
        string expectedError = "error";
        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedError, model.Error);
        Assert.NotNull(model.Result);
        Assert.True(JsonElement.DeepEquals(expectedResult, model.Result.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StreamEventSystemDataOutput
        {
            Status = Status.Starting,
            Error = "error",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StreamEventSystemDataOutput>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StreamEventSystemDataOutput
        {
            Status = Status.Starting,
            Error = "error",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StreamEventSystemDataOutput>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Starting;
        string expectedError = "error";
        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.NotNull(deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedResult, deserialized.Result.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StreamEventSystemDataOutput
        {
            Status = Status.Starting,
            Error = "error",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StreamEventSystemDataOutput { Status = Status.Starting };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StreamEventSystemDataOutput { Status = Status.Starting };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StreamEventSystemDataOutput
        {
            Status = Status.Starting,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Result = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StreamEventSystemDataOutput
        {
            Status = Status.Starting,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Result = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Starting)]
    [InlineData(Status.Connected)]
    [InlineData(Status.Running)]
    [InlineData(Status.Finished)]
    [InlineData(Status.Error)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Starting)]
    [InlineData(Status.Connected)]
    [InlineData(Status.Running)]
    [InlineData(Status.Finished)]
    [InlineData(Status.Error)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StreamEventLogDataOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StreamEventLogDataOutput { Message = "message" };

        string expectedMessage = "message";
        JsonElement expectedStatus = JsonSerializer.Deserialize<JsonElement>("\"running\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedStatus, model.Status));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StreamEventLogDataOutput { Message = "message" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StreamEventLogDataOutput>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StreamEventLogDataOutput { Message = "message" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<StreamEventLogDataOutput>(json);
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        JsonElement expectedStatus = JsonSerializer.Deserialize<JsonElement>("\"running\"");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedStatus, deserialized.Status));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StreamEventLogDataOutput { Message = "message" };

        model.Validate();
    }
}

public class StreamEventTypeTest : TestBase
{
    [Theory]
    [InlineData(StreamEventType.System)]
    [InlineData(StreamEventType.Log)]
    public void Validation_Works(StreamEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamEventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StreamEventType.System)]
    [InlineData(StreamEventType.Log)]
    public void SerializationRoundtrip_Works(StreamEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamEventType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
