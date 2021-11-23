namespace HealthPlusPlus_AW.Example.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        
        //RelationShips
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}