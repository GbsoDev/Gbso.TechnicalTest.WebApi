using Gbso.TechnicalTest.Cl;
using Gbso.TechnicalTest.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Gbso.TechnicalTest.Dal
{
	public interface IBaseDataAccesLayer<TEntity, TKey>
		where TEntity : class, IModel<TKey>
	{
		TEntity Register(TEntity entity);
		TEntity? GetById(params TKey?[]? id);
		TEntity[] Get();
		TEntity[] Where(Expression<Func<TEntity, bool>> expression);
		/// <summary>
		/// Update all properies from entity
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		TEntity? Update(TEntity entity);
		/// <summary>
		/// Update explicit properies of anonymus type
		/// </summary>
		/// <param name="id">Entity id key</param>
		/// <param name="object">Properties object</param>
		/// <returns></returns>
		TEntity? Update(TEntity entity, Expression<Func<TEntity, object>> @object);
		void Remove(TEntity entity);
		void Remove(TKey id);
	}
}
