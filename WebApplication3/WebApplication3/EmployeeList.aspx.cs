using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication3
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private const int id_index = 2;

        private void HideIDColumn()
        {
            if (GridView1.FooterRow.Cells[id_index] == null)
                return;

            GridView1.FooterRow.Cells[id_index].Visible = false;
            GridView1.HeaderRow.Cells[id_index].Visible = false;
            foreach (GridViewRow g in GridView1.Rows)
            {
                g.Cells[id_index].Visible = false;
            }
        }
        private void LoadHRDatabase()
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              select new
                              {
                                  HRTable.Id,
                                  HRTable.Name,
                                  HRTable.Phone,
                                  HRTable.IC,
                                  HRTable.JobTable.Job_Title,
                                  HRTable.JobTable.Job_Salary,
                                  HRTable.DepartmentTable.Department_Name
                              };

                GridView1.DataSource = reviews.ToList();
                GridView1.DataBind();
            }

            SearchText.Text = string.Empty;

            //Hacky solution
            HideIDColumn();
        }

        private void FindInDatabase(string s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              where HRTable.Name == s ||
                              HRTable.IC == s ||
                              HRTable.Phone == s
                              select HRTable;

                GridView1.DataSource = reviews.ToList();
                GridView1.DataBind();
            }

            //Hacky solution
            HideIDColumn();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadHRDatabase();
            }
            else
            {
               
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            FindInDatabase(SearchText.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadHRDatabase();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int s = int.Parse(GridView1.Rows[e.RowIndex].Cells[id_index].Text);
            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from p in myEntities.HRTables
                            where p.Id == s
                            select p).Single();

                var data_job = (from p in myEntities.JobTables
                            where p.Job_ID == data.Job_ID
                            select p).Single();

                var data_department = (from p in myEntities.DepartmentTables
                             where p.Department_ID == data.Department_ID
                             select p).Single();

                myEntities.HRTables.Remove(data);
                myEntities.JobTables.Remove(data_job);
                myEntities.DepartmentTables.Remove(data_department);
                myEntities.SaveChanges();
            }

            LoadHRDatabase();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Response.Write("Chang");
        }
    }
}