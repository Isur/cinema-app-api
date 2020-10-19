using System.Collections.Generic;
using cinema_app_api.Data;
using cinema_app_api.Models;

namespace cinema_app_api.Repository {
    public abstract class BaseCrudService<T> : IBaseCrudService<T>
    {
        protected readonly DataContext _context;
        protected BaseCrudService(DataContext context)
        {
            _context = context;
        }
        abstract public T AddItem(T item);

        abstract public string DeleteItem(string id);

        abstract public List<T> GetItems();

        abstract public T UpdateItem(string id, T item);
        abstract public T GetItem(string id);
    }
}