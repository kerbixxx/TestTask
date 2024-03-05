using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Projects.Queries.GetProjectList
{
    public class ProjectListVm
    {
        public IList<ProjectLookupDto> Projects { get; set; }
    }
}
