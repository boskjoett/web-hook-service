using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WebhookService.Models;
using WebhookService.Repositories;

namespace WebhookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IRepository<BuildNotification> _repository;
        private readonly ILogger _logger;

        public WebhookController(IRepository<BuildNotification> repository, ILogger<WebhookController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/webhook/version
        [HttpGet("version", Name = "GetVersion")]
        public ActionResult<string> GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Azure DevOps web hook endpoint.
        /// POST api/webhook/vsts
        /// See: https://docs.microsoft.com/en-us/azure/devops/service-hooks/services/webhooks?view=vsts
        /// </summary>
        /// <returns>200 - OK</returns>
        [HttpPost("vsts")]
        public async Task<IActionResult> Post()
        {
            string jsonData;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                jsonData = await reader.ReadToEndAsync();

                _logger.LogInformation($"Azure DevOps JSON data: {jsonData}");

                try
                {
                    BuildNotification buildNotification = ParseBuildNotificationJsonData(jsonData);
                    _repository.Add(buildNotification);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception parsing JSON: {ex.Message}");
                }
            }

            return Ok();
        }

        private BuildNotification ParseBuildNotificationJsonData(string jsonData)
        {
            JObject jObject = JObject.Parse(jsonData);

            return new BuildNotification
            {
                Id = (string)jObject["id"],
                EventType = (string)jObject["eventType"],
                ResourceUrl = (string)jObject["resource"]["url"],
                ProjectId = (string)jObject["resourceContainers"]["project"]["id"],
                CreatedTime = (DateTime)jObject["createdDate"]
            };
        }
    }
}
