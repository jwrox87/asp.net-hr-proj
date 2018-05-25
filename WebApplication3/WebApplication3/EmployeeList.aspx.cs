using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication3
{
    public partial class EmployeeList : System.Web.UI.Page, IDatabaseRequirements
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
        public void LoadDatabase()
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
                                  HRTable.DepartmentTable.Department_Name
                              };

                GridView1.DataSource = reviews.ToList();
                GridView1.DataBind();
            }

            SearchText.Text = string.Empty;

            //Hacky solution
            HideIDColumn();
        }

        public void InsertDatabase() { }
        public bool CheckIfInDatabase<T>(T s) { return false; }

        public void EditDatabase<T>(T t) { }

        public void DeleteInDatabase<T>(T s)
        {
            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from p in myEntities.HRTables
                            where p.Id.ToString() == s.ToString()
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
        }

        public void FindInDatabase(string s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              where HRTable.Name == s ||
                              HRTable.IC == s ||
                              HRTable.Phone == s ||
                              HRTable.JobTable.Job_Title == s ||
                              HRTable.DepartmentTable.Department_Name == s
                              select new
                              {
                                  HRTable.Id,
                                  HRTable.Name,
                                  HRTable.Phone,
                                  HRTable.IC,
                                  HRTable.JobTable.Job_Title,
                                  HRTable.DepartmentTable.Department_Name
                              };

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
                LoadDatabase();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            FindInDatabase(SearchText.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int s = int.Parse(GridView1.Rows[e.RowIndex].Cells[id_index].Text);

            DeleteInDatabase(s.ToString());
            LoadDatabase();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            EmployeeDetails employeedetails = new EmployeeDetails();
           
            int s = int.Parse(GridView1.Rows[e.NewSelectedIndex].Cells[id_index].Text);

            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from p in myEntities.HRTables
                            where p.Id == s
                            select p).Single();

                ExtensionMethods.Redirect
               (this.Response, "EmployeeDetails", "_blank",
               "menubar=0,scrollbars=1,width=780,height=800,top=10");

                Employee employee = new Employee(data.Name,
                    data.Phone, data.IC, data.JobTable.Job_Title,
                    data.JobTable.Job_Salary.ToString(), data.DepartmentTable.Department_Name
                    , data.ProfilePicture, data.Id, data.Job_ID, data.Department_ID);

                employeedetails.LoadEmployeeDetails(employee);
            }
        
          
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

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
                                  HRTable.DepartmentTable.Department_Name
                              };

                GridView1.DataSource = reviews.ToList();
                GridView1.DataBind();
            }
        }
    }
}