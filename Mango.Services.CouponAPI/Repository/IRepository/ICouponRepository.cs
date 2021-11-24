using Mango.Services.CouponAPI.Models.Dtos;
using System.Threading.Tasks;

namespace Mango.Services.CouponAPI.Repository.IRepository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
