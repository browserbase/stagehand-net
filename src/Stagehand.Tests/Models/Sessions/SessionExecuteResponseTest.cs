using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new()
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
                            PageUrl = "pageUrl",
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
                CacheEntry = new()
                {
                    CacheKey = "cacheKey",
                    Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
            Success = true,
        };

        SessionExecuteResponseData expectedData = new()
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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new()
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
                            PageUrl = "pageUrl",
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
                CacheEntry = new()
                {
                    CacheKey = "cacheKey",
                    Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new()
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
                            PageUrl = "pageUrl",
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
                CacheEntry = new()
                {
                    CacheKey = "cacheKey",
                    Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SessionExecuteResponseData expectedData = new()
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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new()
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
                            PageUrl = "pageUrl",
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
                CacheEntry = new()
                {
                    CacheKey = "cacheKey",
                    Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionExecuteResponse
        {
            Data = new()
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
                            PageUrl = "pageUrl",
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
                CacheEntry = new()
                {
                    CacheKey = "cacheKey",
                    Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
            Success = true,
        };

        SessionExecuteResponse copied = new(model);

        Assert.Equal(model, copied);
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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
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
                    PageUrl = "pageUrl",
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
        CacheEntry expectedCacheEntry = new()
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedCacheEntry, model.CacheEntry);
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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseData>(
            json,
            ModelBase.SerializerOptions
        );

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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseData>(
            element,
            ModelBase.SerializerOptions
        );
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
                    PageUrl = "pageUrl",
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
        CacheEntry expectedCacheEntry = new()
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedCacheEntry, deserialized.CacheEntry);
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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
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
                        PageUrl = "pageUrl",
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

        Assert.Null(model.CacheEntry);
        Assert.False(model.RawData.ContainsKey("cacheEntry"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
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
                        PageUrl = "pageUrl",
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

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
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
                        PageUrl = "pageUrl",
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

            // Null should be interpreted as omitted for these properties
            CacheEntry = null,
        };

        Assert.Null(model.CacheEntry);
        Assert.False(model.RawData.ContainsKey("cacheEntry"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
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
                        PageUrl = "pageUrl",
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

            // Null should be interpreted as omitted for these properties
            CacheEntry = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
                        PageUrl = "pageUrl",
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
            CacheEntry = new()
            {
                CacheKey = "cacheKey",
                Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        SessionExecuteResponseData copied = new(model);

        Assert.Equal(model, copied);
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
                    PageUrl = "pageUrl",
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
                PageUrl = "pageUrl",
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
        Assert.NotNull(model.Metadata);
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
                    PageUrl = "pageUrl",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResult>(
            json,
            ModelBase.SerializerOptions
        );

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
                    PageUrl = "pageUrl",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SessionExecuteResponseDataResultAction> expectedActions =
        [
            new()
            {
                Type = "click",
                Action = "action",
                Instruction = "instruction",
                PageText = "pageText",
                PageUrl = "pageUrl",
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
        Assert.NotNull(deserialized.Metadata);
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
                    PageUrl = "pageUrl",
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
                    PageUrl = "pageUrl",
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
                    PageUrl = "pageUrl",
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
                    PageUrl = "pageUrl",
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
                    PageUrl = "pageUrl",
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

    [Fact]
    public void CopyConstructor_Works()
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
                    PageUrl = "pageUrl",
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

        SessionExecuteResponseDataResult copied = new(model);

        Assert.Equal(model, copied);
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
            PageUrl = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        string expectedType = "click";
        string expectedAction = "action";
        string expectedInstruction = "instruction";
        string expectedPageText = "pageText";
        string expectedPageUrl = "pageUrl";
        string expectedReasoning = "reasoning";
        bool expectedTaskCompleted = true;
        double expectedTimeMs = 0;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedInstruction, model.Instruction);
        Assert.Equal(expectedPageText, model.PageText);
        Assert.Equal(expectedPageUrl, model.PageUrl);
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
            PageUrl = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResultAction>(
            json,
            ModelBase.SerializerOptions
        );

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
            PageUrl = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionExecuteResponseDataResultAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedType = "click";
        string expectedAction = "action";
        string expectedInstruction = "instruction";
        string expectedPageText = "pageText";
        string expectedPageUrl = "pageUrl";
        string expectedReasoning = "reasoning";
        bool expectedTaskCompleted = true;
        double expectedTimeMs = 0;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedInstruction, deserialized.Instruction);
        Assert.Equal(expectedPageText, deserialized.PageText);
        Assert.Equal(expectedPageUrl, deserialized.PageUrl);
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
            PageUrl = "pageUrl",
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
        Assert.Null(model.PageUrl);
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
            PageUrl = null,
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
        Assert.Null(model.PageUrl);
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
            PageUrl = null,
            Reasoning = null,
            TaskCompleted = null,
            TimeMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionExecuteResponseDataResultAction
        {
            Type = "click",
            Action = "action",
            Instruction = "instruction",
            PageText = "pageText",
            PageUrl = "pageUrl",
            Reasoning = "reasoning",
            TaskCompleted = true,
            TimeMs = 0,
        };

        SessionExecuteResponseDataResultAction copied = new(model);

        Assert.Equal(model, copied);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage
        {
            InferenceTimeMs = 2500,
            InputTokens = 1500,
            OutputTokens = 250,
            CachedInputTokens = 0,
            ReasoningTokens = 0,
        };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CacheEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheEntry
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedCacheKey = "cacheKey";
        JsonElement expectedEntry = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedCacheKey, model.CacheKey);
        Assert.True(JsonElement.DeepEquals(expectedEntry, model.Entry));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CacheEntry
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CacheEntry
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCacheKey = "cacheKey";
        JsonElement expectedEntry = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedCacheKey, deserialized.CacheKey);
        Assert.True(JsonElement.DeepEquals(expectedEntry, deserialized.Entry));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CacheEntry
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CacheEntry
        {
            CacheKey = "cacheKey",
            Entry = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        CacheEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}
