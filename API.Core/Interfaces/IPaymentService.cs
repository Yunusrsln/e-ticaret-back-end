using API.Core.DbModels;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrPaymentIntent(string basketId);
    }
}
