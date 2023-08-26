namespace PropertyDimashAngular.Models
{
    public class House : Property
    {
        public int? FloorNumber { get; set; }
        public double? AreaLand { get; set; }
        public string? SewageSystem { get; set; }
        public string? DrinkingWater { get; set; }
        public string? Electricity { get; set; }
        public string? Heating { get; set; }
        public string? Gas { get; set; }
        public string? RoofCovering { get; set; }
    }
}
