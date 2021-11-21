using Mango.Services.ShoppingCardAPI.Models.Dtos;
using Mango.Services.ShoppingCardAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCardAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        protected ResponseDto _responseDto;
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            this._responseDto = new ResponseDto(); 
            _cartRepository = cartRepository;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCartAsync(string userId)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
                _responseDto.Result = cartDto;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpGet("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                CartDto cart = await _cartRepository.CreateUpdateCart(cartDto);
                _responseDto.Result = cart;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto cart = await _cartRepository.CreateUpdateCart(cartDto);
                _responseDto.Result = cart;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody] int detailsId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveFromCart(detailsId);
                _responseDto.Result = isSuccess;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }
    }
}
