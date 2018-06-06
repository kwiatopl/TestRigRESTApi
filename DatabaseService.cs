using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestRESTApi
{
    public class DatabaseService
    {
        private readonly INHibernateSessionManager sessionManager;
        protected readonly ISession session;

        public DatabaseService(INHibernateSessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
            this.session = sessionManager.GetCurrentSession();
        }

        public void UpdateCollection<T>(ICollection<T> collectionToUpdate) where T : class
        {
            if (collectionToUpdate == null || collectionToUpdate.Count == 0)
            {
                return;
            }

            using (var transaction = this.session.BeginTransaction())
            {
                foreach (var itemToSave in collectionToUpdate)
                {
                    this.session.Update(itemToSave);
                }
                transaction.Commit();
            }
        }

        public void SaveCollection<T>(ICollection<T> collectionToSave) where T : class
        {
            if (collectionToSave == null || collectionToSave.Count == 0)
            {
                return;
            }

            using (var transaction = this.session.BeginTransaction())
            {
                foreach (var itemToSave in collectionToSave)
                {
                    this.session.Save(itemToSave);
                }
                transaction.Commit();
            }
        }

        public void Update<T>(T item) where T : class
        {
            using (var nhibernateTrnasaction = this.session.BeginTransaction())
            {
                this.session.SaveOrUpdate(item);
                nhibernateTrnasaction.Commit();
            }
        }

        public IEnumerable<T> ExecuteProcedure<T>(string name, Dictionary<string, object> arguments = null) where T : class
        {
            NHibernate.IQuery query = session.CreateSQLQuery(string.Format("exec {0}", name));

            if (arguments != null)
            {
                foreach (var item in arguments)
                {
                    switch (item.Value.GetType().ToString())
                    {
                        case "System.Int32":
                            query = query.SetInt32(item.Key, (int)item.Value);
                            break;
                        case "System.String":
                            query = query.SetString(item.Key, (string)item.Value);
                            break;
                        case "System.Bool":
                            query = query.SetBoolean(item.Key, (bool)item.Value);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            var returnValue = query.SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(T))).Future<T>();

            return returnValue;
        }

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> expression = null) where T : class
        {
            using (var nhibernateTrnasaction = this.session.BeginTransaction())
            {
                if (expression != null)
                {
                    return this.session.QueryOver<T>().Where(expression).Future();
                }
                else
                {
                    return this.session.QueryOver<T>().Future();
                }
            }
        }
    }
}
