using System;
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
    Task<SessionActResponse> Act(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Act(SessionActParams, CancellationToken)"/>
    Task<SessionActResponse> Act(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminates the browser session and releases all associated resources.
    /// </summary>
    Task<SessionEndResponse> End(
        SessionEndParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="End(SessionEndParams, CancellationToken)"/>
    Task<SessionEndResponse> End(
        string id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Runs an autonomous AI agent that can perform complex multi-step browser tasks.
    /// </summary>
    Task<SessionExecuteResponse> Execute(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Execute(SessionExecuteParams, CancellationToken)"/>
    Task<SessionExecuteResponse> Execute(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Extracts structured data from the current page using AI-powered analysis.
    /// </summary>
    Task<SessionExtractResponse> Extract(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Extract(SessionExtractParams, CancellationToken)"/>
    Task<SessionExtractResponse> Extract(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Navigates the browser to the specified URL.
    /// </summary>
    Task<SessionNavigateResponse> Navigate(
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Navigate(SessionNavigateParams, CancellationToken)"/>
    Task<SessionNavigateResponse> Navigate(
        string id,
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Identifies and returns available actions on the current page that match the
    /// given instruction.
    /// </summary>
    Task<SessionObserveResponse> Observe(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Observe(SessionObserveParams, CancellationToken)"/>
    Task<SessionObserveResponse> Observe(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new browser session with the specified configuration. Returns a
    /// session ID used for all subsequent operations.
    /// </summary>
    Task<SessionStartResponse> Start(
        SessionStartParams parameters,
        CancellationToken cancellationToken = default
    );
}
