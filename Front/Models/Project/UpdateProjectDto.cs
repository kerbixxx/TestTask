using AutoMapper;
using Business.Common.Mappings;
using Business.Projects.Commands.UpdateProject;
using MediatR;

namespace Front.Models.Project
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public int Id { get; set; }
        public string ProjectManagerId { get; set; }
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int Priority { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Id,
                    opt => opt.MapFrom(projectDto => projectDto.Id))
                .ForMember(projectCommand => projectCommand.ProjectManagerId,
                    opt => opt.MapFrom(projectDto => projectDto.ProjectManagerId))
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectDto => projectDto.Name))
                .ForMember(projectCommand => projectCommand.NameCustomer,
                    opt => opt.MapFrom(projectDto => projectDto.NameCustomer))
                .ForMember(projectCommand => projectCommand.NameContractor,
                    opt => opt.MapFrom(projectDto => projectDto.NameContractor))
                .ForMember(projectCommand => projectCommand.DateBeginning,
                    opt => opt.MapFrom(projectDto => projectDto.DateBeginning))
                .ForMember(projectCommand => projectCommand.DateEnd,
                    opt => opt.MapFrom(projectDto => projectDto.DateEnd))
                .ForMember(projectCommand => projectCommand.Priority,
                    opt => opt.MapFrom(projectDto => projectDto.Priority));
        }
    }
}
