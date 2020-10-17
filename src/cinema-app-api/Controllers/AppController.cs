using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            _logger.LogInformation($"Request {Request.HttpContext.User}");
            return $"Host name: {Environment.MachineName} \nPath: {Request.Path}\nIps: {ips}";
        }

    }
}