using System.Text.Json;
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
            Success = true,
        };

        SessionNavigateResponseData expectedData = new()
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };
        bool expectedSuccess = true;

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
            Success = true,
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
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateResponse>(json);
        Assert.NotNull(deserialized);

        SessionNavigateResponseData expectedData = new()
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            ActionID = "actionId",
        };
        bool expectedSuccess = true;

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
            Success = true,
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
