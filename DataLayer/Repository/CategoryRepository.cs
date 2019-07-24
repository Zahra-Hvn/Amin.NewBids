using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Irepository;
using DataLayer.ViewModels;


namespace DataLayer.Repository
{
     public class CategoryRepository : ICategoryRepo
    {
        public CategoryRepository()
        {
        }

        public List<CategoryViewModel> GetCategoryViewModel()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Categories.Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
                }).ToList();
            }
        }
        public List<Category> GetCategorise()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Categories.ToList();
            }
        }
        public Category GetCategoryById(int CateId)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Categories.Where(a => a.Id == CateId).FirstOrDefault();
            }
        }
        public bool AddCategory(CategoryViewModel AC)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                Category tb = new Category();
                tb.Id = AC.Id;
                tb.CategoryName = AC.CategoryName;
                tb.ParentCategoryId = AC.ParentCategoryId;

                db.Categories.Add(tb);
                return Convert.ToBoolean(db.SaveChanges());
            }
        }
        public bool DeleteCategory(int CategoryId)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                    db.Categories.Remove(GetCategoryById(CategoryId));
                    return Convert.ToBoolean(db.SaveChanges());
            }
        }
        public bool EditeCategory(int CateId , string CName)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var EC = db.Categories.Where(a => a.Id == CateId).FirstOrDefault();
                EC.CategoryName = CName;
                EC.ParentCategoryId = 1;
                return Convert.ToBoolean(db.SaveChanges());
            }
        }

    }
}
