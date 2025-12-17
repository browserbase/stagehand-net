using System;
using System.Net.Http;
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
