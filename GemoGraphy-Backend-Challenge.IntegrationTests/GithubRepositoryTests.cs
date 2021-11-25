using System.Linq;
using System.Threading.Tasks;
using GemoGraphy_Backend_Challenge.Repositories;
using NUnit.Framework;

namespace GemoGraphy_Backend_Challenge.IntegrationTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllRepository_ReturnsWithNoException()
        {
            var repository = new GitHubRepository();
            var result = await repository.GetAllReposAsync();
            Assert.NotNull(result);
            Assert.True(result.Count() > 25);
        }

        [Test]
        public async Task GetNumberOfReposByLanguage_ReturnsValidResult()
        {
            var repository = new GitHubRepository();
            var allRepos = await repository.GetAllReposAsync();
            Assert.NotNull(allRepos);

            var result = await repository.GetNumberOfReposByLanguageAsync( allRepos,"Swift");
            Assert.NotNull(result);

        }
        
        [Test]
        public async Task GetReposByLanguage_ReturnsValidResult()
        {
            var repository = new GitHubRepository();
            var allRepos = await repository.GetAllReposAsync();
            Assert.NotNull(allRepos);

            var result = await repository.GetReposByLanguageAsync( allRepos,"Swift");
            Assert.NotNull(result);

        }
    }
}