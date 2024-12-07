
using System.Linq.Expressions;

namespace BusTicket.Domain.Interfaces
{
    public interface IRepository<TEntity, TData, TType> where TEntity : class 
    {
        
        ///<summary>
        /// Save Entity
        /// </summary> 
        /// <param name="entity"></param>
        Task<TData> Add(TEntity entity);


        ///<summary>
        /// Update Entity
        /// </summary> 
        /// <param name="entity"></param>
        Task<TData> Update(TEntity entity);


        ///<summary>
        /// Remove Entity
        /// </summary> 
        /// <param name="entity"></param>
        Task<TData> Remove(TEntity entity);


        ///<summary>
        /// Get All Data
        /// </summary> 
        /// <returns></returns>
        Task<TData> GetAll();

        ///<summary>
        /// Get Entity By ID
        /// </summary> 
        /// <param name="Id"></param>
        ///<returns></returns>
        Task<TData> GetEntityBy(TType Id);

        ///<summary>
        /// Get All Data
        /// </summary> 
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TData> Exists(Expression<Func<TEntity, bool>> filter);
    }
    
}
