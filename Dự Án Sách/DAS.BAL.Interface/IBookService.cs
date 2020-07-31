using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL.Interface
{
   public interface IBookService
    {
        Task<IEnumerable<Bookss>> Gets();
        Task<Bookss> Get(int id);
        Task<SaveBooksRequest> Save(SaveBooksResult save);
        Task<DeleteBooksResult> Delete(int id);
    }
}
