using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using DAS.Domain.Resquests.Publishing;
using DAS.Domain.Responses.Publishing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.DAL.Interface
{
  public interface IPublishingRepository
    {
        Task<IEnumerable<Publishing>> Gets();
        Task<Publishing> Get(int id);
        Task<SavePublishingResult> Save(SavePublishingResquest save);
        Task<DeletePublishingResult> Delete(int id);
    }
}
