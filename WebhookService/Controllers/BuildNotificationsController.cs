using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebhookService.Models;
using WebhookService.Repositories;

namespace WebhookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildNotificationsController : ControllerBase
    {
        private readonly IRepository<BuildNotification> _repository;
        private readonly ILogger _logger;

        public BuildNotificationsController(IRepository<BuildNotification> repository, ILogger<BuildNotificationsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/BuildNotifications
        [HttpGet]
        public IEnumerable<BuildNotification> GetAll()
        {
            return _repository.GetAll();
        }

        // DELETE api/BuildNotifications/3475634853
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteById(id);
        }
    }
}