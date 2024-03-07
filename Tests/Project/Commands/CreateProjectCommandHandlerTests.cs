using Business.Projects.Commands.CreateProject;
using Microsoft.EntityFrameworkCore;
using Tests.Common;

namespace Tests.Project.Commands
{
    public class CreateProjectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProjectCommandHandler_Success()
        {
            var handler = new CreateProjectCommandHandler(Context);
            var name = "Проект XYZ";
            var nameCustomer = "Клиент ABC";
            var nameContractor = "Исполнитель DEF";
            var dateBeginning = new DateTime(2024, 3, 5);
            var dateEnd = new DateTime(2024, 3, 12);
            var priority = 3;

            var projectId = await handler.Handle(
                new CreateProjectCommand
                {
                    Name = name,
                    NameContractor = nameContractor,
                    NameCustomer = nameCustomer,
                    DateBeginning = dateBeginning,
                    DateEnd = dateEnd,
                    Priority = priority,
                    ProjectManagerId = 1
                },CancellationToken.None);

            Assert.NotNull(await Context.Projects.SingleOrDefaultAsync(project => project.Id == projectId &&
                project.Name == name &&
                project.NameCustomer == nameCustomer &&
                project.NameContractor == nameContractor &&
                project.DateBeginning == dateBeginning &&
                project.DateEnd == dateEnd &&
                project.Priority == priority));
        }
    }
}
