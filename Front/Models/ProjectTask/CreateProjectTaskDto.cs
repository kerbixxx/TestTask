using AutoMapper;
using Business.Common.Mappings;
using Business.ProjectTasks.Commands.CreateProjectTask;
using Data.Enums;

namespace Front.Models.ProjectTask
{
    public class CreateProjectTaskDto : IMapWith<CreateProjectTaskCommand>
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public string? ExecutorId { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectTaskDto, CreateProjectTaskCommand>()
                .ForMember(ptCommand => ptCommand.ProjectId,
                    opt => opt.MapFrom(ptDto => ptDto.ProjectId))
                .ForMember(ptCommand => ptCommand.Name,
                    opt => opt.MapFrom(ptDto => ptDto.Name))
                .ForMember(ptCommand => ptCommand.AuthorId,
                    opt => opt.MapFrom(ptDto => ptDto.AuthorId))
                .ForMember(ptCommand => ptCommand.ExecutorId,
                    opt => opt.MapFrom(ptDto => ptDto.ExecutorId))
                .ForMember(ptCommand => ptCommand.Status,
                    opt => opt.MapFrom(ptDto => ptDto.Status))
                .ForMember(ptCommand => ptCommand.Description,
                    opt => opt.MapFrom(ptDto => ptDto.Description))
                .ForMember(ptCommand => ptCommand.Priority,
                    opt => opt.MapFrom(ptDto => ptDto.Priority));
        }
    }
}
