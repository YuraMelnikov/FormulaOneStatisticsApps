using Entities.Contexts;
using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace XTestProject
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<RepositoryContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<RepositoryContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
                {
                    try
                    {
                        if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                            appContext.Database.Migrate();

                        appContext.Database.EnsureDeleted();  // feels hacky - don't think this is good practice, but does achieve my intention
                        appContext.Database.EnsureCreated();


                        appContext.Seasons.Add(new Season { IdImage = Guid.NewGuid(), Year = 1950 });
                        appContext.Seasons.Add(new Season { IdImage = Guid.NewGuid(), Year = 1951 });
                        appContext.Seasons.Add(new Season { IdImage = Guid.NewGuid(), Year = 1952 });

                        appContext.SaveChanges();


                    }
                    catch
                    {
                        throw;
                    }
                }
            });
        }
    }
}
