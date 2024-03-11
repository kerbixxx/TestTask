using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Employees.Queries.GetEmployeeDetails
{
    public class ProjectDto
    {
        public string Name { get; set; }
    }
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic {  get; set; }
        public string Email { get; set; }
        public List<ProjectDto> Projects { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeVm => employeeVm.Id,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeVm => employeeVm.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeVm => employeeVm.SecondName,
                    opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(employeeVm => employeeVm.Patronymic,
                    opt => opt.MapFrom(employee => employee.Patronymic))
                .ForMember(employeeVm=>employeeVm.Projects,
                    opt=>opt.MapFrom(employee=>employee.Projects))
                .ForMember(employeeVm => employeeVm.Email,
                    opt => opt.MapFrom(employee => employee.Email));

            profile.CreateMap<ProjectEmployee, ProjectDto>()
                .ForMember(projectDto => projectDto.Name, opt => opt.MapFrom(projectEmployee => projectEmployee.Project.Name));
        }
    }
}
