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
            // 
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
        public v

        [Fact]
        public void ChangeDeprecateAlgoSpecAsync_Test()
        {
            // arrange
            var guid = Guid.NewGuid();
            var isDeprecate = true;
            var fakealgoSpecOrigin = this.fakealgoSpecRepository.FindAsync(guid).ConfigureAwait(false).GetAwaiter().GetResult();

            // act
            var temp = this.fakeAlgoSpecManager.ChangeDeprecateAlgoSpecAsync(guid, isDeprecate);

            // assert
            fakealgoSpecOrigin.IsDeprecated.Returns(true);
        }

        [Fact]
        public void CreateCapModuleOncap_Test()
        {
            // arrange
            var fakeAlgoSpec = new AlgoSpec();


            // act
            AlgoSpec fakeAlgoSpecTem = (AlgoSpec)this.fakeAlgoSpecManager.GetAlgoSpecListAsync(fakeAlgoSpec);
            // assert
            foreach (var item in fakeAlgoSpec.Modules)
            {
                ModulesModule fakeModule = item.Value.CapModule;
                item.Value.CapModule.Name.Returns($"NLP {AlgoModuleHelper.ExtractInitials(fakeAlgoSpec.TaskType.GetDisplayName())} {fakeAlgoSpec.Name} {item.Key}");
                if (fakeAlgoSpec.Language != Language.Unspecified)
                {
                    fakeModule.Description.Returns($"NLP {fakeAlgoSpec.TaskType.GetDisplayName()} {fakeAlgoSpec.Name} {item.Key} {fakeAlgoSpec.Language.GetDisplayName()}");
                }
                else
                {
                    fakeModule.Description.Returns($"NLP {fakeAlgoSpec.TaskType.GetDisplayName()} {fakeAlgoSpec.Name} {item.Key}");
                }
                fakeModule.Type.Returns(ModulesModule.TypeEnum.Docker);
                fakeModule.FamilyId.Returns(fakeAlgoSpec.FamilyId.ToString());
                if (item.Key == ModuleType.Train)
                {
                    fakeModule.Category.Returns(Constants.MachineLearning);
                }
                else
                {
                    fakeModule.Category.Returns(Constants.Default);
                }
            }
        }
    }
}
