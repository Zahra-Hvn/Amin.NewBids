using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*-----------*/
using DataLayer;
using DataLayer.Irepository;
using DataLayer.ViewModels;
using System.Transactions;
using static DataLayer.ViewModels.ProductViewModel;

namespace DataLayer.Repository
{
    public class ProductRepository : Iproduct
    {
        public ProductRepository()
        {
        }
        public bool Addproduct(MainViewModel model)
        {
            var result = false;
            //using (TransactionScope scope = new TransactionScope())
            //{
                using (QuiBidsEntities1 db = new QuiBidsEntities1())
                {
                    Product product = new Product
                    {
                        Brand = model.Brand,
                        CatId = model.Catid,
                        Model_Year = model.Model_Year,
                        Name = model.Name,
                        Price = model.Price,
                        Stock = model.Stock
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                    List<Image> listImage = new List<Image>();
                    foreach (var item in model.Img)
                    {
                        Image listImg = new Image
                        {
                            ImageURL = item,
                            ProductId = product.Id

                        };
                        db.Images.Add(listImg);
                       result= db.SaveChanges() == 1 ? true : false;

                        //listImage.Add(listImg);
                    }
                    //db.Image.AddRange(listImage);
                    //var d = db.SaveChanges();
                    //return db.SaveChanges() == 1 ? true : false;
                //}
                //scope.Complete();
            }
            return result;
        }
        public Product GetProductById(int ProductId)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Products.Where(a => a.Id == ProductId).FirstOrDefault();
            }
        }
        public bool DeleteProduct(int ProductId)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var s = GetProductById(ProductId);
                db.Products.Remove(GetProductById(ProductId));
                return Convert.ToBoolean(db.SaveChanges());
            }
        }
        public bool UpDateproduct(ProductViewModel UDP)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var Model = GetProductById(UDP.Id);
                if (Model == null)
                {
                    return false;

                }
                Model.Brand = UDP.Brand;
                Model.Name = UDP.Name;
                Model.Price = UDP.Price;
                Model.Image = UDP.Img;
                Model.Model_Year = UDP.Model_Year;
                Model.Stock = UDP.Stock;
                db.Entry(Model).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(db.SaveChanges());
            }
        }
        public List<Product> GetAllProduct()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Products.ToList();
            }
        }
        public List<ProductForDropDown> GetProForDop()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Products.Select(x => new ProductForDropDown
                {
                    Id=x.Id,
                    Name=x.Name
                }).ToList();
            }
        }

    }

}