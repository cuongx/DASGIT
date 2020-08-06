using Dapper;
using DAS.DAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Responses.Author;
using DAS.Domain.Resquests.Author;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAS.DAL
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public async Task<DeleteAuthorResult> Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"AuthorId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteAuthorResult>(cnn: con,
                                                                           param: parameters,
                                                                           sql: "sp_DeleteAuthor",
                                                                           commandType: CommandType.StoredProcedure);
        }

        public async Task<Author> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"AuthorId", id);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Author>(cnn: con,
                                                           param: parameters,
                                                           sql: "sp_GetAuthor",
                                                           commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Author>> Gets()
        {
            return await SqlMapper.QueryAsync<Author>(cnn: con,
                                                   sql: "sp_GetAuthors",
                                                   commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveAuthorResult> Save(SaveAuthorResquest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"AuthorId", request.AuthorId);
                parameters.Add(@"AuthorName", request.AuthorName);
                parameters.Add(@"AvatarPath", request.AvatarPath);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveAuthorResult>(
                                         cnn: con, param: parameters,
                                         sql: "sp_SaveAuthor",
                                         commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                return new SaveAuthorResult()
                {
                    AuthorId = 0,
                    Message = "Something went wrong, please try again"

                };

            }
        }
    }
}
