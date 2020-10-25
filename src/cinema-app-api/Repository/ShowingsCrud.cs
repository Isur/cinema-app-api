using System;
using System.Collections.Generic;
using System.Linq;
using cinema_app_api.Data;
using cinema_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_app_api.Repository
{
    public class ShowingsCrudService : BaseCrudService<Showings>
    {
        public ShowingsCrudService(DataContext context) : base(context) { }
        public override Showings AddItem(Showings item)
        {
            var entity = _context.Add(item);
            _context.SaveChanges();
            return entity.Entity;
        }

        public override string DeleteItem(string id)
        {
            var entity = _context.Showings.Find(new Guid(id));
            _context.Remove(entity);
            _context.SaveChanges();
            return id;
        }

        public override List<Showings> GetItems()
        {
            var entities = _context.Showings.AsQueryable().Include(c => c.Tickets).ToList();
            return entities;
        }

        public override Showings UpdateItem(string id, Showings item)
        {
            item.Id = new Guid(id);
            var entities = _context.Showings.Update(item);
            _context.SaveChanges();
            return entities.Entity;
        }

        public override Showings GetItem(string id)
        {
            var entity = _context.Showings
                .Include(c => c.Tickets)
                .Include(c => c.Hall)
                .FirstOrDefault(c => c.Id == new Guid(id));
            return entity;
        }
    }
}