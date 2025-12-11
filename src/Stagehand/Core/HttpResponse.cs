using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stagehand.Exceptions;

namespace Stagehand.Core;

public sealed class HttpResponse : IDisposable
{
    public required HttpResponseMessage Message { get; init; }

    public CancellationToken CancellationToken { get; init; } = default;

    public async Task<T> Deserialize<T>(CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        try
        {
            return await JsonSerializer
                    .DeserializeAsync<T>(
                        await this.ReadAsStream(cts.Token).ConfigureAwait(false),
                        ModelBase.SerializerOptions,
                        cts.Token
                    )
                    .ConfigureAwait(false)
                ?? throw new StagehandInvalidDataException("Response cannot be null");
        }
        catch (HttpRequestException e)
        {
            throw new StagehandIOException("I/O Exception", e);
        }
    }

    public async Task<Stream> ReadAsStream(CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return await Message.Content.ReadAsStreamAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public async Task<string> ReadAsString(CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return await Message.Content.ReadAsStringAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public void Dispose()
    {
        this.Message.Dispose();
    }
}
