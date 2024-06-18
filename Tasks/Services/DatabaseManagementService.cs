using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace ManTask.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationAuto(this IApplicationBuilder app)  
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDB = serviceScope
                .ServiceProvider
                .GetService<MyContext>();

                serviceDB!.Database.Migrate();
            }
        }
    }
}
