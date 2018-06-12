using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page, IDatabaseRequirements
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            if (!IsPostBack)
            {           
                LoadDatabase();
            }
        }

        public bool CheckIfInDatabase<T>(T s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from JobPositionTable in myEntities.JobPositionTables
                              where JobPositionTable.Job_Title == s.ToString()
                              select JobPositionTable;

                if (reviews.ToList().Count >= 1)
                    return true;
            }

            return false;
        }

        public void EditDatabase<T>(T t) { }
        
        public void DeleteInDatabase<T>(T s)
        {      
            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from p in myEntities.JobPositionTables
                            where p.JobPosition_ID.ToString() == s.ToString()
                            select p).Single();

                myEntities.JobPositionTables.Remove(data);
                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(
   TypeOfUpdate.Delete, DateTime.Now, "Deleted Job Position: " + data.Job_Title);
            }
        }

        public void InsertDatabase()
        {
            JobPositionTable jobpostable = new JobPositionTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                jobpostable.Job_Title = AddPositionText.Value;

                myEntities.JobPositionTables.Add(jobpostable);
                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(
   TypeOfUpdate.Add, DateTime.Now, "Added new job: " + AddPositionText.Value);
            }
        }

        public void LoadDatabase()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from JobPosTable in myEntities.JobPositionTables
                              orderby JobPosTable.JobPosition_ID ascending
                             select new
                             {
                                 JobPosTable.JobPosition_ID,
                                 JobPosTable.Job_Title
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

        protected void AddPositionBtn_Click(object sender, EventArgs e)
        {
            if (AddPosPanel.Visible)
            {
                AddPosPanel.Visible = false;
                AddPositionText.Value = string.Empty; 
            }
            else
                AddPosPanel.Visible = true;
        }

        protected void AddPosSubmitBtn_Click(object sender, EventArgs e)
        {
          
        }

        protected void AddPosValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (AddPositionText.Value == string.Empty)
                args.IsValid = false;

            if (CheckIfInDatabase(AddPositionText.Value))
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
