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
                                Parameters = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Result = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Timestamp = 0,
                                EndTime = 0,
                                TokenUsage = new()
                                {
                                    Cost = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                        Duration = 0,
                        Timestamp = 0,
                        Url = "url",
                    },
                ],
                ClientLanguage = "clientLanguage",
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
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
                                Parameters = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Result = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Timestamp = 0,
                                EndTime = 0,
                                TokenUsage = new()
                                {
                                    Cost = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                        Duration = 0,
                        Timestamp = 0,
                        Url = "url",
                    },
                ],
                ClientLanguage = "clientLanguage",
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
                                Parameters = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Result = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Timestamp = 0,
                                EndTime = 0,
                                TokenUsage = new()
                                {
                                    Cost = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                        Duration = 0,
                        Timestamp = 0,
                        Url = "url",
                    },
                ],
                ClientLanguage = "clientLanguage",
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
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
                                Parameters = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Result = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Timestamp = 0,
                                EndTime = 0,
                                TokenUsage = new()
                                {
                                    Cost = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                        Duration = 0,
                        Timestamp = 0,
                        Url = "url",
                    },
                ],
                ClientLanguage = "clientLanguage",
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
                                Parameters = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Result = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Timestamp = 0,
                                EndTime = 0,
                                TokenUsage = new()
                                {
                                    Cost = 0,
                                    InputTokens = 0,
                                    OutputTokens = 0,
                                    TimeMs = 0,
                                },
                            },
                        ],
                        Duration = 0,
                        Timestamp = 0,
                        Url = "url",
                    },
                ],
                ClientLanguage = "clientLanguage",
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
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
                        Parameters = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Result = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timestamp = 0,
                        EndTime = 0,
                        TokenUsage = new()
                        {
                            Cost = 0,
                            InputTokens = 0,
                            OutputTokens = 0,
                            TimeMs = 0,
                        },
                    },
                ],
                Duration = 0,
                Timestamp = 0,
                Url = "url",
            },
        ];
        string expectedClientLanguage = "clientLanguage";

        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
        Assert.Equal(expectedClientLanguage, model.ClientLanguage);
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
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
                        Parameters = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Result = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timestamp = 0,
                        EndTime = 0,
                        TokenUsage = new()
                        {
                            Cost = 0,
                            InputTokens = 0,
                            OutputTokens = 0,
                            TimeMs = 0,
                        },
                    },
                ],
                Duration = 0,
                Timestamp = 0,
                Url = "url",
            },
        ];
        string expectedClientLanguage = "clientLanguage";

        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
        Assert.Equal(expectedClientLanguage, deserialized.ClientLanguage);
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
        };

        Assert.Null(model.ClientLanguage);
        Assert.False(model.RawData.ContainsKey("clientLanguage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],

            // Null should be interpreted as omitted for these properties
            ClientLanguage = null,
        };

        Assert.Null(model.ClientLanguage);
        Assert.False(model.RawData.ContainsKey("clientLanguage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],

            // Null should be interpreted as omitted for these properties
            ClientLanguage = null,
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
                            Parameters = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Result = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timestamp = 0,
                            EndTime = 0,
                            TokenUsage = new()
                            {
                                Cost = 0,
                                InputTokens = 0,
                                OutputTokens = 0,
                                TimeMs = 0,
                            },
                        },
                    ],
                    Duration = 0,
                    Timestamp = 0,
                    Url = "url",
                },
            ],
            ClientLanguage = "clientLanguage",
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
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Result = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = 0,
                    EndTime = 0,
                    TokenUsage = new()
                    {
                        Cost = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
            Duration = 0,
            Timestamp = 0,
            Url = "url",
        };

        List<PageAction> expectedActions =
        [
            new()
            {
                Method = "method",
                Parameters = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Result = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Timestamp = 0,
                EndTime = 0,
                TokenUsage = new()
                {
                    Cost = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                    TimeMs = 0,
                },
            },
        ];
        double expectedDuration = 0;
        double expectedTimestamp = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedActions.Count, model.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], model.Actions[i]);
        }
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUrl, model.Url);
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
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Result = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = 0,
                    EndTime = 0,
                    TokenUsage = new()
                    {
                        Cost = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
            Duration = 0,
            Timestamp = 0,
            Url = "url",
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
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Result = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = 0,
                    EndTime = 0,
                    TokenUsage = new()
                    {
                        Cost = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
            Duration = 0,
            Timestamp = 0,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Page>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<PageAction> expectedActions =
        [
            new()
            {
                Method = "method",
                Parameters = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Result = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Timestamp = 0,
                EndTime = 0,
                TokenUsage = new()
                {
                    Cost = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                    TimeMs = 0,
                },
            },
        ];
        double expectedDuration = 0;
        double expectedTimestamp = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedActions.Count, deserialized.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], deserialized.Actions[i]);
        }
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedUrl, deserialized.Url);
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
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Result = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = 0,
                    EndTime = 0,
                    TokenUsage = new()
                    {
                        Cost = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
            Duration = 0,
            Timestamp = 0,
            Url = "url",
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
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Result = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timestamp = 0,
                    EndTime = 0,
                    TokenUsage = new()
                    {
                        Cost = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                        TimeMs = 0,
                    },
                },
            ],
            Duration = 0,
            Timestamp = 0,
            Url = "url",
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
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
            EndTime = 0,
            TokenUsage = new()
            {
                Cost = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TimeMs = 0,
            },
        };

        string expectedMethod = "method";
        Dictionary<string, JsonElement> expectedParameters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedResult = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        double expectedTimestamp = 0;
        double expectedEndTime = 0;
        TokenUsage expectedTokenUsage = new()
        {
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TimeMs = 0,
        };

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedParameters.Count, model.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(model.Parameters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Parameters[item.Key]));
        }
        Assert.Equal(expectedResult.Count, model.Result.Count);
        foreach (var item in expectedResult)
        {
            Assert.True(model.Result.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Result[item.Key]));
        }
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedEndTime, model.EndTime);
        Assert.Equal(expectedTokenUsage, model.TokenUsage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
            EndTime = 0,
            TokenUsage = new()
            {
                Cost = 0,
                InputTokens = 0,
                OutputTokens = 0,
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
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
            EndTime = 0,
            TokenUsage = new()
            {
                Cost = 0,
                InputTokens = 0,
                OutputTokens = 0,
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
        Dictionary<string, JsonElement> expectedParameters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedResult = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        double expectedTimestamp = 0;
        double expectedEndTime = 0;
        TokenUsage expectedTokenUsage = new()
        {
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TimeMs = 0,
        };

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedParameters.Count, deserialized.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(deserialized.Parameters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Parameters[item.Key]));
        }
        Assert.Equal(expectedResult.Count, deserialized.Result.Count);
        foreach (var item in expectedResult)
        {
            Assert.True(deserialized.Result.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Result[item.Key]));
        }
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedEndTime, deserialized.EndTime);
        Assert.Equal(expectedTokenUsage, deserialized.TokenUsage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
            EndTime = 0,
            TokenUsage = new()
            {
                Cost = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TimeMs = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
        };

        Assert.Null(model.EndTime);
        Assert.False(model.RawData.ContainsKey("endTime"));
        Assert.Null(model.TokenUsage);
        Assert.False(model.RawData.ContainsKey("tokenUsage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,

            // Null should be interpreted as omitted for these properties
            EndTime = null,
            TokenUsage = null,
        };

        Assert.Null(model.EndTime);
        Assert.False(model.RawData.ContainsKey("endTime"));
        Assert.Null(model.TokenUsage);
        Assert.False(model.RawData.ContainsKey("tokenUsage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PageAction
        {
            Method = "method",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,

            // Null should be interpreted as omitted for these properties
            EndTime = null,
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
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Result = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = 0,
            EndTime = 0,
            TokenUsage = new()
            {
                Cost = 0,
                InputTokens = 0,
                OutputTokens = 0,
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
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TimeMs = 0,
        };

        double expectedCost = 0;
        double expectedInputTokens = 0;
        double expectedOutputTokens = 0;
        double expectedTimeMs = 0;

        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedTimeMs, model.TimeMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenUsage
        {
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
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
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TimeMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCost = 0;
        double expectedInputTokens = 0;
        double expectedOutputTokens = 0;
        double expectedTimeMs = 0;

        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedTimeMs, deserialized.TimeMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenUsage
        {
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TimeMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TokenUsage { };

        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("inputTokens"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("outputTokens"));
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
            Cost = null,
            InputTokens = null,
            OutputTokens = null,
            TimeMs = null,
        };

        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("inputTokens"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("outputTokens"));
        Assert.Null(model.TimeMs);
        Assert.False(model.RawData.ContainsKey("timeMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TokenUsage
        {
            // Null should be interpreted as omitted for these properties
            Cost = null,
            InputTokens = null,
            OutputTokens = null,
            TimeMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TokenUsage
        {
            Cost = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TimeMs = 0,
        };

        TokenUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
