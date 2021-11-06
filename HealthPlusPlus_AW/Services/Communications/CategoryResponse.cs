using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
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