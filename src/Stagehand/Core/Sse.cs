using System.Collections.Generic;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Stagehand.Exceptions;

namespace Stagehand.Core;

static class Sse
{
    internal static async IAsyncEnumerable<T> Enumerate<T>(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);

        await foreach (var item in SseParser.Create(stream).EnumerateAsync(cancellationToken))
        {
            switch (item.EventType)
            {
                case "error":
                    throw new StagehandSseException(
                        string.Format("SSE error returned from server: '{0}'", item.Data)
                    );
                case "starting":
                case "connected":
                case "running":
                case "finished":
                    T? message;
                    try
                    {
                        message = JsonSerializer.Deserialize<T>(
                            item.Data,
                            ModelBase.SerializerOptions
                        );
                    }
                    catch (JsonException e)
                    {
                        throw new StagehandInvalidDataException(
                            $"Message must be of type {typeof(T).FullName}",
                            e
                        );
                    }
                    yield return message
                        ?? throw new StagehandInvalidDataException("Message cannot be null");
                    break;
            }
        }
    }
}
