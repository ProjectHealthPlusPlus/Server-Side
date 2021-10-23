using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; set; }
        
        public CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }
        
        public CategoryResponse(Category category) : this(true,string.Empty,category){}
        public CategoryResponse(string message) : this(false,message,null){}
    }
}