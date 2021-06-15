using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class HeadingRepository : IHeadingDal
    {
        Context c = new Context();
        DbSet<Heading> _object;

        public void Delete(Heading item)
        {
            throw new NotImplementedException();
        }

        public Heading Get(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Heading item)
        {
            throw new NotImplementedException();
        }

        public List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Heading item)
        {
            throw new NotImplementedException();
        }
    }
}
