using Microsoft.AspNetCore.Identity;

namespace Data.Models
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public List<Project> Projects { get; set; } = [];
    }
}
