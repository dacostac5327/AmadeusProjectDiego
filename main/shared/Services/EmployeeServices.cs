using shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Services
{
    public interface IEmployeeServices
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<int> Add(Employee data);
        public Task<int> Update(Employee data);
        public Task<int> Delete(Employee data);
    }

    public class EmployeeServices : IEmployeeServices
    {
        private readonly AmadeusDbContext _amadeusDbContext;
        public EmployeeServices(AmadeusDbContext amadeusDbContext) 
        {
            _amadeusDbContext = amadeusDbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return _amadeusDbContext.Employees.ToList();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return _amadeusDbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public async Task<int> Add(Employee data)
        {
            _amadeusDbContext.Employees.Add(data);
            return await _amadeusDbContext.SaveChangesAsync();
        }
        public async Task<int> Update(Employee data)
        {
            Employee employee = _amadeusDbContext.Employees.Where(e => e.Id == data.Id).SingleOrDefault();
            if (employee != null)
            {
                _amadeusDbContext.Entry(employee).CurrentValues.SetValues(data);
                return await _amadeusDbContext.SaveChangesAsync();
            }

            return 0;
        }
        public async Task<int> Delete(Employee data)
        {
            _amadeusDbContext.Employees.Remove(data);
            return await _amadeusDbContext.SaveChangesAsync();
        }
    }
}
