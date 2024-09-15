using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfLibrary;
using DIInWPF.StartupHelpers;

namespace DIInWPF;

public partial class App : Application
{
    // starting point for this app
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                //for main window use singleton because you just want to create just one main window not few instances
                services.AddSingleton<MainWindow>();
                //services.AddTransient<ChildForm>();
                services.AddFormFactory<ChildForm>();
                services.AddTransient<IDataAccess, DataAccess>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        // this can be null so add exclamation point so it ignores null
        await AppHost!.StartAsync();

        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        // stopping app host when exiting application
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
