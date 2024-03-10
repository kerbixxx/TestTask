using AutoMapper;
using Business.Common.Mappings;
using Business.Employees.Commands.UpdateEmployee;

namespace Front.Models.Employee
{
    public class UpdateEmployeeDto : IMapWith<UpdateEmployeeCommand>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.Id,
                    opt => opt.MapFrom(employeeDto => employeeDto.Id))
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
