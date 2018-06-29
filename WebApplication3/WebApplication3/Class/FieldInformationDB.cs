using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public static class FieldInformationDB
    {
        public static void CreateFieldInformation(FieldInformation fieldInfo)
        {
            InsertDatabase(fieldInfo);
        }

        public static void CreateFieldInformation(TypeOfUpdate ut, DateTime dt, string description,string author)
        {
            FieldInformation fieldInfo
                = new FieldInformation(ut, dt, description,author);

            InsertDatabase(fieldInfo);
        }

        private static void InsertDatabase(FieldInformation fieldInformation)
        {
            FieldInfoTable fieldInfoTables = new FieldInfoTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                fieldInfoTables.Update_Type 
                    = fieldInformation.GetFieldInfo().Item1.ToString();

                fieldInfoTables.Update_Date = fieldInformation.GetFieldInfo().Item2;
                fieldInfoTables.Update_Text = fieldInformation.GetFieldInfo().Item3;

                fieldInfoTables.Author = fieldInformation.GetAuthor();

                myEntities.FieldInfoTables.Add(fieldInfoTables);
                myEntities.SaveChanges();
            }
        }

    }
}