﻿using Microsoft.Extensions.DependencyInjection;
using SurveyApi.Application.Services;
using SurveyApi.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
