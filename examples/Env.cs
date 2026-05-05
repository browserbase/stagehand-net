using System;
using System.IO;
using System.Linq;

namespace Stagehand.Examples
{
    internal static class Env
    {
        private static readonly string[] RequiredKeys =
        [
            "STAGEHAND_API_URL",
            "MODEL_API_KEY",
            "BROWSERBASE_API_KEY",
            "BROWSERBASE_PROJECT_ID",
        ];

        public static void Load()
        {
            var envPath =
                FindEnvPath()
                ?? throw new InvalidOperationException(
                    "Missing examples/.env (expected in repo examples/ directory)."
                );

            foreach (var line in File.ReadAllLines(envPath))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith("#"))
                {
                    continue;
                }

                var parts = trimmed.Split('=', 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(parts[0])))
                {
                    Environment.SetEnvironmentVariable(parts[0], parts[1]);
                }
            }

            var missing = RequiredKeys
                .Where(key => string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(key)))
                .ToArray();
            if (missing.Length > 0)
            {
                throw new InvalidOperationException(
                    $"Missing required env vars: {string.Join(", ", missing)} (from examples/.env)"
                );
            }
        }

        private static string? FindEnvPath()
        {
            var current = Directory.GetCurrentDirectory();
            while (true)
            {
                var candidate = Path.Combine(current, "examples", ".env");
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                var parent = Directory.GetParent(current);
                if (parent == null)
                {
                    return null;
                }

                current = parent.FullName;
            }
        }
    }
}
