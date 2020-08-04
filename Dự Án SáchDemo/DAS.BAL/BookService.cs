using DAS.BAL.Interface;
using DAS.DAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Responses.Books;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAS.BAL
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository booksRepository;

        public BookService(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public async Task<Bookss> Get(int id)
        {
            return await booksRepository.Get(id);
        }

        public async Task<IEnumerable<Bookss>> Gets(int id)
        {
            return await booksRepository.Gets(id);
        }

        public async Task<SaveBooksResult> Save(SaveBooksRequest save)
        {
            return await booksRepository.Save(save);
        }

       public async Task<DeleteBooksResult> Delete(int id)
        {
            return await booksRepository.Delete(id);
        }
    }
}
