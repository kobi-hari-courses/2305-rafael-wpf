using FunWithMvvm.App.Services;
using MvvmTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMvvm.App.Components.Shell
{
    public class ShellVm: BindableBase
    {
        private readonly IAnswersService? _answersService;

        public int TheAnswer
        {
            get => Get(42);
            set => Set(value);
        }

        public ShellVm() { }

        public ShellVm(IAnswersService answersService) 
        {
            _answersService = answersService;
            Initialize();
        }

        private async void Initialize()
        {
            TheAnswer = await (_answersService?.GetAnswer() ?? Task.FromResult(0));
        }
    }
}
