using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class DBMethods<T> where T : class
    {
        public static void LoadDatabase(System.Data.Entity.DbSet<T> dataTables)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var data = from table in dataTables
                           select table;


            }
        }
    }
}