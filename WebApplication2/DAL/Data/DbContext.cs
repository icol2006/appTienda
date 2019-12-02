using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{

    public static class DbContext
    {
        public static Object Execute(Func<WebDatabaseContext, Object> f)
        {
            using (var db = new WebDatabaseContext())
                return f(db);
        }
    }
}
