using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaAccountManager : ISocialMediaAccountService
    {
        private readonly ISocialMediaAccountDal _socialMediaAccountDal;

        public SocialMediaAccountManager(ISocialMediaAccountDal socialMediaAccountDal)
        {
            _socialMediaAccountDal = socialMediaAccountDal;
        }

        public void TDelete(int id)
        {
            _socialMediaAccountDal.Delete(id);
        }

        public List<SocialMediaAccount> TGetActiveSocialMediaAccounts()
        {
            return _socialMediaAccountDal.GetActiveSocialMediaAccounts();
        }

        public List<SocialMediaAccount> TGetAll()
        {
            return _socialMediaAccountDal.GetAll();
        }

        public SocialMediaAccount TGetById(int id)
        {
            return _socialMediaAccountDal.GetById(id);
        }

        public async Task<List<SocialMediaAccount>> TGetSocialMediaAccountsByAppUserIdAsync(int id)
        {
            return await _socialMediaAccountDal.GetSocialMediaAccountsByAppUserIdAsync(id);
        }

        public void TInsert(SocialMediaAccount entity)
        {
            _socialMediaAccountDal.Insert(entity);
        }

        public void TUpdate(SocialMediaAccount entity)
        {
            _socialMediaAccountDal.Update(entity);
        }
    }
}
