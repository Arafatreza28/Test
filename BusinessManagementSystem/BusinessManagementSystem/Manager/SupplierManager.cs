using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Repository;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Manager
{
    class SupplierManager
    {
        SupplierRepo _supplierRepo = new SupplierRepo();

        public bool Add(Supplier supplier)
        {
            return _supplierRepo.Add(supplier);
        }

        public bool IsCodeExists(Supplier supplier)
        {
            return _supplierRepo.IsCodeExists(supplier);
        }

        public bool IsContactExists(Supplier supplier)
        {
            return _supplierRepo.IsContactExists(supplier);
        }

        public bool IsEmailExists(Supplier supplier)
        {
            return _supplierRepo.IsEmailExists(supplier);
        }

        public List<Supplier> Display()
        {
            return _supplierRepo.Display();
        }

        public List<Supplier> Search(string search)
        {
            return _supplierRepo.Search(search);
        }
    }
}
