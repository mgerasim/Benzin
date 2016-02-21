using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using Benzin.Models;
using Benzin.Common;

namespace Benzin.Repositories
{
    public class EmpRepository : IRepository<Emp>
        {
            #region IRepository<Measurement> Members

            void IRepository<Emp>.Save(Emp entity)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                }
            }

            void IRepository<Emp>.Update(Emp entity)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                }
            }

            void IRepository<Emp>.Delete(Emp entity)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                }
            }

            Emp IRepository<Emp>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Emp>().Add(Restrictions.Eq("ID", id)).UniqueResult<Emp>();
            }

            IList<Emp> IRepository<Emp>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Emp));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Emp>();
                }
            }

            #endregion
        }
    
}
