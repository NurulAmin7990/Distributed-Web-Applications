using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
namespace WebApplicationTest
{
    class FakeParentRepository : IRepository<Parent>
    {
        public bool found;

        public FakeParentRepository(bool found = true)
        {
            this.found = found;
        }

        public void Add(Parent entity)
        {
        }

        public void Delete(int? id)
        {
        }

        public void Dispose()
        {
        }

        public Parent Find(int? id)
        {
            if (found)
            {
                return new Parent();
            }
            return null;
        }

        public List<Parent> ToList()
        {
            return new List<Parent>();
        }

        public void Update(Parent Parent)
        {
        }
    }
}
