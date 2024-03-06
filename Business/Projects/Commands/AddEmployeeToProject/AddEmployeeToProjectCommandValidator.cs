using FluentValidation;

namespace Business.Projects.Commands.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommandValidator : AbstractValidator<AddEmployeeToProjectCommand>
    {
        public AddEmployeeToProjectCommandValidator()
        {
            RuleFor(command => command.EmployeeId).NotNull().WithMessage("ID не должен быть пустым");
            RuleFor(command => command.ProjectId).NotNull().WithMessage("ID не должен быть пустым");
        }
    }
}
