using EntityLayer.Concrete;
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
    }
}
