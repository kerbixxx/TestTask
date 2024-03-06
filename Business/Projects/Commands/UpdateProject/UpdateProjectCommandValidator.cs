
using FluentValidation;

namespace Business.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(updateProjectCommand =>
                    updateProjectCommand.Name).NotEmpty().WithMessage("Имя не должно быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина имени 250 символов")
                .Must(IsNameValid).WithMessage("Имя должно содержать только буквы");
            RuleFor(updateProjectCommand =>
                updateProjectCommand.ProjectManagerId).NotNull();
            RuleFor(updateProjectCommand =>
                    updateProjectCommand.NameContractor).NotEmpty().WithMessage("Название не должно быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина названия 250 символов")
                .Must(IsNameValid).WithMessage("Название должно содержать только буквы");
            RuleFor(updateProjectCommand =>
                    updateProjectCommand.NameCustomer).NotEmpty().WithMessage("Название не должно быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина названия 250 символов")
                .Must(IsNameValid).WithMessage("Название должно содержать только буквы");
            RuleFor(updateProjectCommand =>
                    updateProjectCommand.Priority).NotNull().WithMessage("Приоритет не должен быть пустым")
                .GreaterThan(0).WithMessage("Приоритет должен быть положительным");
        }
        private bool IsNameValid(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}
