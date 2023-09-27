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
            if (!ModelState.IsValid)
            {
                return BadRequest("The data submitted for creating this issue is invalid");
            }

            var result = await _gitHubService.CreateIssueAsync(issue.Title, issue.Body);

            if (result)
            {
                return Ok("Your issue has been successfully recorded!");
            }
            else
            {
                return BadRequest("An error occurred while creating the issue.");
            }
        }
    }
}
