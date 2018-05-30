﻿using System;
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

        public FieldInformation() { }

        public FieldInformation(TypeOfUpdate tou, DateTime dt, string ut)
        {
            updateType = tou;
            date_time_added = dt;
            updateText = ut;
        }

        public (TypeOfUpdate, DateTime, string) GetFieldInfo()
        {
            return (updateType, date_time_added, updateText);
        }
    }
}