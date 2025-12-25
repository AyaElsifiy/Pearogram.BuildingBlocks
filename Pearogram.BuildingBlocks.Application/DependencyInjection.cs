using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Pearogram.BuildingBlocks.Application.Common.Behaviours;
using Pearogram.BuildingBlocks.Application.Features.RecentlyDeleted;
using Pearogram.BuildingBlocks.Application.Helpers;
using Pearogram.BuildingBlocks.Domain.Contract;
using System.Globalization;

namespace Pearogram.BuildingBlocks.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddLocalizationConfigurations(this IServiceCollection services)
    {

        services.AddScoped<ILanguageContext, LanguageContext>();
        services.AddScoped<IEntityLogger, EntityLogger>();
        services.AddHttpContextAccessor();
        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        //services.Decorate(typeof(IRepository<>), typeof(TranslatableRepositoryDecorator<>));
        //services.AddScoped(typeof(IRepositoryWithTranslation<>), typeof(TranslatableRepositoryDecorator<>));
        services.AddControllersWithViews();
        services.AddLocalization(opt =>
        {
            opt.ResourcesPath = "";
        });
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        var supportedCultures = new[]
      {
            new CultureInfo("ar"),
            new CultureInfo("en-US"),
};
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en-US"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures,
            RequestCultureProviders = new[] { new CookieRequestCultureProvider() }
        };
        return services;
    }

    public static IServiceCollection AddFluentValidationConfigurations(this IServiceCollection services)
    {
        //services.AddFluentValidationAutoValidation()
        //    .AddFluentValidationClientsideAdapters();

        //services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidations>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserContextBehavior<,>));


        //services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services;
    }
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(LogDeletionHandler).Assembly);
        });

        return services;
    }

}
