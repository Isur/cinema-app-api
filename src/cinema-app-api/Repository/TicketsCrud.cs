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
            var entity = _context.Tickets.FirstOrDefault(c => c.Id == new Guid(id));
            entity.Showing = item.Showing;
            entity.Status = item.Status;
            entity.FieldX = item.FieldX;
            entity.FieldY = item.FieldY;
            entity.User = item.User;
            _context.SaveChanges();
            return entity;
        }

        public override Tickets GetItem(string id)
        {
            var entity = _context.Tickets.Find(new Guid(id));
            return entity;
        }

        public bool CheckIfFree(int x, int y, string showing)
        {
            var ticket = _context.Tickets.FirstOrDefault(entity => entity.FieldX == x && entity.FieldY == y && entity.ShowingId == new Guid(showing));
            return ticket == null;
        }

        public bool CheckIfCanUpdate(int x, int y, string id, string showing) {
            var ticket = _context.Tickets.FirstOrDefault(entity => entity.FieldX == x && entity.FieldY == y && entity.Id != new Guid(id) && entity.ShowingId == new Guid(showing));
            return ticket == null;
        } 
    }
}