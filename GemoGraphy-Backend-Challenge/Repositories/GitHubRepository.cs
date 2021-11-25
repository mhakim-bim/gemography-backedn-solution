using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GemoGraphy_Backend_Challenge.Interfaces;
using GemoGraphy_Backend_Challenge.Models;
using Newtonsoft.Json;

namespace GemoGraphy_Backend_Challenge.Repositories
{
    public class GitHubRepository : IGitHubRepository
    {

        private HttpClient _httpClient;

        public GitHubRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", "1")); // set your own values here
        }
        public async Task<IEnumerable<GithubRepo>> GetAllReposAsync()
        {
            var dateMonthEarlier = DateTime.Today.AddMonths(-1);
            var path =
                $"https://api.github.com/search/repositories?q=created:%3E{dateMonthEarlier:yyyy-MM-dd}&sort=stars&order=desc";

            
            var response = await _httpClient.GetAsync(path);
            var jsonString = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<GithubApiResponse>(jsonString))?.items;
        }

        public async Task<int> GetNumberOfReposByLanguageAsync(IEnumerable<GithubRepo> githubRepos, string language)
        {
            return await Task.Run(() => githubRepos
                .Count(g => g.language != null && g.language.ToLower() == language.ToLower()));
        }

        public async Task<IEnumerable<GithubRepo>> GetReposByLanguageAsync(IEnumerable<GithubRepo> githubRepos,string language)
        {
            return await Task.Run(() => githubRepos
                .Where(g => g.language != null && g.language.ToLower() == language.ToLower()));
        }
    }
}