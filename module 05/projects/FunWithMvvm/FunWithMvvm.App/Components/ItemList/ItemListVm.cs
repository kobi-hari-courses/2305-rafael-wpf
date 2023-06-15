using FunWithMvvm.App.Services;
using MvvmTools;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMvvm.App.Components.ItemList
{
    public class ItemListVm: BindableBase
    {
        private readonly IAnswersService? _answerService;

        public int ItemsCount { get => Get(0); set => Set(value); }

        public ItemListVm()
        {

        }

        public ItemListVm(IAnswersService answersService)
        {
            _answerService = answersService;
        }
    }
}
