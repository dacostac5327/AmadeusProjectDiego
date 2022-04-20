using shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Services
{
    public interface IDepartmentServices
    {
        public Task<List<Department>> GetDepartments();
    }
    public class DepartmentServices : IDepartmentServices
    {
        private readonly AmadeusDbContext _amadeusDbContext;
        public DepartmentServices(AmadeusDbContext amadeusDbContext)
        {
            _amadeusDbContext = amadeusDbContext;
        }
        public async Task<List<Department>> GetDepartments()
        {
            return _amadeusDbContext.Departments.ToList();
        }
    }
}
