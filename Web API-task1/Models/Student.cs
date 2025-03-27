using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_task1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepID { get; set; }
        public Department Department { get; set; }



    }
}
