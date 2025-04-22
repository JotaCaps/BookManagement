using BookManagement.Application.Commands.BookCommands.RegisterBook;
using BookManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();
            
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();
            
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<RegisterBookCommand>());
            
            return services;
        }
    }
}
