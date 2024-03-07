using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Projects.Queries.GetProjectDetails
{
    public class ProjectDetailsVm : IMapWith<Project>
    {
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsVm>()
                .ForMember(projectVm => projectVm.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(projectVm => projectVm.NameCustomer,
                    opt => opt.MapFrom(project => project.NameCustomer))
                .ForMember(projectVm => projectVm.NameContractor,
                    opt => opt.MapFrom(project => project.NameContractor))
                .ForMember(projectVm => projectVm.DateBeginning,
                    opt => opt.MapFrom(project => project.DateBeginning))
                .ForMember(projectVm => projectVm.DateEnd,
                    opt => opt.MapFrom(project => project.DateEnd))
                .ForMember(projectVm => projectVm.Priority,
                    opt => opt.MapFrom(project => project.Priority));
        }
    }
}
