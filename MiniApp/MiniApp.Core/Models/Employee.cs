using MiniApp.Core.Models.BaseModels;
namespace MiniApp.Core.Models
{
    public class Employee:BaseModel
    {
        private static int _id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee(string Name, string Surname, string Position, double Salary)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Position = Position;
            this.Salary = Salary;
            _id++;
            Id = _id;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name} {Surname}, Positon: {Position}, Salary: ${Salary}, Created: {CreatedDate}, Updated: {UpdatedDate}";
        }
    }
}