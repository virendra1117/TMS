using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.EntityModel;
using TMS.Model;

namespace TMS.Data.Repository
{
    public class CategoriesRepository
    {
        public List<CategoryModel> GetAllCategoryList()
        {
            List<CategoryModel> CategoryList = null;
            using (ticketmanagmentEntities db = new ticketmanagmentEntities())
            {
                CategoryList = db.tblCategories.Where(x => x.IsActive == true).Select(x => new CategoryModel
                {
                    CategoryId = x.CategoryId,
                    CatgoryName = x.CatgoryName,

                }).ToList();
            }
            return CategoryList;
        }
    }
}
