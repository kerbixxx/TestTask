using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Business.Projects.Commands.DeleteProject;
using Tests.Common;

namespace Tests.Project.Commands
{
    public class DeleteProjectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            var handler = new DeleteProjectCommandHandler(Context);
            await handler.Handle(new DeleteProjectCommand
            {
                Id = DataContextFactory.ProjectIdForDelete

            }, CancellationToken.None);

            Assert.Null(Context.Projects.SingleOrDefault(project=>project.Id==DataContextFactory.ProjectIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteProjectCommandHandler(Context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProjectCommand()
                    {
                        Id = 10
                    }, CancellationToken.None));
        }
    }
}
