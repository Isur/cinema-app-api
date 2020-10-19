using System.Collections.Generic;
using cinema_app_api.Data;

namespace cinema_app_api.Repository
{
    public interface IBaseCrudService<T>
    {
        public List<T> GetItems();
        public T AddItem(T item);
        public T UpdateItem(string id, T item);
        public string DeleteItem(string id);
        public T GetItem(string id);
    }
}