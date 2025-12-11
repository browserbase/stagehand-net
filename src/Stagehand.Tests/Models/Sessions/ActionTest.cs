using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class ActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",
            BackendNodeID = 0,
        };

        List<string> expectedArguments = ["string"];
        string expectedDescription = "description";
        string expectedMethod = "method";
        string expectedSelector = "selector";
        long expectedBackendNodeID = 0;

        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        for (int i = 0; i < expectedArguments.Count; i++)
        {
            Assert.Equal(expectedArguments[i], model.Arguments[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedBackendNodeID, model.BackendNodeID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",
            BackendNodeID = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Action>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",
            BackendNodeID = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Action>(json);
        Assert.NotNull(deserialized);

        List<string> expectedArguments = ["string"];
        string expectedDescription = "description";
        string expectedMethod = "method";
        string expectedSelector = "selector";
        long expectedBackendNodeID = 0;

        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        for (int i = 0; i < expectedArguments.Count; i++)
        {
            Assert.Equal(expectedArguments[i], deserialized.Arguments[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedBackendNodeID, deserialized.BackendNodeID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",
            BackendNodeID = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",
        };

        Assert.Null(model.BackendNodeID);
        Assert.False(model.RawData.ContainsKey("backendNodeId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",

            // Null should be interpreted as omitted for these properties
            BackendNodeID = null,
        };

        Assert.Null(model.BackendNodeID);
        Assert.False(model.RawData.ContainsKey("backendNodeId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Action
        {
            Arguments = ["string"],
            Description = "description",
            Method = "method",
            Selector = "selector",

            // Null should be interpreted as omitted for these properties
            BackendNodeID = null,
        };

        model.Validate();
    }
}
