using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISocialMediaAccountService : IGenericService<SocialMediaAccount>
    {
        public List<SocialMediaAccount> TGetActiveSocialMediaAccounts();
        public Task<List<SocialMediaAccount>> TGetSocialMediaAccountsByAppUserIdAsync(int id);
    }
}
