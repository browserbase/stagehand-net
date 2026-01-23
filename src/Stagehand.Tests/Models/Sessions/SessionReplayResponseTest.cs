using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionReplayResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionReplayResponse
        {
            Data = new()
            {
                Pages =
                [
                    new()
                    {
                        Actions =
                        [
                            new()
                            {
                                Method = "method",
                                TokenUsage = new()
                                {
                                    CachedInputTokens = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    ReasoningTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                    },
                ],
            },
            Success = true,
        };

        SessionReplayResponseData expectedData = new()
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionReplayResponse
        {
            Data = new()
            {
                Pages =
                [
                    new()
                    {
                        Actions =
                        [
                            new()
                            {
                                Method = "method",
                                TokenUsage = new()
                                {
                                    CachedInputTokens = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    ReasoningTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                    },
                ],
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionReplayResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionReplayResponse
        {
            Data = new()
            {
                Pages =
                [
                    new()
                    {
                        Actions =
                        [
                            new()
                            {
                                Method = "method",
                                TokenUsage = new()
                                {
                                    CachedInputTokens = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    ReasoningTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                    },
                ],
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionReplayResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SessionReplayResponseData expectedData = new()
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionReplayResponse
        {
            Data = new()
            {
                Pages =
                [
                    new()
                    {
                        Actions =
                        [
                            new()
                            {
                                Method = "method",
                                TokenUsage = new()
                                {
                                    CachedInputTokens = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    ReasoningTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                    },
                ],
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionReplayResponse
        {
            Data = new()
            {
                Pages =
                [
                    new()
                    {
                        Actions =
                        [
                            new()
                            {
                                Method = "method",
                                TokenUsage = new()
                                {
                                    CachedInputTokens = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    ReasoningTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                    },
                ],
            },
            Success = true,
        };

        SessionReplayResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionReplayResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionReplayResponseData
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };

        List<Page> expectedPages =
        [
            new()
            {
                Actions =
                [
                    new()
                    {
                        Method = "method",
                        TokenUsage = new()
                        {
                            CachedInputTokens = 0,
                            InputTokens = 0,
                            OutputTokens = 0,
                            ReasoningTokens = 0,
                            TimeMs = 0,
                        },
                    },
                ],
            },
        ];

        Assert.NotNull(model.Pages);
        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionReplayResponseData
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionReplayResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionReplayResponseData
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionReplayResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Page> expectedPages =
        [
            new()
            {
                Actions =
                [
                    new()
                    {
                        Method = "method",
                        TokenUsage = new()
                        {
                            CachedInputTokens = 0,
                            InputTokens = 0,
                            OutputTokens = 0,
                            ReasoningTokens = 0,
                            TimeMs = 0,
                        },
                    },
                ],
            },
        ];

        Assert.NotNull(deserialized.Pages);
        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionReplayResponseData
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionReplayResponseData { };

        Assert.Null(model.Pages);
        Assert.False(model.RawData.ContainsKey("pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionReplayResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionReplayResponseData
        {
            // Null should be interpreted as omitted for these properties
            Pages = null,
        };

        Assert.Null(model.Pages);
        Assert.False(model.RawData.ContainsKey("pages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionReplayResponseData
        {
            // Null should be interpreted as omitted for these properties
            Pages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionReplayResponseData
        {
            Pages =
            [
                new()
                {
                    Actions =
                    [
                        new()
                        {
                            Method = "method",
                            TokenUsage = new()
                            {
                                CachedInputTokens = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                ReasoningTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                },
            ],
        };

        SessionReplayResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Page
        {
            Actions =
            [
                new()
                {
                    Method = "method",
                    TokenUsage = new()
                    {
                        CachedInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        ReasoningTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
        };

        List<PageAction> expectedActions =
        [
            new()
            {
                Method = "method",
                TokenUsage = new()
                {
                    CachedInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                    ReasoningTokens = 0,
                    TimeMs = 0,
                },
            },
        ];

        Assert.NotNull(model.Actions);
        Assert.Equal(expectedActions.Count, model.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], model.Actions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Page
        {
            Actions =
            [
                new()
                {
                    Method = "method",
                    TokenUsage = new()
                    {
                        CachedInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        ReasoningTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Page
        {
            Actions =
            [
                new()
                {
                    Method = "method",
                    TokenUsage = new()
                    {
                        CachedInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        ReasoningTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<PageAction> expectedActions =
        [
            new()
            {
                Method = "method",
                TokenUsage = new()
                {
                    CachedInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                    ReasoningTokens = 0,
                    TimeMs = 0,
                },
            },
        ];

        Assert.NotNull(deserialized.Actions);
        Assert.Equal(expectedActions.Count, deserialized.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], deserialized.Actions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Page
        {
            Actions =
            [
                new()
                {
                    Method = "method",
                    TokenUsage = new()
                    {
                        CachedInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        ReasoningTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Page { };

        Assert.Null(model.Actions);
        Assert.False(model.RawData.ContainsKey("actions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Page { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Page
        {
            // Null should be interpreted as omitted for these properties
            Actions = null,
        };

        Assert.Null(model.Actions);
        Assert.False(model.RawData.ContainsKey("actions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Page
        {
            // Null should be interpreted as omitted for these properties
            Actions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Page
        {
            Actions =
            [
                new()
                {
                    Method = "method",
                    TokenUsage = new()
                    {
                        CachedInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        ReasoningTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
        };

        Page copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PageActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            TokenUsage = new()
            {
                CachedInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                ReasoningTokens = 0,
                TimeMs = 0,
            },
        };

        string expectedMethod = "method";
        TokenUsage expectedTokenUsage = new()
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedTokenUsage, model.TokenUsage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            TokenUsage = new()
            {
                CachedInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                ReasoningTokens = 0,
                TimeMs = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            TokenUsage = new()
            {
                CachedInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                ReasoningTokens = 0,
                TimeMs = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMethod = "method";
        TokenUsage expectedTokenUsage = new()
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedTokenUsage, deserialized.TokenUsage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            TokenUsage = new()
            {
                CachedInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                ReasoningTokens = 0,
                TimeMs = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PageAction { };

        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.TokenUsage);
        Assert.False(model.RawData.ContainsKey("tokenUsage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PageAction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PageAction
        {
            // Null should be interpreted as omitted for these properties
            Method = null,
            TokenUsage = null,
        };

        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.TokenUsage);
        Assert.False(model.RawData.ContainsKey("tokenUsage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PageAction
        {
            // Null should be interpreted as omitted for these properties
            Method = null,
            TokenUsage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            TokenUsage = new()
            {
                CachedInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                ReasoningTokens = 0,
                TimeMs = 0,
            },
        };

        PageAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TokenUsage
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        double expectedCachedInputTokens = 0;
        double expectedInputTokens = 0;
        double expectedOutputTokens = 0;
        double expectedReasoningTokens = 0;
        double expectedTimeMs = 0;

        Assert.Equal(expectedCachedInputTokens, model.CachedInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedReasoningTokens, model.ReasoningTokens);
        Assert.Equal(expectedTimeMs, model.TimeMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenUsage
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TokenUsage
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCachedInputTokens = 0;
        double expectedInputTokens = 0;
        double expectedOutputTokens = 0;
        double expectedReasoningTokens = 0;
        double expectedTimeMs = 0;

        Assert.Equal(expectedCachedInputTokens, deserialized.CachedInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedReasoningTokens, deserialized.ReasoningTokens);
        Assert.Equal(expectedTimeMs, deserialized.TimeMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenUsage
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TokenUsage { };

        Assert.Null(model.CachedInputTokens);
        Assert.False(model.RawData.ContainsKey("cachedInputTokens"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("inputTokens"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("outputTokens"));
        Assert.Null(model.ReasoningTokens);
        Assert.False(model.RawData.ContainsKey("reasoningTokens"));
        Assert.Null(model.TimeMs);
        Assert.False(model.RawData.ContainsKey("timeMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TokenUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TokenUsage
        {
            // Null should be interpreted as omitted for these properties
            CachedInputTokens = null,
            InputTokens = null,
            OutputTokens = null,
            ReasoningTokens = null,
            TimeMs = null,
        };

        Assert.Null(model.CachedInputTokens);
        Assert.False(model.RawData.ContainsKey("cachedInputTokens"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("inputTokens"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("outputTokens"));
        Assert.Null(model.ReasoningTokens);
        Assert.False(model.RawData.ContainsKey("reasoningTokens"));
        Assert.Null(model.TimeMs);
        Assert.False(model.RawData.ContainsKey("timeMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TokenUsage
        {
            // Null should be interpreted as omitted for these properties
            CachedInputTokens = null,
            InputTokens = null,
            OutputTokens = null,
            ReasoningTokens = null,
            TimeMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TokenUsage
        {
            CachedInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            ReasoningTokens = 0,
            TimeMs = 0,
        };

        TokenUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
