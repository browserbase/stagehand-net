using System.Text.Json;
using Stagehand.Core;
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
                CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
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
                CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
                CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SessionStartResponseData expectedData = new()
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
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
                CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionStartResponse
        {
            Data = new()
            {
                Available = true,
                SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
                CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
            },
            Success = true,
        };

        SessionStartResponse copied = new(model);

        Assert.Equal(model, copied);
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
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        bool expectedAvailable = true;
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedCdpUrl = "wss://connect.browserbase.com/?signingKey=abc123";

        Assert.Equal(expectedAvailable, model.Available);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedCdpUrl, model.CdpUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAvailable = true;
        string expectedSessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedCdpUrl = "wss://connect.browserbase.com/?signingKey=abc123";

        Assert.Equal(expectedAvailable, deserialized.Available);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedCdpUrl, deserialized.CdpUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
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

        Assert.Null(model.CdpUrl);
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

            CdpUrl = null,
        };

        Assert.Null(model.CdpUrl);
        Assert.True(model.RawData.ContainsKey("cdpUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",

            CdpUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionStartResponseData
        {
            Available = true,
            SessionID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            CdpUrl = "wss://connect.browserbase.com/?signingKey=abc123",
        };

        SessionStartResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
