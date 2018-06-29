using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public enum TypeOfUpdate
    {
        None,
        Add,
        Delete,
        Modify
    }

    public class FieldInformation
    {
        TypeOfUpdate updateType = TypeOfUpdate.None;
        DateTime date_time_added;
        string updateText;
        string author;

        string color;

        public FieldInformation() { }

        public FieldInformation(TypeOfUpdate tou, DateTime dt, string ut,string a)
        {
            updateType = tou;
            date_time_added = dt;
            updateText = ut;
            author = a;
        }

        public (TypeOfUpdate, DateTime, string) GetFieldInfo()
        {
            return (updateType, date_time_added, updateText);
        }

        public string GetAuthor()
        {
            return author;
        }

        public string GetColor()
        {
            switch (updateType)
            {
                case TypeOfUpdate.Add:
                    color = "cornsilk";
                break;

                case TypeOfUpdate.Delete:
                    color = "indianred";
                break;

                case TypeOfUpdate.Modify:
                    color = "lightgreen";
                break;
            }
            return color;
        }
    }
}