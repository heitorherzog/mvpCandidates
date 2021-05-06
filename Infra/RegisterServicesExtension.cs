using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Infra
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
        }
    }
}
