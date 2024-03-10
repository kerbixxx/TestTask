using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int Priority { get; set; }
        public string? ProjectManagerId { get; set; }
        public Employee? ProjectManager { get; set; }
        public IEnumerable<ProjectEmployee>? Employees { get; set; } = new List<ProjectEmployee>();
    }
}
