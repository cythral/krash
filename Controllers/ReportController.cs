﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using krash.Models;
using System.ComponentModel.DataAnnotations;
using Octokit;

namespace krash.Controllers {
    [Route("report")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private GitHubClient githubClient;
        private GithubOptions githubOptions;

        public ValuesController(GitHubClient githubClient, GithubOptions githubOptions) {
            this.githubClient = githubClient;
            this.githubOptions = githubOptions;
        }

        [HttpPost]
        public async Task<Issue> Post([Required] Report report) {
            if(!ModelState.IsValid) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            report.userAgent = Request.Headers["user-agent"];
            report.ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            
            var newIssue = new NewIssue($"Crash Report from {report.ip}");
            newIssue.Body = report.ToString();
            newIssue.Labels.Add("crash");

            var issue = await githubClient.Issue.Create(githubOptions.User, report.repo, newIssue);
            return issue;
        }
    }
}
