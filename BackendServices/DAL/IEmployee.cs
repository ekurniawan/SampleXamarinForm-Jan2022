using BackendServices.Models;

namespace BackendServices.DAL
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Insert(Employee employee);
        Employee Update(int id,Employee employee);
        void Delete(int id);
    }
}
