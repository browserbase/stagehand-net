using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
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
            Success = SessionObserveResponseSuccess.True,
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
        ApiEnum<bool, SessionObserveResponseSuccess> expectedSuccess =
            SessionObserveResponseSuccess.True;

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
            Success = SessionObserveResponseSuccess.True,
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
            Success = SessionObserveResponseSuccess.True,
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
        ApiEnum<bool, SessionObserveResponseSuccess> expectedSuccess =
            SessionObserveResponseSuccess.True;

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
            Success = SessionObserveResponseSuccess.True,
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

public class SessionObserveResponseSuccessTest : TestBase
{
    [Theory]
    [InlineData(SessionObserveResponseSuccess.True)]
    public void Validation_Works(SessionObserveResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionObserveResponseSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionObserveResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionObserveResponseSuccess.True)]
    public void SerializationRoundtrip_Works(SessionObserveResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionObserveResponseSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionObserveResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionObserveResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionObserveResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
