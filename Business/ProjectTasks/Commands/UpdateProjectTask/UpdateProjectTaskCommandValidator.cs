using FluentValidation;

namespace Business.ProjectTasks.Commands.UpdateProjectTask
{
    public class UpdateProjectTaskCommandValidator : AbstractValidator<UpdateProjectTaskCommand>
    {
        public UpdateProjectTaskCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Название задачи не может быть пустым");
            RuleFor(createProjectTask => createProjectTask.Priority)
                .GreaterThan(0).WithMessage("Приоритет не должен быть отрицательным")
                .NotNull().WithMessage("Приоритет не может быть пустым");
            RuleFor(createProjectTask => createProjectTask.Status)
                .IsInEnum().WithMessage("Status должен быть одним из следующих: Todo, InProgress, Done");
        }
    }
}
