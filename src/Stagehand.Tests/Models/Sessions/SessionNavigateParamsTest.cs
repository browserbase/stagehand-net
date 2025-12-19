using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

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
