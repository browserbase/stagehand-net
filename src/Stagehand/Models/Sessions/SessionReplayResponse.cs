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
    public required IReadOnlyList<Page> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Page>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Page>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ClientLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clientLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("clientLanguage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
        _ = this.ClientLanguage;
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

    [SetsRequiredMembers]
    public SessionReplayResponseData(IReadOnlyList<Page> pages)
        : this()
    {
        this.Pages = pages;
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
    public required IReadOnlyList<PageAction> Actions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PageAction>>("actions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PageAction>>(
                "actions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    public required double Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Actions)
        {
            item.Validate();
        }
        _ = this.Duration;
        _ = this.Timestamp;
        _ = this.Url;
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
    public required string Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Parameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "parameters"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "parameters",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyDictionary<string, JsonElement> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("result");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "result",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required double Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    public double? EndTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("endTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endTime", value);
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
        _ = this.Parameters;
        _ = this.Result;
        _ = this.Timestamp;
        _ = this.EndTime;
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
    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cost", value);
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
        _ = this.Cost;
        _ = this.InputTokens;
        _ = this.OutputTokens;
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
