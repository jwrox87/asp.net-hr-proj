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
            Employee e = (Employee)Session["Employee"];

            nameLabel.InnerText = e.Name;
            phoneLabel.InnerText = e.Phone;
            icLabel.InnerText = e.IC;
            jobPosLabel.InnerText = e.JobPos;
            jobSalaryLabel.InnerText = ((float.Parse(e.JobSalary) * 100f) / 100f).ToString();
            depNameLabel.InnerText = e.DepartmentName;

            if (e.Picture != null)
            {
                byte[] b = (byte[])e.Picture;
                Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(b);
            }

            if (e.JoinDate != null)
                joinDateLabel.InnerText = e.JoinDate.ToString();

            idLabel.InnerText = e.id.ToString();
        }

        //Store session variables from employee - taken from employee list page
        public void LoadEmployeeDetails(Employee e)
        {
            Session["Employee"] = e;
        }
    }
}