using System.Collections.Generic;
using DatabaseConnectionString.Models;
using DatabaseConnectionString.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnectionString.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionStringsController : ControllerBase
    {
        private IConnectionString connectinStringRepository;

        public ConnectionStringsController(IConnectionString aConnectionStringRepository)
        {
            connectinStringRepository = aConnectionStringRepository;
        }

        // GET: api/ConnectionStrings
        [HttpGet]
        public IEnumerable<ConnectionString> Get()
        {
            return connectinStringRepository.GetConnectionStrings();
        }

        // GET: api/ConnectionStrings/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var connectionString = connectinStringRepository.GetConnectionString(id);
            return connectionString == null ? NotFound("Connection string not found") : (IActionResult)Ok(connectionString);
        }

        [HttpGet("Get{name}", Name = "GetEnv")]
        public IActionResult Get(string name)
        {
            var connectionString = connectinStringRepository.GetConnectionString(name);
            return connectionString == null ? NotFound("Connection string not found") : (IActionResult)Ok(connectionString);
        }

        // POST: api/ConnectionStrings
        [HttpPost]
        public IActionResult Post([FromBody] ConnectionString connectionString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            connectinStringRepository.UpdateConnectionString(connectionString);
            return Ok("Connection string updated");
        }

        // PUT: api/ConnectionStrings/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
