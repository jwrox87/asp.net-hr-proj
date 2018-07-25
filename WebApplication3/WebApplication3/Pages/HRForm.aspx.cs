using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace WebApplication3
{
    public partial class HRForm : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            InitValidators(); 
            if (IsPostBack)
            {
                
            }
        }

        private void InitDropDownList()
        {
            using (HRDatabaseEntities myEntity = new HRDatabaseEntities())
            {
                var job_data = from JobPositionTable in myEntity.JobPositionTables
                           select new
                           {
                               JobPositionTable.Job_Title
                           };

                var dp_data = from dTable in myEntity.DepartmentPositionTables
                            select new
                            {
                                dTable.Department_Name
                            };

                if (job_data.Count() <= 0)
                {
                    ListItem listItem = new ListItem("None");
                    UserControl.InputJob.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < job_data.Count(); i++)
                {
                    ListItem listItem = new ListItem(job_data.ToList()[i].Job_Title);
                    UserControl.InputJob.Items.Add(listItem);
                }

                if (dp_data.Count() <= 0)
                {
                    ListItem listItem = new ListItem("None");
                    UserControl.InputJob.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < dp_data.Count(); i++)
                {
                    ListItem listItem = new ListItem(dp_data.ToList()[i].Department_Name);
                    UserControl.InputDepartment.Items.Add(listItem);
                }
            }
        }

        private void UpdateStatusLabel(string labelname, string text)
        {      
            UpdateStatus.Visible = true;
            UpdateStatus.Text = text;
        }

        public void InsertJobTable(ref Employee employee)
        {
            JobTable jobtable = new JobTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                
                jobtable.Job_GroupId = UserControl.InputJob.Text;

                var data = (from jposTable in myEntities.JobPositionTables
                            where jposTable.JobPosition_ID.ToString() == jobtable.Job_GroupId
                            select jposTable).Single();

                jobtable.Job_Title = data.Job_Title;

                if (UserControl.InputSalary.Text != string.Empty)
                    jobtable.Job_Salary = decimal.Parse(UserControl.InputSalary.Text);
                else
                    jobtable.Job_Salary = 0;

                var dt = DateTime.Now;
                jobtable.Job_JoinDate = DateTime.Parse(dt.ToShortDateString());
                 
                myEntities.JobTables.Add(jobtable);
                myEntities.SaveChanges();

                employee.job_id = jobtable.Job_ID;             
            }   
        }

        public void InsertDepartmentTable(ref Employee employee)
        {
            DepartmentTable deptable = new DepartmentTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                deptable.Department_GroupId = UserControl.InputDepartment.Text;

                var data = (from dposTable in myEntities.DepartmentPositionTables
                            where dposTable.DepartmentPos_Id.ToString() == deptable.Department_GroupId
                            select dposTable).Single();

                deptable.Department_Name = data.Department_Name;

            
                myEntities.DepartmentTables.Add(deptable);
                myEntities.SaveChanges();

                employee.department_id = deptable.Department_ID;
            }
        }

        public void InsertHRTable(Employee employee)
        {
            int phone_number = 0;

            if (UserControl.InputPhone.Text != "")
                phone_number = int.Parse(UserControl.InputPhone.Text);

            HRTable hrtable = new HRTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                hrtable.Name = UserControl.InputName.Text;
                hrtable.Phone = phone_number.ToString();
                hrtable.IC = UserControl.InputIC.Text;
                hrtable.Job_ID = employee.job_id;
                hrtable.Department_ID = employee.department_id;
                hrtable.ProfilePicture = UserControl.InputPicture.FileBytes;      

                myEntities.HRTables.Add(hrtable);
                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(
                    TypeOfUpdate.Add, DateTime.Now, "Added new employee: " +UserControl.InputName.Text,
                    HttpContext.Current.User.Identity.Name);
            }
        }

        private bool CheckIfICInDatabase(string s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              where HRTable.IC == s
                              select HRTable;

                if (reviews.ToList().Count >= 1)
                    return true;
            }

            return false;
        }

        private bool CheckIfPhoneInDatabase(string s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              where HRTable.Phone == s
                              select HRTable;

                if (reviews.ToList().Count >= 1)
                    return true;
            }

            return false;
        }

        protected void OnClick_AddEmployee(object sender, EventArgs e)
        {      
           
        }

        protected void OnClick_SeeEmployeeList(object sender, EventArgs e)
        {
            
        }

        protected void InsertIntoDatabase()
        {
            Employee employee = new Employee();

            InsertJobTable(ref employee);
            InsertDepartmentTable(ref employee);
            InsertHRTable(employee);

            UpdateStatusLabel("UpdateStatus", "Successfully added into database");

            ExtensionMethods.ClearTextBoxes(Page);
            ExtensionMethods.ResetDropDownLists(Page);
        }


        private void InitValidators()
        { 
            CheckICValidator.ControlToValidate = UserControl.InputIC.ID;
            UserControl.InputIC.Controls.Add(CheckICValidator);  

            CheckPhoneValidator.ControlToValidate = UserControl.InputPhone.ID;
            UserControl.InputPhone.Controls.Add(CheckPhoneValidator);

            UploadPicValidator.ControlToValidate = UserControl.InputPicture.ID;
            UserControl.InputPicture.Controls.Add(new LiteralControl("<br />"));
            UserControl.InputPicture.Controls.Add(UploadPicValidator);
        }

        bool IC_Checked = false;
        protected void CheckICValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CheckIfICInDatabase(args.Value))
                args.IsValid = false;
            else
                args.IsValid = true;           

            IC_Checked = args.IsValid;
        }

       
        protected void UploadPicValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (UserControl.InputPicture.PostedFile.FileName != "")
            {
                if (UserControl.InputPicture.PostedFile.FileName.Contains(".png")
                    || UserControl.InputPicture.PostedFile.FileName.Contains(".jpg"))
                {
                    if (IC_Checked && Phone_Checked)
                    {
                        args.IsValid = true;
                        InsertIntoDatabase();
                    }
                    else
                    {
                         args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }

        bool Phone_Checked = false;
        protected void CheckPhoneValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CheckIfPhoneInDatabase(args.Value))
                args.IsValid = false;
            else
                args.IsValid = true;

            Phone_Checked = args.IsValid;
        }

       
    }
}