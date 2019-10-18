using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessManagementSystem.Manager;
using BusinessManagementSystem.Model;


namespace BusinessManagementSystem
{
    public partial class CategoryUI : Form
    {
        CategoryManager _categoryManager = new CategoryManager();

        public CategoryUI()
        {
            
            InitializeComponent();
            ShowDataGridView.DataSource = _categoryManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            //Set as Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            category.Code = codeTextBox.Text;
            category.Name = nameTextBox.Text;

            //Check UNIQUE

            if (_categoryManager.IsCodeExists(category))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists!");
                return;
            }

            if (_categoryManager.IsNameExists(category))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }

           


            


            bool isAdded = _categoryManager.Add(category);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else

            {
                MessageBox.Show("Not Saved");
            }

            ShowDataGridView.DataSource = _categoryManager.Display();
        }

        

        private void searchButton_Click(object sender, EventArgs e)
        {
            ShowDataGridView.DataSource = _categoryManager.Search(searchTextBox.Text);
        }

        private void ShowDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDataGridView.DataSource = _categoryManager.Display();
        }
    }
}
