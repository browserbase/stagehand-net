using System.Collections.Generic;
using System.Threading.Tasks;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Services;

public class SessionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Act_Works()
    {
        var response = await this.client.Sessions.Act(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new() { Input = "Click the login button" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ActStreaming_Works()
    {
        var stream = this.client.Sessions.ActStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new() { Input = "Click the login button" },
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task End_Works()
    {
        var response = await this.client.Sessions.End(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Sessions.Execute(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new()
            {
                AgentConfig = new()
                {
                    Cua = true,
                    ExecutionModel = new ExecutionModelVertexModelConfigObject()
                    {
                        Auth = new()
                        {
                            Credentials = new()
                            {
                                ClientEmail = "client_email",
                                PrivateKey = "private_key",
                                AuthProviderX509CertUrl = "https://example.com",
                                AuthUri = "https://example.com",
                                ClientID = "client_id",
                                ClientX509CertUrl = "https://example.com",
                                PrivateKeyID = "private_key_id",
                                ProjectID = "project_id",
                                TokenUri = "https://example.com",
                                Type =
                                    ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                                UniverseDomain = "universe_domain",
                            },
                            ProjectID = "projectId",
                            Scopes = "string",
                            UniverseDomain = "universeDomain",
                        },
                        ModelName = "openai/gpt-5.4-mini",
                        ProviderOptions = new(
                            new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                            {
                                Location = "us-central1",
                                Project = "my-gcp-project",
                                BaseUrl = "https://example.com",
                                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                            }
                        ),
                        ApiKey = "sk-some-openai-api-key",
                        BaseUrl = "https://api.openai.com/v1",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    Mode = Mode.Cua,
                    Model = new AgentConfigModelVertexModelConfigObject()
                    {
                        Auth = new()
                        {
                            Credentials = new()
                            {
                                ClientEmail = "client_email",
                                PrivateKey = "private_key",
                                AuthProviderX509CertUrl = "https://example.com",
                                AuthUri = "https://example.com",
                                ClientID = "client_id",
                                ClientX509CertUrl = "https://example.com",
                                PrivateKeyID = "private_key_id",
                                ProjectID = "project_id",
                                TokenUri = "https://example.com",
                                Type =
                                    AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                                UniverseDomain = "universe_domain",
                            },
                            ProjectID = "projectId",
                            Scopes = "string",
                            UniverseDomain = "universeDomain",
                        },
                        ModelName = "openai/gpt-5.4-mini",
                        ProviderOptions = new(
                            new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                            {
                                Location = "us-central1",
                                Project = "my-gcp-project",
                                BaseUrl = "https://example.com",
                                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                            }
                        ),
                        ApiKey = "sk-some-openai-api-key",
                        BaseUrl = "https://api.openai.com/v1",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    Provider = AgentConfigProvider.OpenAI,
                    SystemPrompt = "systemPrompt",
                },
                ExecuteOptions = new()
                {
                    Instruction =
                        "Log in with username 'demo' and password 'test123', then navigate to settings",
                    HighlightCursor = true,
                    MaxSteps = 20,
                    ToolTimeout = 30000,
                    UseSearch = true,
                    Variables = new Dictionary<string, ExecuteOptionsVariable>()
                    {
                        { "foo", "string" },
                    },
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExecuteStreaming_Works()
    {
        var stream = this.client.Sessions.ExecuteStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new()
            {
                AgentConfig = new()
                {
                    Cua = true,
                    ExecutionModel = new ExecutionModelVertexModelConfigObject()
                    {
                        Auth = new()
                        {
                            Credentials = new()
                            {
                                ClientEmail = "client_email",
                                PrivateKey = "private_key",
                                AuthProviderX509CertUrl = "https://example.com",
                                AuthUri = "https://example.com",
                                ClientID = "client_id",
                                ClientX509CertUrl = "https://example.com",
                                PrivateKeyID = "private_key_id",
                                ProjectID = "project_id",
                                TokenUri = "https://example.com",
                                Type =
                                    ExecutionModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                                UniverseDomain = "universe_domain",
                            },
                            ProjectID = "projectId",
                            Scopes = "string",
                            UniverseDomain = "universeDomain",
                        },
                        ModelName = "openai/gpt-5.4-mini",
                        ProviderOptions = new(
                            new ExecutionModelVertexModelConfigObjectProviderOptionsVertex()
                            {
                                Location = "us-central1",
                                Project = "my-gcp-project",
                                BaseUrl = "https://example.com",
                                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                            }
                        ),
                        ApiKey = "sk-some-openai-api-key",
                        BaseUrl = "https://api.openai.com/v1",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    Mode = Mode.Cua,
                    Model = new AgentConfigModelVertexModelConfigObject()
                    {
                        Auth = new()
                        {
                            Credentials = new()
                            {
                                ClientEmail = "client_email",
                                PrivateKey = "private_key",
                                AuthProviderX509CertUrl = "https://example.com",
                                AuthUri = "https://example.com",
                                ClientID = "client_id",
                                ClientX509CertUrl = "https://example.com",
                                PrivateKeyID = "private_key_id",
                                ProjectID = "project_id",
                                TokenUri = "https://example.com",
                                Type =
                                    AgentConfigModelVertexModelConfigObjectAuthCredentialsType.ServiceAccount,
                                UniverseDomain = "universe_domain",
                            },
                            ProjectID = "projectId",
                            Scopes = "string",
                            UniverseDomain = "universeDomain",
                        },
                        ModelName = "openai/gpt-5.4-mini",
                        ProviderOptions = new(
                            new AgentConfigModelVertexModelConfigObjectProviderOptionsVertex()
                            {
                                Location = "us-central1",
                                Project = "my-gcp-project",
                                BaseUrl = "https://example.com",
                                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                            }
                        ),
                        ApiKey = "sk-some-openai-api-key",
                        BaseUrl = "https://api.openai.com/v1",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    Provider = AgentConfigProvider.OpenAI,
                    SystemPrompt = "systemPrompt",
                },
                ExecuteOptions = new()
                {
                    Instruction =
                        "Log in with username 'demo' and password 'test123', then navigate to settings",
                    HighlightCursor = true,
                    MaxSteps = 20,
                    ToolTimeout = 30000,
                    UseSearch = true,
                    Variables = new Dictionary<string, ExecuteOptionsVariable>()
                    {
                        { "foo", "string" },
                    },
                },
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Extract_Works()
    {
        var response = await this.client.Sessions.Extract(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExtractStreaming_Works()
    {
        var stream = this.client.Sessions.ExtractStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Navigate_Works()
    {
        var response = await this.client.Sessions.Navigate(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new() { UrlValue = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Observe_Works()
    {
        var response = await this.client.Sessions.Observe(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ObserveStreaming_Works()
    {
        var stream = this.client.Sessions.ObserveStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replay_Works()
    {
        var response = await this.client.Sessions.Replay(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Start_Works()
    {
        var response = await this.client.Sessions.Start(
            new() { ModelName = "openai/gpt-5.4-mini" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
