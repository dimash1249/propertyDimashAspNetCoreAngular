
using Microsoft.EntityFrameworkCore;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Services
{
    public class ResidentialComplexService : IResidentialComplexService
    {
        private readonly ApplicationDbContext _context;

        public ResidentialComplexService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ResidentialComplex> GetResidentialComplexList()
        {
            return _context.ResidentialComplexes.Include(d => d.Properties).ToList();
        }

        public ResidentialComplex GetResidentialComplexById(string id)
        {
            return _context.ResidentialComplexes.Include(d => d.Properties).FirstOrDefault(d => d.Id == id);
        }

        public ResidentialComplex CreateResidentialComplex(ResidentialComplex residentialComplex)
        {
            _context.ResidentialComplexes.Add(residentialComplex);
            _context.SaveChanges();
            return residentialComplex;
        }

        public void DeleteResidentialComplex(ResidentialComplex residentialComplex)
        {
            _context.ResidentialComplexes.Remove(residentialComplex);
            _context.SaveChanges();
        }
    }
}
