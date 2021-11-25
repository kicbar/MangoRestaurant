using Mango.Services.CouponAPI.Models.Dtos;
using Mango.Services.CouponAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponAPIController : Controller
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _responseDto;

        public CouponAPIController(ICouponRepository couponRepository)
        {
            this._responseDto = new ResponseDto();
            _couponRepository = couponRepository;
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountByCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                _responseDto.Result = coupon;
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
