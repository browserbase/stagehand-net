using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionStartResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new() { Available = true, SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" },
            Success = SessionStartResponseSuccess.True,
        };

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };
        ApiEnum<bool, SessionStartResponseSuccess> expectedSuccess =
            SessionStartResponseSuccess.True;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new() { Available = true, SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" },
            Success = SessionStartResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new() { Available = true, SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" },
            Success = SessionStartResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(json);
        Assert.NotNull(deserialized);

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };
        ApiEnum<bool, SessionStartResponseSuccess> expectedSuccess =
            SessionStartResponseSuccess.True;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new() { Available = true, SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" },
            Success = SessionStartResponseSuccess.True,
        };

        model.Validate();
    }
}

public class SessionStartResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        bool expectedAvailable = true;
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";

        Assert.Equal(expectedAvailable, model.Available);
        Assert.Equal(expectedSessionID, model.SessionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponseData>(json);
        Assert.NotNull(deserialized);

        bool expectedAvailable = true;
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";

        Assert.Equal(expectedAvailable, deserialized.Available);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        model.Validate();
    }
}

public class SessionStartResponseSuccessTest : TestBase
{
    [Theory]
    [InlineData(SessionStartResponseSuccess.True)]
    public void Validation_Works(SessionStartResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionStartResponseSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionStartResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionStartResponseSuccess.True)]
    public void SerializationRoundtrip_Works(SessionStartResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionStartResponseSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionStartResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionStartResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionStartResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
