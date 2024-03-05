using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Common.Mappings;
using Domain.Models;

namespace Business.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.Name,
                    opt => opt.MapFrom(project => project.Name));
        }
    }
}
