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
    public class EfTagCloudDal : GenericRepository<TagCloud>, ITagCloudDal
    {
        private readonly MarkediaBlogContext _context;

        public EfTagCloudDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
