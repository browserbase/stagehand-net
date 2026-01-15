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
    /// <inheritdoc/>
    public ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SessionService(this._client.WithOptions(modifier));
    }

    readonly IStagehandClient _client;

    public SessionService(IStagehandClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SessionActResponse> Act(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionActResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SessionActResponse> Act(
        string id,
        SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Act(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ActStreaming(
        SessionActParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(parameters.RawBodyData, e => e.Key, e => e.Value);
        rawBodyData["streamResponse"] = JsonSerializer.Deserialize<JsonElement>("true");
        parameters = SessionActParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );

        HttpRequest<SessionActParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var deserializedItem in Sse.Enumerate<StreamEvent>(response.Message, cancellationToken)
        )
        {
            if (this._client.ResponseValidation)
            {
                deserializedItem.Validate();
            }
            yield return deserializedItem;
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
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionEndParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionEndResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SessionEndResponse> End(
        string id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.End(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionExecuteResponse> Execute(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionExecuteResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SessionExecuteResponse> Execute(
        string id,
        SessionExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Execute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ExecuteStreaming(
        SessionExecuteParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(parameters.RawBodyData, e => e.Key, e => e.Value);
        rawBodyData["streamResponse"] = JsonSerializer.Deserialize<JsonElement>("true");
        parameters = SessionExecuteParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );

        HttpRequest<SessionExecuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var deserializedItem in Sse.Enumerate<StreamEvent>(response.Message, cancellationToken)
        )
        {
            if (this._client.ResponseValidation)
            {
                deserializedItem.Validate();
            }
            yield return deserializedItem;
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
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionExtractParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionExtractResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SessionExtractResponse> Extract(
        string id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Extract(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ExtractStreaming(
        SessionExtractParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(parameters.RawBodyData, e => e.Key, e => e.Value);
        rawBodyData["streamResponse"] = JsonSerializer.Deserialize<JsonElement>("true");
        parameters = SessionExtractParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );

        HttpRequest<SessionExtractParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var deserializedItem in Sse.Enumerate<StreamEvent>(response.Message, cancellationToken)
        )
        {
            if (this._client.ResponseValidation)
            {
                deserializedItem.Validate();
            }
            yield return deserializedItem;
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
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionNavigateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionNavigateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SessionNavigateResponse> Navigate(
        string id,
        SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Navigate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionObserveResponse> Observe(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionObserveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SessionObserveResponse> Observe(
        string id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Observe(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<StreamEvent> ObserveStreaming(
        SessionObserveParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawBodyData = Enumerable.ToDictionary(parameters.RawBodyData, e => e.Key, e => e.Value);
        rawBodyData["streamResponse"] = JsonSerializer.Deserialize<JsonElement>("true");
        parameters = SessionObserveParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );

        HttpRequest<SessionObserveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var deserializedItem in Sse.Enumerate<StreamEvent>(response.Message, cancellationToken)
        )
        {
            if (this._client.ResponseValidation)
            {
                deserializedItem.Validate();
            }
            yield return deserializedItem;
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
    public async Task<SessionStartResponse> Start(
        SessionStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SessionStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SessionStartResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
