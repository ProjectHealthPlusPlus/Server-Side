using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class DiagnosticResponse : BaseResponse<Diagnostic>
    {
        public DiagnosticResponse(string message) : base(message)
        {
        }

        public DiagnosticResponse(Diagnostic diagnostic) : base(diagnostic)
        {
        }
    }
}