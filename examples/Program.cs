using System;
using System.Threading.Tasks;

namespace Stagehand.Examples
{
    internal static class Program
    {
        private static async Task<int> Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return 1;
            }

            switch (args[0].ToLowerInvariant())
            {
                case "remote":
                    await RemoteBrowserPlaywrightExample.RunAsync();
                    return 0;
                case "local":
                    await LocalBrowserPlaywrightExample.RunAsync();
                    return 0;
                case "local-multiregion":
                    await LocalServerMultiregionBrowserExample.RunAsync();
                    return 0;
                default:
                    Console.Error.WriteLine($"Unknown example: {args[0]}");
                    PrintUsage();
                    return 1;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: dotnet run --project examples -- <remote|local|local-multiregion>");
        }
    }
}
