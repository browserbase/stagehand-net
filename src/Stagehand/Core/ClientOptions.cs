using System;
using System.Net.Http;
using Stagehand.Exceptions;

namespace Stagehand.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
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
    ///
    /// <para>Note: The HttpClient has a built-in timeout, which defaults to 100 seconds.
    /// When passing a custom HttpClient, this timeout may conflict with the SDK's
    /// own timeout handler and cause premature cancellation.</para>
    /// </summary>
    public HttpClient HttpClient { get; set; } =
        new(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Available })
        {
            Timeout = global::System.Threading.Timeout.InfiniteTimeSpan,
        };

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
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="IStagehandClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
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
    public int? MaxRetries { get; set; } = null;

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    Lazy<string> _browserbaseApiKey = new(() =>
        Environment.GetEnvironmentVariable("BROWSERBASE_API_KEY")
        ?? throw new StagehandInvalidDataException(
            string.Format("{0} cannot be null", nameof(BrowserbaseApiKey)),
            new ArgumentNullException(nameof(BrowserbaseApiKey))
        )
    );

    /// <summary>
    /// Your [Browserbase API Key](https://www.browserbase.com/settings)
    /// </summary>
    public string BrowserbaseApiKey
    {
        readonly get { return _browserbaseApiKey.Value; }
        set { _browserbaseApiKey = new(() => value); }
    }

    /// <summary>
    /// Deprecated. Browserbase API keys are now project-scoped, so this value is
    /// no longer required.
    /// </summary>
    Lazy<string?> _browserbaseProjectID = new(() =>
        Environment.GetEnvironmentVariable("BROWSERBASE_PROJECT_ID")
    );

    /// <summary>
    /// Deprecated. Browserbase API keys are now project-scoped, so this value is
    /// no longer required.
    /// </summary>
    public string? BrowserbaseProjectID
    {
        readonly get { return _browserbaseProjectID.Value; }
        set { _browserbaseProjectID = new(() => value); }
    }

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    Lazy<string> _modelApiKey = new(() =>
        Environment.GetEnvironmentVariable("MODEL_API_KEY")
        ?? throw new StagehandInvalidDataException(
            string.Format("{0} cannot be null", nameof(ModelApiKey)),
            new ArgumentNullException(nameof(ModelApiKey))
        )
    );

    /// <summary>
    /// Your LLM provider API key (e.g. OPENAI_API_KEY, ANTHROPIC_API_KEY, etc.)
    /// </summary>
    public string ModelApiKey
    {
        readonly get { return _modelApiKey.Value; }
        set { _modelApiKey = new(() => value); }
    }
}
