using AutoMapper;
using Ecommerce.Server.Product.Model;
using Ecommerce.Server.Shared.Model;

namespace Ecommerce.Server.Product.Extension
{
    public class ProductDetailProfile:Profile
    {
        public ProductDetailProfile()
        {
            CreateMap<ProductDetail, ProductResponse>()
           .ForMember(dest => dest.TagMessage, opt => opt.MapFrom(src =>
               src.StockQuantity <= 0
                   ? "Out of Stock"
                   : src.StockQuantity <= 5
                       ? "Limited Stock"
                       : "In Stock"));

            CreateMap<ProductCreate, ProductDetail>().ForMember(des=> des.Id, opt=> opt.Ignore());
        }
    }
}
