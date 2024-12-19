using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> AwaitingApprovalArticles();
        List<Article> ApprovedArticles();
        List<Article> DisapprovedArticles();
        List<Article> ArticleListWithCategoryAndAppUser();
        Article GetArticleDetails(int id);
        void ArticleViewCountIncrease(int id);
        List<Article> GetArticlesByAppUserId(int id);
        Article GetLastArticle();
    }
}
