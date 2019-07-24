using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Model_Year { get; set; }
        public int Price { get; set; }
        public string Img  { get; set; }
        public short Stock { get; set; }

        public class ProductForDropDown
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}