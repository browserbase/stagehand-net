using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;
using Stagehand.Exceptions;
using Stagehand.Models.Sessions;

namespace Stagehand.Services;

/// <inheritdoc/>
public sealed class SessionService : ISessionService
{
    readonly Lazy<ISessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISessionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStagehandClient _client;

    /// <inheritdoc/>
    public ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SessionService(this._client.WithOptions(modifier));
    }

    public SessionService(IStagehandClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SessionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SessionActResponse> Act(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Act(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionActResponse> Act(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Act(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ActStreaming(
        SessionActParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ActStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ActStreaming(
        string id,
        SessionActParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var item in this.ActStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async Task<SessionEndResponse> End(
        SessionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.End(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionEndResponse> End(
        string id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.End(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionExecuteResponse> Execute(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Execute(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionExecuteResponse> Execute(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Execute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ExecuteStreaming(
        SessionExecuteParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ExecuteStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ExecuteStreaming(
        string id,
        SessionExecuteParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var item in this.ExecuteStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async Task<SessionExtractResponse> Extract(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Extract(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionExtractResponse> Extract(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Extract(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ExtractStreaming(
        SessionExtractParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ExtractStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ExtractStreaming(
        string id,
        SessionExtractParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.ExtractStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async Task<SessionNavigateResponse> Navigate(
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Navigate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionNavigateResponse> Navigate(
        string id,
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Navigate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionObserveResponse> Observe(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Observe(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionObserveResponse> Observe(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Observe(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ObserveStreaming(
        SessionObserveParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ObserveStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var item in response.Enumerate(cancellationToken))
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ObserveStreaming(
        string id,
        SessionObserveParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.ObserveStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    public async Task<SessionReplayResponse> Replay(
        SessionReplayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replay(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SessionReplayResponse> Replay(
        string id,
        SessionReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replay(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionStartResponse> Start(
        SessionStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Start(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SessionServiceWithRawResponse : ISessionServiceWithRawResponse
{
    readonly IStagehandClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISessionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SessionServiceWithRawResponse(IStagehandClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionActResponse>> Act(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionActParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionActResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionActResponse>> Act(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Act(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<StreamEvent>> ActStreaming(
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawBodyData["streamResponse"] = JsonSerializer.SerializeToElement(true);
        parameters = SessionActParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData,
            parameters.ID
        );

        HttpRequest<SessionActParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<StreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var deserializedItem in Sse.Enumerate<StreamEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    deserializedItem.Validate();
                }
                yield return deserializedItem;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<StreamEvent>> ActStreaming(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ActStreaming(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionEndResponse>> End(
        SessionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionEndParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionEndResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionEndResponse>> End(
        string id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.End(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionExecuteResponse>> Execute(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionExecuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionExecuteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionExecuteResponse>> Execute(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Execute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<StreamEvent>> ExecuteStreaming(
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawBodyData["streamResponse"] = JsonSerializer.SerializeToElement(true);
        parameters = SessionExecuteParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData,
            parameters.ID
        );

        HttpRequest<SessionExecuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<StreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var deserializedItem in Sse.Enumerate<StreamEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    deserializedItem.Validate();
                }
                yield return deserializedItem;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<StreamEvent>> ExecuteStreaming(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ExecuteStreaming(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionExtractResponse>> Extract(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionExtractParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionExtractResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionExtractResponse>> Extract(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Extract(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<StreamEvent>> ExtractStreaming(
        SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawBodyData["streamResponse"] = JsonSerializer.SerializeToElement(true);
        parameters = SessionExtractParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData,
            parameters.ID
        );

        HttpRequest<SessionExtractParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<StreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var deserializedItem in Sse.Enumerate<StreamEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    deserializedItem.Validate();
                }
                yield return deserializedItem;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<StreamEvent>> ExtractStreaming(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ExtractStreaming(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionNavigateResponse>> Navigate(
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionNavigateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionNavigateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionNavigateResponse>> Navigate(
        string id,
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Navigate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionObserveResponse>> Observe(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionObserveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionObserveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionObserveResponse>> Observe(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Observe(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<StreamEvent>> ObserveStreaming(
        SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawBodyData["streamResponse"] = JsonSerializer.SerializeToElement(true);
        parameters = SessionObserveParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData,
            parameters.ID
        );

        HttpRequest<SessionObserveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<StreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var deserializedItem in Sse.Enumerate<StreamEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    deserializedItem.Validate();
                }
                yield return deserializedItem;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<StreamEvent>> ObserveStreaming(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ObserveStreaming(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionReplayResponse>> Replay(
        SessionReplayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionReplayParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionReplayResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SessionReplayResponse>> Replay(
        string id,
        SessionReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replay(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionStartResponse>> Start(
        SessionStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SessionStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SessionStartResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
