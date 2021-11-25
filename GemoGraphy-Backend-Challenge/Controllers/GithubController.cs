using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GemoGraphy_Backend_Challenge.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GemoGraphy_Backend_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GithubController(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }
        
        [HttpGet]
        [Route("GetNumberOfReposByLanguage/{language}")]
        public async Task<ActionResult> GetNumberOfReposByLanguage(string langauge)
        {
            try
            {
                var allRepos = await _gitHubRepository.GetAllReposAsync();
                var result = await _gitHubRepository.GetNumberOfReposByLanguageAsync(allRepos, langauge);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetReposByLanguage/{language}")]
        public async Task<ActionResult> GetReposByLanguage(string langauge)
        {
            try
            {
                var allRepos = await _gitHubRepository.GetAllReposAsync();
                var result = await _gitHubRepository.GetReposByLanguageAsync(allRepos, langauge);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
