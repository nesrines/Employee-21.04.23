using MiniApp.Core.Models;

namespace MiniApp.App.Services.Interfaces
{
    internal interface IEmployeeService
    {
        public void Create();
        public void Update();
        public void Delete();
        public void ShowAll();
        public void ShowOne();
    }
}