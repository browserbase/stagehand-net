using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionEndResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionEndResponse { };

        JsonElement expectedSuccess = JsonSerializer.Deserialize<JsonElement>("true");

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionEndResponse { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionEndResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionEndResponse { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionEndResponse>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedSuccess = JsonSerializer.Deserialize<JsonElement>("true");

        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionEndResponse { };

        model.Validate();
    }
}
