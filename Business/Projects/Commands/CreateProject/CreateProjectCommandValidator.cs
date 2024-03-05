using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createProjectCommand =>
                createProjectCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createProjectCommand =>
                createProjectCommand.ProjectManagerId).NotNull();
        }
    }
}
