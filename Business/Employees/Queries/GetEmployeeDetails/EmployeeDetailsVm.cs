using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic {  get; set; }

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
                    opt => opt.MapFrom(employee => employee.Patronymic));
        }
    }
}
