using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPNET.Fundamentals.Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (_logger.BeginScope("Message attached to logs created in the using block"))
            {
                try
                {
                    return new string[] { "value1", "value2" };
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(LoggingEvents.ListItems, ex, "Get failed");
                    return BadRequest();
                }
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogWarning(LoggingEvents.DeleteItem, "Delete item {ID}", id);
        }
    }
}
