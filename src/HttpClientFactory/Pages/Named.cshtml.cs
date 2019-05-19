using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ASPNET.Fundamentals.HttpClientFactory.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET.Fundamentals.HttpClientFactory.Pages
{
    public class NamedModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<GitHubPullRequest> PullRequests { get; private set; }

        public bool GetPullRequestsError { get; private set; }

        public bool HasPullRequests => PullRequests.Any();

        public NamedModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "repos/aspnet/AspNetCore.Docs/pulls");
            var client = _clientFactory.CreateClient("github");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                PullRequests = await response.Content.ReadAsAsync<IEnumerable<GitHubPullRequest>>();
            }
            else
            {
                GetPullRequestsError = true;
                PullRequests = Array.Empty<GitHubPullRequest>();
            }
        }
    }
}
