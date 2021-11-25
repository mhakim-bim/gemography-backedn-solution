using System.Collections.Generic;
using System.Threading.Tasks;
using GemoGraphy_Backend_Challenge.Models;

namespace GemoGraphy_Backend_Challenge.Interfaces
{
    public interface IGitHubRepository
    {
        Task<IEnumerable<GithubRepo>> GetAllReposAsync();
        Task<int> GetNumberOfReposByLanguageAsync(IEnumerable<GithubRepo> githubRepos, string language);
        Task<IEnumerable<GithubRepo>> GetReposByLanguageAsync(IEnumerable<GithubRepo> githubRepos,string language);
        
        

    }
}