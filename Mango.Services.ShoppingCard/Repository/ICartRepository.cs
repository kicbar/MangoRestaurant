using Mango.Services.ShoppingCardAPI.Models.Dtos;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCardAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);
    }
}
