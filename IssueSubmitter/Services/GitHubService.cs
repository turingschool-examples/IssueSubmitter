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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                "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"
            );
        }

        public async Task<bool> CreateIssueAsync(string title, string body)
        {
            //Would be better to move this out of the service to be set in the controller, so this service could be used for any repo and owner.
            var repoOwner = "zoefarrell";
            var repoName = "MvcMovieStarter";
            var jsonContent = new StringContent(
                $"{{\"title\":\"{title}\",\"body\":\"{body}\"}}",
                Encoding.UTF8
            );

            var response = await _httpClient.PostAsync(
                $"/repos/{repoOwner}/{repoName}/issues",
                jsonContent
            );
            Console.WriteLine(response);

            return response.IsSuccessStatusCode;
        }
    }
}
