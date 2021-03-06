﻿using System;
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
            NameText.Text = "I am me";
            PhoneText.Text = "82593245";
            ICText.Text = "S9811724C";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SetValidations(false);
            }
            else
            {
                TestingPurpose();
                InitDropDownList();                
            }
        }

        public void SetValidations(bool b)
        {
            reqName.Visible = b;
        }

        private void InitDropDownList()
        {
            ListItem listItem0 = new ListItem("None");
            ListItem listItem1 = new ListItem("System Analyst");
            ListItem listItem2 = new ListItem("Lead System Analyst");

            titleList.Items.Add(listItem0);
            titleList.Items.Add(listItem1);
            titleList.Items.Add(listItem2);


            ListItem listItemDName0 = new ListItem("IT");
            ListItem listItemDName1 = new ListItem("HR");
            ListItem listItemDName2 = new ListItem("R & D");

            DepartmentNameList.Items.Add(listItemDName0);
            DepartmentNameList.Items.Add(listItemDName1);
            DepartmentNameList.Items.Add(listItemDName2);
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
                jobtable.Job_Salary = decimal.Parse(JobSalaryText.Text);

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

        public void InsertHRTable(int phoneNo, Employee employee)
        {
            HRTable hrtable = new HRTable();
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                hrtable.Name = NameText.Text;
                hrtable.Phone = phoneNo.ToString();
                hrtable.IC = ICText.Text;
                hrtable.Job_ID = employee.job_id;
                hrtable.Department_ID = employee.department_id;

                myEntities.HRTables.Add(hrtable);
                myEntities.SaveChanges();
            }
        }

        protected void OnClick_AddEmployee(object sender, EventArgs e)
        {
            int phone_number = 0;

            if (PhoneText.Text != "")
                phone_number = int.Parse(PhoneText.Text);

            SetValidations(true);

            Employee employee = new Employee();

            InsertJobTable(ref employee);
            InsertDepartmentTable(ref employee);
            InsertHRTable(phone_number, employee);

            UpdateStatusLabel("UpdateStatus", "Successfully added into database");

            ExtensionMethods.ClearTextBoxes(Page);
            ExtensionMethods.ResetDropDownLists(Page);
        }

        protected void OnClick_SeeEmployeeList(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeList.aspx");
        }

     
    }
}