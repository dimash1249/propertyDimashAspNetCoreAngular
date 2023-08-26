using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyDimashAngular.Models
{
    public class PropertyImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public byte[] Image { get; set; }
        public string PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}
