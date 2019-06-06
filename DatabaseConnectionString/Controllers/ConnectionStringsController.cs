using System.Collections.Generic;
using DatabaseConnectionString.Models;
using DatabaseConnectionString.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnectionString.Controllers
{
    [Route("api/ConnectionStrings")]
    [ApiController]
    public class ConnectionStringsController : ControllerBase
    {
        private readonly IConnectionString connectionStringRepository;

        public ConnectionStringsController(IConnectionString aConnectionStringRepository)
        {
            connectionStringRepository = aConnectionStringRepository;
        }

        // GET: api/ConnectionStrings
        [HttpGet]
        public IEnumerable<ConnectionString> Get()
        {
            return connectionStringRepository.GetConnectionStrings();
        }

        // GET: api/ConnectionStrings/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var connectionString = connectionStringRepository.GetConnectionString(id);
            return connectionString == null ? NotFound("Connection string not found") : (IActionResult)Ok(connectionString);
        }

        [HttpGet("Get{name}", Name = "GetEnv")]
        public IActionResult Get(string name)
        {
            var connectionString = connectionStringRepository.GetConnectionString(name);
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

            connectionStringRepository.UpdateConnectionString(connectionString);
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
