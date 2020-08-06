using DAS.Domain.Responses;
using DAS.Domain.Responses.Books;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL.Interface
{
   public interface IBookService
    {
        Task<IEnumerable<Bookss>> Gets(int id);
        Task<Bookss> Get(int id);
        Task<SaveBooksResult> Save(SaveBooksRequest save);
        Task<DeleteBooksResult> Delete(int id);
    }
}
