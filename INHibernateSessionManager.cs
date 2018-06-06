using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRESTApi
{
    public interface INHibernateSessionManager : IDisposable
    {
        NHibernate.ISession GetCurrentSession();
    }
}
