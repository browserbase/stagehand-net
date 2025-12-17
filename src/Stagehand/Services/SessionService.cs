using System;
using System.Net.Http;
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
    public async Task<JsonElement> Act(
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
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Act(
        JsonElement id,
        SessionActParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Act(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> End(
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
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> End(
        JsonElement id,
        SessionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.End(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> ExecuteAgent(
        SessionExecuteAgentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StagehandInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SessionExecuteAgentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> ExecuteAgent(
        JsonElement id,
        SessionExecuteAgentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ExecuteAgent(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Extract(
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
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Extract(
        JsonElement id,
        SessionExtractParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Extract(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Navigate(
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
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Navigate(
        JsonElement id,
        SessionNavigateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Navigate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Observe(
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
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Observe(
        JsonElement id,
        SessionObserveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Observe(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Start(
        SessionStartParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SessionStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }
}
