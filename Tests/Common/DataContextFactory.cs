using Data.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests.Common
{
    public class DataContextFactory
    {
        public static int ProjectIdForDelete = 1;
        public static int ProjectIdForUpdate = 1;

        public static DataDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DataDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DataDbContext(options);
            context.Database.EnsureCreated();
            var projects = GenerateData();
            context.Projects.AddRange(projects);
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DataDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        public static List<Domain.Models.Project> GenerateData()
        {
            // Создание объектов класса Employee
            var employee1 = new Employee
            {
                Name = "Иван",
                SecondName = "Иванов",
                Patronymic = "Иванович",
                Email = "ivanov@example.com"
            };

            var employee2 = new Employee
            {
                Name = "Петр",
                SecondName = "Петров",
                Patronymic = "Петрович",
                Email = "petrov@example.com"
            };

            // Создание объектов класса Project
            var project1 = new Domain.Models.Project
            {
                Name = "Проект 1",
                NameCustomer = "Компания А",
                NameContractor = "Компания Б",
                DateBeginning = new DateTime(2024, 4, 1),
                DateEnd = new DateTime(2024, 6, 30),
                Priority = 1,
                ProjectManagerId = 1,
                ProjectManager = employee1,
                Employees = new List<Employee> { employee1, employee2 }
            };

            var project2 = new Domain.Models.Project
            {
                Name = "Проект 2",
                NameCustomer = "Компания В",
                NameContractor = "Компания Г",
                DateBeginning = new DateTime(2024, 7, 1),
                DateEnd = new DateTime(2024, 9, 30),
                Priority = 2,
                ProjectManagerId = 2,
                ProjectManager = employee2,
                Employees = new List<Employee> { employee1, employee2 }
            };

            // Добавление проектов в список сотрудников
            employee1.Projects.Add(project1);
            employee1.Projects.Add(project2);

            employee2.Projects.Add(project1);
            employee2.Projects.Add(project2);
            return [project1, project1];
        }
    }
}
