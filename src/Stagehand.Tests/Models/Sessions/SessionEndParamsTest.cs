using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionEndParamsXLanguageTest : TestBase
{
    [Theory]
    [InlineData(SessionEndParamsXLanguage.Typescript)]
    [InlineData(SessionEndParamsXLanguage.Python)]
    [InlineData(SessionEndParamsXLanguage.Playground)]
    public void Validation_Works(SessionEndParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionEndParamsXLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionEndParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionEndParamsXLanguage.Typescript)]
    [InlineData(SessionEndParamsXLanguage.Python)]
    [InlineData(SessionEndParamsXLanguage.Playground)]
    public void SerializationRoundtrip_Works(SessionEndParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionEndParamsXLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SessionEndParamsXLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionEndParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SessionEndParamsXLanguage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionEndParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionEndParamsXStreamResponse.True)]
    [InlineData(SessionEndParamsXStreamResponse.False)]
    public void Validation_Works(SessionEndParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionEndParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionEndParamsXStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionEndParamsXStreamResponse.True)]
    [InlineData(SessionEndParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionEndParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionEndParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionEndParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionEndParamsXStreamResponse>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionEndParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
