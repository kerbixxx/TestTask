using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Employees.Queries.GetEmployeeList
{
    public class EmployeeLookupDto : IMapWith<Employee>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic {get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeLookupDto>()
                .ForMember(employeeDto => employeeDto.Id,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeDto => employeeDto.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeDto => employeeDto.SecondName,
                    opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(employeeDto => employeeDto.Patronymic,
                    opt => opt.MapFrom(employee => employee.Patronymic));
        }
    }
}
