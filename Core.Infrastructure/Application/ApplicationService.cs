using Core.EF.EntityFrameworkCore;
using System;

namespace Core.Services.Application
{
    /// <summary>
    /// This class can be used as a base class for application services. 
    /// </summary>
    public abstract class ApplicationService : IApplicationService
    {
        protected AppDbContext AppContextExternal { get; set; } = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ApplicationService()
        {
        }

        public void SetContext(AppDbContext context)
        {
            AppContextExternal = context;
        }

        public AppDbContext GetContext(Func<AppDbContext> appContext)
        {
            if (AppContextExternal != null)
                return AppContextExternal;

            return appContext();
        }
    }
}
