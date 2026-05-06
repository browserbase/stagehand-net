using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;
using Stagehand.Services;

namespace Stagehand;

/// <summary>
/// A client for interacting with the Stagehand REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStagehandClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    string BrowserbaseApiKey { get; init; }

    /// <summary>
    /// Deprecated. Browserbase API keys are now project-scoped, so this value is
    /// no longer required.
    /// </summary>
    string? BrowserbaseProjectID { get; init; }

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    string ModelApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStagehandClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStagehandClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISessionService Sessions { get; }
}

/// <summary>
/// A view of <see cref="IStagehandClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IStagehandClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    string BrowserbaseApiKey { get; init; }

    /// <summary>
    /// Deprecated. Browserbase API keys are now project-scoped, so this value is
    /// no longer required.
    /// </summary>
    string? BrowserbaseProjectID { get; init; }

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    string ModelApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStagehandClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISessionServiceWithRawResponse Sessions { get; }

    /// <summary>
    /// Sends a request to the Stagehand REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
