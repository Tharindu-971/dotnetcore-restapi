namespace DXDY.REST.API.Models.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetAll();
        Employee GetEmployeeById(int id);
        bool IsEmployeeExist(int id);
        bool IsEmployeeExist(string name);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}
