using FunWithMvvm.App.Components.Details;
using FunWithMvvm.App.Components.ItemList;
using FunWithMvvm.App.Components.PageA;
using FunWithMvvm.App.Components.PageB;
using FunWithMvvm.App.Services;
using Microsoft.Extensions.DependencyInjection;
using MvvmTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunWithMvvm.App.Components.Shell
{
    public class ShellVm: BindableBase
    {
        private readonly IAnswersService _answersService = null!;
        private readonly IServiceProvider _serviceProvider = null!;

        public int TheAnswer
        {
            get => Get(42);
            set => Set(value);
        }

        public BindableBase? MainPage
        {
            get => Get<BindableBase>(null); 
            set => Set(value);
        }

        public DelegateCommand<String> NavigateToCommand { get; }

        public ShellVm() {
            NavigateToCommand = new DelegateCommand<string>(Navigate, str =>
            {
                if ((str == "A") && (MainPage is PageAVm)) return false;
                if ((str == "B") && (MainPage is PageBVm)) return false;
                return true;
            });
        }

        public ShellVm(
            IAnswersService answersService, 
            ItemListVm itemList, 
            IServiceProvider serviceProvider
            ) :this()
        {
            _answersService = answersService;
            _serviceProvider = serviceProvider;
            MainPage = itemList;
            Initialize();
        }

        void Navigate(string str)
        {
            if (str == "A") NavigateToPageA();
            else if (str == "B") NavigateToPageB();

            NavigateToCommand.TriggerCanExecuteChanged();
        }

        void NavigateToPageA()
        {
            MainPage = _serviceProvider.GetRequiredService<PageAVm>();
        }

        void NavigateToPageB()
        {
            MainPage = _serviceProvider.GetRequiredService<PageBVm>();
        }

        private async void Initialize()
        {
            TheAnswer = await _answersService.GetAnswer();
        }
    }
}
