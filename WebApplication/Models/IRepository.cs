using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int? id);
        void Dispose();
        T Find(int? id);
        List<T> ToList();
        void Update(T Parent);
    }
}