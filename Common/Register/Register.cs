using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

public static class Register
{
    public static void RegisterDbContext(this IServiceCollection services)
    {
        var connectionString = services.BuildServiceProvider()
        .GetRequiredService<IConfiguration>()
        .GetConnectionString("Default");
        services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));
    }

    public static void RegisterRepository(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IVideoRepository, VideoRepository>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
    }


    public static void RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddSingleton<IFileService, FileService>();
    }

    public static void RegisterValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserValidators>();
    }
}