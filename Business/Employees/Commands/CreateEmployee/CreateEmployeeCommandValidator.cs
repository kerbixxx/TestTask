using FluentValidation;

namespace Business.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.Name).NotEmpty().WithMessage("Имя не может быть пустым")
                .Length(2, 50).WithMessage("Имя должно быть от 2 до 50 символов")
                .Must(IsNameValid).WithMessage("Имя может содержать только буквы");
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.SecondName).NotEmpty().WithMessage("Фамилия не может быть пустым")
                .Length(2, 50).WithMessage("Фамилия должна быть от 2 до 50 символов")
                .Must(IsNameValid).WithMessage("Фамилия может содержать только буквы");
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.SecondName).NotEmpty().WithMessage("Отчество не может быть пустым")
                .Length(2, 50).WithMessage("Отчество должно быть от 2 до 50 символов")
                .Must(IsNameValid).WithMessage("Отчество может содержать только буквы");
            RuleFor(createEmployeeCommand =>
                createEmployeeCommand.Email).EmailAddress().WithMessage("Email введен некорректно");
        }

        private bool IsNameValid(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}
