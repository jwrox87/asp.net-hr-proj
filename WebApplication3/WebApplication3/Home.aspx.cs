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
                        cdt, fieldInfoTables[i].Update_Text);

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

                List<FieldInfoTable> fits = data.ToList();

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

        public bool CheckIfInDatabase<T>(T t) { return false; }

        private void PrintTypeOfUse(Label label_ut, FieldInformation fi)
        {
            label_ut.Text = fi.GetFieldInfo().Item1.ToString();
            label_ut.Width = Unit.Percentage(40);
            label_ut.Style.Add("text-align", "left");
            label_ut.Font.Size = FontUnit.Large;
            label_ut.Style.Add("background-color", fi.GetColor());
        }

        private void PrintTime(Label label_time, FieldInformation fi)
        {
            label_time.Text = fi.GetFieldInfo().Item2.ToString();
            label_time.Width = Unit.Percentage(60);
            label_time.Style.Add("text-align", "left");
            label_time.Font.Size = FontUnit.Large;
            label_time.Style.Add("background-color", fi.GetColor());
        }

        private void PrintDescription(Label label_desc, FieldInformation fi)
        {
            label_desc.Text = fi.GetFieldInfo().Item3;
            label_desc.Width = Unit.Percentage(100);
            label_desc.Font.Size = FontUnit.Large;
            label_desc.Style.Add("background-color", fi.GetColor());
        }


        private void PrintInfo(FieldInformation fi)
        {
            Label label_ut = new Label();
            Label label_time = new Label();
            Label label_desc = new Label();

            //Button button = new Button();
            //button.Text = "Delete";
            //button.PostBackUrl = "Home";
            //button.Attributes.Add("runat", "server");

            //button.Click += (sender, e) =>
            //{
            //};

            PrintTypeOfUse(label_ut, fi);
            PrintTime(label_time, fi);
            PrintDescription(label_desc, fi);

            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<fieldset> "));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_ut);

            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_time);

            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

            UpdatePanel1.ContentTemplateContainer.Controls.Add(label_desc);
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));

            //UpdatePanel1.ContentTemplateContainer.Controls.Add(button);
            UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</fieldset>"));
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
