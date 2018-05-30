﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page, IDatabaseRequirements
    {
        List<FieldInformation> fieldInfo_List = new List<FieldInformation>();


        public void EditDatabase<T>(T t){ }

        public void LoadDatabase()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var data = from info in myEntities.FieldInfoTables
                           select info;

                List<FieldInfoTable> fieldInfoTables = data.ToList();

                for (int i =0; i < fieldInfoTables.Count; i++)
                {
                    TypeOfUpdate tou =
                    (TypeOfUpdate)Enum.Parse(typeof(TypeOfUpdate), fieldInfoTables[i].Update_Type);

                    DateTime cdt = (DateTime)fieldInfoTables[i].Update_Date;

                    FieldInformation fi
                       = new FieldInformation(tou,
                        cdt, fieldInfoTables[i].Update_Text);

                    fieldInfo_List.Add(fi);
                }
            }
        }

        public void InsertDatabase(){ }

        public void DeleteInDatabase<T>(T t) { }

        public bool CheckIfInDatabase<T>(T t) { return false; }
 

        private void PrintInfo(FieldInformation fi)
        {
            Label label_ut = new Label();
            Label label_time = new Label();
            Label label_desc = new Label();

            label_ut.Text = fi.GetFieldInfo().Item1.ToString();
            label_ut.Width = Unit.Percentage(40);
            label_ut.Style.Add("text-align", "left");
            label_ut.Font.Size = FontUnit.Large;
            label_ut.Style.Add("background-color", "cornsilk");

            label_time.Text = fi.GetFieldInfo().Item2.ToString();
            label_time.Width = Unit.Percentage(60);
            label_time.Style.Add("text-align", "left");
            label_time.Font.Size = FontUnit.Large;
            label_time.Style.Add("background-color", "cornsilk");

            label_desc.Text = fi.GetFieldInfo().Item3;
            label_desc.Width = Unit.Percentage(60);
            label_desc.Font.Size = FontUnit.Large;
            label_desc.Style.Add("background-color", "cornsilk");

            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_ut);
            //UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("&nbsp;"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_time);
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_desc);
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fieldInfo_List.Clear();

                LoadDatabase();

                for (int i= fieldInfo_List.Count; i > 0; i--)
                    PrintInfo(fieldInfo_List[i-1]);
            }


           
        }
    }
}