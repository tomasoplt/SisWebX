using Core.EF.EntityFrameworkCore;
using Core.Services.Dependency;
using System;

namespace Core.Services.Application
{
    /// <summary>
    /// This interface must be implemented by all application services to identify them by convention.
    /// </summary>
    public interface IApplicationService : ITransientDependency
    {
        void SetContext(AppDbContext context);
        AppDbContext GetContext(Func<AppDbContext> appContext);
    }
}
