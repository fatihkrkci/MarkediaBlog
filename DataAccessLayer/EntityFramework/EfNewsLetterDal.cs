using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNewsLetterDal : GenericRepository<NewsLetter>, INewsLetterDal
    {
        private readonly MarkediaBlogContext _context;

        public EfNewsLetterDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
