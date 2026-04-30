using System;
using Stagehand.Core;

namespace Stagehand.Tests;

[Collection("Environment variables")]
public class ClientOptionsTest
{
    [Fact]
    public void BaseUrlUsesStagehandApiUrl()
    {
        WithEnv(
            "STAGEHAND_API_URL",
            "http://localhost:5000/from-api-env",
            "STAGEHAND_BASE_URL",
            "http://localhost:5000/from-base-env",
            () =>
            {
                var options = new ClientOptions();

                Assert.Equal("http://localhost:5000/from-api-env", options.BaseUrl);
            }
        );
    }

    [Fact]
    public void BaseUrlUsesLegacyStagehandBaseUrl()
    {
        WithEnv(
            "STAGEHAND_API_URL",
            null,
            "STAGEHAND_BASE_URL",
            "http://localhost:5000/from-base-env",
            () =>
            {
                var options = new ClientOptions();

                Assert.Equal("http://localhost:5000/from-base-env", options.BaseUrl);
            }
        );
    }

    static void WithEnv(
        string firstKey,
        string? firstValue,
        string secondKey,
        string? secondValue,
        Action action
    )
    {
        var firstOldValue = Environment.GetEnvironmentVariable(firstKey);
        var secondOldValue = Environment.GetEnvironmentVariable(secondKey);
        try
        {
            Environment.SetEnvironmentVariable(firstKey, firstValue);
            Environment.SetEnvironmentVariable(secondKey, secondValue);
            action();
        }
        finally
        {
            Environment.SetEnvironmentVariable(firstKey, firstOldValue);
            Environment.SetEnvironmentVariable(secondKey, secondOldValue);
        }
    }
}

[CollectionDefinition("Environment variables", DisableParallelization = true)]
public class EnvironmentVariablesCollection { }
