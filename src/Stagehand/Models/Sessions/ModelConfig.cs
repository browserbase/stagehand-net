using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(ModelConverter<ModelConfig, ModelConfigFromRaw>))]
public sealed record class ModelConfig : ModelBase
{
    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? APIKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "apiKey"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "apiKey", value);
        }
    }

    /// <summary>
    /// Custom base URL for API
    /// </summary>
    public string? BaseURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "baseURL"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "baseURL", value);
        }
    }

    /// <summary>
    /// Model name
    /// </summary>
    public string? Model
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "model"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "model", value);
        }
    }

    public ApiEnum<string, ModelConfigProvider>? Provider
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, ModelConfigProvider>>(
                this.RawData,
                "provider"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.APIKey;
        _ = this.BaseURL;
        _ = this.Model;
        this.Provider?.Validate();
    }

    public ModelConfig() { }

    public ModelConfig(ModelConfig modelConfig)
        : base(modelConfig) { }

    public ModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigFromRaw.FromRawUnchecked"/>
    public static ModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelConfigFromRaw : IFromRaw<ModelConfig>
{
    /// <inheritdoc/>
    public ModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConfigProviderConverter))]
public enum ModelConfigProvider
{
    OpenAI,
    Anthropic,
    Google,
}

sealed class ModelConfigProviderConverter : JsonConverter<ModelConfigProvider>
{
    public override ModelConfigProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => ModelConfigProvider.OpenAI,
            "anthropic" => ModelConfigProvider.Anthropic,
            "google" => ModelConfigProvider.Google,
            _ => (ModelConfigProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ModelConfigProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ModelConfigProvider.OpenAI => "openai",
                ModelConfigProvider.Anthropic => "anthropic",
                ModelConfigProvider.Google => "google",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
