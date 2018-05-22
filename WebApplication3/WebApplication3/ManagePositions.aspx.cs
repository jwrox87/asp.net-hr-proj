using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJobPosDatabase();
            }
        }

        private bool CheckIfInDatabase(string s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from JobPositionTable in myEntities.JobPositionTables
                              where JobPositionTable.Job_Title == s
                              select JobPositionTable;

                if (reviews.ToList().Count >= 1)
                    return true;
            }

            return false;
        }

        const int id_index = 1;
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int s = int.Parse(GridView1.Rows[e.RowIndex].Cells[id_index].Text);
            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from p in myEntities.JobPositionTables
                            where p.JobPosition_ID == s
                            select p).Single();

                myEntities.JobPositionTables.Remove(data);
                myEntities.SaveChanges();
            }

            LoadJobPosDatabase();
        }

        public void InsertJobPosTable()
        {
            JobPositionTable jobpostable = new JobPositionTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                jobpostable.Job_Title = AddPositionText.Value;

                myEntities.JobPositionTables.Add(jobpostable);
                myEntities.SaveChanges();
            }
        }

        protected void LoadJobPosDatabase()
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

                InsertJobPosTable();
                LoadJobPosDatabase();
            }
        }
    }

}
