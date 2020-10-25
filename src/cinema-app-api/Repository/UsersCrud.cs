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
        private readonly IEncryptor _encryptor;

        public UsersCrudService(DataContext context, IEncryptor encryptor) : base(context)
        {
            _encryptor = encryptor;
        }
        public override Users AddItem(Users item)
        {
            var existing = _context.Users.FirstOrDefault(d => d.UserName == item.UserName);
            if (existing != null) return null;
            
            item.FirstName = _encryptor.Encrypt(item.FirstName);
            item.LastName = _encryptor.Encrypt(item.LastName);

            var entity = _context.Add(item);
            _context.SaveChanges();
            
            entity.Entity.FirstName = _encryptor.Decrypt(entity.Entity.FirstName);
            entity.Entity.LastName = _encryptor.Decrypt(entity.Entity.LastName);
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
                entity.FirstName = _encryptor.Decrypt(entity.FirstName);
                entity.LastName = _encryptor.Decrypt(entity.LastName);
            }
            return entities;
        }

        public override Users UpdateItem(string id, Users item)
        {
            
            item.Id = new Guid(id);
            item.FirstName = _encryptor.Encrypt(item.FirstName);
            item.LastName = _encryptor.Encrypt(item.LastName);
            
            var entity = _context.Users.Update(item);
            _context.SaveChanges();

            entity.Entity.FirstName = _encryptor.Decrypt(entity.Entity.FirstName);
            entity.Entity.LastName = _encryptor.Decrypt(entity.Entity.LastName);
            
            return entity.Entity;
        }

        public override Users GetItem(string id)
        {
            var entity = _context.Users.Find(new Guid(id));
            entity.Password = null;
            entity.FirstName = _encryptor.Decrypt(entity.FirstName);
            entity.LastName = _encryptor.Decrypt(entity.LastName);
            return entity;
        }
    }
}