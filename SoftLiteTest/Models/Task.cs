using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoftLiteTest.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        public int Status_ID { get; set; }

        public Status Status { get; set; }
    }
}
