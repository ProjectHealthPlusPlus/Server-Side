using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class DiagnosticResponse : BaseResponse
    {
        public Diagnostic Diagnostic { get; private set; }

        public DiagnosticResponse(bool success, string message, Diagnostic diagnostic) : base(success, message)
        {
            Diagnostic = diagnostic;
        }

        public DiagnosticResponse(Diagnostic diagnostic) : this(true, string.Empty, diagnostic){}
        
        public DiagnosticResponse(string message) : this(false, message, null){}
    }
}