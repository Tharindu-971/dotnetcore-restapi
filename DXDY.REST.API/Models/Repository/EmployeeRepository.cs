using DXDY.REST.API.Data;
using DXDY.REST.API.Models.Repository.IRepository;

namespace DXDY.REST.API.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateEmployee(Employee employee)
        {
            _context.employees.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _context?.employees.Remove(employee);
            return Save();
        }

        public ICollection<Employee> GetAll()
        {
            return _context.employees.OrderBy(x => x.Name).ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.employees.FirstOrDefault(x => x.Id == id);
        }

        public bool IsEmployeeExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsEmployeeExist(string name)
        {
            bool value =  _context.employees.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;   
        }

        public bool Save()
        {
            return _context.SaveChanges()>=0?true:false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _context.employees.Update(employee);
            return Save();
        }
    }
}
