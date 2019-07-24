using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ViewModels;
using DataLayer;


namespace DataLayer.Irepository
{
    public interface ICategoryRepo
    {
        List<Category> GetCategorise();
        List<CategoryViewModel> GetCategoryViewModel();
        bool AddCategory(CategoryViewModel AC);
        Category GetCategoryById(int CateId);
        bool DeleteCategory(int CategoryId);
        bool EditeCategory(int CateId , string CName);

    }
}
