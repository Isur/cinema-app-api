using System;
using System.Collections.Generic;
using System.Linq;
using cinema_app_api.Data;
using cinema_app_api.Models;

namespace cinema_app_api.Repository
{
    public class HallsCrudService : BaseCrudService<Halls>
    {
        public HallsCrudService(DataContext context) : base(context) { }
        public override Halls AddItem(Halls item)
        {
            var hall = _context.Add(item);
            _context.SaveChanges();
            return hall.Entity;
        }

        public override string DeleteItem(string id)
        {
            var hall = _context.Halls.Find(new Guid(id));
            _context.Remove(hall);
            _context.SaveChanges();
            return id;
        }

        public override List<Halls> GetItems()
        {
            var halls = _context.Halls.AsQueryable().ToList();
            return halls;
        }

        public override Halls UpdateItem(string id, Halls item)
        {
            item.Id = new Guid(id);
            var hall = _context.Halls.Update(item);
            _context.SaveChanges();
            return hall.Entity;
        }

        public override Halls GetItem(string id)
        {
            var hall = _context.Halls.Find(new Guid(id));
            return hall;
        }
    }
}