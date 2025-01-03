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
    public class EfSocialMediaAccountDal : GenericRepository<SocialMediaAccount>, ISocialMediaAccountDal
    {
        private readonly MarkediaBlogContext _context;

        public EfSocialMediaAccountDal(MarkediaBlogContext context) : base(context)
        {
            _context = context;
        }

        public List<SocialMediaAccount> GetActiveSocialMediaAccounts()
        {
            return _context.SocialMediaAccounts.Where(x => x.Status == true).ToList();
        }

        public async Task<List<SocialMediaAccount>> GetSocialMediaAccountsByAppUserIdAsync(int id)
        {
            return await _context.SocialMediaAccounts.Where(x => x.AppUserId == id).ToListAsync();
        }
    }
}
