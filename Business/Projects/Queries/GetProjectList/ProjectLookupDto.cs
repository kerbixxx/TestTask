using AutoMapper;
using Business.Common.Mappings;
using Data.Models;

namespace Business.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(projectDto => projectDto.NameCustomer,
                    opt => opt.MapFrom(project => project.NameCustomer))
                .ForMember(projectDto => projectDto.NameContractor,
                    opt => opt.MapFrom(project => project.NameContractor))
                .ForMember(projectDto => projectDto.DateBeginning,
                    opt => opt.MapFrom(project => project.DateBeginning))
                .ForMember(projectDto => projectDto.DateEnd,
                    opt => opt.MapFrom(project => project.DateEnd))
                .ForMember(projectDto => projectDto.Priority,
                    opt => opt.MapFrom(project => project.Priority));
        }
    }
}
