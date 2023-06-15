using System.Threading.Tasks;

namespace FunWithMvvm.App.Services
{
    public interface IAnswersService
    {
        Task<int> GetAnswer();
    }
}