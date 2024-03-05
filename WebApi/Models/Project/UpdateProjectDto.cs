using AutoMapper;
using Business.Common.Mappings;
using Business.Projects.Commands.UpdateProject;

namespace WebApi.Models.Project
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectCommand, UpdateProjectDto>()
                .ForMember(projectCommand => projectCommand.Id,
                    opt => opt.MapFrom(projectDto => projectDto.Id))
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectDto => projectDto.Name))
                .ForMember(projectCommand => projectCommand.NameCustomer,
                    opt => opt.MapFrom(projectDto => projectDto.NameCustomer))
                .ForMember(projectCommand => projectCommand.NameContractor,
                    opt => opt.MapFrom(projectDto => projectDto.NameContractor));
        }
    }
}
