using System;
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

namespace krash.Controllers 
{
    [Route("healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase 
    {
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}