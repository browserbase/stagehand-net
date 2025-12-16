using System.Text.Json;
using BrowserbaseStagehandNet.Models.Sessions;

namespace BrowserbaseStagehandNet.Tests.Models.Sessions;

public class SessionNavigateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionNavigateResponse
        {
            Ok = true,
            Status = 0,
            URL = "url",
        };

        bool expectedOk = true;
        long expectedStatus = 0;
        string expectedURL = "url";

        Assert.Equal(expectedOk, model.Ok);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SessionNavigateResponse
        {
            Ok = true,
            Status = 0,
            URL = "url",
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
            Ok = true,
            Status = 0,
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SessionNavigateResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedOk = true;
        long expectedStatus = 0;
        string expectedURL = "url";

        Assert.Equal(expectedOk, deserialized.Ok);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SessionNavigateResponse
        {
            Ok = true,
            Status = 0,
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionNavigateResponse { };

        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionNavigateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionNavigateResponse
        {
            // Null should be interpreted as omitted for these properties
            Ok = null,
            Status = null,
            URL = null,
        };

        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SessionNavigateResponse
        {
            // Null should be interpreted as omitted for these properties
            Ok = null,
            Status = null,
            URL = null,
        };

        model.Validate();
    }
}
