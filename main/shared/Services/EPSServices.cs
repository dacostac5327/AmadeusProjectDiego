using shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Services
{
    public interface IEPSServices
    {
        public Task<List<EPS>> GetEPSs();
    }
    public class EPSServices : IEPSServices
    {
        private readonly AmadeusDbContext _amadeusDbContext;
        public EPSServices(AmadeusDbContext amadeusDbContext)
        {
            _amadeusDbContext = amadeusDbContext;
        }
        public async Task<List<EPS>> GetEPSs()
        {
            return _amadeusDbContext.EPS.ToList();
        }
    }
}
