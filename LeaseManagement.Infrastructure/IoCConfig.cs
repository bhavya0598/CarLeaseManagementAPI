using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaseManagement.Infrastructure
{
    public class IoCConfig
    {
        public static void ConfigContainer(IServiceCollection _services)
        {
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
