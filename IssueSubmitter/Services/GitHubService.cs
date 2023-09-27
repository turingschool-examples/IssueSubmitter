using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using IssueSubmitter.Interfaces;

namespace IssueSubmitter.Services
{
    public class GitHubService : IGitHubService
    {
        // Using _ here because that's the convention for private variables
        private readonly HttpClient _httpClient;

        public GitHubService()
        {
            //TODO Create Client
        }

        public async Task<bool> CreateIssueAsync(string title, string body)
        {
            //TODO Create issue
            return true;
        }
    }
}
