namespace PropertyDimashAngular.Models
{
    public class ResidentialComplex
    {
        public string Id { get; set; }
        public string ResidentialComplexName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public List<Flat>? Properties { get; set; }
    }
}
