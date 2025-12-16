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
public interface IStagehandClient
{
    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    /// </summary>
    HttpClient HttpClient { get; init; }

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    string BaseUrl { get; init; }

    /// <summary>
    /// Whether to validate every response before returning it.
    ///
    /// <para>Defaults to false, which means the shape of the response will not be
    /// validated upfront. Instead, validation will only occur for the parts of the
    /// response that are accessed.</para>
    /// </summary>
    bool ResponseValidation { get; init; }

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    int? MaxRetries { get; init; }

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    string BrowserbaseAPIKey { get; init; }

    /// <summary>
    /// Your [Browserbase Project ID](https://www.browserbase.com/settings)
    /// </summary>
    string BrowserbaseProjectID { get; init; }

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    string ModelAPIKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStagehandClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISessionService Sessions { get; }

    /// <summary>
    /// Sends a request to the Stagehand REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
