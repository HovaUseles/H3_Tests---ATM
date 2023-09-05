using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.Repositories
{
    /// <summary>
    /// Responsible for manipulating data in the data source
    /// </summary>
    /// <typeparam name="T">The model the repository is responsible for</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Get a specific Model from an identifier
        /// </summary>
        /// <param name="id">The identifier for the model</param>
        /// <returns>The Model</returns>
        public Task<T> GetById(object id);

        /// <summary>
        /// Get all models from the data source
        /// </summary>
        /// <returns>All the models</returns>
        public Task<T[]> GetAll();

        /// <summary>
        /// Add the model to the data source
        /// </summary>
        /// <param name="model">The model to be added</param>
        /// <returns>The added model with an identifier</returns>
        public Task<T> Add(T model);

        /// <summary>
        /// Update a model in the data source
        /// </summary>
        /// <param name="model">The model to be updated</param>
        /// <returns>The updated model</returns>
        public Task<T> Update(T model);

        /// <summary>
        /// Delete a model in the data source
        /// </summary>
        /// <param name="model">The Model to be deleted</param>
        /// <returns>The deleted model</returns>
        public Task<T> Delete(T model);
    }
}