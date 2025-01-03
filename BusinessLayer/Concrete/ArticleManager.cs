﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> TApprovedArticles()
        {
            return _articleDal.ApprovedArticles();
        }

        public List<Article> TArticleListWithCategoryAndAppUser()
        {
            return _articleDal.ArticleListWithCategoryAndAppUser();
        }

        public void TArticleViewCountIncrease(int id)
        {
            _articleDal.ArticleViewCountIncrease(id);
        }

        public List<Article> TAwaitingApprovalArticles()
        {
            return _articleDal.AwaitingApprovalArticles();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TDisapprovedArticles()
        {
            return _articleDal.DisapprovedArticles();
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public List<CategoryArticleCountViewModel> TGetArticleCountGroupedByCategory()
        {
            return _articleDal.GetArticleCountGroupedByCategory();
        }

        public Article TGetArticleDetails(int id)
        {
            return _articleDal.GetArticleDetails(id);
        }

        public List<Article> TGetArticlesByAppUserId(int id)
        {
            return _articleDal.GetArticlesByAppUserId(id);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public Article TGetLastArticle()
        {
            return _articleDal.GetLastArticle();
        }

        public Article TGetLastArticleByAppUserIdWithCategory(int id)
        {
            return _articleDal.GetLastArticleByAppUserIdWithCategory(id);
        }

        public List<Article> TGetLastThreeArticles()
        {
            return _articleDal.GetLastThreeArticles();
        }

        public List<Article> TGetPopularArticles()
        {
            return _articleDal.GetPopularArticles();
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }
    }
}
