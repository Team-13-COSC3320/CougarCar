using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTutorial.Models
{
    public class Product
    {
        public enum Product_Category
        {
            Cat1, Cat2, Cate3, Cat4, Cat5
        }
        public int ID { get; set; }
        public string P_Name { get; set; }
        public string P_Category { get; set; }
        public Byte[]? P_Image { get; set; }
        public int? P_Price { get; set; }
        public string? P_Description { get; set; }

    }
}
