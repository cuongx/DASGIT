using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.DAL.Interface
{
   public interface ICategoryRepository
    {
       Task<IEnumerable<Category>> Gets();      
        Task<Category> Get(int id);
        Task<SaveCategoryResult> Save(Category category);
        Task<DeleteCategoryResult> Delete(int id);
    }
}
