using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            AssignProperties();
        }

        //Assign labels with session variables
        void AssignProperties()
        {
            nameLabel.InnerText = Session["name"].ToString();
            phoneLabel.InnerText = Session["phone"].ToString();
            icLabel.InnerText = Session["ic"].ToString();
            jobPosLabel.InnerText = Session["jobtitle"].ToString();
            jobSalaryLabel.InnerText = Session["jobsalary"].ToString();
            depNameLabel.InnerText = Session["departmentname"].ToString();

            if (Session["picture"] != null)
            {
                byte[] b = (byte[])Session["picture"];
                Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(b);
            }

            if (Session["joinDate"] != null)
                joinDateLabel.InnerText = Session["joinDate"].ToString();

            idLabel.InnerText = Session["id"].ToString();
            jobidLabel.InnerText = Session["job_id"].ToString();
            didLabel.InnerText = Session["department_id"].ToString();

            Session.Clear();
        }

        //Store session variables from employee - taken from employee list page
        public void LoadEmployeeDetails(Employee e)
        {
            Session["name"] = e.Name;
            Session["phone"] = e.Phone;
            Session["ic"] = e.IC;
            Session["jobtitle"] = e.JobPos;
            Session["jobsalary"] = (float.Parse(e.JobSalary) * 100f) / 100f;
            Session["joinDate"] = e.JoinDate;
            Session["departmentname"] = e.DepartmentName;
            Session["picture"] = e.Picture;

            Session["id"] = e.id;
            Session["job_id"] = e.job_id;
            Session["department_id"] = e.department_id;
        }
    }
}