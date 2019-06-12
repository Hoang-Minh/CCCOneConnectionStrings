using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DatabaseConnectionString.Models;
using DatabaseConnectionString.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnectionString.Controllers
{
    [Route("api/ConnectionStrings")]
    [ApiController]
    [Authorize]
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
            return connectionString == null ? NotFound("Record not found") : (IActionResult)Ok(connectionString);
        }

        [HttpGet("Get{name}", Name = "GetEnv")]
        public IActionResult Get(string name)
        {
            var connectionString = connectionStringRepository.GetConnectionString(name);
            return connectionString == null ? NotFound("Record not found") : (IActionResult)Ok(connectionString);
        }

        // POST: api/ConnectionStrings
        [HttpPost]
        public IActionResult Post([FromBody] ConnectionString connectionString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            connectionString.UserId = userId;

            connectionStringRepository.AddConnectionString(connectionString);
            return Ok("Record has been added");
        }

        // PUT: api/ConnectionStrings/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ConnectionString connectionString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var connectionStringsInDb =
                connectionStringRepository.GetConnectionString(id);
            if (connectionStringsInDb == null) return BadRequest("Record not found");

            //var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //if (userId != connectionStringsInDb.UserId)
            //    return BadRequest("You don't have permission to update this record");

            connectionStringsInDb.EnvironmentName = connectionString.EnvironmentName;
            connectionStringsInDb.Value = connectionString.Value;

            connectionStringRepository.UpdateConnectionString(connectionStringsInDb);
            return Ok("Record has been updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var connectionStringsInDb =
                connectionStringRepository.GetConnectionString(id);
            if (connectionStringsInDb == null) return BadRequest("Record not found");

            //var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //if (userId != connectionStringsInDb.UserId)
            //    return BadRequest("You don't have permission to update this record");

            connectionStringRepository.DeleteConnectionString(connectionStringsInDb);
            return Ok("Record has been removed");
        }
    }
}
