using System;
using System.Net.Http;
using Stagehand.Exceptions;

namespace Stagehand.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public struct ClientOptions()
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    /// </summary>
    public HttpClient HttpClient { get; set; } = new();

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("STAGEHAND_BASE_URL") ?? EnvironmentUrl.Production
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate every response before returning it.
    ///
    /// <para>Defaults to false, which means the shape of the response will not be
    /// validated upfront. Instead, validation will only occur for the parts of the
    /// response that are accessed.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

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
    public int? MaxRetries { get; set; }

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    Lazy<string> _browserbaseAPIKey = new(() =>
        Environment.GetEnvironmentVariable("BROWSERBASE_API_KEY")
        ?? throw new StagehandInvalidDataException(
            string.Format("{0} cannot be null", nameof(BrowserbaseAPIKey)),
            new ArgumentNullException(nameof(BrowserbaseAPIKey))
        )
    );

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    public string BrowserbaseAPIKey
    {
        readonly get { return _browserbaseAPIKey.Value; }
        set { _browserbaseAPIKey = new(() => value); }
    }

    /// <summary>
    /// Your [Browserbase Project ID](https://www.browserbase.com/settings)
    /// </summary>
    Lazy<string> _browserbaseProjectID = new(() =>
        Environment.GetEnvironmentVariable("BROWSERBASE_PROJECT_ID")
        ?? throw new StagehandInvalidDataException(
            string.Format("{0} cannot be null", nameof(BrowserbaseProjectID)),
            new ArgumentNullException(nameof(BrowserbaseProjectID))
        )
    );

    /// <summary>
    /// Your [Browserbase Project ID](https://www.browserbase.com/settings)
    /// </summary>
    public string BrowserbaseProjectID
    {
        readonly get { return _browserbaseProjectID.Value; }
        set { _browserbaseProjectID = new(() => value); }
    }

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    Lazy<string> _modelAPIKey = new(() =>
        Environment.GetEnvironmentVariable("MODEL_API_KEY")
        ?? throw new StagehandInvalidDataException(
            string.Format("{0} cannot be null", nameof(ModelAPIKey)),
            new ArgumentNullException(nameof(ModelAPIKey))
        )
    );

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    public string ModelAPIKey
    {
        readonly get { return _modelAPIKey.Value; }
        set { _modelAPIKey = new(() => value); }
    }
}
