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
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            Method = "click",
        };

        string expectedDescription = "Click the submit button";
        string expectedSelector = "[data-testid='submit-button']";
        List<string> expectedArguments = ["Hello World"];
        string expectedMethod = "click";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.NotNull(model.Arguments);
        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        for (int i = 0; i < expectedArguments.Count; i++)
        {
            Assert.Equal(expectedArguments[i], model.Arguments[i]);
        }
        Assert.Equal(expectedMethod, model.Method);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Action
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            Method = "click",
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
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            Method = "click",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Action>(json);
        Assert.NotNull(deserialized);

        string expectedDescription = "Click the submit button";
        string expectedSelector = "[data-testid='submit-button']";
        List<string> expectedArguments = ["Hello World"];
        string expectedMethod = "click";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.NotNull(deserialized.Arguments);
        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        for (int i = 0; i < expectedArguments.Count; i++)
        {
            Assert.Equal(expectedArguments[i], deserialized.Arguments[i]);
        }
        Assert.Equal(expectedMethod, deserialized.Method);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Action
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            Method = "click",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Action
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Action
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Action
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Method = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Action
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Method = null,
        };

        model.Validate();
    }
}
