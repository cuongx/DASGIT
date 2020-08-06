using DAS.BAL.Interface;
using DAS.DAL.Interface;
using DAS.Domain.Responses.Author;
using DAS.Domain.Resquests.Author;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public  AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
  
        public async Task<Author> Get(int id)
        {
            return await authorRepository.Get(id);
        }

        public async Task<IEnumerable<Author>> Gets()
        {
            return await authorRepository.Gets();
        }

        public async Task<SaveAuthorResult> Save(SaveAuthorResquest save)
        {
            return await authorRepository.Save(save);
        }

        public async Task<DeleteAuthorResult> Delete(int id)
        {
            return await authorRepository.Delete(id);
        }
    }
}
