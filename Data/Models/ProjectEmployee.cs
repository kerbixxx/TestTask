using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    [PrimaryKey("ProjectId", "EmployeeId")]
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public string EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }

}
