using HealthPlusPlus_AW.Example.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Example.Services.Communications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(string message) : base(message)
        {
        }

        public ProductResponse(Product product) : base(product)
        {
        }
    }
}