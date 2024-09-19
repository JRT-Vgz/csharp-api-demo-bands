using csharp_api_demo_bands.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_demo_bands.Repository
{
    public class BandRepository : IRepository<Band>
    {
        private BandsContext _bandContext;

        public BandRepository(BandsContext bandContext)
        {
            _bandContext = bandContext;
        }

        public async Task<IEnumerable<Band>> GetAll() =>
            await _bandContext.Bands.ToListAsync();

        public async Task<Band> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Band entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Band entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Band entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
