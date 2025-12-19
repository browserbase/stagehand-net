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
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
                CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
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
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
                CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
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
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
                CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(element);
        Assert.NotNull(deserialized);

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
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
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
                CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
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
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        bool expectedAvailable = true;
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedCdpURL = "wss://connect.browserbase.com/?signingKey=abc123";

        Assert.Equal(expectedAvailable, model.Available);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedCdpURL, model.CdpURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
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
            CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponseData>(element);
        Assert.NotNull(deserialized);

        bool expectedAvailable = true;
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedCdpURL = "wss://connect.browserbase.com/?signingKey=abc123";

        Assert.Equal(expectedAvailable, deserialized.Available);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedCdpURL, deserialized.CdpURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpURL = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        Assert.Null(model.CdpURL);
        Assert.False(model.RawData.ContainsKey("cdpUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",

            CdpURL = null,
        };

        Assert.Null(model.CdpURL);
        Assert.True(model.RawData.ContainsKey("cdpUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",

            CdpURL = null,
        };

        model.Validate();
    }
}
