using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using DataLayer.ViewModels;
using DataLayer;



namespace DataLayer.Irepository
{
    public interface Iproduct
    {

        bool Addproduct(MainViewModel AP);
        bool UpDateproduct(ProductViewModel UDP);
        bool DeleteProduct(int ProductId);
        List<Product> GetAllProduct();
        Product GetProductById(int Id);


    }
}