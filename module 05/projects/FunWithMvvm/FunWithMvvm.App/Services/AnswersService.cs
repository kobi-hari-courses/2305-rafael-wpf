using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMvvm.App.Services
{
    public class AnswersService : IAnswersService
    {
        public async Task<int> GetAnswer()
        {
            await Task.Delay(5000);
            return 52;
        }
    }
}
