using System.Text.Json;
using BrowserbaseStagehandNet.Core;
using BrowserbaseStagehandNet.Exceptions;
using BrowserbaseStagehandNet.Models.Sessions;

namespace BrowserbaseStagehandNet.Tests.Models.Sessions;

public class SessionNavigateParamsOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionNavigateParamsOptions { WaitUntil = WaitUntil.Load };

        ApiEnum<string, WaitUntil> expectedWaitUntil = WaitUntil.Load;

        Assert.Equal(expectedWaitUntil, model.WaitUntil);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionNavigateParamsOptions { WaitUntil = WaitUntil.Load };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateParamsOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionNavigateParamsOptions { WaitUntil = WaitUntil.Load };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateParamsOptions>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, WaitUntil> expectedWaitUntil = WaitUntil.Load;

        Assert.Equal(expectedWaitUntil, deserialized.WaitUntil);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionNavigateParamsOptions { WaitUntil = WaitUntil.Load };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionNavigateParamsOptions { };

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
            WaitUntil = null,
        };

        Assert.Null(model.WaitUntil);
        Assert.False(model.RawData.ContainsKey("waitUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionNavigateParamsOptions
        {
            // Null should be interpreted as omitted for these properties
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
