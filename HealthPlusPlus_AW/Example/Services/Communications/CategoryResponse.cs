using HealthPlusPlus_AW.Example.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Example.Services.Communications
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public CategoryResponse(string message) : base(message)
        {
        }

        public CategoryResponse(Category category) : base(category)
        {   
        }
    }
}