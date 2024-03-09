using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Projects.Queries.GetProjectDetails
{
    public class EmployeeInProj : IMapWith<Employee>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeInProj>()
                .ForMember(empInPr => empInPr.Id,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(empInPr => empInPr.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(empInPr => empInPr.SecondName,
                    opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(empInPr => empInPr.Patronymic,
                    opt => opt.MapFrom(employee => employee.Patronymic));
        }
    }
}
