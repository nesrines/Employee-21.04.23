using MiniApp.Core.Models.BaseModels;
namespace MiniApp.Data.Repositories
{
    public class Repository<T> where T : BaseModel
    {
        protected readonly List<T> _items = new List<T>();

        public void Create(T model)
        { _items.Add(model); }

        public void Delete(T model)
        { _items.Remove(model); }

        public List<T> GetAll()
        { return _items; }
    }
}