using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DatabaseConnectionString.Models
{
    public class ConnectionString
    {
        public int Id { get; set; }
        [Required]
        public string EnvironmentName { get; set; }
        [Required]
        public string Value { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
