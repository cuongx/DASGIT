using DAS.BAL.Interface;
using DAS.DAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<DeleteCategoryResult> Delete(int id)
        {
            return categoryRepository.Delete(id);
        }

        public Task<Category> Get(int id)
        {
            return categoryRepository.Get(id);
        }

        public Task<IEnumerable<Category>> Gets()
        {
            return categoryRepository.Gets();
        }

        public Task<SaveCategoryResult> Save(Category category)
        {
            return categoryRepository.Save(category);
        }
    }
}
