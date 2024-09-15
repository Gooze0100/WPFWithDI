using Microsoft.Extensions.DependencyInjection;

namespace DIInWPF.StartupHelpers;

public static class ServiceExtensions
{
    public static void AddFormFactory<TForm>(this IServiceCollection services)
        where TForm : class
    {
        // addded Generic form 
        services.AddTransient<TForm>();
        // added Func which is delegate which will create form with this x.GetService<TForm>() whenever we run the delegate
        // so the deletage gets addded to the dependency injection not just the form
        services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
        services.AddSingleton<IAbstractFactory<TForm>, AbstractFactory<TForm>>();
    }
}
