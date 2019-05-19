using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ASPNET.Fundamentals.HttpClientFactory.GitHub;

namespace ASPNET.Fundamentals.HttpClientFactory.Services
{
    public class IssuesService
    {
        private readonly HttpClient _httpClient;

        public IssuesService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<GitHubIssue>> GetIssues()
        {
            var response = await _httpClient.GetAsync("/repos/aspnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<GitHubIssue>>();

            return result;
        }
    }
}
