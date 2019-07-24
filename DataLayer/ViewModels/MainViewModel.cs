using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DataLayer.ViewModels
{
    public class MainViewModel
    {
        public List<CategoryViewModel> getCategory { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Model_Year { get; set; }
        public int Price { get; set; }
        public short Stock { get; set; }
        public int Catid { get; set; }
        public List<string> Img { get; set; }

        //public string Img { get; set; }

    }
}
