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
            Available = true,
            SessionID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        bool expectedAvailable = true;
        string expectedSessionID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedAvailable, model.Available);
        Assert.Equal(expectedSessionID, model.SessionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionStartResponse
        {
            Available = true,
            SessionID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Available = true,
            SessionID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionStartResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedAvailable = true;
        string expectedSessionID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedAvailable, deserialized.Available);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionStartResponse
        {
            Available = true,
            SessionID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }
}
