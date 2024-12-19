using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly MarkediaBlogContext _context;

        public EfCommentDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsByAppUserId(int id)
        {
            return _context.Comments.Where(x => x.AppUserId == id).ToList();
        }

        public List<Comment> GetCommentsByArticleId(int id)
        {
            return _context.Comments.Where(x => x.ArticleId == id).Include(y => y.AppUser).ToList();
        }
    }
}
