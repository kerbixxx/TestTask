namespace Domain.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int Priority { get; set; }
        public int ProjectManagerId { get; set; }
        public Employee? ProjectManager { get; set; }
        public List<Employee>? Employees { get; set; } = new();
    }
}
