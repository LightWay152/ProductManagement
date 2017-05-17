using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class frmProduct : Form
    {
        public static List<Category> lstCategory = new List<Category>();
        List<Product> lstProductOfCategory = new List<Product>();
        public frmProduct()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            frmCategory frmCat = new frmCategory();
            frmCategory.isChanged = false;
            if(frmCat.ShowDialog()==DialogResult.OK)
            {
                DisplayCategoryOnCombobox();
            }
        }

        private void DisplayCategoryOnCombobox()
        {
            cboCategory.Items.Clear();
            foreach(Category cat in lstCategory)
            {
                cboCategory.Items.Add(cat);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cboCategory.SelectedIndex==-1)
            {
                MessageBox.Show("You haven't selected a category!");
                return;
            }
            Category cat = cboCategory.SelectedItem as Category;
            Product pro = new Product();
            pro.ProductID = txtProductID.Text;
            pro.ProductName = txtProductName.Text;
            pro.Price = double.Parse(txtPrice.Text);
            pro.Origin = txtOrigin.Text;
            pro.ExiryDate = dtpExpiryDate.Value;
            cat.AddProduct(pro);
            lstProductOfCategory.Add(pro);

            DisplayProductOnListBox();

            DeleteAllDetailsOfProduct();
        }
        void DeleteAllDetailsOfProduct()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtOrigin.Text = "";
            txtProductID.Focus();
        }
        void DisplayProductOnListBox()
        {
            lstProduct.Items.Clear();
            foreach(Product proOnCat in lstProductOfCategory)
                lstProduct.Items.Add(proOnCat);
        }

        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProduct.SelectedIndex == -1)
                return;
            Product pro = lstProduct.SelectedItem as Product;
            //cboCategory.SelectedItem = pro;
            cboCategory.Text = pro.CategoryOfProduct.CategoryName;
            txtProductID.Text = pro.ProductID;
            txtProductName.Text = pro.ProductName;
            txtPrice.Text = pro.Price + "";
            txtOrigin.Text = pro.Origin;
            dtpExpiryDate.Value = pro.ExiryDate;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedIndex == -1)
            {
                MessageBox.Show("You haven't choose product to delete!");
                return;
            }
            Product pro = lstProduct.SelectedItem as Product;
            DialogResult ret = MessageBox.Show(
                "Are you want to delete [" + pro.ProductName + "]?", 
                "Delete product", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                lstProductOfCategory.Remove(pro);
                DisplayProductOnListBox();
                DeleteAllDetailsOfProduct();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show(
                "Are you want to exit program?",
                "Exit program",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
