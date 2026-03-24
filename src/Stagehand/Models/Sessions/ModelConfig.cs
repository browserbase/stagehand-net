using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;
using Stagehand.Exceptions;
using System = System;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<ModelConfig, ModelConfigFromRaw>))]
public sealed record class ModelConfig : JsonModel
{
    /// <summary>
    /// Model name string with provider prefix (e.g., 'openai/gpt-5-nano')
    /// </summary>
    public required string ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("modelName");
        }
        init { this._rawData.Set("modelName", value); }
    }

    /// <summary>
    /// API key for the model provider
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKey", value);
        }
    }

    /// <summary>
    /// Base URL for the model provider
    /// </summary>
    public string? BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseURL");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseURL", value);
        }
    }

    /// <summary>
    /// Custom headers sent with every request to the model provider
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// AI provider for the model (or provide a baseURL endpoint instead)
    /// </summary>
    public ApiEnum<string, ModelConfigProvider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ModelConfigProvider>>("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ModelName;
        _ = this.ApiKey;
        _ = this.BaseUrl;
        _ = this.Headers;
        this.Provider?.Validate();
    }

    public ModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelConfig(ModelConfig modelConfig)
        : base(modelConfig) { }
#pragma warning restore CS8618

    public ModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelConfigFromRaw.FromRawUnchecked"/>
    public static ModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ModelConfig(string modelName)
        : this()
    {
        this.ModelName = modelName;
    }
}

class ModelConfigFromRaw : IFromRawJson<ModelConfig>
{
    /// <inheritdoc/>
    public ModelConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// AI provider for the model (or provide a baseURL endpoint instead)
/// </summary>
[JsonConverter(typeof(ModelConfigProviderConverter))]
public enum ModelConfigProvider
{
    OpenAI,
    Anthropic,
    Google,
    Microsoft,
    Bedrock,
}

sealed class ModelConfigProviderConverter : JsonConverter<ModelConfigProvider>
{
    public override ModelConfigProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => ModelConfigProvider.OpenAI,
            "anthropic" => ModelConfigProvider.Anthropic,
            "google" => ModelConfigProvider.Google,
            "microsoft" => ModelConfigProvider.Microsoft,
            "bedrock" => ModelConfigProvider.Bedrock,
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
                ModelConfigProvider.Microsoft => "microsoft",
                ModelConfigProvider.Bedrock => "bedrock",
                _ => throw new StagehandInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
