using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExtractResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionExtractResponseSuccess.True,
        };

        SessionExtractResponseData expectedData = new()
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };
        ApiEnum<bool, SessionExtractResponseSuccess> expectedSuccess =
            SessionExtractResponseSuccess.True;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExtractResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionExtractResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExtractResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionExtractResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExtractResponse>(json);
        Assert.NotNull(deserialized);

        SessionExtractResponseData expectedData = new()
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };
        ApiEnum<bool, SessionExtractResponseSuccess> expectedSuccess =
            SessionExtractResponseSuccess.True;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExtractResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionExtractResponseSuccess.True,
        };

        model.Validate();
    }
}

public class SessionExtractResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedActionID = "actionId";

        Assert.True(JsonElement.DeepEquals(expectedResult, model.Result));
        Assert.Equal(expectedActionID, model.ActionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExtractResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionExtractResponseData>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedActionID = "actionId";

        Assert.True(JsonElement.DeepEquals(expectedResult, deserialized.Result));
        Assert.Equal(expectedActionID, deserialized.ActionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionExtractResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        model.Validate();
    }
}

public class SessionExtractResponseSuccessTest : TestBase
{
    [Theory]
    [InlineData(SessionExtractResponseSuccess.True)]
    public void Validation_Works(SessionExtractResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionExtractResponseSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionExtractResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionExtractResponseSuccess.True)]
    public void SerializationRoundtrip_Works(SessionExtractResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionExtractResponseSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionExtractResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionExtractResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SessionExtractResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
