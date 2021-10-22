using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveDiagnosticResponse : BaseResponse
    {
        public Diagnostic Diagnostic { get; private set; }

        public SaveDiagnosticResponse(bool success, string message, Diagnostic diagnostic) : base(success, message)
        {
            Diagnostic = diagnostic;
        }

        public SaveDiagnosticResponse(Diagnostic diagnostic) : this(true, string.Empty, diagnostic){}
        
        public SaveDiagnosticResponse(string message) : this(false, message, null){}
    }
}