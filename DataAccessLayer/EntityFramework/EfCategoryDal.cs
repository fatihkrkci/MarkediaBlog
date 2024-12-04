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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly MarkediaBlogContext _context;

        public EfCategoryDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetActiveCategoriesSortedDescending()
        {
            return _context.Categories.Where(x => x.Status == true).OrderByDescending(y => y.CategoryId).ToList();
        }

        public List<Category> GetArchivedCategoriesSortedDescending()
        {
            return _context.Categories.Where(x => x.Status == false).OrderByDescending(y => y.CategoryId).ToList();
        }
    }
}
