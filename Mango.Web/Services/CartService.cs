using Mango.Web.Models;
using Mango.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class CartService : ICartService
    {
        public Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            throw new NotImplementedException();
        }
    }
}
