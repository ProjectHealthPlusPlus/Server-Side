using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
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