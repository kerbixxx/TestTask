using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore.Internal;

namespace Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DataDbContext Context;

        public TestCommandBase()
        {
            Context = DataContextFactory.Create();
        }

        public void Dispose()
        {
            DataContextFactory.Destroy(Context);
        }
    }
}
