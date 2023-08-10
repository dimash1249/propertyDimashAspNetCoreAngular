
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Services
{
    public interface IResidentialComplexService
    {
        IEnumerable<ResidentialComplex> GetResidentialComplexList();
        ResidentialComplex GetResidentialComplexById(string id);
        ResidentialComplex CreateResidentialComplex(ResidentialComplex residentialComplex);
        void DeleteResidentialComplex(ResidentialComplex residentialComplex);
    }
}
