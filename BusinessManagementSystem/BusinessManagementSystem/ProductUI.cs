using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessManagementSystem.Model;
using BusinessManagementSystem.Manager;

namespace BusinessManagementSystem
{
    public partial class ProductUI : Form
    {
        ProductManager _ProductManager = new ProductManager();

        Product product = new Product();
       

        public ProductUI()
        {
            InitializeComponent();
            ShowDataGridView.DataSource = _ProductManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Set Code as Mandatory
            if (String.IsNullOrEmpty(categoryComboBox.Text))
            {
                MessageBox.Show("Category should not be empty!");
                return;
            }

            //Set Code as Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code should not be empty!");
                return;
            }

            //Set Name as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty!");
                return;
            }

            //Set ReOrderLevel as Mandatory
            if (String.IsNullOrEmpty(reorderlevelTextBox.Text))
            {
                MessageBox.Show("ReOrderLevel should not be empty!");
                return;
            }

            //Set Description as Mandatory
            if (String.IsNullOrEmpty(descriptionTextBox.Text))
            {
                MessageBox.Show("Description should not be empty!");
                return;
            }

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }
            

            product.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            product.Code = codeTextBox.Text;
            product.Name = nameTextBox.Text;
            product.ReorderLevel = reorderlevelTextBox.Text;
            product.Description = descriptionTextBox.Text;

            //Check UNIQUE
            if (_ProductManager.IsCodeExists(product))
            {
                MessageBox.Show(codeTextBox.Text + " already exists!");
            }
            if (_ProductManager.IsNameExists(product))
            {
                MessageBox.Show(codeTextBox.Text + " already exists!");
            }

            

            bool added = _ProductManager.Add(product);

            if (added)
            {
                MessageBox.Show("Products inserted successfully!");
                codeTextBox.Clear();
                nameTextBox.Clear();
                reorderlevelTextBox.Clear();
                descriptionTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Not inserted");
            }
                

            //Display();
            ShowDataGridView.DataSource = _ProductManager.Display();

            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ShowDataGridView.DataSource = _ProductManager.Search(searchTextBox.Text);
        }

        private void ProductUI_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _ProductManager.ProductCombo();
        }
    }
}
