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
    public class TagCloudManager : ITagCloudService
    {
        private readonly ITagCloudDal _tagCloudDal;

        public TagCloudManager(ITagCloudDal tagCloudDal)
        {
            _tagCloudDal = tagCloudDal;
        }

        public void TDelete(int id)
        {
            _tagCloudDal.Delete(id);
        }

        public List<TagCloud> TGetAll()
        {
            return _tagCloudDal.GetAll();
        }

        public TagCloud TGetById(int id)
        {
            return _tagCloudDal.GetById(id);
        }

        public void TInsert(TagCloud entity)
        {
            _tagCloudDal.Insert(entity);
        }

        public void TUpdate(TagCloud entity)
        {
            _tagCloudDal.Update(entity);
        }
    }
}
