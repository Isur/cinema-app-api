using Microsoft.AspNetCore.Mvc;
using cinema_app_api.Repository;
using System.Collections.Generic;

namespace cinema_app_api.Controllers
{
    [ApiController]
    public class CrudController<T> : ControllerBase
    {
        protected readonly IBaseCrudService<T> _crud;
        public CrudController(IBaseCrudService<T> crud)
        {
            _crud = crud;
        }

        [HttpGet]
        virtual public List<T> GetList()
        {
            return _crud.GetItems();
        }

        [HttpGet, Route("{id}")]
        virtual public T Get(string id)
        {
            return _crud.GetItem(id);
        }

        [HttpDelete, Route("{id}")]
        virtual public IActionResult Delete(string id)
        {
            var deletedId = _crud.DeleteItem(id);
            return Ok(new { id = deletedId });
        }
    }
}