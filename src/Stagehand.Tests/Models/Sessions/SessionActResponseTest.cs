using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
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
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = Success.True,
        };

        Data expectedData = new()
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
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };
        ApiEnum<bool, Success> expectedSuccess = Success.True;

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
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = Success.True,
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
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = Success.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionActResponse>(json);
        Assert.NotNull(deserialized);

        Data expectedData = new()
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
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };
        ApiEnum<bool, Success> expectedSuccess = Success.True;

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
                            Method = "click",
                        },
                    ],
                    Message = "Successfully clicked the login button",
                    Success = true,
                },
                ActionID = "actionId",
            },
            Success = Success.True,
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
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
        var model = new Data
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
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
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
                        Method = "click",
                    },
                ],
                Message = "Successfully clicked the login button",
                Success = true,
            },
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
        var model = new Data
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
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        string expectedActionDescription = "Clicked button with text 'Login'";
        List<Action> expectedActions =
        [
            new()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
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
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);
        Assert.NotNull(deserialized);

        string expectedActionDescription = "Clicked button with text 'Login'";
        List<Action> expectedActions =
        [
            new()
            {
                Description = "Click the submit button",
                Selector = "[data-testid='submit-button']",
                Arguments = ["Hello World"],
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
                    Method = "click",
                },
            ],
            Message = "Successfully clicked the login button",
            Success = true,
        };

        model.Validate();
    }
}

public class SuccessTest : TestBase
{
    [Theory]
    [InlineData(Success.True)]
    public void Validation_Works(Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Success> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Success.True)]
    public void SerializationRoundtrip_Works(Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Success> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
