using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm3 : System.Web.UI.Page , IDatabaseRequirements
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadDatabase();
            }
        }

        public bool CheckIfInDatabase<T>(T s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from d in myEntities.DepartmentPositionTables
                              where d.Department_Name == s.ToString()
                              select d;

                if (reviews.ToList().Count >= 1)
                    return true;
            }

            return false;
        }

        public void DeleteInDatabase<T>(T s)
        {
            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from d in myEntities.DepartmentPositionTables
                            where d.DepartmentPos_Id.ToString() == s.ToString()
                            select d).Single();

                myEntities.DepartmentPositionTables.Remove(data);
                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(
                   TypeOfUpdate.Delete, DateTime.Now, "Deleted department: " + data.Department_Name);
            }
        }

        public void EditDatabase<T>(T t) { }

        public void InsertDatabase()
        {
            DepartmentPositionTable depTable = new DepartmentPositionTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                depTable.Department_Name = AddDepText.Value;

                myEntities.DepartmentPositionTables.Add(depTable);
                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(
                   TypeOfUpdate.Add, DateTime.Now, "Added new department: " +AddDepText.Value);
            }
        }

        public void LoadDatabase()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from d in myEntities.DepartmentPositionTables
                              orderby d.DepartmentPos_Id ascending
                              select new
                              {
                                  d.DepartmentPos_Id,
                                  d.Department_Name
                              };

                GridView1.DataSource = reviews.ToList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            const int id_index = 1;
            int s = int.Parse(GridView1.Rows[e.RowIndex].Cells[id_index].Text);
            DeleteInDatabase(s.ToString());

            LoadDatabase();
        }

        protected void AddDepartmentBtn_Click(object sender, EventArgs e)
        {
            if (AddDepPanel.Visible)
            {
                AddDepPanel.Visible = false;
                AddDepText.Value = string.Empty;
            }
            else
                AddDepPanel.Visible = true;
        }

        protected void AddDepSubmitBtn_Click(object sender, EventArgs e)
        {

        }

        protected void AddDepValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (AddDepText.Value == string.Empty)
                args.IsValid = false;

            if (CheckIfInDatabase(AddDepText.Value))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;

                InsertDatabase();
                LoadDatabase();
            }
        }
}
}