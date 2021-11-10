
using Microsoft.Extensions.DependencyInjection;
using VideoMenuConsoleApp.Core.ApplicationService;
using VideoMenuConsoleApp.Core.ApplicationService.Services;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories;

namespace VideoMenuConsoleApp
{
    internal static class Program
    {
        private static void Main()
        {
            var serviceColletion = new ServiceCollection();
            serviceColletion.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceColletion.AddScoped<ICustomerService, CustomerService>();
            serviceColletion.AddScoped<IVideoRepository, VideoRepository>();
            serviceColletion.AddScoped<IVideoService, VideoService>();
            serviceColletion.AddScoped<IGenreRepository, GenreRepository>();
            serviceColletion.AddScoped<IGenreService,   GenreService>();
            serviceColletion.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceColletion.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.ShowMainMenu();
        }

    }
}