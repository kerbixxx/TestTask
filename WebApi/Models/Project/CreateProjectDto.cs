using AutoMapper;
using Business.Common.Mappings;
using Business.Projects.Commands.CreateProject;

namespace WebApi.Models.Project
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectDto => projectDto.Name))
                .ForMember(projectCommand => projectCommand.NameCustomer,
                    opt => opt.MapFrom(projectDto => projectDto.NameCustomer))
                .ForMember(projectCommand => projectCommand.NameContractor,
                    opt => opt.MapFrom(projectDto => projectDto.NameContractor));
        }
    }
}
