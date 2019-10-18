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
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
            ShowDataGridView.DataSource = _customerManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ShowDataGridView.DataSource = _customerManager.Search(searchTextBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

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
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(loyalityTextBox.Text))
            {
                MessageBox.Show("Loyality Can not be Empty!!!");
                return;
            }

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            customer.Code = codeTextBox.Text;
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Contact = contactTextBox.Text;
            customer.LoyalityPoint = Convert.ToInt32(loyalityTextBox.Text);

            //Check UNIQUE

            if (_customerManager.IsCodeExists(customer))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists!");
                return;
            }

            if (_customerManager.IsNameExists(customer))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }
            if (_customerManager.IsContactExists(customer))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exists!");
                return;
            }

            if (_customerManager.IsEmailExists(customer))
            {
                MessageBox.Show(emailTextBox.Text + " Already Exists!");
                return;
            }







            bool isAdded = _customerManager.Add(customer);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else

            {
                MessageBox.Show("Not Saved");
            }

            ShowDataGridView.DataSource = _customerManager.Display();
        }
    }
}
