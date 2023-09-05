using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.Repositories
{
    internal class MongoGenericRepository<T> : IGenericRepository<T>
        where T : Entity
    {

        public MongoGenericRepository()
        {
            DB.InitAsync("ATM", "localhost", 27017);
        }

        public async Task<T> Add(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await model.SaveAsync();
            return model; // With new id
        }

        public async Task<T> Delete(T model)
        {
            await DB.DeleteAsync<T>(model.ID);
            return model;
        }

        public async Task<T[]> GetAll()
        {
            List<T> entityList = await DB.Find<T>().ManyAsync(_ => true);
            return entityList.ToArray();
        }

        public async Task<T> GetById(object id)
        {
            return await DB.Find<T>().OneAsync((string)id);
        }

        public async Task<T> Update(T modelChanges)
        {
            return await DB.UpdateAndGet<T>()
                    .MatchID(modelChanges.ID)
                    .ModifyWith(modelChanges)
                    .ExecuteAsync();
        }
    }
}
