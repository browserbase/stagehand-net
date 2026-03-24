using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Sessions = Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionActParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            FrameID = "frameId",
            Options = new()
            {
                Model = new Sessions::ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = Sessions::ModelConfigProvider.OpenAI,
                },
                Timeout = 30000,
                Variables = new Dictionary<string, Sessions::Variable>()
                {
                    { "username", "john_doe" },
                    {
                        "password",
                        new Sessions::UnionMember3()
                        {
                            Value = "secret123",
                            Description = "The login password",
                        }
                    },
                },
            },
            XStreamResponse = Sessions::XStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        Sessions::Input expectedInput = "Click the login button";
        string expectedFrameID = "frameId";
        Sessions::Options expectedOptions = new()
        {
            Model = new Sessions::ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = Sessions::ModelConfigProvider.OpenAI,
            },
            Timeout = 30000,
            Variables = new Dictionary<string, Sessions::Variable>()
            {
                { "username", "john_doe" },
                {
                    "password",
                    new Sessions::UnionMember3()
                    {
                        Value = "secret123",
                        Description = "The login password",
                    }
                },
            },
        };
        ApiEnum<string, Sessions::XStreamResponse> expectedXStreamResponse =
            Sessions::XStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            FrameID = "frameId",
        };

        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            FrameID = "frameId",

            // Null should be interpreted as omitted for these properties
            Options = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            Options = new()
            {
                Model = new Sessions::ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = Sessions::ModelConfigProvider.OpenAI,
                },
                Timeout = 30000,
                Variables = new Dictionary<string, Sessions::Variable>()
                {
                    { "username", "john_doe" },
                    {
                        "password",
                        new Sessions::UnionMember3()
                        {
                            Value = "secret123",
                            Description = "The login password",
                        }
                    },
                },
            },
            XStreamResponse = Sessions::XStreamResponse.True,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            Options = new()
            {
                Model = new Sessions::ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = Sessions::ModelConfigProvider.OpenAI,
                },
                Timeout = 30000,
                Variables = new Dictionary<string, Sessions::Variable>()
                {
                    { "username", "john_doe" },
                    {
                        "password",
                        new Sessions::UnionMember3()
                        {
                            Value = "secret123",
                            Description = "The login password",
                        }
                    },
                },
            },
            XStreamResponse = Sessions::XStreamResponse.True,

            FrameID = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.True(parameters.RawBodyData.ContainsKey("frameId"));
    }

    [Fact]
    public void Url_Works()
    {
        Sessions::SessionActParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
        };

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
                "https://api.stagehand.browserbase.com/v1/sessions/c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123/act"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Sessions::SessionActParams parameters = new()
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            XStreamResponse = Sessions::XStreamResponse.True,
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
        var parameters = new Sessions::SessionActParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            Input = "Click the login button",
            FrameID = "frameId",
            Options = new()
            {
                Model = new Sessions::ModelConfig()
                {
                    ModelName = "openai/gpt-5-nano",
                    ApiKey = "sk-some-openai-api-key",
                    BaseUrl = "https://api.openai.com/v1",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Provider = Sessions::ModelConfigProvider.OpenAI,
                },
                Timeout = 30000,
                Variables = new Dictionary<string, Sessions::Variable>()
                {
                    { "username", "john_doe" },
                    {
                        "password",
                        new Sessions::UnionMember3()
                        {
                            Value = "secret123",
                            Description = "The login password",
                        }
                    },
                },
            },
            XStreamResponse = Sessions::XStreamResponse.True,
        };

        Sessions::SessionActParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Sessions::Input value = "string";
        value.Validate();
    }

    [Fact]
    public void ActionValidationWorks()
    {
        Sessions::Input value = new Sessions::Action()
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            BackendNodeID = 0,
            Method = "click",
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Sessions::Input value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Input>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionSerializationRoundtripWorks()
    {
        Sessions::Input value = new Sessions::Action()
        {
            Description = "Click the submit button",
            Selector = "[data-testid='submit-button']",
            Arguments = ["Hello World"],
            BackendNodeID = 0,
            Method = "click",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Input>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sessions::Options
        {
            Model = new Sessions::ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = Sessions::ModelConfigProvider.OpenAI,
            },
            Timeout = 30000,
            Variables = new Dictionary<string, Sessions::Variable>()
            {
                { "username", "john_doe" },
                {
                    "password",
                    new Sessions::UnionMember3()
                    {
                        Value = "secret123",
                        Description = "The login password",
                    }
                },
            },
        };

        Sessions::Model expectedModel = new Sessions::ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = Sessions::ModelConfigProvider.OpenAI,
        };
        double expectedTimeout = 30000;
        Dictionary<string, Sessions::Variable> expectedVariables = new()
        {
            { "username", "john_doe" },
            {
                "password",
                new Sessions::UnionMember3()
                {
                    Value = "secret123",
                    Description = "The login password",
                }
            },
        };

        Assert.Equal(expectedModel, model.Model);
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
        var model = new Sessions::Options
        {
            Model = new Sessions::ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = Sessions::ModelConfigProvider.OpenAI,
            },
            Timeout = 30000,
            Variables = new Dictionary<string, Sessions::Variable>()
            {
                { "username", "john_doe" },
                {
                    "password",
                    new Sessions::UnionMember3()
                    {
                        Value = "secret123",
                        Description = "The login password",
                    }
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Options>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sessions::Options
        {
            Model = new Sessions::ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = Sessions::ModelConfigProvider.OpenAI,
            },
            Timeout = 30000,
            Variables = new Dictionary<string, Sessions::Variable>()
            {
                { "username", "john_doe" },
                {
                    "password",
                    new Sessions::UnionMember3()
                    {
                        Value = "secret123",
                        Description = "The login password",
                    }
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Sessions::Model expectedModel = new Sessions::ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = Sessions::ModelConfigProvider.OpenAI,
        };
        double expectedTimeout = 30000;
        Dictionary<string, Sessions::Variable> expectedVariables = new()
        {
            { "username", "john_doe" },
            {
                "password",
                new Sessions::UnionMember3()
                {
                    Value = "secret123",
                    Description = "The login password",
                }
            },
        };

        Assert.Equal(expectedModel, deserialized.Model);
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
        var model = new Sessions::Options
        {
            Model = new Sessions::ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = Sessions::ModelConfigProvider.OpenAI,
            },
            Timeout = 30000,
            Variables = new Dictionary<string, Sessions::Variable>()
            {
                { "username", "john_doe" },
                {
                    "password",
                    new Sessions::UnionMember3()
                    {
                        Value = "secret123",
                        Description = "The login password",
                    }
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sessions::Options { };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sessions::Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Sessions::Options
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Timeout = null,
            Variables = null,
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Sessions::Options
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Timeout = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Sessions::Options
        {
            Model = new Sessions::ModelConfig()
            {
                ModelName = "openai/gpt-5-nano",
                ApiKey = "sk-some-openai-api-key",
                BaseUrl = "https://api.openai.com/v1",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Provider = Sessions::ModelConfigProvider.OpenAI,
            },
            Timeout = 30000,
            Variables = new Dictionary<string, Sessions::Variable>()
            {
                { "username", "john_doe" },
                {
                    "password",
                    new Sessions::UnionMember3()
                    {
                        Value = "secret123",
                        Description = "The login password",
                    }
                },
            },
        };

        Sessions::Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void ConfigValidationWorks()
    {
        Sessions::Model value = new Sessions::ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = Sessions::ModelConfigProvider.OpenAI,
        };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Sessions::Model value = "string";
        value.Validate();
    }

    [Fact]
    public void ConfigSerializationRoundtripWorks()
    {
        Sessions::Model value = new Sessions::ModelConfig()
        {
            ModelName = "openai/gpt-5-nano",
            ApiKey = "sk-some-openai-api-key",
            BaseUrl = "https://api.openai.com/v1",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Provider = Sessions::ModelConfigProvider.OpenAI,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Model>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Sessions::Model value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Model>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VariableTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Sessions::Variable value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Sessions::Variable value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Sessions::Variable value = true;
        value.Validate();
    }

    [Fact]
    public void UnionMember3ValidationWorks()
    {
        Sessions::Variable value = new Sessions::UnionMember3()
        {
            Value = "string",
            Description = "description",
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Sessions::Variable value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Variable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Sessions::Variable value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Variable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Sessions::Variable value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Variable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember3SerializationRoundtripWorks()
    {
        Sessions::Variable value = new Sessions::UnionMember3()
        {
            Value = "string",
            Description = "description",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::Variable>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sessions::UnionMember3 { Value = "string", Description = "description" };

        Sessions::UnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Sessions::UnionMember3 { Value = "string", Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::UnionMember3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sessions::UnionMember3 { Value = "string", Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::UnionMember3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Sessions::UnionMember3Value expectedValue = "string";
        string expectedDescription = "description";

        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Sessions::UnionMember3 { Value = "string", Description = "description" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sessions::UnionMember3 { Value = "string" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sessions::UnionMember3 { Value = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Sessions::UnionMember3
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
        var model = new Sessions::UnionMember3
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
        var model = new Sessions::UnionMember3 { Value = "string", Description = "description" };

        Sessions::UnionMember3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember3ValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Sessions::UnionMember3Value value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Sessions::UnionMember3Value value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Sessions::UnionMember3Value value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Sessions::UnionMember3Value value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::UnionMember3Value>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Sessions::UnionMember3Value value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::UnionMember3Value>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Sessions::UnionMember3Value value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sessions::UnionMember3Value>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class XStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(Sessions::XStreamResponse.True)]
    [InlineData(Sessions::XStreamResponse.False)]
    public void Validation_Works(Sessions::XStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sessions::XStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sessions::XStreamResponse.True)]
    [InlineData(Sessions::XStreamResponse.False)]
    public void SerializationRoundtrip_Works(Sessions::XStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sessions::XStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sessions::XStreamResponse>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
