using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;
using Stagehand.Models.Sessions;

namespace Stagehand.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISessionService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Executes a browser action using natural language instructions or a predefined
    /// Action object.
    /// </summary>
    Task<JsonElement> Act(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Act(SessionActParams, CancellationToken)"/>
    Task<JsonElement> Act(
        JsonElement id,
        SessionActParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminates the browser session and releases all associated resources.
    /// </summary>
    Task<JsonElement> End(
        SessionEndParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="End(SessionEndParams, CancellationToken)"/>
    Task<JsonElement> End(
        JsonElement id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Runs an autonomous AI agent that can perform complex multi-step browser tasks.
    /// </summary>
    Task<JsonElement> ExecuteAgent(
        SessionExecuteAgentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExecuteAgent(SessionExecuteAgentParams, CancellationToken)"/>
    Task<JsonElement> ExecuteAgent(
        JsonElement id,
        SessionExecuteAgentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Extracts structured data from the current page using AI-powered analysis.
    /// </summary>
    Task<JsonElement> Extract(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Extract(SessionExtractParams, CancellationToken)"/>
    Task<JsonElement> Extract(
        JsonElement id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Navigates the browser to the specified URL.
    /// </summary>
    Task<JsonElement> Navigate(
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Navigate(SessionNavigateParams, CancellationToken)"/>
    Task<JsonElement> Navigate(
        JsonElement id,
        SessionNavigateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Identifies and returns available actions on the current page that match the
    /// given instruction.
    /// </summary>
    Task<JsonElement> Observe(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Observe(SessionObserveParams, CancellationToken)"/>
    Task<JsonElement> Observe(
        JsonElement id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new browser session with the specified configuration. Returns a
    /// session ID used for all subsequent operations.
    /// </summary>
    Task<JsonElement> Start(
        SessionStartParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
