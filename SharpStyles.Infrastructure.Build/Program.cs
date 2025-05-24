// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using ADotNet.Clients.Builders;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;

namespace SharpStyles.Infrastructure.Build
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
            string directoryPath = Path.GetDirectoryName(buildScriptPath);

            if (Directory.Exists(directoryPath) is false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            GitHubPipelineBuilder.CreateNewPipeline()
                .SetName("Build & Test SharpStyles")
                    .OnPush("master")
                        .OnPullRequest("master")
                            .AddJob("build", job => job
                                .WithName("Build")
                                .RunsOn(BuildMachines.Windows2022)
                                .AddCheckoutStep("Check Out")

                                .AddSetupDotNetStep(
                                    version: "9.0.101",
                                    includePrerelease: true)

                                .AddRestoreStep()
                                .AddBuildStep()
                                .AddTestStep())

                .SaveToFile(buildScriptPath);
        }
    }
}
