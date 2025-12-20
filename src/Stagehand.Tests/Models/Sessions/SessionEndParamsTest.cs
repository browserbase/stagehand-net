using System;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionEndParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionEndParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            XLanguage = SessionEndParamsXLanguage.Typescript,
            XSDKVersion = "3.0.6",
            XSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z"),
            XStreamResponse = SessionEndParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        ApiEnum<string, SessionEndParamsXLanguage> expectedXLanguage =
            SessionEndParamsXLanguage.Typescript;
        string expectedXSDKVersion = "3.0.6";
        DateTimeOffset expectedXSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z");
        ApiEnum<string, SessionEndParamsXStreamResponse> expectedXStreamResponse =
            SessionEndParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXLanguage, parameters.XLanguage);
        Assert.Equal(expectedXSDKVersion, parameters.XSDKVersion);
        Assert.Equal(expectedXSentAt, parameters.XSentAt);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionEndParams { ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123" };

        Assert.Null(parameters.XLanguage);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-language"));
        Assert.Null(parameters.XSDKVersion);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sdk-version"));
        Assert.Null(parameters.XSentAt);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sent-at"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionEndParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",

            // Null should be interpreted as omitted for these properties
            XLanguage = null,
            XSDKVersion = null,
            XSentAt = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.XLanguage);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-language"));
        Assert.Null(parameters.XSDKVersion);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sdk-version"));
        Assert.Null(parameters.XSentAt);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-sent-at"));
        Assert.Null(parameters.XStreamResponse);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-stream-response"));
    }
}

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

        Assert.NotNull(value);
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

        Assert.NotNull(value);
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
