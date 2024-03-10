using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Projects.Queries.GetProjectDetails
{
    public class EmployeeInProj : IMapWith<ProjectEmployee>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectEmployee, EmployeeInProj>()
                .ForMember(empInPr => empInPr.Id, opt => opt.MapFrom(pe => pe.EmployeeId))
                .ForMember(empInPr => empInPr.Name, opt => opt.MapFrom(pe => pe.Employee.Name))
                .ForMember(empInPr => empInPr.SecondName, opt => opt.MapFrom(pe => pe.Employee.SecondName))
                .ForMember(empInPr => empInPr.Patronymic, opt => opt.MapFrom(pe => pe.Employee.Patronymic));
        }
    }
}
