using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BrowserbaseStagehandNet.Core;
using Sessions = BrowserbaseStagehandNet.Models.Sessions;

namespace BrowserbaseStagehandNet.Services;

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
    /// Performs a browser action based on natural language instruction or a specific
    /// action object returned by observe().
    /// </summary>
    Task<Sessions::SessionActResponse> Act(
        Sessions::SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Act(Sessions::SessionActParams, CancellationToken)"/>
    Task<Sessions::SessionActResponse> Act(
        string sessionID,
        Sessions::SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Closes the browser and cleans up all resources associated with the session.
    /// </summary>
    Task<Sessions::SessionEndResponse> End(
        Sessions::SessionEndParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="End(Sessions::SessionEndParams, CancellationToken)"/>
    Task<Sessions::SessionEndResponse> End(
        string sessionID,
        Sessions::SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Runs an autonomous agent that can perform multiple actions to complete a
    /// complex task.
    /// </summary>
    Task<Sessions::SessionExecuteAgentResponse> ExecuteAgent(
        Sessions::SessionExecuteAgentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExecuteAgent(Sessions::SessionExecuteAgentParams, CancellationToken)"/>
    Task<Sessions::SessionExecuteAgentResponse> ExecuteAgent(
        string sessionID,
        Sessions::SessionExecuteAgentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Extracts data from the current page using natural language instructions and
    /// optional JSON schema for structured output.
    /// </summary>
    Task<Sessions::SessionExtractResponse> Extract(
        Sessions::SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Extract(Sessions::SessionExtractParams, CancellationToken)"/>
    Task<Sessions::SessionExtractResponse> Extract(
        string sessionID,
        Sessions::SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Navigates the browser to the specified URL and waits for page load.
    /// </summary>
    Task<Sessions::SessionNavigateResponse?> Navigate(
        Sessions::SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Navigate(Sessions::SessionNavigateParams, CancellationToken)"/>
    Task<Sessions::SessionNavigateResponse?> Navigate(
        string sessionID,
        Sessions::SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of candidate actions that can be performed on the page, optionally
    /// filtered by natural language instruction.
    /// </summary>
    Task<List<Sessions::Action>> Observe(
        Sessions::SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Observe(Sessions::SessionObserveParams, CancellationToken)"/>
    Task<List<Sessions::Action>> Observe(
        string sessionID,
        Sessions::SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initializes a new Stagehand session with a browser instance. Returns a session
    /// ID that must be used for all subsequent requests.
    /// </summary>
    Task<Sessions::SessionStartResponse> Start(
        Sessions::SessionStartParams parameters,
        CancellationToken cancellationToken = default
    );
}
