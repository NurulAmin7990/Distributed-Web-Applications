using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ParentRepository : IRepository<Parent>
    {
        private DatabaseEntities db = new DatabaseEntities();

        public void Add(Parent entity)
        {
           db.Parents.Add(entity);
           db.SaveChanges();
        }

        public void Delete(int? id)
        {
            db.Parents.Remove(db.Parents.Find(id));
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Parent Find(int? id)
        {
            return db.Parents.Find(id);
        }

        public List<Parent> ToList()
        {
            return db.Parents.ToList();
        }

        public void Update(Parent Parent)
        {
            db.Entry(Parent).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}