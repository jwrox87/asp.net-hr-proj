using System;
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
        
        public void EditDatabase<T>(T t) { }

        public void LoadDatabase()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var data = from info in myEntities.FieldInfoTables
                           select info;

                List<FieldInfoTable> fieldInfoTables = data.ToList();

                for (int i = 0; i < fieldInfoTables.Count; i++)
                {
                    TypeOfUpdate tou =
                    (TypeOfUpdate)Enum.Parse(typeof(TypeOfUpdate), fieldInfoTables[i].Update_Type);

                    DateTime cdt = (DateTime)fieldInfoTables[i].Update_Date;

                    FieldInformation fi
                       = new FieldInformation(tou,
                        cdt, fieldInfoTables[i].Update_Text,
                        fieldInfoTables[i].Author);

                    fieldInfo_List.Add(fi);
                }
            }
        }

        public void InsertDatabase() { }

        public void DeleteInDatabase<T>(T t)
        {
            DateTime dt = DateTime.Now;
            dt.AddDays(7);

            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {           
                var data = (from d in myEntities.FieldInfoTables
                            select d);

                List < FieldInfoTable > fits = data.ToList();

                foreach (FieldInfoTable fit in fits)
                {
                    if (fit.Update_Date > dt)
                    {
                        myEntities.FieldInfoTables.Remove(fit);
                    }
                }
                myEntities.SaveChanges();
            }
        }

        public static void DeleteOldDepartmentData()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var department_data = from d in myEntities.DepartmentTables
                                      select d;

                var hr_data = from d in myEntities.HRTables
                             select new
                             {
                                 d.Department_ID
                             };
             
                foreach (DepartmentTable dt in department_data.ToList())
                {
                    var j = new { dt.Department_ID };
                    if (!hr_data.ToList().Contains(j))
                    {
                        myEntities.DepartmentTables.Remove(dt);
                    }
                }

                myEntities.SaveChanges();
                    
            }
        }

        public static void DeleteOldPositionData()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var position_data = from d in myEntities.JobTables
                                      select d;

                var hr_data = from d in myEntities.HRTables
                              select new
                              {
                                  d.Job_ID
                              };

                foreach (JobTable jt in position_data.ToList())
                {
                    var j = new { jt.Job_ID };
                    if (!hr_data.ToList().Contains(j))
                    {
                        myEntities.JobTables.Remove(jt);
                    }
                }

                myEntities.SaveChanges();
            }
        }

        public bool CheckIfInDatabase<T>(T t) { return false; }

        private void PrintTypeOfUse(Label label_ut, FieldInformation fi)
        {
            label_ut.Text = fi.GetFieldInfo().Item1.ToString();
            label_ut.Width = Unit.Percentage(40);
            label_ut.Style.Add("text-align", "left");
            label_ut.Font.Size = FontUnit.Large;
            //label_ut.Style.Add("background-color", fi.GetColor());
        }

        private void PrintTime(Label label_time, FieldInformation fi)
        {
            label_time.Text = fi.GetFieldInfo().Item2.ToString();
            label_time.Width = Unit.Percentage(60);
            label_time.Style.Add("text-align", "right");
            label_time.Font.Size = FontUnit.Large;
            //label_time.Style.Add("background-color", fi.GetColor());
        }

        private void PrintDescription(Label label_desc, FieldInformation fi)
        {
            label_desc.Text = fi.GetFieldInfo().Item3;
            label_desc.Width = Unit.Percentage(100);
            label_desc.Font.Size = FontUnit.Large;
            //label_desc.Style.Add("background-color", fi.GetColor());
        }

        private void PrintAuthor(Label label_author, FieldInformation fi)
        {
            label_author.Text = "Author: " + fi.GetAuthor();
            label_author.Width = Unit.Percentage(100);
            label_author.Font.Size = FontUnit.Large;
        }


        private void PrintInfo(FieldInformation fi)
        {
            Label label_ut = new Label();
            Label label_time = new Label();
            Label label_desc = new Label();
            Label label_author = new Label();

            PrintTypeOfUse(label_ut, fi);
            PrintTime(label_time, fi);
            PrintDescription(label_desc, fi);
            PrintAuthor(label_author,fi);

            string div_type = "<div class='alert-primary rounded;border border-secondary' role='alert' style='width:80%'>";

            if (fi.GetFieldInfo().Item1 == TypeOfUpdate.Delete)
            {
                div_type = "<div class='alert-danger rounded;border border-secondary' role='alert' style='width:80%'>";
            }
            else if (fi.GetFieldInfo().Item1 == TypeOfUpdate.Modify)
            {
                div_type = "<div class='alert-info rounded;border border-secondary' role='alert' style='width:80%'>";
            }
          
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<div style='padding-left:20%'>"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl(div_type));
            
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_ut);
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_time);
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_author);

            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<hr style='opacity=0.2'/>"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_desc);

            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</div>"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
        }

        private void FillDropDownList(ListItem li)
        {
            DropDownList1.Items.Add(li);
        }

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);

            ListItem listItem1 = new ListItem("Show last 5 activities");
            ListItem listItem2 = new ListItem("Show all activities");
            FillDropDownList(listItem1);
            FillDropDownList(listItem2);

            DeleteInDatabase<string>(null);
            DeleteOldDepartmentData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDatabase();

            if (fieldInfo_List.Count > 5
                && DropDownList1.SelectedValue == DropDownList1.Items[0].Text)
            {
                for (int i = fieldInfo_List.Count; i > fieldInfo_List.Count - 5; i--)
                    PrintInfo(fieldInfo_List[i - 1]);
            }
            else
            {
                for (int i = fieldInfo_List.Count; i > 0; i--)
                    PrintInfo(fieldInfo_List[i - 1]);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
