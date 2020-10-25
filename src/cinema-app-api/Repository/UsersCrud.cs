using System;
using System.Collections.Generic;
using System.Linq;
using cinema_app_api.Data;
using cinema_app_api.Helpers;
using cinema_app_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cinema_app_api.Repository
{
    public class UsersCrudService : BaseCrudService<Users>
    {
        public UsersCrudService(DataContext context) : base(context) { }
        public override Users AddItem(Users item)
        {
            var existing = _context.Users.FirstOrDefault(d => d.UserName == item.UserName);
            if (existing != null) return null;

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

            return entities;
        }

        public override Users UpdateItem(string id, Users item)
        {
            var entity = _context.Users.FirstOrDefault(c => c.Id == new Guid(id));
            entity.LastName = item.LastName;
            entity.Role = item.Role;
            entity.UserName = item.UserName;
            entity.FirstName = item.FirstName;
            _context.SaveChanges();
            return entity;
        }

        public override Users GetItem(string id)
        {
            var entity = _context.Users.Find(new Guid(id));
            return entity;
        }
    }
}