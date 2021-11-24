using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Heal.Services.Communications
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