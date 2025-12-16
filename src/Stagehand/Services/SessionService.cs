using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;
using Stagehand.Exceptions;
using Sessions = Stagehand.Models.Sessions;

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
    public async Task<Sessions::SessionActResponse> Act(
        Sessions::SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new StagehandInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<Sessions::SessionActParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Sessions::SessionActResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionActResponse> Act(
        string sessionID,
        Sessions::SessionActParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Act(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionEndResponse> End(
        Sessions::SessionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new StagehandInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<Sessions::SessionEndParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Sessions::SessionEndResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionEndResponse> End(
        string sessionID,
        Sessions::SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.End(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionExecuteAgentResponse> ExecuteAgent(
        Sessions::SessionExecuteAgentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new StagehandInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<Sessions::SessionExecuteAgentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Sessions::SessionExecuteAgentResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionExecuteAgentResponse> ExecuteAgent(
        string sessionID,
        Sessions::SessionExecuteAgentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.ExecuteAgent(
            parameters with
            {
                SessionID = sessionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionExtractResponse> Extract(
        Sessions::SessionExtractParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new StagehandInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<Sessions::SessionExtractParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Sessions::SessionExtractResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionExtractResponse> Extract(
        string sessionID,
        Sessions::SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Extract(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionNavigateResponse?> Navigate(
        Sessions::SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new StagehandInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<Sessions::SessionNavigateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Sessions::SessionNavigateResponse?>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse?.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionNavigateResponse?> Navigate(
        string sessionID,
        Sessions::SessionNavigateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Navigate(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Sessions::Action>> Observe(
        Sessions::SessionObserveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new StagehandInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<Sessions::SessionObserveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var actions = await response
            .Deserialize<List<Sessions::Action>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in actions)
            {
                item.Validate();
            }
        }
        return actions;
    }

    /// <inheritdoc/>
    public async Task<List<Sessions::Action>> Observe(
        string sessionID,
        Sessions::SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Observe(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Sessions::SessionStartResponse> Start(
        Sessions::SessionStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Sessions::SessionStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Sessions::SessionStartResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
