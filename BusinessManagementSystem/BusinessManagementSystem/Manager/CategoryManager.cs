using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Repository;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Manager
{
    class CategoryManager
    {
        CategoryRepo _categoryRepository = new CategoryRepo();

        public bool Add(Category category)
        {

            return _categoryRepository.Add(category);

        }

        public bool IsNameExists(Category category)
        {

            return _categoryRepository.IsNameExists(category);
        }

        public bool IsCodeExists(Category category)
        {

            return _categoryRepository.IsCodeExists(category);

        }

        public List<Category> Display()
        {
            return _categoryRepository.Display();
        }

        public List<Category> Search(string search)
        {
            return _categoryRepository.Search(search);
        }
    }
}
