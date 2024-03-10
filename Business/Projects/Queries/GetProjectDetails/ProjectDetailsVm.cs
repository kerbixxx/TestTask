using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Projects.Queries.GetProjectDetails
{
    public class ProjectDetailsVm : IMapWith<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjectManagerId { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public List<EmployeeInProj> Employees { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsVm>()
                .ForMember(projectVm => projectVm.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectVm => projectVm.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(projectVm => projectVm.ProjectManagerId,
                    opt => opt.MapFrom(project => project.ProjectManagerId))
                .ForMember(projectVm => projectVm.NameCustomer,
                    opt => opt.MapFrom(project => project.NameCustomer))
                .ForMember(projectVm => projectVm.NameContractor,
                    opt => opt.MapFrom(project => project.NameContractor))
                .ForMember(projectVm => projectVm.DateBeginning,
                    opt => opt.MapFrom(project => project.DateBeginning))
                .ForMember(projectVm => projectVm.DateEnd,
                    opt => opt.MapFrom(project => project.DateEnd))
                .ForMember(projectVm => projectVm.Priority,
                    opt => opt.MapFrom(project => project.Priority))
                .ForMember(projectVm=>projectVm.Employees,
                    opt=>opt.MapFrom(project=>project.Employees));
        }
    }
}
