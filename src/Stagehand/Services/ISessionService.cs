using System;
using System.Collections.Generic;
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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISessionServiceWithRawResponse WithRawResponse { get; }

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
    /// Executes a browser action using natural language instructions or a predefined
    /// Action object.
    /// </summary>
    IAsyncEnumerable<StreamEvent> ActStreaming(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ActStreaming(SessionActParams, CancellationToken)"/>
    IAsyncEnumerable<StreamEvent> ActStreaming(
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
    /// Runs an autonomous AI agent that can perform complex multi-step browser tasks.
    /// </summary>
    IAsyncEnumerable<StreamEvent> ExecuteStreaming(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExecuteStreaming(SessionExecuteParams, CancellationToken)"/>
    IAsyncEnumerable<StreamEvent> ExecuteStreaming(
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
    /// Extracts structured data from the current page using AI-powered analysis.
    /// </summary>
    IAsyncEnumerable<StreamEvent> ExtractStreaming(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExtractStreaming(SessionExtractParams, CancellationToken)"/>
    IAsyncEnumerable<StreamEvent> ExtractStreaming(
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
    /// Identifies and returns available actions on the current page that match the
    /// given instruction.
    /// </summary>
    IAsyncEnumerable<StreamEvent> ObserveStreaming(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ObserveStreaming(SessionObserveParams, CancellationToken)"/>
    IAsyncEnumerable<StreamEvent> ObserveStreaming(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves replay metrics for a session.
    /// </summary>
    Task<SessionReplayResponse> Replay(
        SessionReplayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replay(SessionReplayParams, CancellationToken)"/>
    Task<SessionReplayResponse> Replay(
        string id,
        SessionReplayParams? parameters = null,
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

/// <summary>
/// A view of <see cref="ISessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/act</c>, but is otherwise the
    /// same as <see cref="ISessionService.Act(SessionActParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionActResponse>> Act(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Act(SessionActParams, CancellationToken)"/>
    Task<HttpResponse<SessionActResponse>> Act(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/act</c>, but is otherwise the
    /// same as <see cref="ISessionService.ActStreaming(SessionActParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<StreamEvent>> ActStreaming(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ActStreaming(SessionActParams, CancellationToken)"/>
    Task<StreamingHttpResponse<StreamEvent>> ActStreaming(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/end</c>, but is otherwise the
    /// same as <see cref="ISessionService.End(SessionEndParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionEndResponse>> End(
        SessionEndParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="End(SessionEndParams, CancellationToken)"/>
    Task<HttpResponse<SessionEndResponse>> End(
        string id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/agentExecute</c>, but is otherwise the
    /// same as <see cref="ISessionService.Execute(SessionExecuteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionExecuteResponse>> Execute(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Execute(SessionExecuteParams, CancellationToken)"/>
    Task<HttpResponse<SessionExecuteResponse>> Execute(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/agentExecute</c>, but is otherwise the
    /// same as <see cref="ISessionService.ExecuteStreaming(SessionExecuteParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<StreamEvent>> ExecuteStreaming(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExecuteStreaming(SessionExecuteParams, CancellationToken)"/>
    Task<StreamingHttpResponse<StreamEvent>> ExecuteStreaming(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/extract</c>, but is otherwise the
    /// same as <see cref="ISessionService.Extract(SessionExtractParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionExtractResponse>> Extract(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Extract(SessionExtractParams, CancellationToken)"/>
    Task<HttpResponse<SessionExtractResponse>> Extract(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/extract</c>, but is otherwise the
    /// same as <see cref="ISessionService.ExtractStreaming(SessionExtractParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<StreamEvent>> ExtractStreaming(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExtractStreaming(SessionExtractParams, CancellationToken)"/>
    Task<StreamingHttpResponse<StreamEvent>> ExtractStreaming(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/navigate</c>, but is otherwise the
    /// same as <see cref="ISessionService.Navigate(SessionNavigateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionNavigateResponse>> Navigate(
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Navigate(SessionNavigateParams, CancellationToken)"/>
    Task<HttpResponse<SessionNavigateResponse>> Navigate(
        string id,
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/observe</c>, but is otherwise the
    /// same as <see cref="ISessionService.Observe(SessionObserveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionObserveResponse>> Observe(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Observe(SessionObserveParams, CancellationToken)"/>
    Task<HttpResponse<SessionObserveResponse>> Observe(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{id}/observe</c>, but is otherwise the
    /// same as <see cref="ISessionService.ObserveStreaming(SessionObserveParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<StreamEvent>> ObserveStreaming(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ObserveStreaming(SessionObserveParams, CancellationToken)"/>
    Task<StreamingHttpResponse<StreamEvent>> ObserveStreaming(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{id}/replay</c>, but is otherwise the
    /// same as <see cref="ISessionService.Replay(SessionReplayParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionReplayResponse>> Replay(
        SessionReplayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replay(SessionReplayParams, CancellationToken)"/>
    Task<HttpResponse<SessionReplayResponse>> Replay(
        string id,
        SessionReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/start</c>, but is otherwise the
    /// same as <see cref="ISessionService.Start(SessionStartParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionStartResponse>> Start(
        SessionStartParams parameters,
        CancellationToken cancellationToken = default
    );
}
