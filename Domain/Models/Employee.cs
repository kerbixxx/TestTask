namespace Domain.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public List<Project>? Projects = new();
    }
}
