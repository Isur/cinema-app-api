using System;
using System.Collections.Generic;
using System.Linq;
using cinema_app_api.Data;
using cinema_app_api.Models;

namespace cinema_app_api.Repository
{
    public class MoviesCrudService : BaseCrudService<Movies>
    {
        public MoviesCrudService(DataContext context) : base(context) { }
        public override Movies AddItem(Movies item)
        {
            var movie = _context.Add(item);
            _context.SaveChanges();
            return movie.Entity;
        }

        public override string DeleteItem(string id)
        {
            var movie = _context.Movies.Find(new Guid(id));
            _context.Remove(movie);
            _context.SaveChanges();
            return id;
        }

        public override List<Movies> GetItems()
        {
            var movies = _context.Movies.AsQueryable().ToList();
            return movies;
        }

        public override Movies UpdateItem(string id, Movies item)
        {
            item.Id = new Guid(id);
            var movie = _context.Movies.Update(item);
            _context.SaveChanges();
            return movie.Entity;
        }

        public override Movies GetItem(string id)
        {
            var movie = _context.Movies.Find(new Guid(id));
            return movie;
        }
    }
}