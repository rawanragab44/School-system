using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_API_task1.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [uniqueNameValidation]
        public string Name { get; set; }

        [locationIn]
        public string location { get; set; }
        public string managerName { get; set; }

        [JsonIgnore]
        public List<Student>? Students { get; set; }
    }
}
