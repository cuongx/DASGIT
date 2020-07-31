using Dapper;
using DAS.DAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.DAL
{
    
    public class BooksRepository :BaseRepository, IBooksRepository
    {

        public async Task<DeleteBooksResult> Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"Id", id);
            return await SqlMapper.QueryFirstAsync<DeleteBooksResult>(cnn: con, param: parameters, sql: "sp_DeleteBookss",commandType:CommandType.StoredProcedure);
        }

        public async Task<Bookss> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"Id", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<Bookss>(cnn: con, param: parameters, sql: "sp_GetBooksById", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Bookss>> Gets()
        {
            return await SqlMapper.QueryAsync<Bookss>(cnn: con, sql: "sp_GetBookss", commandType: CommandType.StoredProcedure);
            
        }

        public async Task<SaveBooksRequest> Save(SaveBooksResult save)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", save.Id);
                parameters.Add(@"BookName", save.BookName);
                parameters.Add(@"Avatar", save.Avatar);
                parameters.Add(@"AuthorId", save.AuthorId);
                parameters.Add(@"CategoryId", save.CategoryId);
                parameters.Add(@"Updateday", DateTime.Parse(save.Updateday));
                parameters.Add(@"PublishingId", save.PublishingId);
                parameters.Add(@"Description", save.Description);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveBooksRequest>(cnn: con, sql:"sp_SaveBookss",param:parameters , commandType: CommandType.StoredProcedure));
            }
            catch(Exception e)
            {
                return new SaveBooksRequest()
                {
                    Id = 0,
                    Message = "Something went wrong, please try again"

                };
                 
            }
        }
    }
}
