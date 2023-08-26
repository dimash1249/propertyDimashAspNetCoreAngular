using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Services
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetPropertyList();
        Property GetPropertyById(string id);
        Flat CreatePropertyFlat(Flat property);
        House CreatePropertyHouse(House property);
        void DeleteProperty(Property property);
    }
}
