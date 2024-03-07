using Business.Projects.Commands.UpdateProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Tests.Common;

namespace Tests.Project.Commands
{
    public class UpdateProjectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProjectCommandHandler_Success()
        {
            var handler = new UpdateProjectCommandHandler(Context);
            var updatedName = "New ProjectName";

            await handler.Handle(new UpdateProjectCommand{
                Id=DataContextFactory.ProjectIdForUpdate,
                Name=updatedName
            }, CancellationToken.None);

            Assert.NotNull(await Context.Projects.SingleOrDefaultAsync(project=>project.Id == DataContextFactory.ProjectIdForUpdate && project.Name == updatedName));
        }

        [Fact]
        public async Task UpdateProjectCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateProjectCommandHandler(Context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProjectCommand
                    {
                        Id = 5
                    }, CancellationToken.None));
        }
    }
}
