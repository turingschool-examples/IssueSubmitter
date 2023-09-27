using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using IssueSubmitter.Interfaces;

namespace IssueSubmitter.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://api.github.com") };
            _httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("IssueSubmitter", "1.0")
            );
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                "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"
            );
        }

        public async Task<bool> CreateIssueAsync(string title, string body)
        {
            var repoOwner = "zoefarrell";
            var repoName = "MvcMovieStarter";
            var jsonContent = new StringContent(
                $"{{\"title\":\"{title}\",\"body\":\"{body}\"}}",
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"/repos/{repoOwner}/{repoName}/issues",
                jsonContent
            );

            return response.IsSuccessStatusCode;
        }
    }
}
