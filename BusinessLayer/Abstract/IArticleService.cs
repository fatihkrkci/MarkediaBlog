using EntityLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        public List<Article> TAwaitingApprovalArticles();
        public List<Article> TApprovedArticles();
        public List<Article> TDisapprovedArticles();
        public List<Article> TArticleListWithCategoryAndAppUser();
        public Article TGetArticleDetails(int id);
        public void TArticleViewCountIncrease(int id);
        public List<Article> TGetArticlesByAppUserId(int id);
        public Article TGetLastArticle();
        public List<Article> TGetLastThreeArticles();
        public List<CategoryArticleCountViewModel> TGetArticleCountGroupedByCategory();
    }
}
