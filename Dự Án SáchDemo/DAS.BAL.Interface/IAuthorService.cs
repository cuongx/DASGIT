using DAS.Domain.Responses.Author;
using DAS.Domain.Resquests.Author;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL.Interface
{
   public interface IAuthorService
    {
        Task<IEnumerable<Author>> Gets();
        Task<Author> Get(int id);
        Task<SaveAuthorResult> Save(SaveAuthorResquest resquest);
        Task<DeleteAuthorResult> Delete(int id);
    }
}
