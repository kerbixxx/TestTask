using AutoMapper;
using Business.ProjectTasks.Commands.CreateProjectTask;
using Business.ProjectTasks.Commands.UpdateProjectTask;
using Domain.Enums;

namespace WebApi.Models.ProjectTask
{
    public class UpdateProjectTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectTaskDto, UpdateProjectTaskCommand>()
                .ForMember(ptCommand => ptCommand.Id,
                    opt => opt.MapFrom(ptDto => ptDto.Id))
                .ForMember(ptCommand => ptCommand.Name,
                    opt => opt.MapFrom(ptDto => ptDto.Name))
                .ForMember(ptCommand => ptCommand.Status,
                    opt => opt.MapFrom(ptDto => ptDto.Status))
                .ForMember(ptCommand => ptCommand.Description,
                    opt => opt.MapFrom(ptDto => ptDto.Description))
                .ForMember(ptCommand => ptCommand.Priority,
                    opt => opt.MapFrom(ptDto => ptDto.Priority));
        }
    }
}
