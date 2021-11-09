using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
   public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        /// <summary>
        /// Veri kaynağına entity ekler
        /// </summary>
        /// <param name="entity">Eklenecek entity</param>
        void Add(T entity);

        /// <summary>  
        /// Veri kaynağından, entity'i şarta göre getirir.
        /// </summary>
        /// <param name=""></param>
        /// <returns>Bir tek bir entity döndürür.</returns>
        T Get(Expression<Func<T, bool>> filter);

    }
}
