using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IPaymentService
    {
        Task CreateCharge(string token, int amount, string currency, string description);
    }
}