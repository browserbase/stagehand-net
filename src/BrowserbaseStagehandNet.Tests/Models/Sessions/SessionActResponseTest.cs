using System.Collections.Generic;
using System.Text.Json;
using BrowserbaseStagehandNet.Models.Sessions;

namespace BrowserbaseStagehandNet.Tests.Models.Sessions;

public class SessionActResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionActResponse
        {
            Actions =
            [
                new()
                {
                    Arguments = ["string"],
                    Description = "description",
                    Method = "method",
                    Selector = "selector",
                    BackendNodeID = 0,
                },
            ],
            Message = "message",
            Success = true,
        };

        List<Action> expectedActions =
        [
            new()
            {
                Arguments = ["string"],
                Description = "description",
                Method = "method",
                Selector = "selector",
                BackendNodeID = 0,
            },
        ];
        string expectedMessage = "message";
        bool expectedSuccess = true;

        Assert.Equal(expectedActions.Count, model.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], model.Actions[i]);
        }
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionActResponse
        {
            Actions =
            [
                new()
                {
                    Arguments = ["string"],
                    Description = "description",
                    Method = "method",
                    Selector = "selector",
                    BackendNodeID = 0,
                },
            ],
            Message = "message",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionActResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionActResponse
        {
            Actions =
            [
                new()
                {
                    Arguments = ["string"],
                    Description = "description",
                    Method = "method",
                    Selector = "selector",
                    BackendNodeID = 0,
                },
            ],
            Message = "message",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionActResponse>(json);
        Assert.NotNull(deserialized);

        List<Action> expectedActions =
        [
            new()
            {
                Arguments = ["string"],
                Description = "description",
                Method = "method",
                Selector = "selector",
                BackendNodeID = 0,
            },
        ];
        string expectedMessage = "message";
        bool expectedSuccess = true;

        Assert.Equal(expectedActions.Count, deserialized.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], deserialized.Actions[i]);
        }
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionActResponse
        {
            Actions =
            [
                new()
                {
                    Arguments = ["string"],
                    Description = "description",
                    Method = "method",
                    Selector = "selector",
                    BackendNodeID = 0,
                },
            ],
            Message = "message",
            Success = true,
        };

        model.Validate();
    }
}
