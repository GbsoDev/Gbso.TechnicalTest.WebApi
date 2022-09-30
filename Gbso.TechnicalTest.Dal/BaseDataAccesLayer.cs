using Gbso.TechnicalTest.Cl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Gbso.TechnicalTest.Model;

namespace Gbso.TechnicalTest.Dal
{
	public partial class BaseDataAccesLayer<TEntity, TKey> : IBaseDataAccesLayer<TEntity, TKey>
		where TEntity : class, IModel<TKey>
	{
		protected readonly RootContext RootContext;

		public BaseDataAccesLayer(IServiceProvider serviceProvider)
		{
			RootContext = ActivatorUtilities.GetServiceOrCreateInstance<RootContext>(serviceProvider);
		}

		public virtual TEntity Register(TEntity entity)
		{
			RootContext.Set<TEntity>().Add(entity);
			RootContext.SaveChanges();
			return entity;
		}

		public virtual TEntity? GetById(params TKey?[]? id)
		{
			var result  = RootContext.Find<TEntity>(id);
			return result;
		}

		public virtual TEntity[] Get()
		{
			var result = RootContext.Set<TEntity>().ToArray();
			return result;
		}

		public virtual TEntity[] Where(Expression<Func<TEntity, bool>> expression)
		{
			var result = RootContext.Set<TEntity>().Where(expression).ToArray();
			return result;
		}

		public virtual TEntity? Update(TEntity entity)
		{
			var entityResult = RootContext.Find<TEntity>(entity.Id);
			if (entityResult == null) return null;
			RootContext.Entry(entity).CurrentValues.SetValues(entity);
			return entityResult;
		}

		public virtual TEntity? Update(TEntity entity, Expression<Func<TEntity, object>> @object)
		{
			var entityResult = RootContext.Find<TEntity>(entity.Id);
			var objectResult = @object?.Compile()?.Invoke(entity);
			if (entityResult == null) return null;
			if (objectResult != null)
				RootContext.Entry(entity).CurrentValues.SetValues(objectResult);
			return entityResult;
		}

		public virtual void Remove(TEntity entity)
		{
			RootContext.Remove(entity);
		}

		public virtual void Remove(TKey id)
		{
			var entityResult = RootContext.Find<TEntity>(id);
			if (entityResult != null)
			{
				Remove(entityResult);
			}
		}
	}
}
