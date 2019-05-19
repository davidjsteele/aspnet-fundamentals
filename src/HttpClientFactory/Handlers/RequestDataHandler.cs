﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ASPNET.Fundamentals.HttpClientFactory.Handlers
{
    public class RequestDataHandler : DelegatingHandler
    {
        private readonly ILogger<RequestDataHandler> _logger;

        private const string RequestSourceHeaderName = "Request-Source";
        private const string RequestSource = "HttpClientFactorySampleApp";
        private const string RequestIdHeaderName = "Request-Identifier";

        public RequestDataHandler(ILogger<RequestDataHandler> logger)
        {
            _logger = logger;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var identifier = Guid.NewGuid();

            _logger.LogInformation($"Starting request {identifier}");

            request.Headers.Add(RequestSourceHeaderName, RequestSource);
            request.Headers.Add(RequestIdHeaderName, identifier.ToString());

            return base.SendAsync(request, cancellationToken);
        }
    }
}
