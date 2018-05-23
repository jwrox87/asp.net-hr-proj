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

        void AssignProperties()
        {
            nameLabel.InnerText = Session["name"].ToString();
            phoneLabel.InnerText = Session["phone"].ToString();
            icLabel.InnerText = Session["ic"].ToString();
            jobPosLabel.InnerText = Session["jobtitle"].ToString();
            jobSalaryLabel.InnerText = Session["jobsalary"].ToString();
            depNameLabel.InnerText = Session["departmentname"].ToString();
        }

        public void LoadEmployeeDetails(Employee e)
        {
            Session["name"] = e.Name;
            Session["phone"] = e.Phone;
            Session["ic"] = e.IC;
            Session["jobtitle"] = e.JobPos;
            Session["jobsalary"] = e.JobSalary;
            Session["departmentname"] = e.DepartmentName;
        }
    }
}