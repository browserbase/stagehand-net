using System;
using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionNavigateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionNavigateParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            URL = "https://example.com",
            FrameID = "frameId",
            Options = new()
            {
                Referer = "referer",
                Timeout = 30000,
                WaitUntil = WaitUntil.Networkidle,
            },
            StreamResponse = true,
            XLanguage = SessionNavigateParamsXLanguage.Typescript,
            XSDKVersion = "3.0.6",
            XSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z"),
            XStreamResponse = SessionNavigateParamsXStreamResponse.True,
        };

        string expectedID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123";
        string expectedURL = "https://example.com";
        string expectedFrameID = "frameId";
        SessionNavigateParamsOptions expectedOptions = new()
        {
            Referer = "referer",
            Timeout = 30000,
            WaitUntil = WaitUntil.Networkidle,
        };
        bool expectedStreamResponse = true;
        ApiEnum<string, SessionNavigateParamsXLanguage> expectedXLanguage =
            SessionNavigateParamsXLanguage.Typescript;
        string expectedXSDKVersion = "3.0.6";
        DateTimeOffset expectedXSentAt = DateTimeOffset.Parse("2025-01-15T10:30:00Z");
        ApiEnum<string, SessionNavigateParamsXStreamResponse> expectedXStreamResponse =
            SessionNavigateParamsXStreamResponse.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedURL, parameters.URL);
        Assert.Equal(expectedFrameID, parameters.FrameID);
        Assert.Equal(expectedOptions, parameters.Options);
        Assert.Equal(expectedStreamResponse, parameters.StreamResponse);
        Assert.Equal(expectedXLanguage, parameters.XLanguage);
        Assert.Equal(expectedXSDKVersion, parameters.XSDKVersion);
        Assert.Equal(expectedXSentAt, parameters.XSentAt);
        Assert.Equal(expectedXStreamResponse, parameters.XStreamResponse);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionNavigateParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            URL = "https://example.com",
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.StreamResponse);
        Assert.False(parameters.RawBodyData.ContainsKey("streamResponse"));
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
        var parameters = new SessionNavigateParams
        {
            ID = "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            URL = "https://example.com",

            // Null should be interpreted as omitted for these properties
            FrameID = null,
            Options = null,
            StreamResponse = null,
            XLanguage = null,
            XSDKVersion = null,
            XSentAt = null,
            XStreamResponse = null,
        };

        Assert.Null(parameters.FrameID);
        Assert.False(parameters.RawBodyData.ContainsKey("frameId"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
        Assert.Null(parameters.StreamResponse);
        Assert.False(parameters.RawBodyData.ContainsKey("streamResponse"));
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

public class SessionNavigateParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            Referer = "referer",
            Timeout = 30000,
            WaitUntil = WaitUntil.Networkidle,
        };

        string expectedReferer = "referer";
        double expectedTimeout = 30000;
        ApiEnum<string, WaitUntil> expectedWaitUntil = WaitUntil.Networkidle;

        Assert.Equal(expectedReferer, model.Referer);
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.Equal(expectedWaitUntil, model.WaitUntil);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            Referer = "referer",
            Timeout = 30000,
            WaitUntil = WaitUntil.Networkidle,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateParamsOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            Referer = "referer",
            Timeout = 30000,
            WaitUntil = WaitUntil.Networkidle,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateParamsOptions>(element);
        Assert.NotNull(deserialized);

        string expectedReferer = "referer";
        double expectedTimeout = 30000;
        ApiEnum<string, WaitUntil> expectedWaitUntil = WaitUntil.Networkidle;

        Assert.Equal(expectedReferer, deserialized.Referer);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.Equal(expectedWaitUntil, deserialized.WaitUntil);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            Referer = "referer",
            Timeout = 30000,
            WaitUntil = WaitUntil.Networkidle,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionNavigateParamsOptions { };

        Assert.Null(model.Referer);
        Assert.False(model.RawData.ContainsKey("referer"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.WaitUntil);
        Assert.False(model.RawData.ContainsKey("waitUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionNavigateParamsOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Referer = null,
            Timeout = null,
            WaitUntil = null,
        };

        Assert.Null(model.Referer);
        Assert.False(model.RawData.ContainsKey("referer"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.WaitUntil);
        Assert.False(model.RawData.ContainsKey("waitUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            // Null should be interpreted as omitted for these properties
            Referer = null,
            Timeout = null,
            WaitUntil = null,
        };

        model.Validate();
    }
}

public class WaitUntilTest : TestBase
{
    [Theory]
    [InlineData(WaitUntil.Load)]
    [InlineData(WaitUntil.Domcontentloaded)]
    [InlineData(WaitUntil.Networkidle)]
    public void Validation_Works(WaitUntil rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WaitUntil> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WaitUntil>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WaitUntil.Load)]
    [InlineData(WaitUntil.Domcontentloaded)]
    [InlineData(WaitUntil.Networkidle)]
    public void SerializationRoundtrip_Works(WaitUntil rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WaitUntil> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WaitUntil>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WaitUntil>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WaitUntil>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SessionNavigateParamsXLanguageTest : TestBase
{
    [Theory]
    [InlineData(SessionNavigateParamsXLanguage.Typescript)]
    [InlineData(SessionNavigateParamsXLanguage.Python)]
    [InlineData(SessionNavigateParamsXLanguage.Playground)]
    public void Validation_Works(SessionNavigateParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionNavigateParamsXLanguage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionNavigateParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionNavigateParamsXLanguage.Typescript)]
    [InlineData(SessionNavigateParamsXLanguage.Python)]
    [InlineData(SessionNavigateParamsXLanguage.Playground)]
    public void SerializationRoundtrip_Works(SessionNavigateParamsXLanguage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionNavigateParamsXLanguage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionNavigateParamsXLanguage>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SessionNavigateParamsXLanguage>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionNavigateParamsXLanguage>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SessionNavigateParamsXStreamResponseTest : TestBase
{
    [Theory]
    [InlineData(SessionNavigateParamsXStreamResponse.True)]
    [InlineData(SessionNavigateParamsXStreamResponse.False)]
    public void Validation_Works(SessionNavigateParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionNavigateParamsXStreamResponse> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionNavigateParamsXStreamResponse>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionNavigateParamsXStreamResponse.True)]
    [InlineData(SessionNavigateParamsXStreamResponse.False)]
    public void SerializationRoundtrip_Works(SessionNavigateParamsXStreamResponse rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SessionNavigateParamsXStreamResponse> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionNavigateParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SessionNavigateParamsXStreamResponse>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SessionNavigateParamsXStreamResponse>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
