using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class HRUserControl : System.Web.UI.UserControl
    {

        public TextBox InputName
        {
            set { NameText = value; }
            get { return NameText; }
        }

        public TextBox InputIC
        {
            set { ICText = value; }
            get { return ICText; }
        }

        public TextBox InputPhone
        {
            set { PhoneText = value; }
            get { return PhoneText; }
        }

        public TextBox InputSalary
        {
            set { JobSalaryText = value; }
            get { return JobSalaryText; }
        }

        public DropDownList InputJob
        {
            get { return titleList; }
        }

        public DropDownList InputDepartment
        {
            get { return DepartmentNameList; }
        }

        public FileUpload InputPicture
        {
            get { return FileUpload1; }
        }

        public RequiredFieldValidator RequiredFieldValidator_Name
        {
            get { return reqName; }
        }

        public RequiredFieldValidator RequiredFieldValidator_IC
        {
            get { return reqIC2; }
        }

        public RequiredFieldValidator RequiredFieldValidator_Phone
        {
            get { return ReqPhone2; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}