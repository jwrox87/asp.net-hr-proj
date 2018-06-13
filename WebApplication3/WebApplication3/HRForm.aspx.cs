using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication3
{
    public partial class HRForm : System.Web.UI.Page, IValidation
    {
        void TestingPurpose()
        {
            NameText.Text = "I am meAA";
            PhoneText.Text = "81593245";
            ICText.Text = "S9811724Q";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SetValidations(false);
            }
            else
            {
                //TestingPurpose();
                InitDropDownList();                
            }
        }

        public void SetValidations(bool b)
        {
            reqName.Visible = b;
        }

        private void InitDropDownList()
        {
            using (HRDatabaseEntities myEntity = new HRDatabaseEntities())
            {
                var data = from JobPositionTable in myEntity.JobPositionTables
                           select new
                           {
                               JobPositionTable.Job_Title
                           };

                var data2 = from dTable in myEntity.DepartmentPositionTables
                            select new
                            {
                                dTable.Department_Name
                            };

                if (data.Count() <= 0)
                {
                    ListItem listItem = new ListItem("None");
                    titleList.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < data.Count(); i++)
                {
                    ListItem listItem = new ListItem(data.ToList()[i].Job_Title);
                    titleList.Items.Add(listItem);
                }

                if (data2.Count() <= 0)
                {
                    ListItem listItem = new ListItem("None");
                    titleList.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < data2.Count(); i++)
                {
                    ListItem listItem = new ListItem(data2.ToList()[i].Department_Name);
                    DepartmentNameList.Items.Add(listItem);
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
                jobtable.Job_Title = titleList.Text;

                if (JobSalaryText.Text != string.Empty)
                    jobtable.Job_Salary = decimal.Parse(JobSalaryText.Text);
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
                deptable.Department_Name = DepartmentNameList.Text;

                myEntities.DepartmentTables.Add(deptable);
                myEntities.SaveChanges();

                employee.department_id = deptable.Department_ID;
            }
        }

        public void InsertHRTable(Employee employee)
        {
            int phone_number = 0;

            if (PhoneText.Text != "")
                phone_number = int.Parse(PhoneText.Text);

            HRTable hrtable = new HRTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                hrtable.Name = NameText.Text;
                hrtable.Phone = phone_number.ToString();
                hrtable.IC = ICText.Text;
                hrtable.Job_ID = employee.job_id;
                hrtable.Department_ID = employee.department_id;
                hrtable.ProfilePicture = FileUpload1.FileBytes;

                myEntities.HRTables.Add(hrtable);
                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(
        TypeOfUpdate.Add, DateTime.Now, "Added new employee: " +NameText.Text);
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
            SetValidations(true);
        }

        protected void OnClick_SeeEmployeeList(object sender, EventArgs e)
        {
            //Response.Redirect("EmployeeList.aspx");
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
            if (FileUpload1.PostedFile.FileName != "")
            {
                if (FileUpload1.FileName.Contains(".png")
                    || FileUpload1.FileName.Contains(".jpg"))
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