using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stagehand.Core;

namespace Stagehand.Models.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionReplayResponse, SessionReplayResponseFromRaw>))]
public sealed record class SessionReplayResponse : JsonModel
{
    public required SessionReplayResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionReplayResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        _ = this.Success;
    }

    public SessionReplayResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionReplayResponse(SessionReplayResponse sessionReplayResponse)
        : base(sessionReplayResponse) { }
#pragma warning restore CS8618

    public SessionReplayResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionReplayResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionReplayResponseFromRaw.FromRawUnchecked"/>
    public static SessionReplayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionReplayResponseFromRaw : IFromRawJson<SessionReplayResponse>
{
    /// <inheritdoc/>
    public SessionReplayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionReplayResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SessionReplayResponseData, SessionReplayResponseDataFromRaw>)
)]
public sealed record class SessionReplayResponseData : JsonModel
{
    public IReadOnlyList<Page>? Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Page>>("pages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Page>?>(
                "pages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages ?? [])
        {
            item.Validate();
        }
    }

    public SessionReplayResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionReplayResponseData(SessionReplayResponseData sessionReplayResponseData)
        : base(sessionReplayResponseData) { }
#pragma warning restore CS8618

    public SessionReplayResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionReplayResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionReplayResponseDataFromRaw.FromRawUnchecked"/>
    public static SessionReplayResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionReplayResponseDataFromRaw : IFromRawJson<SessionReplayResponseData>
{
    /// <inheritdoc/>
    public SessionReplayResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionReplayResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Page, PageFromRaw>))]
public sealed record class Page : JsonModel
{
    public IReadOnlyList<PageAction>? Actions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PageAction>>("actions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PageAction>?>(
                "actions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Actions ?? [])
        {
            item.Validate();
        }
    }

    public Page() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Page(Page page)
        : base(page) { }
#pragma warning restore CS8618

    public Page(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Page(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageFromRaw.FromRawUnchecked"/>
    public static Page FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageFromRaw : IFromRawJson<Page>
{
    /// <inheritdoc/>
    public Page FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Page.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PageAction, PageActionFromRaw>))]
public sealed record class PageAction : JsonModel
{
    public string? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    public TokenUsage? TokenUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TokenUsage>("tokenUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tokenUsage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Method;
        this.TokenUsage?.Validate();
    }

    public PageAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageAction(PageAction pageAction)
        : base(pageAction) { }
#pragma warning restore CS8618

    public PageAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageActionFromRaw.FromRawUnchecked"/>
    public static PageAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageActionFromRaw : IFromRawJson<PageAction>
{
    /// <inheritdoc/>
    public PageAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PageAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TokenUsage, TokenUsageFromRaw>))]
public sealed record class TokenUsage : JsonModel
{
    public double? CachedInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cachedInputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cachedInputTokens", value);
        }
    }

    public double? InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("inputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inputTokens", value);
        }
    }

    public double? OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("outputTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("outputTokens", value);
        }
    }

    public double? ReasoningTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("reasoningTokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reasoningTokens", value);
        }
    }

    public double? TimeMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("timeMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeMs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CachedInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        _ = this.ReasoningTokens;
        _ = this.TimeMs;
    }

    public TokenUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenUsage(TokenUsage tokenUsage)
        : base(tokenUsage) { }
#pragma warning restore CS8618

    public TokenUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenUsageFromRaw.FromRawUnchecked"/>
    public static TokenUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TokenUsageFromRaw : IFromRawJson<TokenUsage>
{
    /// <inheritdoc/>
    public TokenUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TokenUsage.FromRawUnchecked(rawData);
}
