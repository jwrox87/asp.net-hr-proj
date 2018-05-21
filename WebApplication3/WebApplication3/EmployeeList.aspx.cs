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
                              select HRTable;

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

                myEntities.HRTables.Remove(data);
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