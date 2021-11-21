using Mango.Services.ShoppingCardAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCardAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
