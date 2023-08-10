using Microsoft.EntityFrameworkCore;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;

        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetPropertyList()
        {
            return _context.Properties.Include(d => d.Images).Include(d => d.User).ToList();
        }

        public Property GetPropertyById(string id)
        {
            return _context.Properties.Include(d => d.Images).Include(d => d.User).FirstOrDefault(d => d.Id == id);
        }

        public Flat CreatePropertyFlat(Flat property)
        {
            List<PropertyImage> propertyImages = new List<PropertyImage>();
            foreach(var image in property.Images)
            {
                var propertyImage = new PropertyImage
                {
                    Id = image.Id,
                    Image = image.Image,
                    PropertyId = image.PropertyId,
                    Property = property
                };
                propertyImages.Add(propertyImage);
            }
            property.Images = propertyImages;
            property.ResidentialComplex = _context.ResidentialComplexes.FirstOrDefault(d => d.Id == property.ResidentialComplexId);
            _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public House CreatePropertyHouse(House property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public void DeleteProperty(Property property)
        {
            _context.Properties.Remove(property);
            _context.SaveChanges();
        }
    }
}
