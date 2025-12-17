using System.Text.Json;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionNavigateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionNavigateResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionNavigateResponseSuccess.True,
        };

        SessionNavigateResponseData expectedData = new()
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };
        ApiEnum<bool, SessionNavigateResponseSuccess> expectedSuccess =
            SessionNavigateResponseSuccess.True;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionNavigateResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionNavigateResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionNavigateResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionNavigateResponseSuccess.True,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateResponse>(json);
        Assert.NotNull(deserialized);

        SessionNavigateResponseData expectedData = new()
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };
        ApiEnum<bool, SessionNavigateResponseSuccess> expectedSuccess =
            SessionNavigateResponseSuccess.True;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionNavigateResponse
        {
            Data = new()
            {
                Result = JsonSerializer.Deserialize<JsonElement>("{}"),
                ActionID = "actionId",
            },
            Success = SessionNavigateResponseSuccess.True,
        };

        model.Validate();
    }
}

public class SessionNavigateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionNavigateResponseData
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
        var model = new SessionNavigateResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionNavigateResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateResponseData>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedActionID = "actionId";

        Assert.True(JsonElement.DeepEquals(expectedResult, deserialized.Result));
        Assert.Equal(expectedActionID, deserialized.ActionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionNavigateResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionNavigateResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("actionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionNavigateResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionNavigateResponseData
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
        var model = new SessionNavigateResponseData
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            ActionID = null,
        };

        model.Validate();
    }
}

public class SessionNavigateResponseSuccessTest : TestBase
{
    [Theory]
    [InlineData(SessionNavigateResponseSuccess.True)]
    public void Validation_Works(SessionNavigateResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionNavigateResponseSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionNavigateResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<StagehandInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SessionNavigateResponseSuccess.True)]
    public void SerializationRoundtrip_Works(SessionNavigateResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SessionNavigateResponseSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, SessionNavigateResponseSuccess>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SessionNavigateResponseSuccess>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, SessionNavigateResponseSuccess>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
