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

        var done = false;
        await foreach (var item in SseParser.Create(stream).EnumerateAsync(cancellationToken))
        {
            // Stop emitting messages, but iterate through the full stream.
            if (done)
            {
                continue;
            }

            if (item.Data.StartsWith("finished"))
            {
                // In this case we don't break because we still want to iterate through the full stream.
                done = true;
                continue;
            }
            else if (item.Data.StartsWith("error"))
            {
                throw new StagehandSseException(
                    string.Format("SSE error returned from server: '{0}'", item.Data)
                );
            }

            switch (item.EventType)
            {
                case null:
                    yield return JsonSerializer.Deserialize<T>(item.Data)
                        ?? throw new StagehandInvalidDataException("Message cannot be null");
                    break;
            }
        }
    }
}
