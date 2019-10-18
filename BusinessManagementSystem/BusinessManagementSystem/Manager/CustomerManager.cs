using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Model;
using BusinessManagementSystem.Repository;

namespace BusinessManagementSystem.Manager
{
    class CustomerManager
    {
        CustomerRepo _customerRepo = new CustomerRepo();

        public bool Add(Customer customer)
        {

            return _customerRepo.Add(customer);

        }

        public bool IsNameExists(Customer customer)
        {

            return _customerRepo.IsNameExists(customer);
        }

        public bool IsCodeExists(Customer customer)
        {

            return _customerRepo.IsCodeExists(customer);

        }
        public bool IsContactExists(Customer customer)
        {

            return _customerRepo.IsContactExists(customer);

        }
        public bool IsEmailExists(Customer customer)
        {

            return _customerRepo.IsEmailExists(customer);

        }

        public List<Customer> Display()
        {
            return _customerRepo.Display();
        }

        public List<Customer> Search(string search)
        {
            return _customerRepo.Search(search);
        }

    }
}
