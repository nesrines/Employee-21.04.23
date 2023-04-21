using MiniApp.App.Services.Interfaces;
using MiniApp.Core.Models;
using MiniApp.Data.Repositories;
namespace MiniApp.App.Services.Implementations
{
    internal class EmployeeService:IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private bool Check(string data, int min)
        { return (!(String.IsNullOrWhiteSpace(data)) && data.Length >= min); }
        
        public void Create()
        {
            Console.WriteLine("Enter the name:");
            string Name = Console.ReadLine().Trim();
            while(!(Check(Name, 2)))
            {
                Console.WriteLine();
                Console.WriteLine("Enter the name again:");
                Name = Console.ReadLine().Trim();
            }

            Console.WriteLine();
            Console.WriteLine("Enter the surname:");
            string Surname = Console.ReadLine().Trim();
            while (!(Check(Surname, 2)))
            {
                Console.WriteLine();
                Console.WriteLine("Enter the surname again:");
                Surname = Console.ReadLine().Trim();
            }

            Console.WriteLine();
            Console.WriteLine("Enter the position:");
            string Position = Console.ReadLine().Trim();
            while (!(Check(Position, 5)))
            {
                Console.WriteLine();
                Console.WriteLine("Enter the position again:");
                Position = Console.ReadLine().Trim();
            }

            Console.WriteLine();
            Console.WriteLine("Enter the salary:");
            double.TryParse(Console.ReadLine().Trim(), out double Salary);
            while(Salary == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Salary is not in the correct format. Enter the salary again:");
                double.TryParse(Console.ReadLine().Trim(), out Salary);
            }

            Employee NewEmployee = new Employee(Name, Surname, Position, Salary);
            NewEmployee.CreatedDate = DateTime.UtcNow.AddHours(4);
            NewEmployee.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _employeeRepository.Create(NewEmployee);
            Console.WriteLine("Created new employee successfully!");
        }
        
        public void Update()
        {
            Employee employee = _search();
            Console.WriteLine();
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }
            else { Console.WriteLine(employee); }
            Console.WriteLine();

            Console.WriteLine("What do you want to change?");
            Console.WriteLine("0. Nothing; 1. Name; 2. Surname; 3. Position; 4. Salary");
            string Request = Console.ReadLine().Trim();
            while(Request != "0")
            {
                Console.Clear();

                switch (Request)
                {
                    case "1":
                        Console.WriteLine("Enter the new name:");
                        string NewName = Console.ReadLine().Trim();
                        while (!(Check(NewName, 2)))
                        {
                            Console.WriteLine("Enter the new name again:");
                            NewName = Console.ReadLine().Trim();
                        }
                        employee.Name = NewName;
                        break;

                    case "2":
                        Console.WriteLine("Enter the new surname:");
                        string NewSurname = Console.ReadLine().Trim();
                        while (!(Check(NewSurname, 2)))
                        {
                            Console.WriteLine("Enter the new surname again:");
                            NewSurname = Console.ReadLine().Trim();
                        }
                        employee.Surname = NewSurname;
                        break;

                    case "3":
                        Console.WriteLine("Enter the new position:");
                        string NewPosition = Console.ReadLine().Trim();
                        while (!(Check(NewPosition, 5)))
                        {
                            Console.WriteLine("Enter the new position again:");
                            NewPosition = Console.ReadLine().Trim();
                        }
                        employee.Position = NewPosition;
                        break;

                    case "4":
                        Console.WriteLine("Enter the new salary:");
                        double.TryParse(Console.ReadLine().Trim(), out double NewSalary);
                        while (NewSalary == 0)
                        {
                            Console.WriteLine("Salary is not in the correct format. Enter the new salary again:");
                            double.TryParse(Console.ReadLine().Trim(), out NewSalary);
                        }
                        employee.Salary = NewSalary;
                        break;

                    default:
                        Console.WriteLine("Choose a valid option:");
                        break;
                }
                Console.WriteLine(employee);
                Console.WriteLine("What else do you want to change?");
                Console.WriteLine("0. Nothing; 1. Name; 2. Surname; 3. Position; 4. Salary");
                Request = Console.ReadLine().Trim();
            }
            employee.UpdatedDate = DateTime.UtcNow.AddHours(4);
            Console.WriteLine("OK, All Changes Saved!");
        }

        public void Delete()
        {
            Employee employee = _search();
            Console.WriteLine();
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }
            else { Console.WriteLine(employee); }
            Console.WriteLine();

            Console.WriteLine("Are you sure you want to delete this employee? (yes/no)");
            string Delete = Console.ReadLine().Trim();
            if (Delete == "yes" || Delete == "Yes" || Delete == "YES")
            {
                _employeeRepository.Delete(employee);
                Console.WriteLine("Deleted successfully!");
            }
            else { Console.WriteLine("Couldn't delete the employee."); }
        }

        public void ShowAll()
        {
            List<Employee> Employees = _employeeRepository.GetAll();
            if (Employees.Count == 0) { Console.WriteLine("No available employees"); }
            foreach(Employee Employee in Employees)
            { Console.WriteLine(Employee); }
        }

        public void ShowOne()
        {
            Employee employee = _search();
            Console.WriteLine();
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }
            else { Console.WriteLine(employee); }
        }
        private Employee _search()
        {
            Console.WriteLine("Please, enter any information about the employee you're looking for:");
            string SearchInfo = Console.ReadLine().Trim();
            return _employeeRepository.GetByField(SearchInfo);
        }
    }
}