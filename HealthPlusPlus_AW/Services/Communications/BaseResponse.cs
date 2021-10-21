namespace HealthPlusPlus_AW.Services.Communications
{
    public class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}