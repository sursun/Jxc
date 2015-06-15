using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using NHibernate;
using NHibernate.Linq;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate;

namespace Gms.Infrastructure
{
    public class RepositoryBase<T> : NHibernateRepository<T>, IRepositoryBase<T> where T : EntityWithTypedId<int>
    {
        protected override NHibernate.ISession Session
        {
            get
            {
                string factoryKey = SessionFactoryAttribute.GetKeyFrom(this);
                return NHibernateSession.CurrentFor(factoryKey);
            }
        }

        public virtual RecordList<T> GetList<TQ>(TQ query) where TQ : QueryBase
        {
            return GetList(ParseQuery(query), query.PageIndex, query.PageSize);
        }

        public virtual IList<T> GetAll<TQ>(TQ query) where TQ : QueryBase
        {
            return ParseQuery(query).ToList();
        }

        public virtual int GetCount<TQ>(TQ query) where TQ : QueryBase
        {
            return LoadQuery(query).Count();
        }

        protected virtual RecordList<TS> GetList<TS>(IQueryable<TS> query, int pageindex, int pagesize)
        {

            var records = new RecordList<TS> { PageIndex = pageindex, PageSize = pagesize, RecordCount = query.Count() };
            IList<TS> data;
            if (records.RecordCount == 0)
            {
                data = new TS[0];
            }
            else
            {
                do
                {
                    data = records.StartIndex > 0 ? query.Skip(records.StartIndex).Take(pagesize).ToList() : query.Take(pagesize).ToList();
                    if (data.Count == 0 && records.PageIndex > 1)
                    {
                        records.PageIndex--;
                    }
                } while (data.Count == 0 && records.PageIndex > 1);
            }
            records.Data = data;
            return records;
        }

        protected virtual RecordList<TS> GetList<TS>(IQueryable<TS> query, int? pageindex, int? pagesize)
        {
            if (pageindex.HasValue && pagesize.HasValue)
            {
                return GetList(query, pageindex.Value, pagesize.Value);
            }

            var list = new RecordList<TS>(query.ToList());
            list.RecordCount = list.Count;
            return list;
        }

        protected virtual IQueryable<T> ParseQuery<TQ>(TQ query)
            where TQ : QueryBase
        {
            var q = LoadQuery(query);
            q = query.OrderBy.NotNullAndEmpty()
                  ? q.OrderUsingSortExpression(query.OrderBy)
                  : q.OrderByDescending(c => c.Id);

            return q;
        }

        protected virtual IQueryable<T> LoadQuery<TQ>(TQ query) where TQ : QueryBase
        {
            return LoadQuery<T, TQ>(query);
        }
        protected virtual IQueryable<TS> LoadQuery<TS, TQ>(TQ query) where TQ : QueryBase
        {
            return Session.Query<TS>();
        }

        public virtual IQueryable<T> Query { get {  return Session.Query<T>();}
        }


        //public virtual T SaveOrUpdate(T entity)
        //{
        //    Session.SaveOrUpdate(entity);

        //    return entity;
        //}

        //public virtual void Delete(int id)
        //{
        //    var tablename = typeof(T).FullName;
        //    Session.Delete(
        //        string.Format("from  {0}  where Id=? ", tablename)
        //               , id
        //               , NHibernateUtil.Int32
        //           );
        //}

        //public virtual void Delete(T entity)
        //{
        //    Session.Delete(entity);
        //}

    }


}
