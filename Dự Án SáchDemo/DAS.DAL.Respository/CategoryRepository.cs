using Dapper;
using DAS.DAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAS.DAL
{
    public class CategoryRepository :BaseRepository, ICategoryRepository
    {
        public async Task<DeleteCategoryResult> Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"CategoryId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteCategoryResult>(cnn: con, 
                                                                           param: parameters, 
                                                                           sql: "sp_DeleteCategory",
                                                                           commandType: CommandType.StoredProcedure);
        }

        public async Task<Category> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"CategoryId", id);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Category>(cnn: con,
                                                           param: parameters, 
                                                           sql: "sp_GetCategory", 
                                                           commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Category>> Gets()
        {
            return await SqlMapper.QueryAsync<Category>(cnn: con, 
                                                   sql: "sp_GetCategorys", 
                                                   commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveCategoryResult> Save(Category category)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"CategoryId", category.CategoryId);
                parameters.Add(@"CategoryName", category.CategoryName);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCategoryResult>(
                                         cnn: con, param: parameters, 
                                         sql: "sp_SaveCategory", 
                                         commandType: CommandType.StoredProcedure);
            }catch(Exception e)
            {
                return new SaveCategoryResult()
                {
                    CategoryId = 0,
                    Message = "Something went wrong, please try again"
                  
            };
            
        }
        }
    }
}
