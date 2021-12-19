using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using mShop.Discount.Core.Domain;
using mShop.Discount.Grpc.Infrastructure.Mapper.Extensions;
using mShop.Discount.Grpc.Protos;
using mShop.Discount.Services;

namespace mShop.Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly ICouponService _couponService;

        public DiscountService(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var coupon = _couponService.GetCouponByProductId(request.ProductId);
                if (coupon == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found with product identifier:{request.ProductId}"));
                }

                var model = coupon.ToModel<CouponModel>();
                return model;
            });
        }

        public override async Task<CouponModel> InsertDiscount(InsertDiscountRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var coupon = request.Coupon.ToEntity<Coupon>();
                _couponService.InsertCoupon(coupon);
                return coupon.ToModel<CouponModel>();
            });
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var coupon = request.Coupon.ToEntity<Coupon>();
                _couponService.UpdateCoupon(coupon);
                return coupon.ToModel<CouponModel>();
            });
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var coupon = _couponService.GetCouponByProductId(request.ProductId);
                _couponService.DeleteCoupon(coupon);
                return new DeleteDiscountResponse { Success = true };
            });
        }
    }
}