using DAS.BAL.Interface;
using DAS.DAL.Interface;
using DAS.Domain.Responses.Author;
using DAS.Domain.Responses.Publishing;
using DAS.Domain.Resquests.Publishing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL
{
    public class PublishingService : IPublishingService
    {
        private readonly IPublishingRepository publishingRepository;

        public PublishingService(IPublishingRepository publishingRepository)
        {
            this.publishingRepository = publishingRepository;
        }

        public Task<DeletePublishingResult> Delete(int id)
        {
            return publishingRepository.Delete(id);
        }

        public Task<Publishing> Get(int id)
        {
            return publishingRepository.Get(id);
        }

        public Task<IEnumerable<Publishing>> Gets()
        {
            return publishingRepository.Gets();
        }

        public Task<SavePublishingResult> Save(SavePublishingResquest resquest)
        {
            return publishingRepository.Save(resquest);
        }

      
    }
}
