using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionObserveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveResponse
        {
            Data = new()
            {
                Result =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        Method = "click",
                    },
                ],
                ActionID = "actionId",
            },
            Success = true,
        };

        SessionObserveResponseData expectedData = new()
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
            ActionID = "actionId",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveResponse
        {
            Data = new()
            {
                Result =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        Method = "click",
                    },
                ],
                ActionID = "actionId",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveResponse
        {
            Data = new()
            {
                Result =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        Method = "click",
                    },
                ],
                ActionID = "actionId",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveResponse>(json);
        Assert.NotNull(deserialized);

        SessionObserveResponseData expectedData = new()
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
            ActionID = "actionId",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveResponse
        {
            Data = new()
            {
                Result =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        Method = "click",
                    },
                ],
                ActionID = "actionId",
            },
            Success = true,
        };

        model.Validate();
    }
}

public class SessionObserveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
            ActionID = "actionId",
        };

        List<Action> expectedResult =
        [
            new()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                Method = "click",
            },
        ];
        string expectedActionID = "actionId";

        Assert.Equal(expectedResult.Count, model.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], model.Result[i]);
        }
        Assert.Equal(expectedActionID, model.ActionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionObserveResponseData>(json);
        Assert.NotNull(deserialized);

        List<Action> expectedResult =
        [
            new()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                Method = "click",
            },
        ];
        string expectedActionID = "actionId";

        Assert.Equal(expectedResult.Count, deserialized.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], deserialized.Result[i]);
        }
        Assert.Equal(expectedActionID, deserialized.ActionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
            ActionID = "actionId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionObserveResponseData
        {
            Result =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    Method = "click",
                },
            ],

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        model.Validate();
    }
}
