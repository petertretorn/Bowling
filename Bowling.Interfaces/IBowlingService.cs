using Bowling.Dtos;
using System.Threading.Tasks;

namespace Bowling.Interfaces
{
    public interface IBowlingService
    {
        Task<ViewData> ValidateResults();
    }
}
