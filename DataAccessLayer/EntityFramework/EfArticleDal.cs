﻿using DataAccessLayer.Abstract;
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
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly MarkediaBlogContext _context;

        public EfArticleDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Article> ApprovedArticles()
        {
            return _context.Articles.Include(x => x.Category).Where(y => y.ArticleStatus == ArticleStatus.Approved).ToList();
        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            return _context.Articles.Include(x => x.Category).Include(y => y.AppUser).Where(z => z.ArticleStatus == ArticleStatus.Approved && z.Status == true).ToList();
        }

        public void ArticleViewCountIncrease(int id)
        {
            var updatedValue = _context.Articles.Find(id);
            updatedValue.ViewCount += 1;
            _context.SaveChanges();
        }

        public List<Article> AwaitingApprovalArticles()
        {
            return _context.Articles.Include(x => x.Category).Where(y => y.ArticleStatus == ArticleStatus.AwaitingApproval).ToList();
        }

        public List<Article> DisapprovedArticles()
        {
            return _context.Articles.Include(x => x.Category).Where(y => y.ArticleStatus == ArticleStatus.Disapproved).ToList();
        }

        public Article GetArticleDetails(int id)
        {
            return _context.Articles.Include(x => x.Category).Include(y => y.AppUser).Where(z => z.ArticleId == id).FirstOrDefault();
        }

        public List<Article> GetArticlesByAppUserId(int id)
        {
            return _context.Articles.Where(x => x.AppUserId == id).ToList();
        }

        public Article GetLastArticle()
        {
            return _context.Articles.OrderByDescending(x => x.ArticleId).Take(1).FirstOrDefault();
        }
    }
}
