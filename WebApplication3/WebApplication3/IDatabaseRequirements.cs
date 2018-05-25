using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3
{
    //List of requirements if a page requires an entity database
    public interface IDatabaseRequirements
    {
        //Check if variable in database
        bool CheckIfInDatabase<T>(T t);
        //Delete an item from database
        void DeleteInDatabase<T>(T t);
        //Insert an item in database
        void InsertDatabase();
        //Load the database
        void LoadDatabase();
        //Edit existing database
        void EditDatabase<T>(T t);
    }
}
