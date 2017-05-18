using DDDTest.Core;
using DDDTest.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DDDTest.Domain;
using System.Runtime.Caching;

namespace DDDTest.Data
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity,IAggregateRoot
    {
        string typeName = typeof(T).Name;
        private ObjectCache cacheDB = MemoryCache.Default;
        private CacheItemPolicy policy = new CacheItemPolicy();
        private static readonly object syncObject = new object();

        public RepositoryBase()
        {
            policy.AbsoluteExpiration.Add(new TimeSpan(-12, 0, 0));
        }

        private List<T> TableRS
        {
            get
            {
                return (List<T>)this.cacheDB[typeName];
            }
        }
        public List<T> RS
        {
            get
            {
                List<T> rs = this.TableRS;
                if (this.TableRS == null)
                {
                    lock (syncObject) 
                    { 
                        if(this.TableRS == null)
                        { 
                            rs = new List<T>();
                            this.cacheDB.Add(typeName, rs, policy);
                        }
                    }
                }
                return rs;
            }
        }

        public T GetById(Guid id)
        {
            return this.RS.FirstOrDefault(item => item.Id == id);
        }

        public bool Insert(T entity)
        {
            if (this.RS.Where(item => item.Id == entity.Id).Count() == 0)
            {
                this.RS.Add(entity);
                return true;
            }
            return false;
        }

        public bool Update(T entity)
        {
            if (this.RS.Where(item => item.Id == entity.Id).Count() == 1)
            {
                if(this.Delete(entity))
                { 
                    this.Insert(entity);
                    return true;
                }
            }
            return false;
        }

        public bool Delete(T entity)
        {
            if (this.RS.Where(item => item.Id == entity.Id).Count() == 1)
            {
                var obj = this.RS.First(item => item.Id == entity.Id);
                if (obj != null)
                { 
                   this.RS.Remove(obj);
                   return true;
                }
            }
            return false;
        }
    }
}
