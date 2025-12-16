using System.Collections.Generic;
using System.Text.Json;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Models.Sessions;

public class SessionExtractResponseTest : TestBase
{
    [Fact]
    public void ExtractionValidation_Works()
    {
        SessionExtractResponse value = new(new Extraction() { ExtractionValue = "extraction" });
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidation_Works()
    {
        SessionExtractResponse value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ExtractionSerializationRoundtrip_Works()
    {
        SessionExtractResponse value = new(new Extraction() { ExtractionValue = "extraction" });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SessionExtractResponse>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtrip_Works()
    {
        SessionExtractResponse value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SessionExtractResponse>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Extraction { ExtractionValue = "extraction" };

        string expectedExtractionValue = "extraction";

        Assert.Equal(expectedExtractionValue, model.ExtractionValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Extraction { ExtractionValue = "extraction" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Extraction>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Extraction { ExtractionValue = "extraction" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Extraction>(json);
        Assert.NotNull(deserialized);

        string expectedExtractionValue = "extraction";

        Assert.Equal(expectedExtractionValue, deserialized.ExtractionValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Extraction { ExtractionValue = "extraction" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Extraction { };

        Assert.Null(model.ExtractionValue);
        Assert.False(model.RawData.ContainsKey("extraction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Extraction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Extraction
        {
            // Null should be interpreted as omitted for these properties
            ExtractionValue = null,
        };

        Assert.Null(model.ExtractionValue);
        Assert.False(model.RawData.ContainsKey("extraction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Extraction
        {
            // Null should be interpreted as omitted for these properties
            ExtractionValue = null,
        };

        model.Validate();
    }
}
