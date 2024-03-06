using Business.Employees.Commands.CreateEmployee;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(createEmployeeCommand => createEmployeeCommand.Id).NotNull();
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.Name).NotEmpty().WithMessage("Имя не может быть пустым")
                .Length(2, 50).WithMessage("Имя должно быть от 2 до 50 символов")
                .Must(IsNameValid).WithMessage("Имя может содержать только буквы");
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.SecondName).NotEmpty().WithMessage("Фамилия не может быть пустым")
                .Length(2, 50).WithMessage("Фамилия должна быть от 2 до 50 символов")
                .Must(IsNameValid).WithMessage("Фамилия может содержать только буквы");
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.Patronymic).NotEmpty().WithMessage("Отчество не может быть пустым")
                .Length(2, 50).WithMessage("Отчество должно быть от 2 до 50 символов")
                .Must(IsNameValid).WithMessage("Отчество может содержать только буквы");
            RuleFor(createEmployeeCommand =>
                    createEmployeeCommand.Email).NotEmpty().WithMessage("Email не должен быть пустым")
                .EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Email введен некорректно");
            //EmailValidationMode.Net4xRegex проверяет емейл по регексу. Без него он проверяет просто наличие @.
            //Нужно исходить из требований. Пока не выявил в чем может быть минус использования Net4xRegex.
        }

        private bool IsNameValid(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}
