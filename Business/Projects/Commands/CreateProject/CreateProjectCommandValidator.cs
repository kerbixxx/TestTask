using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createProjectCommand =>
                    createProjectCommand.Name).NotEmpty().WithMessage("Имя не должно быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина имени 250 символов");
            RuleFor(createProjectCommand =>
                createProjectCommand.ProjectManagerId).NotNull();
            RuleFor(createProjectCommand =>
                    createProjectCommand.NameContractor).NotEmpty().WithMessage("Название не должно быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина названия 250 символов")
                .Must(name => IsNameValid(name)).WithMessage("Название должно содержать только буквы и пробелы");
            RuleFor(createProjectCommand =>
                    createProjectCommand.NameCustomer).NotEmpty().WithMessage("Название не должно быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина названия 250 символов")
                .Must(name => IsNameValid(name)).WithMessage("Название должно содержать только буквы и пробелы");
            RuleFor(createProjectCommand =>
                    createProjectCommand.Priority).NotNull().WithMessage("Приоритет не должен быть пустым")
                .GreaterThan(0).WithMessage("Приоритет должен быть положительным");
        }
        private bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, "^[A-Za-zА-Яа-я\\s]*$");
        }
    }
}
