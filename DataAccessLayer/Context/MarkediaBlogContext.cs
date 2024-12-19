using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class MarkediaBlogContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FATIHKUREKCI\\SQLEXPRESS;initial catalog=MarkediaBlogDb;integrated security=true;");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
    }
}
