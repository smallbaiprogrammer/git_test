using CapTraining.Apis;
using CapTraining.Models;
using Microsoft.Carina.Common.Utils;
using Microsoft.Carina.Common.Utils.Config;
using Microsoft.Carina.TextAnalytics.Algo.DTO;
using Microsoft.Carina.TextAnalytics.Common;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;

namespace Microsoft.Carina.TextAnalytics.Algo.Samples
{
    public class SampleManager_Tests : AlgoDomainTestBase
    {
        private static List<AlgoTemplate> fakeAlgoTemplates;
        private readonly IAlgoSpecRepository fakealgoSpecRepository;
        private readonly TrainingApiClient faketrainingApiClient;
        private readonly string fakeprojectId;
        private readonly AlgoSpecManager fakeAlgoSpecManager;

        public SampleManager_Tests()
        {
            var fakelogger = Substitute.For<ILogger<AlgoSpecManager>>();
            this.fakealgoSpecRepository = Substitute.For<IAlgoSpecRepository>();
            // problem one 
            // throw url formal Exception 
            //  endPoint and basicAuthorization should be 特定的值
            //  or it throws Excepiton;
            var endPoint = "fake_endPoint";
            var basicAuthorization = "fake_basic_Authorization";
            this.faketrainingApiClient = new TrainingApiClient(endPoint, basicAuthorization);
            this.fakeAlgoSpecManager = new AlgoSpecManager(fakelogger, fakealgoSpecRepository, faketrainingApiClient);
            fakeAlgoTemplates = this.fakeAlgoSpecManager.GetAlgoTemplateListAsync().Result;
            var configuration = ConfigFileLoader.LoadConfiguration().GetSection("Cap");
            this.fakeprojectId = configuration["PublicProjectId"];
        }

        [Fact]
        public void Test_GetAlgoSpecListAsync() 
        {
            // arrange
            var algoSpecTest = new AlgoSpec();

            // act
            var fake = this.fakeAlgoSpecManager.GetAlgoSpecListAsync(algoSpecTest);
            
            // assert 
            fake.ShouldBeNull();
        }

        [Fact]
        public void Test_CreateAlgoSpecAsync()
        {
            // arrange
            var fakeAlgoSpec = new AlgoSpec();
            fakeAlgoSpec.Modules.ShouldBe(default);

            // act
            var test_fakeAlgoSpec = this.fakeAlgoSpecManager.CreateAlgoSpecAsync(fakeAlgoSpec).Result;

            // assert
            foreach (var item in test_fakeAlgoSpec.Modules) 
            {
                ModulesModule createModule = item.Value.CapModule;
                createModule.Name.ShouldBe($"NLP {AlgoModuleHelper.ExtractInitials(test_fakeAlgoSpec.TaskType.GetDisplayName())} {test_fakeAlgoSpec.Name} {item.Key}");
                if (test_fakeAlgoSpec.Language != Language.Unspecified)
                {
                    createModule.Description.ShouldBe($"NLP {test_fakeAlgoSpec.TaskType.GetDisplayName()} {test_fakeAlgoSpec.Name} {item.Key} {test_fakeAlgoSpec.Language.GetDisplayName()}");
                }
                else
                {
                    createModule.Description = $"NLP {test_fakeAlgoSpec.TaskType.GetDisplayName()} {test_fakeAlgoSpec.Name} {item.Key}";
                }
                createModule.Type.ShouldBe(ModulesModule.TypeEnum.Docker);
                createModule.FamilyId.ShouldBe(test_fakeAlgoSpec.FamilyId.ToString());
                if (item.Key == ModuleType.Train)
                {
                    createModule.Category.ShouldBe(Constants.MachineLearning);
                }
                else
                {
                    createModule.Category.ShouldBe(Constants.Default);
                }
                //problem two 
                //createModule.ProjectId.ShouldBe();
                //createModule.Tags.ShouldBe(new List<string> { Constants.BuildIn });
                //item.Value.CapModule.ShouldBe(this.fake);
            }
        }

        // publem three 抛出异常后该如何测试
        [Fact]
        public void Test_ChangeDeprecateAlgoSpecAsync()
        {
            // arrange
            var test_id = Guid.NewGuid();
            var test_isDeprecate = true;
            var test_algoSpecOrigin = this.fakealgoSpecRepository.FindAsync(test_id).ConfigureAwait(false).GetAwaiter().GetResult();
            test_algoSpecOrigin.IsDeprecated.ShouldBe(default);

            // act 
            this.fakeAlgoSpecManager.ChangeDeprecateAlgoSpecAsync(test_id,test_isDeprecate);

            //assert
            var test_algoSpecChange = this.fakealgoSpecRepository.FindAsync(test_id).ConfigureAwait(false).GetAwaiter().GetResult();
            test_algoSpecChange.IsDeprecated.ShouldBeTrue();
        }
    }
}
