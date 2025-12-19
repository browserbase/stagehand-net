using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionActResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionActResponse
        {
            Data = new()
            {
                Result = new()
                {
                    ActionDescription = "Clicked button with text 'Login'",
                    Actions =
                    [
                        new()
                        {
                            Description = "Click the submit button",
                            Selector = "[data-testid='submit-button']",
                            Arguments = ["Hello World"],
                            BackendNodeID = 0,
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = true,
        };

        SessionActResponseData expectedData = new()
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionActResponse
        {
            Data = new()
            {
                Result = new()
                {
                    ActionDescription = "Clicked button with text 'Login'",
                    Actions =
                    [
                        new()
                        {
                            Description = "Click the submit button",
                            Selector = "[data-testid='submit-button']",
                            Arguments = ["Hello World"],
                            BackendNodeID = 0,
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
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
            Data = new()
            {
                Result = new()
                {
                    ActionDescription = "Clicked button with text 'Login'",
                    Actions =
                    [
                        new()
                        {
                            Description = "Click the submit button",
                            Selector = "[data-testid='submit-button']",
                            Arguments = ["Hello World"],
                            BackendNodeID = 0,
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionActResponse>(element);
        Assert.NotNull(deserialized);

        SessionActResponseData expectedData = new()
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionActResponse
        {
            Data = new()
            {
                Result = new()
                {
                    ActionDescription = "Clicked button with text 'Login'",
                    Actions =
                    [
                        new()
                        {
                            Description = "Click the submit button",
                            Selector = "[data-testid='submit-button']",
                            Arguments = ["Hello World"],
                            BackendNodeID = 0,
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = true,
        };

        model.Validate();
    }
}

public class SessionActResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };

        Result expectedResult = new()
        {
            ActionDescription = "Clicked button with text 'Login'",
            Actions =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    BackendNodeID = 0,
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };
        string expectedActionID = "actionId";

        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedActionID, model.ActionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionActResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionActResponseData>(element);
        Assert.NotNull(deserialized);

        Result expectedResult = new()
        {
            ActionDescription = "Clicked button with text 'Login'",
            Actions =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    BackendNodeID = 0,
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };
        string expectedActionID = "actionId";

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedActionID, deserialized.ActionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionActResponseData
        {
            Result = new()
            {
                ActionDescription = "Clicked button with text 'Login'",
                Actions =
                [
                    new()
                    {
                        Description = "Click the submit button",
                        Selector = "[data-testid='submit-button']",
                        Arguments = ["Hello World"],
                        BackendNodeID = 0,
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        model.Validate();
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            ActionDescription = "Clicked button with text 'Login'",
            Actions =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    BackendNodeID = 0,
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        string expectedActionDescription = "Clicked button with text 'Login'";
        List<ResultAction> expectedActions =
        [
            new()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                BackendNodeID = 0,
                Method = "click",
            },
        ];
        string expectedMessage = "Successfully clicked the login button";
        bool expectedSuccess = true;

        Assert.Equal(expectedActionDescription, model.ActionDescription);
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
        var model = new Result
        {
            ActionDescription = "Clicked button with text 'Login'",
            Actions =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    BackendNodeID = 0,
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            ActionDescription = "Clicked button with text 'Login'",
            Actions =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    BackendNodeID = 0,
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(element);
        Assert.NotNull(deserialized);

        string expectedActionDescription = "Clicked button with text 'Login'";
        List<ResultAction> expectedActions =
        [
            new()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
                BackendNodeID = 0,
                Method = "click",
            },
        ];
        string expectedMessage = "Successfully clicked the login button";
        bool expectedSuccess = true;

        Assert.Equal(expectedActionDescription, deserialized.ActionDescription);
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
        var model = new Result
        {
            ActionDescription = "Clicked button with text 'Login'",
            Actions =
            [
                new()
                {
                    Description = "Click the submit button",
                    Selector = "[data-testid='submit-button']",
                    Arguments = ["Hello World"],
                    BackendNodeID = 0,
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        model.Validate();
    }
}

public class ResultActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            BackendNodeID = 0,
            Method = "click",
        };

        string expectedDescription = "Click the submit button";
        string expectedSelector = "[data-testid='submit-button']";
        List<string> expectedArguments = ["Hello World"];
        double expectedBackendNodeID = 0;
        string expectedMethod = "click";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.NotNull(model.Arguments);
        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        for (int i = 0; i < expectedArguments.Count; i++)
        {
            Assert.Equal(expectedArguments[i], model.Arguments[i]);
        }
        Assert.Equal(expectedBackendNodeID, model.BackendNodeID);
        Assert.Equal(expectedMethod, model.Method);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            BackendNodeID = 0,
            Method = "click",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ResultAction>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            BackendNodeID = 0,
            Method = "click",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ResultAction>(element);
        Assert.NotNull(deserialized);

        string expectedDescription = "Click the submit button";
        string expectedSelector = "[data-testid='submit-button']";
        List<string> expectedArguments = ["Hello World"];
        double expectedBackendNodeID = 0;
        string expectedMethod = "click";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.NotNull(deserialized.Arguments);
        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        for (int i = 0; i < expectedArguments.Count; i++)
        {
            Assert.Equal(expectedArguments[i], deserialized.Arguments[i]);
        }
        Assert.Equal(expectedBackendNodeID, deserialized.BackendNodeID);
        Assert.Equal(expectedMethod, deserialized.Method);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            BackendNodeID = 0,
            Method = "click",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.BackendNodeID);
        Assert.False(model.RawData.ContainsKey("backendNodeId"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            BackendNodeID = null,
            Method = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.BackendNodeID);
        Assert.False(model.RawData.ContainsKey("backendNodeId"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResultAction
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            BackendNodeID = null,
            Method = null,
        };

        model.Validate();
    }
}
