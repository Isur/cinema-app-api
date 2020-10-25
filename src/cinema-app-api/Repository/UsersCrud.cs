using System;
using System.Collections.Generic;
using System.Linq;
using cinema_app_api.Data;
using cinema_app_api.Models;

namespace cinema_app_api.Repository
{
    public class UsersCrudService : BaseCrudService<Users>
    {
        public UsersCrudService(DataContext context) : base(context) { }
        public override Users AddItem(Users item)
        {
            var entity = _context.Add(item);
            _context.SaveChanges();
            return entity.Entity;
        }

        public override string DeleteItem(string id)
        {
            var entity = _context.Users.Find(new Guid(id));
            _context.Remove(entity);
            _context.SaveChanges();
            return id;
        }

        public override List<Users> GetItems()
        {
            var entities = _context.Users.AsQueryable().ToList();
            foreach (var entity in entities)
            {
                entity.Password = null;
            }
            return entities;
        }

        public override Users UpdateItem(string id, Users item)
        {
            item.Id = new Guid(id);
            var entities = _context.Users.Update(item);
            _context.SaveChanges();
            return entities.Entity;
        }

        public override Users GetItem(string id)
        {
            var entity = _context.Users.Find(new Guid(id));
            entity.Password = null;
            return entity;
        }
    }
}