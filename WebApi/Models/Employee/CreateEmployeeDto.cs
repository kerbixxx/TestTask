using AutoMapper;
using Business.Common.Mappings;
using Business.Employees.Commands.CreateEmployee;

namespace WebApi.Models.Employee
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.Name,
                    opt => opt.MapFrom(employeeDto => employeeDto.Name))
                .ForMember(employeeCommand => employeeCommand.SecondName,
                    opt => opt.MapFrom(employeeDto => employeeDto.SecondName))
                .ForMember(employeeCommand => employeeCommand.Patronymic,
                    opt => opt.MapFrom(employeeDto => employeeDto.Patronymic))
                .ForMember(employeeCommand => employeeCommand.Email,
                    opt => opt.MapFrom(employeeDto => employeeDto.Email));
        }
    }
}
