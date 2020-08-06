using Dapper;
using DAS.DAL.Interface;
using DAS.Domain.Responses.Publishing;
using DAS.Domain.Resquests.Publishing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAS.DAL
{
  public class PublishingRepository:BaseRepository,IPublishingRepository
    {
        public async Task<DeletePublishingResult> Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"PublishingId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeletePublishingResult>(cnn: con,
                                                                           param: parameters,
                                                                           sql: "sp_DeletePublishing",
                                                                           commandType: CommandType.StoredProcedure);
        }

        public async Task<Publishing> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"PublishingId", id);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Publishing>(cnn: con,
                                                           param: parameters,
                                                           sql: "sp_GetPublishing",
                                                           commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Publishing>> Gets()
        {
            return await SqlMapper.QueryAsync<Publishing>(cnn: con,
                                                   sql: "sp_GetPublishings",
                                                   commandType: CommandType.StoredProcedure);
        }

        public async Task<SavePublishingResult> Save(SavePublishingResquest resquest)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"PublishingId", resquest.PublishingId);
                parameters.Add(@"PublishingName", resquest.PublishingName);
                return await SqlMapper.QueryFirstOrDefaultAsync<SavePublishingResult>(
                                         cnn: con, param: parameters,
                                         sql: "sp_SavePublishing",
                                         commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                return new SavePublishingResult()
                {
                    PublishingId = 0,
                    Message = "Something went wrong, please try again"

                };

            }
        }
    }
}
