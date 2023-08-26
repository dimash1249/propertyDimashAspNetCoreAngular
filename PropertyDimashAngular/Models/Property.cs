using PropertyDimashAngular.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyDimashAngular.Models
{
    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Type { get; set; }
        public string PropertyType { get; set; }
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public string TypeOfBuilding { get; set; }
        public int YearOfBuilding { get; set; }
        public double TotalArea { get; set; }
        public double AreaLiving { get; set; }
        public double AreaKitchen { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public string Condition { get; set; }
        public string Telephone { get; set; }
        public string Internet { get; set; }
        public string Bathroom { get; set; }
        public double HeightOfCeiling { get; set; }
        public string Security { get; set; }
        public string Different { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }     
        public List<PropertyImage> Images { get; set; }
        public string UserTelephone { get; set; }
        public string UserEmail { get; set; }
    }
}
