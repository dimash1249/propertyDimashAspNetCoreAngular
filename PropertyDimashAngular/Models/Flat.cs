namespace PropertyDimashAngular.Models
{
    public class Flat : Property
    {
        public int? PropertyFloor { get; set; }
        public int? TotalFloor { get; set; }
        public bool? FormerDormitory { get; set; }
        public string? Balcony { get; set; }
        public bool? BalconyGlazed { get; set; }
        public string? Door { get; set; }
        public string? Parking { get; set; }
        public string? PropertyFurnished { get; set; }
        public string? Floor { get; set; }
        public string ResidentialComplexId { get; set; }
        public ResidentialComplex? ResidentialComplex { get; set; }
    }
}
