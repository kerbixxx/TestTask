﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Mappings;
using Data.Models;
using MediatR;

namespace Business.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public string Id { get; set; }
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
