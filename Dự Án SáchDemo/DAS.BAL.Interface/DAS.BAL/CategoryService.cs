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

        public async Task<DeleteCategoryResult> Delete(int id)
        {
            return await categoryRepository.Delete(id);
        }

        public async Task<Category> Get(int id)
        {
            return await categoryRepository.Get(id);
        }

        public async Task<IEnumerable<Category>> Gets()
        {
            return await categoryRepository.Gets();
        }

        public async Task<SaveCategoryResult> Save(Category category)
        {
            return await categoryRepository.Save(category);
        }
    }
}
