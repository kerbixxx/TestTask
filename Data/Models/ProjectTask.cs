using Data.Enums;

namespace Data.Models
{
    public class ProjectTask : Entity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public Employee? Author { get; set; }
        public string? ExecutorId { get; set; }
        public Employee? Executor { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
