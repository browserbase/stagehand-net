using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class EnvTest : TestBase
{
    [Theory]
    [InlineData(Env.Local)]
    [InlineData(Env.Browserbase)]
    public void Validation_Works(Env rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Env> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Env>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Env.Local)]
    [InlineData(Env.Browserbase)]
    public void SerializationRoundtrip_Works(Env rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Env> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Env>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Env>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Env>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LocalBrowserLaunchOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocalBrowserLaunchOptions { Headless = true };

        bool expectedHeadless = true;

        Assert.Equal(expectedHeadless, model.Headless);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LocalBrowserLaunchOptions { Headless = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LocalBrowserLaunchOptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LocalBrowserLaunchOptions { Headless = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LocalBrowserLaunchOptions>(json);
        Assert.NotNull(deserialized);

        bool expectedHeadless = true;

        Assert.Equal(expectedHeadless, deserialized.Headless);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LocalBrowserLaunchOptions { Headless = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LocalBrowserLaunchOptions { };

        Assert.Null(model.Headless);
        Assert.False(model.RawData.ContainsKey("headless"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LocalBrowserLaunchOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LocalBrowserLaunchOptions
        {
            // Null should be interpreted as omitted for these properties
            Headless = null,
        };

        Assert.Null(model.Headless);
        Assert.False(model.RawData.ContainsKey("headless"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LocalBrowserLaunchOptions
        {
            // Null should be interpreted as omitted for these properties
            Headless = null,
        };

        model.Validate();
    }
}
