using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionObserveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = ModelConfigProvider.OpenAI,
                },
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedFrameID = "frameId";
        string expectedInstruction = "Find all clickable navigation links";
        SessionObserveParamsOptions expectedOptions = new()
        {
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };
        ApiEnum<string, SessionObserveParamsXStreamResponse> expectedXStreamResponse =
            SessionObserveParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedInstruction, parameters.Instruction);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
        };

        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",

            // Null should be interpreted as omitted for these properties
            Instruction = null,
            Options = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.Instruction);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = ModelConfigProvider.OpenAI,
                },
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = ModelConfigProvider.OpenAI,
                },
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,

            FrameID = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.True(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionObserveParams parameters = new() { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

        var url = parameters.Url(
            new()
            {
                BrowserbaseApiKey = "My Browserbase API Key",
                BrowserbaseProjectID = "My Browserbase Project ID",
                ModelApiKey = "My Model API Key",
            }
        );

        Assert.Equal(
            new Uri(
                "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/observe"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionObserveParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new()
            {
                BrowserbaseApiKey = "My Browserbase API Key",
                BrowserbaseProjectID = "My Browserbase Project ID",
                ModelApiKey = "My Model API Key",
            }
        );

        Assert.Equal(["true"], requestMessage.Headers.GetValues("x-stream-response"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SessionObserveParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            FrameID = "frameId",
            Instruction = "Find all clickable navigation links",
            Options = new()
            {
                Model = new ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = ModelConfigProvider.OpenAI,
                },
                Selector = "nav",
                Timeout = 30000,
                Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
                {
                    {
                        "username",
                        new SessionObserveParamsOptionsVariableUnionMember3()
                        {
                            Value = "john@example.com",
                            Description = "The login email",
                        }
                    },
                    { "rememberMe", true },
                },
            },
            XStreamResponse = SessionObserveParamsXStreamResponse.True,
        };

        SessionObserveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SessionObserveParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        SessionObserveParamsOptionsModel expectedModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };
        string expectedSelector = "nav";
        double expectedTimeout = 30000;
        Dictionary<string, SessionObserveParamsOptionsVariable> expectedVariables = new()
        {
            {
                "username",
                new SessionObserveParamsOptionsVariableUnionMember3()
                {
                    Value = "john@example.com",
                    Description = "The login email",
                }
            },
            { "rememberMe", true },
        };

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSelector, model.Selector);
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(model.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Variables[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SessionObserveParamsOptionsModel expectedModel = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };
        string expectedSelector = "nav";
        double expectedTimeout = 30000;
        Dictionary<string, SessionObserveParamsOptionsVariable> expectedVariables = new()
        {
            {
                "username",
                new SessionObserveParamsOptionsVariableUnionMember3()
                {
                    Value = "john@example.com",
                    Description = "The login email",
                }
            },
            { "rememberMe", true },
        };

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSelector, deserialized.Selector);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(deserialized.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Variables[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptions { };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionObserveParamsOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Selector = null,
            Timeout = null,
            Variables = null,
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Selector);
        Assert.False(model.RawData.ContainsKey("selector"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Selector = null,
            Timeout = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionObserveParamsOptions
        {
            Model = new ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = ModelConfigProvider.OpenAI,
            },
            Selector = "nav",
            Timeout = 30000,
            Variables = new Dictionary<string, SessionObserveParamsOptionsVariable>()
            {
                {
                    "username",
                    new SessionObserveParamsOptionsVariableUnionMember3()
                    {
                        Value = "john@example.com",
                        Description = "The login email",
                    }
                },
                { "rememberMe", true },
            },
        };

        SessionObserveParamsOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsModelTest : TestBase
{
    [Fact]
    public void ConfigValidationWorks()
    {
        SessionObserveParamsOptionsModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsModel value = "string";
        value.Validate();
    }

    [Fact]
    public void ConfigSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModel value = new ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = ModelConfigProvider.OpenAI,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsVariableTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsVariable value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SessionObserveParamsOptionsVariable value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SessionObserveParamsOptionsVariable value = true;
        value.Validate();
    }

    [Fact]
    public void SessionObserveParamsOptionsVariableUnionMember3ValidationWorks()
    {
        SessionObserveParamsOptionsVariable value =
            new SessionObserveParamsOptionsVariableUnionMember3()
            {
                Value = "string",
                Description = "description",
            };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionObserveParamsOptionsVariableUnionMember3SerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariable value =
            new SessionObserveParamsOptionsVariableUnionMember3()
            {
                Value = "string",
                Description = "description",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionObserveParamsOptionsVariable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsOptionsVariableUnionMember3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        SessionObserveParamsOptionsVariableUnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SessionObserveParamsOptionsVariableUnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3 { Value = "string" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3 { Value = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionObserveParamsOptionsVariableUnionMember3
        {
            Value = "string",
            Description = "description",
        };

        SessionObserveParamsOptionsVariableUnionMember3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SessionObserveParamsOptionsVariableUnionMember3ValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3Value>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3Value>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        SessionObserveParamsOptionsVariableUnionMember3Value value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SessionObserveParamsOptionsVariableUnionMember3Value>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SessionObserveParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionObserveParamsXStreamResponse.True)]
    [InlineData(SessionObserveParamsXStreamResponse.False)]
    public void Validation_Works(SessionObserveParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionObserveParamsXStreamResponse.True)]
    [InlineData(SessionObserveParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionObserveParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionObserveParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionObserveParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
