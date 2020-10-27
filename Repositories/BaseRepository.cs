using MongoDB.Bson;
using MongoDB.Driver;
using RepositoryUnitOfWorkNoSql.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack;


namespace RepositoryUnitOfWorkNoSql.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        protected void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id)));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public virtual void Remove(string id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id))));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}