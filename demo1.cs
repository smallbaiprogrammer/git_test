using CapTraining.Apis;
using Microsoft.Carina.Common.Utils.Config;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;

namespace Microsoft.Carina.TextAnalytics.Algo.Experiments
{
    public class ExperimentManager_Tests : AlgoDomainTestBase
    {

        private readonly IExperimentRepository experimentRepository;
        private readonly IAlgoSpecRepository algoSpecRepository;
        private readonly string projectId;
        private readonly string shuffleTextFileModule;
        private readonly TrainingApiClient trainingApiClient;
        private readonly int priority;
        private readonly int runningTimeout;
        private readonly int waitingTimeout;
        private readonly string quotaGroup;
        private readonly ExperimentManager fakexperimentManager;

        public ExperimentManager_Tests()
        {
            this.experimentRepository = Substitute.For<IExperimentRepository>();
            this.algoSpecRepository = Substitute.For<IAlgoSpecRepository>();
            var configuration = ConfigFileLoader.LoadConfiguration();
            var capConfig = configuration.GetSection("Cap");
            this.projectId = capConfig["PublicProjectId"];
            this.shuffleTextFileModule = "fake_shuffle_text_file_module";
            var endpoint = "fake_endpoint";
            var basicAuthorization = "fake_basicAuthorization";
            this.trainingApiClient = new TrainingApiClient(endpoint, basicAuthorization);
            var jobConfig = configuration.GetSection("services:algo:Job");
            this.priority = string.IsNullOrEmpty(jobConfig["Priority"]) ? 1 : int.Parse(jobConfig["Priority"]);
            this.runningTimeout = string.IsNullOrEmpty(jobConfig["RunningTimeout"]) ? 4320000 : int.Parse(jobConfig["RunningTimeout"]);
            this.waitingTimeout = string.IsNullOrEmpty(jobConfig["WaitingTimeout"]) ? 43200 : int.Parse(jobConfig["WaitingTimeout"]);
            this.quotaGroup = "fake_quotaGroup";
            var logger = Substitute.For<ILogger<ExperimentManager>>();
            this.fakexperimentManager = new ExperimentManager(logger,this.experimentRepository,this.algoSpecRepository,this.trainingApiClient);
        }

        [Fact]
        public void Test_GetExperimentAsync_notThrow()
        {
            // arrange
            var id = new Guid();

            // act
            var result = this.fakexperimentManager.GetExperimentAsync(id).Result;

            // assert
        }

        [Fact]
        public void Test_GetExperimentAsync_throw()
        {
            // arrange
            var id = new Guid();

            // act
            // assert
        }
    }
}
