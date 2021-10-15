using System.ComponentModel;

namespace HealthPlusPlus_AW.Domain.Models
{
    public enum EUnitOfMeasurement : byte
    {
        [Description("UN")]
        Unit = 1,
        [Description("ML")]
        Milligram = 2,
        [Description("G")]
        Gram = 3,
        [Description("KG")]
        Kilogram = 4,
        [Description("L")]
        Liter = 5
    }
}