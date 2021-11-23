namespace HealthPlusPlus_AW.Shared.Services.Communications
{
    public class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; set; }
        public T Resource {get; private set;}
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
        
        public BaseResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }
    }
}