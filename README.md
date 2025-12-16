# Stagehand C# API Library

> [!NOTE]
> The Stagehand C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/browserbase/stagehand-net/issues/new).

The Stagehand C# SDK provides convenient access to the [Stagehand REST API](https://docs.stagehand.dev) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.stagehand.dev](https://docs.stagehand.dev).

## Installation

```bash
git clone git@github.com:browserbase/stagehand-net.git
dotnet add reference stagehand-net/src/Stagehand
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Stagehand;
using Stagehand.Models.Sessions;

StagehandClient client = new();

SessionActParams parameters = new()
{
    SessionID = "00000000-your-session-id-000000000000",
    Input = "click the first link on the page",
};

var response = await client.Sessions.Act(parameters);

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Stagehand;

// Configured using the BROWSERBASE_API_KEY, BROWSERBASE_PROJECT_ID, MODEL_API_KEY and STAGEHAND_BASE_URL environment variables
StagehandClient client = new();
```

Or manually:

```csharp
using Stagehand;

StagehandClient client = new()
{
    BrowserbaseAPIKey = "My Browserbase API Key",
    BrowserbaseProjectID = "My Browserbase Project ID",
    ModelAPIKey = "My Model API Key",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property               | Environment variable     | Required | Default value                                |
| ---------------------- | ------------------------ | -------- | -------------------------------------------- |
| `BrowserbaseAPIKey`    | `BROWSERBASE_API_KEY`    | true     | -                                            |
| `BrowserbaseProjectID` | `BROWSERBASE_PROJECT_ID` | true     | -                                            |
| `ModelAPIKey`          | `MODEL_API_KEY`          | true     | -                                            |
| `BaseUrl`              | `STAGEHAND_BASE_URL`     | true     | `"https://api.stagehand.browserbase.com/v1"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Sessions.Start(parameters);

Console.WriteLine(response);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Stagehand API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Sessions.Act` should be called with an instance of `SessionActParams`, and it will return an instance of `Task<SessionActResponse>`.

## Error handling

The SDK throws custom unchecked exception types:

- `StagehandApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                |
| ------ | ---------------------------------------- |
| 400    | `StagehandBadRequestException`           |
| 401    | `StagehandUnauthorizedException`         |
| 403    | `StagehandForbiddenException`            |
| 404    | `StagehandNotFoundException`             |
| 422    | `StagehandUnprocessableEntityException`  |
| 429    | `StagehandRateLimitException`            |
| 5xx    | `Stagehand5xxException`                  |
| others | `StagehandUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Stagehand4xxException`.

false

- `StagehandIOException`: I/O networking errors.

- `StagehandInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `StagehandException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Stagehand;

StagehandClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Sessions.Start(parameters);

Console.WriteLine(response);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Stagehand;

StagehandClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Sessions.Start(parameters);

Console.WriteLine(response);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `StagehandInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var response = client.Sessions.Act(parameters);
response.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Stagehand;

StagehandClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Sessions.Act(parameters);

Console.WriteLine(response);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/browserbase/stagehand-net/issues) with questions, bugs, or suggestions.
