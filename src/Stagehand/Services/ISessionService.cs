using System;
using System.Text.Json;
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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new browser session with the specified configuration. Returns a
    /// session ID used for all subsequent operations.
    /// </summary>
    Task<JsonElement> Start(
        SessionStartParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
