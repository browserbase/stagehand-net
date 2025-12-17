using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Core;
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
