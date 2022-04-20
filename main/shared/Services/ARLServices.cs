using shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Services
{
    public interface IARLServices
    {
        public Task<List<ARL>> GetARLs();
    }
    public class ARLServices : IARLServices
    {
        private readonly AmadeusDbContext _amadeusDbContext;
        public ARLServices(AmadeusDbContext amadeusDbContext)
        {
            _amadeusDbContext = amadeusDbContext;
        }
        public async Task<List<ARL>> GetARLs()
        {
            return _amadeusDbContext.ARL.ToList();
        }
    }
}
