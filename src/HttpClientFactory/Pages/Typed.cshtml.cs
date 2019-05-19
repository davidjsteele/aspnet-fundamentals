// GitHubService or RepoService
#define GitHubService

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ASPNET.Fundamentals.HttpClientFactory.GitHub;
using ASPNET.Fundamentals.HttpClientFactory.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET.Fundamentals.HttpClientFactory.Pages
{
    public class TypedModel : PageModel
    {
        private readonly GitHubService _gitHubService;
        private readonly IssuesService _issuesService;

        public IEnumerable<GitHubIssue> LatestIssues { get; private set; }

        public bool HasIssue => LatestIssues.Any();

        public bool GetIssuesError { get; private set; }

        public TypedModel(GitHubService gitHubService, IssuesService issuesService)
        {
            _gitHubService = gitHubService;
            _issuesService = issuesService;
        }

        public async Task OnGet()
        {
            try
            {
#if GitHubService
                LatestIssues = await _gitHubService.GetAspNetDocsIssues();
#endif
#if RepoService
                LatestIssues = await _issuesService.GetIssues();
#endif
            }
            catch (HttpRequestException)
            {
                GetIssuesError = true;
                LatestIssues = Array.Empty<GitHubIssue>();
            }
        }
    }
}
