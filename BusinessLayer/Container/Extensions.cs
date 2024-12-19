using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<IArticleService, ArticleManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<ISocialMediaAccountDal, EfSocialMediaAccountDal>();
            services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();

            services.AddScoped<ITagCloudDal, EfTagCloudDal>();
            services.AddScoped<ITagCloudService, TagCloudManager>();

            services.AddScoped<INewsLetterDal, EfNewsLetterDal>();
            services.AddScoped<INewsLetterService, NewsLetterManager>();
        }
    }
}
