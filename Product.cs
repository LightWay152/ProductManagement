using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Origin { get; set; }
        public DateTime ExiryDate { get; set; }
        public Category CategoryOfProduct { get; set; }
        public override string ToString()
        {
            return this.ProductName;
        }
    }
}
