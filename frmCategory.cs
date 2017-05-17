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
    public partial class frmCategory : Form
    {
        public static bool isChanged = false;
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.CategoryID = txtCategoryID.Text;
            cat.CategoryName = txtCategoryName.Text;
            frmProduct.lstCategory.Add(cat);
            DisplayCategoryOnListBox();

            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            txtCategoryID.Focus();
            isChanged = true;
        }
        void DisplayCategoryOnListBox()
        {
            lstCategory.Items.Clear();
            foreach(Category cat in frmProduct.lstCategory)
            {
                lstCategory.Items.Add(cat);
            }
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstCategory.SelectedIndex!=-1)
            {
                Category cat = lstCategory.SelectedItem as Category;
                txtCategoryID.Text = cat.CategoryID;
                txtCategoryName.Text = cat.CategoryName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedIndex != -1)
            {
                Category cat = lstCategory.SelectedItem as Category;
                lstCategory.Items.Remove(cat);
                isChanged = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (isChanged == true)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            DisplayCategoryOnListBox();
        }
    }
}
