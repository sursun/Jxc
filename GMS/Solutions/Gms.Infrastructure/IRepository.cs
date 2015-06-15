using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate.Contracts.Repositories;

namespace Gms.Infrastructure
{


    public interface IRepositoryBase<T> : INHibernateRepository<T>
    {
        RecordList<T> GetList<TQ>(TQ query) where TQ : QueryBase;
        IList<T> GetAll<TQ>(TQ query) where TQ : QueryBase;
        int GetCount<TQ>(TQ query) where TQ : QueryBase;
        //T SaveOrUpdate(T entity);
        //void Delete(int id);
        //void Delete(T entity);

        IQueryable<T> Query { get; }
    }

}
