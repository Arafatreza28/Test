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
    public partial class SupplierUi : Form
    {
        SupplierManager _supplierManager = new SupplierManager();
        public SupplierUi()
        {
            InitializeComponent();
            ShowDataGridView.DataSource = _supplierManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();

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

            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;

            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Can not be Empty!!!");
                return;

            }

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            supplier.Code = codeTextBox.Text;
            supplier.Name = nameTextBox.Text;
            supplier.Address = addressTextBox.Text;
            supplier.Email = emailTextBox.Text;
            supplier.Contact = contactTextBox.Text;
            supplier.ContactPerson = contactpersonTextBox.Text;

            //Check UNIQUE

            if (_supplierManager.IsCodeExists(supplier))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists!");
                return;
            }

            if (_supplierManager.IsContactExists(supplier))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exists!");
                return;
            }

            if (_supplierManager.IsEmailExists(supplier))
            {
                MessageBox.Show(emailTextBox.Text + " Already Exists!");
                return;
            }


            bool isAdded = _supplierManager.Add(supplier);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else

            {
                MessageBox.Show("Not Saved");
            }

            ShowDataGridView.DataSource = _supplierManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ShowDataGridView.DataSource = _supplierManager.Search(searchTextBox.Text);
        }
    }
}
