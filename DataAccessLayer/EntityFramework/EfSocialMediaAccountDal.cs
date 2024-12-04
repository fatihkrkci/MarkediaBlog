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
    public class EfSocialMediaAccountDal : GenericRepository<SocialMediaAccount>, ISocialMediaAccountDal
    {
        private readonly MarkediaBlogContext _context;

        public EfSocialMediaAccountDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
