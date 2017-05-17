using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    public class Category
    {
        private Dictionary<string, Product> lstProduct = 
            new Dictionary<string, Product>();
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public void AddProduct(Product pro)
        {
            if (this.lstProduct.ContainsKey(pro.ProductID) == false)
            {
                this.lstProduct.Add(pro.ProductID, pro);
                pro.CategoryOfProduct = this;
            }
        }
        public Dictionary<string,Product> Products
        {
            get { return this.lstProduct; }
            set { this.lstProduct = value; }
        }
        public override string ToString()
        {
            return this.CategoryName;
        }
    }
}
