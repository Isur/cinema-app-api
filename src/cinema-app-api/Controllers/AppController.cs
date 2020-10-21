using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Worker")]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;

        public AppController(ILogger<AppController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string ips = "";
            foreach (var ip in localIPs)
            {
                ips = $"{ips}\nIP: {ip}";
            }
            return $"Host name: {Environment.MachineName} \nPath: {Request.Path}\nIps: {ips}";
        }

    }
}