using AutoMapper;
using Business.Common.Mappings;
using Business.ProjectTasks.Queries.GetProjectTaskDetails;
using Data.Enums;
using Data.Models;

namespace Business.ProjectTasks.Queries.GetProjectTaskList
{
    public class ProjectTaskLookupDto : IMapWith<ProjectTask>
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectTask, ProjectTaskDetailsVm>()
                .ForMember(ptVm => ptVm.Name,
                    opt => opt.MapFrom(projectTask => projectTask.Name))
                .ForMember(ptVm => ptVm.Status,
                    opt => opt.MapFrom(projectTask => projectTask.Status))
                .ForMember(ptVm => ptVm.Description,
                    opt => opt.MapFrom(projectTask => projectTask.Description))
                .ForMember(ptVm => ptVm.Priority,
                    opt => opt.MapFrom(projectTask => projectTask.Priority));
        }
    }
}
