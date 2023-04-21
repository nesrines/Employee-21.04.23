using MiniApp.Core.Models;
namespace MiniApp.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public Employee GetByField(string data)
        {
            foreach (Employee employee in _items)
            {
                if(employee.Id.ToString().Contains(data) || employee.Name.Contains(data) || employee.Surname.Contains(data) || employee.Position.Contains(data) || employee.Salary.ToString().Contains(data))
                { return employee; }
            }
            return null;
        }
    }
}