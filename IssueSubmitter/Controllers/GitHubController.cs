using IssueSubmitter.Models;
using Microsoft.AspNetCore.Mvc;
using IssueSubmitter.Services;
using IssueSubmitter.Interfaces;

namespace IssueSubmitter.Controllers
{
    public class GitHubController : Controller
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public IActionResult CreateIssue()
        {
            return View();
        }

        [HttpPost("createissue")]
        public async Task<IActionResult> CreateIssueAsync(GitHubIssue issue)
        {
            //TODO: Create issue
            return Ok("Your issue has been successfully recorded!");
        }
    }
}
