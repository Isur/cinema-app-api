using System;
using System.Collections.Generic;
using System.Linq;
using cinema_app_api.Data;
using cinema_app_api.Models;
using cinema_app_api.Repository.ExtendedRepositories;

namespace cinema_app_api.Repository
{
    public class TicketsCrudService : BaseCrudService<Tickets>, ITicketRepository
    {
        public TicketsCrudService(DataContext context) : base(context) { }
        public override Tickets AddItem(Tickets item)
        {
            var entity = _context.Add(item);
            _context.SaveChanges();
            return entity.Entity;
        }

        public override string DeleteItem(string id)
        {
            var entity = _context.Tickets.Find(new Guid(id));
            _context.Remove(entity);
            _context.SaveChanges();
            return id;
        }

        public override List<Tickets> GetItems()
        {
            var entities = _context.Tickets.AsQueryable().ToList();
            return entities;
        }

        public override Tickets UpdateItem(string id, Tickets item)
        {
            item.Id = new Guid(id);
            var entities = _context.Tickets.Update(item);
            _context.SaveChanges();
            return entities.Entity;
        }

        public override Tickets GetItem(string id)
        {
            var entity = _context.Tickets.Find(new Guid(id));
            return entity;
        }

        public bool CheckIfFree(int x, int y)
        {
            var ticket = _context.Tickets.FirstOrDefault(entity => entity.FieldX == x && entity.FieldY == y);
            return ticket == null;
        }
    }
}