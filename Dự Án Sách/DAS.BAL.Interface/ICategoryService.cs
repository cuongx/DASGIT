using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL.Interface
{
  public  interface ICategoryService
    {
        Task<IEnumerable<Category>> Gets();
        Task<Category> Get(int id);
        Task<SaveCategoryResult> Save(Category category);
        Task<DeleteCategoryResult> Delete(int id);
    }
}
