using HealthPlusPlus_AW.meeting.Resource;

namespace HealthPlusPlus_AW.Profile.Resource
{
    public class ClinicResource : UserResource
    {
        public ClinicLocationResource ClinicLocation { get; set; }
    }
}