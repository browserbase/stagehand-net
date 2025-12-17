using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new(
                new SessionExecuteResponseDataResult()
                {
                    Actions =
                    [
                        new()
                        {
                            Type = "click",
                            Action = "action",
                            Instruction = "instruction",
                            PageText = "pageText",
                            PageURL = "pageUrl",
                            Reasoning = "reasoning",
                            TaskCompleted = true,
                            TimeMs = 0,
                        },
                    ],
                    Completed = true,
                    Message = "Successfully logged in and navigated to dashboard",
                    Success = true,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Usage = new()
                    {
                        InferenceTimeMs = 2500,
                        InputTokens = 1500,
                        OutputTokens = 250,
                        CachedInputTokens = 0,
                        ReasoningTokens = 0,
                    },
                }
            ),
            Success = SessionExecuteResponseSuccess.True,
        };

        SessionExecuteResponseData expectedData = new(
            new SessionExecuteResponseDataResult()
            {
                Actions =
                [
                    new()
                    {
                        Type = "click",
                        Action = "action",
                        Instruction = "instruction",
                        PageText = "pageText",
                        PageURL = "pageUrl",
                        Reasoning = "reasoning",
                        TaskCompleted = true,
                        TimeMs = 0,
                    },
                ],
                Completed = true,
                Message = "Successfully logged in and navigated to dashboard",
                Success = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Usage = new()
                {
                    InferenceTimeMs = 2500,
                    InputTokens = 1500,
                    OutputTokens = 250,
                    CachedInputTokens = 0,
                    ReasoningTokens = 0,
                },
            }
        );
        ApiEnum<bool, SessionExecuteResponseSuccess> expectedSuccess =
            SessionExecuteResponseSuccess.True;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new(
                new SessionExecuteResponseDataResult()
                {
                    Actions =
                    [
                        new()
                        {
                            Type = "click",
                            Action = "action",
                            Instruction = "instruction",
                            PageText = "pageText",
                            PageURL = "pageUrl",
                            Reasoning = "reasoning",
                            TaskCompleted = true,
                            TimeMs = 0,
                        },
                    ],
                    Completed = true,
                    Message = "Successfully logged in and navigated to dashboard",
                    Success = true,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Usage = new()
                    {
                        InferenceTimeMs = 2500,
                        InputTokens = 1500,
                        OutputTokens = 250,
                        CachedInputTokens = 0,
                        ReasoningTokens = 0,
                    },
                }
            ),
            Success = SessionExecuteResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new(
                new SessionExecuteResponseDataResult()
                {
                    Actions =
                    [
                        new()
                        {
                            Type = "click",
                            Action = "action",
                            Instruction = "instruction",
                            PageText = "pageText",
                            PageURL = "pageUrl",
                            Reasoning = "reasoning",
                            TaskCompleted = true,
                            TimeMs = 0,
                        },
                    ],
                    Completed = true,
                    Message = "Successfully logged in and navigated to dashboard",
                    Success = true,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Usage = new()
                    {
                        InferenceTimeMs = 2500,
                        InputTokens = 1500,
                        OutputTokens = 250,
                        CachedInputTokens = 0,
                        ReasoningTokens = 0,
                    },
                }
            ),
            Success = SessionExecuteResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponse>(json);
        Assert.NotNull(deserialized);

        SessionExecuteResponseData expectedData = new(
            new SessionExecuteResponseDataResult()
            {
                Actions =
                [
                    new()
                    {
                        Type = "click",
                        Action = "action",
                        Instruction = "instruction",
                        PageText = "pageText",
                        PageURL = "pageUrl",
                        Reasoning = "reasoning",
                        TaskCompleted = true,
                        TimeMs = 0,
                    },
                ],
                Completed = true,
                Message = "Successfully logged in and navigated to dashboard",
                Success = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Usage = new()
                {
                    InferenceTimeMs = 2500,
                    InputTokens = 1500,
                    OutputTokens = 250,
                    CachedInputTokens = 0,
                    ReasoningTokens = 0,
                },
            }
        );
        ApiEnum<bool, SessionExecuteResponseSuccess> expectedSuccess =
            SessionExecuteResponseSuccess.True;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new(
                new SessionExecuteResponseDataResult()
                {
                    Actions =
                    [
                        new()
                        {
                            Type = "click",
                            Action = "action",
                            Instruction = "instruction",
                            PageText = "pageText",
                            PageURL = "pageUrl",
                            Reasoning = "reasoning",
                            TaskCompleted = true,
                            TimeMs = 0,
                        },
                    ],
                    Completed = true,
                    Message = "Successfully logged in and navigated to dashboard",
                    Success = true,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Usage = new()
                    {
                        InferenceTimeMs = 2500,
                        InputTokens = 1500,
                        OutputTokens = 250,
                        CachedInputTokens = 0,
                        ReasoningTokens = 0,
                    },
                }
            ),
            Success = SessionExecuteResponseSuccess.True,
        };

        model.Validate();
    }
}

public class SessionExecuteResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExecuteResponseData
        {
            Result = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = "click",
                        Action = "action",
                        Instruction = "instruction",
                        PageText = "pageText",
                        PageURL = "pageUrl",
                        Reasoning = "reasoning",
                        TaskCompleted = true,
                        TimeMs = 0,
                    },
                ],
                Completed = true,
                Message = "Successfully logged in and navigated to dashboard",
                Success = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Usage = new()
                {
                    InferenceTimeMs = 2500,
                    InputTokens = 1500,
                    OutputTokens = 250,
                    CachedInputTokens = 0,
                    ReasoningTokens = 0,
                },
            },
        };

        SessionExecuteResponseDataResult expectedResult = new()
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Usage = new()
            {
                InferenceTimeMs = 2500,
                InputTokens = 1500,
                OutputTokens = 250,
                CachedInputTokens = 0,
                ReasoningTokens = 0,
            },
        };

        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExecuteResponseData
        {
            Result = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = "click",
                        Action = "action",
                        Instruction = "instruction",
                        PageText = "pageText",
                        PageURL = "pageUrl",
                        Reasoning = "reasoning",
                        TaskCompleted = true,
                        TimeMs = 0,
                    },
                ],
                Completed = true,
                Message = "Successfully logged in and navigated to dashboard",
                Success = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Usage = new()
                {
                    InferenceTimeMs = 2500,
                    InputTokens = 1500,
                    OutputTokens = 250,
                    CachedInputTokens = 0,
                    ReasoningTokens = 0,
                },
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExecuteResponseData
        {
            Result = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = "click",
                        Action = "action",
                        Instruction = "instruction",
                        PageText = "pageText",
                        PageURL = "pageUrl",
                        Reasoning = "reasoning",
                        TaskCompleted = true,
                        TimeMs = 0,
                    },
                ],
                Completed = true,
                Message = "Successfully logged in and navigated to dashboard",
                Success = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Usage = new()
                {
                    InferenceTimeMs = 2500,
                    InputTokens = 1500,
                    OutputTokens = 250,
                    CachedInputTokens = 0,
                    ReasoningTokens = 0,
                },
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseData>(json);
        Assert.NotNull(deserialized);

        SessionExecuteResponseDataResult expectedResult = new()
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Usage = new()
            {
                InferenceTimeMs = 2500,
                InputTokens = 1500,
                OutputTokens = 250,
                CachedInputTokens = 0,
                ReasoningTokens = 0,
            },
        };

        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExecuteResponseData
        {
            Result = new()
            {
                Actions =
                [
                    new()
                    {
                        Type = "click",
                        Action = "action",
                        Instruction = "instruction",
                        PageText = "pageText",
                        PageURL = "pageUrl",
                        Reasoning = "reasoning",
                        TaskCompleted = true,
                        TimeMs = 0,
                    },
                ],
                Completed = true,
                Message = "Successfully logged in and navigated to dashboard",
                Success = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Usage = new()
                {
                    InferenceTimeMs = 2500,
                    InputTokens = 1500,
                    OutputTokens = 250,
                    CachedInputTokens = 0,
                    ReasoningTokens = 0,
                },
            },
        };

        model.Validate();
    }
}

public class SessionExecuteResponseDataResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Usage = new()
            {
                InferenceTimeMs = 2500,
                InputTokens = 1500,
                OutputTokens = 250,
                CachedInputTokens = 0,
                ReasoningTokens = 0,
            },
        };

        List<SessionExecuteResponseDataResultAction> expectedActions =
        [
            new()
            {
                Type = "click",
                Action = "action",
                Instruction = "instruction",
                PageText = "pageText",
                PageURL = "pageUrl",
                Reasoning = "reasoning",
                TaskCompleted = true,
                TimeMs = 0,
            },
        ];
        bool expectedCompleted = true;
        string expectedMessage = "Successfully logged in and navigated to dashboard";
        bool expectedSuccess = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Usage expectedUsage = new()
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        Assert.Equal(expectedActions.Count, model.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], model.Actions[i]);
        }
        Assert.Equal(expectedCompleted, model.Completed);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Usage = new()
            {
                InferenceTimeMs = 2500,
                InputTokens = 1500,
                OutputTokens = 250,
                CachedInputTokens = 0,
                ReasoningTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Usage = new()
            {
                InferenceTimeMs = 2500,
                InputTokens = 1500,
                OutputTokens = 250,
                CachedInputTokens = 0,
                ReasoningTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResult>(json);
        Assert.NotNull(deserialized);

        List<SessionExecuteResponseDataResultAction> expectedActions =
        [
            new()
            {
                Type = "click",
                Action = "action",
                Instruction = "instruction",
                PageText = "pageText",
                PageURL = "pageUrl",
                Reasoning = "reasoning",
                TaskCompleted = true,
                TimeMs = 0,
            },
        ];
        bool expectedCompleted = true;
        string expectedMessage = "Successfully logged in and navigated to dashboard";
        bool expectedSuccess = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Usage expectedUsage = new()
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        Assert.Equal(expectedActions.Count, deserialized.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], deserialized.Actions[i]);
        }
        Assert.Equal(expectedCompleted, deserialized.Completed);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Usage = new()
            {
                InferenceTimeMs = 2500,
                InputTokens = 1500,
                OutputTokens = 250,
                CachedInputTokens = 0,
                ReasoningTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Usage = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionExecuteResponseDataResult
        {
            Actions =
            [
                new()
                {
                    Type = "click",
                    Action = "action",
                    Instruction = "instruction",
                    PageText = "pageText",
                    PageURL = "pageUrl",
                    Reasoning = "reasoning",
                    TaskCompleted = true,
                    TimeMs = 0,
                },
            ],
            Completed = true,
            Message = "Successfully logged in and navigated to dashboard",
            Success = true,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Usage = null,
        };

        model.Validate();
    }
}

public class SessionExecuteResponseDataResultActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",
            Action = "action",
            Instruction = "instruction",
            PageText = "pageText",
            PageURL = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        string expectedType = "click";
        string expectedAction = "action";
        string expectedInstruction = "instruction";
        string expectedPageText = "pageText";
        string expectedPageURL = "pageUrl";
        string expectedReasoning = "reasoning";
        bool expectedTaskCompleted = true;
        double expectedTimeMs = 0;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.Equal(expectedPageText, model.PageText);
        Assert.Equal(expectedPageURL, model.PageURL);
        Assert.Equal(expectedReasoning, model.Reasoning);
        Assert.Equal(expectedTaskCompleted, model.TaskCompleted);
        Assert.Equal(expectedTimeMs, model.TimeMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",
            Action = "action",
            Instruction = "instruction",
            PageText = "pageText",
            PageURL = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResultAction>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",
            Action = "action",
            Instruction = "instruction",
            PageText = "pageText",
            PageURL = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResultAction>(json);
        Assert.NotNull(deserialized);

        string expectedType = "click";
        string expectedAction = "action";
        string expectedInstruction = "instruction";
        string expectedPageText = "pageText";
        string expectedPageURL = "pageUrl";
        string expectedReasoning = "reasoning";
        bool expectedTaskCompleted = true;
        double expectedTimeMs = 0;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.Equal(expectedPageText, deserialized.PageText);
        Assert.Equal(expectedPageURL, deserialized.PageURL);
        Assert.Equal(expectedReasoning, deserialized.Reasoning);
        Assert.Equal(expectedTaskCompleted, deserialized.TaskCompleted);
        Assert.Equal(expectedTimeMs, deserialized.TimeMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",
            Action = "action",
            Instruction = "instruction",
            PageText = "pageText",
            PageURL = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExecuteResponseDataResultAction { Type = "click" };

        Assert.Null(model.Action);
        Assert.False(model.RawData.ContainsKey("action"));
        Assert.Null(model.Instruction);
        Assert.False(model.RawData.ContainsKey("instruction"));
        Assert.Null(model.PageText);
        Assert.False(model.RawData.ContainsKey("pageText"));
        Assert.Null(model.PageURL);
        Assert.False(model.RawData.ContainsKey("pageUrl"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.TaskCompleted);
        Assert.False(model.RawData.ContainsKey("taskCompleted"));
        Assert.Null(model.TimeMs);
        Assert.False(model.RawData.ContainsKey("timeMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionExecuteResponseDataResultAction { Type = "click" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",

            // Null should be interpreted as omitted for these properties
            Action = null,
            Instruction = null,
            PageText = null,
            PageURL = null,
            Reasoning = null,
            TaskCompleted = null,
            TimeMs = null,
        };

        Assert.Null(model.Action);
        Assert.False(model.RawData.ContainsKey("action"));
        Assert.Null(model.Instruction);
        Assert.False(model.RawData.ContainsKey("instruction"));
        Assert.Null(model.PageText);
        Assert.False(model.RawData.ContainsKey("pageText"));
        Assert.Null(model.PageURL);
        Assert.False(model.RawData.ContainsKey("pageUrl"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.TaskCompleted);
        Assert.False(model.RawData.ContainsKey("taskCompleted"));
        Assert.Null(model.TimeMs);
        Assert.False(model.RawData.ContainsKey("timeMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",

            // Null should be interpreted as omitted for these properties
            Action = null,
            Instruction = null,
            PageText = null,
            PageURL = null,
            Reasoning = null,
            TaskCompleted = null,
            TimeMs = null,
        };

        model.Validate();
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        double expectedInferenceTimeMs = 2500;
        double expectedInputTokens = 1500;
        double expectedOutputTokens = 250;
        double expectedCachedInputTokens = 0;
        double expectedReasoningTokens = 0;

        Assert.Equal(expectedInferenceTimeMs, model.InferenceTimeMs);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedCachedInputTokens, model.CachedInputTokens);
        Assert.Equal(expectedReasoningTokens, model.ReasoningTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);
        Assert.NotNull(deserialized);

        double expectedInferenceTimeMs = 2500;
        double expectedInputTokens = 1500;
        double expectedOutputTokens = 250;
        double expectedCachedInputTokens = 0;
        double expectedReasoningTokens = 0;

        Assert.Equal(expectedInferenceTimeMs, deserialized.InferenceTimeMs);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedCachedInputTokens, deserialized.CachedInputTokens);
        Assert.Equal(expectedReasoningTokens, deserialized.ReasoningTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
        };

        Assert.Null(model.CachedInputTokens);
        Assert.False(model.RawData.ContainsKey("cached_input_tokens"));
        Assert.Null(model.ReasoningTokens);
        Assert.False(model.RawData.ContainsKey("reasoning_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,

            // Null should be interpreted as omitted for these properties
            CachedInputTokens = null,
            ReasoningTokens = null,
        };

        Assert.Null(model.CachedInputTokens);
        Assert.False(model.RawData.ContainsKey("cached_input_tokens"));
        Assert.Null(model.ReasoningTokens);
        Assert.False(model.RawData.ContainsKey("reasoning_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,

            // Null should be interpreted as omitted for these properties
            CachedInputTokens = null,
            ReasoningTokens = null,
        };

        model.Validate();
    }
}

public class SessionExecuteResponseSuccessTest : TestBase
{
    [Theory]
    [InlineData(SessionExecuteResponseSuccess.True)]
    public void Validation_Works(SessionExecuteResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionExecuteResponseSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionExecuteResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExecuteResponseSuccess.True)]
    public void SerializationRoundtrip_Works(SessionExecuteResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionExecuteResponseSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionExecuteResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionExecuteResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionExecuteResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
