using FunWithMvvm.App.Components.Shell;
using FunWithMvvm.App.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;

namespace FunWithMvvm.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var provider = serviceCollection.BuildServiceProvider();

            var win = new Window();
            var shellView = new ShellView();
            var vm = provider.GetRequiredService<ShellVm>();

            shellView.DataContext = vm;
            win.Content = shellView;
            win.Show();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ShellVm>();
            services.AddSingleton<IAnswersService, AnswersService>();
        }
    }
}
