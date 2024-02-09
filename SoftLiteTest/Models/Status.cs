using System.Collections.Generic;

namespace SoftLiteTest.Models
{
    public class Status
    {
        public int Status_ID {  get; set; }
        public string Status_Name { get; set;}
        public List<Task> Tasks { get; set; }
    }
}
