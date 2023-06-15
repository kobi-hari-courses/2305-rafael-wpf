using FunWithMvvm.App.Components.Details;
using FunWithMvvm.App.Components.ItemList;
using FunWithMvvm.App.Components.PageA;
using FunWithMvvm.App.Components.PageB;
using FunWithMvvm.App.Components.Shell;
using FunWithMvvm.App.Services;
using FunWithMvvm.App.Shared;
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
            win.ContentTemplateSelector = new ViewTemplateSelector();
            var vm = provider.GetRequiredService<ShellVm>();

            win.Content = vm;
            win.Show();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ShellVm>();
            services.AddTransient<ItemListVm>();
            services.AddTransient<DetailsVm>();
            services.AddTransient<PageAVm>();
            services.AddTransient<PageBVm>();

            services.AddSingleton<IAnswersService, AnswersService>();
        }
    }
}
