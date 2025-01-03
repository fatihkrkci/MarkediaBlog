﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISocialMediaAccountDal : IGenericDal<SocialMediaAccount>
    {
        List<SocialMediaAccount> GetActiveSocialMediaAccounts();
        Task<List<SocialMediaAccount>> GetSocialMediaAccountsByAppUserIdAsync(int id);
    }
}
