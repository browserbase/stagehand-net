using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionStartResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new()
            {
                Available = true,
                ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            },
            Success = true,
        };

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new()
            {
                Available = true,
                ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            },
            Success = true,
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
            Data = new()
            {
                Available = true,
                ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(json);
        Assert.NotNull(deserialized);

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new()
            {
                Available = true,
                ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            },
            Success = true,
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
            ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        bool expectedAvailable = true;
        string expectedConnectURL = "wss://connect.browserbase.com/?signingKey=abc123";
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";

        Assert.Equal(expectedAvailable, model.Available);
        Assert.Equal(expectedConnectURL, model.ConnectURL);
        Assert.Equal(expectedSessionID, model.SessionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
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
            ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponseData>(json);
        Assert.NotNull(deserialized);

        bool expectedAvailable = true;
        string expectedConnectURL = "wss://connect.browserbase.com/?signingKey=abc123";
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";

        Assert.Equal(expectedAvailable, deserialized.Available);
        Assert.Equal(expectedConnectURL, deserialized.ConnectURL);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            ConnectURL = "wss://connect.browserbase.com/?signingKey=abc123",
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        model.Validate();
    }
}
