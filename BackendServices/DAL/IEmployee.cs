using BackendServices.Models;

namespace BackendServices.DAL
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Insert(Employee employee);
        void Update(int id,Employee employee);
        void Delete(int id);
    }
}
