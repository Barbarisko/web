using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
	public class Repository<TEntity>  /*IRepository<TEntity> where TEntity : IIDentity*/
	{
	//	private readonly DbSet<TEntity> contextDbSet;
	//	private readonly EFDBContext context;

	//	public Repository(EFDBContext context)
	//	{
	//		contextDbSet = context.Set<TEntity>();
	//		this.context = context;
	//	}

	//	public IEnumerable<TEntity> GetAll()
	//	{
	//		return contextDbSet.ToList();
	//	}

	//	public void Add(TEntity entity)
	//	{
	//		contextDbSet.Add(entity);
	//	}

	//	public TEntity Get(int id)
	//	{
	//		return contextDbSet.Find(id);
	//	}

	//	public void Update(TEntity entity)
	//	{
	//		contextDbSet.Attach(entity);
	//		context.Entry(entity).State = EntityState.Modified;
	//	}

	//	public void Delete(int id)
	//	{
	//		var tEntity = contextDbSet.Find(id);
	//		if (tEntity != null)
	//		{
	//			contextDbSet.Remove(tEntity);
	//		}
	//	}
	}
}
