using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExecuteAgentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExecuteAgentResponse
        {
            Message = "message",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string expectedMessage = "message";
        List<JsonElement> expectedSteps = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedMessage, model.Message);
        Assert.NotNull(model.Steps);
        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSteps[i], model.Steps[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExecuteAgentResponse
        {
            Message = "message",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteAgentResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExecuteAgentResponse
        {
            Message = "message",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteAgentResponse>(json);
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        List<JsonElement> expectedSteps = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.NotNull(deserialized.Steps);
        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSteps[i], deserialized.Steps[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExecuteAgentResponse
        {
            Message = "message",
            Steps = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExecuteAgentResponse { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionExecuteAgentResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExecuteAgentResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Steps = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionExecuteAgentResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Steps = null,
        };

        model.Validate();
    }
}
