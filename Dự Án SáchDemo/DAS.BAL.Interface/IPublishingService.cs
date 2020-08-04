using DAS.Domain.Responses.Author;
using DAS.Domain.Responses.Publishing;
using DAS.Domain.Resquests.Publishing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.BAL.Interface
{
  public  interface IPublishingService
    {
        Task<IEnumerable<Publishing>> Gets();
        Task<Publishing> Get(int id);
        Task<SavePublishingResult> Save(SavePublishingResquest resquest);
        Task<DeletePublishingResult> Delete(int id);
    }
}
