using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class EmployeeEdit : System.Web.UI.Page, IDatabaseRequirements
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDropDownList();
            }
        }

        public void LoadDatabase(){ }
        public void InsertDatabase() { }
        public void DeleteInDatabase<T>(T s) { }

        public void EditDatabase<T>(T s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var data = myEntities.HRTables.SingleOrDefault(p => p.Id.ToString() == s.ToString());

                if (data != null)
                {
                    if (inputPhone.Value != "")
                        data.Phone = inputPhone.Value;

                    if (inputJS.Value != "")
                        data.JobTable.Job_Salary = decimal.Parse(inputJS.Value);

                    data.JobTable.Job_Title = ddlJP.Text;
                    data.DepartmentTable.Department_Name = ddlDN.Text;

                    if (fileuploadPP.PostedFile.FileName != "")
                    data.ProfilePicture = fileuploadPP.FileBytes;
                }

                myEntities.SaveChanges();

                FieldInformationDB.CreateFieldInformation(TypeOfUpdate.Modify,
                    DateTime.Now, "Employee: " + data.Name + " has been edited",
                    HttpContext.Current.User.Identity.Name);
            }
        }

        public bool CheckIfInDatabase<T>(T s)
        {
            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              where HRTable.Id.ToString() == s.ToString()
                              select new
                              {
                                  HRTable.Id,
                                  HRTable.Name,
                                  HRTable.Phone,
                                  HRTable.IC
                              };

                if (reviews.ToList().Count >= 1)
                {
                    GridView1.DataSource = reviews.ToList();
                    GridView1.DataBind();

                    return true;
                }
            }

            return false;
        }

        private Employee GetValueFromGridView()
        {
            const int rowIndex = 0;
            const int colIndex = 0;
            int s = int.Parse(GridView1.Rows[rowIndex].Cells[colIndex].Text);

            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var data = (from hrTable in myEntities.HRTables
                            where hrTable.Id == s
                            select hrTable).Single();

                return new Employee(data.Name, data.Phone,
                    data.IC, data.JobTable.Job_Title, data.JobTable.Job_Salary.ToString(), data.JobTable.Job_JoinDate,
                    data.DepartmentTable.Department_Name, data.ProfilePicture,
                    data.Id, data.Job_ID, data.Department_ID);
            }
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
                    ddlJP.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < data.Count(); i++)
                {
                    ListItem listItem = new ListItem(data.ToList()[i].Job_Title);
                    ddlJP.Items.Add(listItem);
                }

                if (data2.Count() <= 0)
                {
                    ListItem listItem = new ListItem("None");
                    ddlDN.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < data2.Count(); i++)
                {
                    ListItem listItem = new ListItem(data2.ToList()[i].Department_Name);
                    ddlDN.Items.Add(listItem);
                }
            }
        }

        private void AddOffset()
        {
            RefIDText.Style.Add("margin-bottom", "30px");
            //TableDetails.Style.Add("margin-top", "80px");
        }

        private void AssignProperties(Employee e)
        {
            inputName.Value = e.Name;
            inputIC.Value = e.IC;
        }

        private void ShowNotification(bool b)
        {
            NotificationLabel.InnerText = "Changes saved";
            NotificationLabel.Visible = b;
        }


        private void ShowEmployeeDetailsTable()
        {
            PanelDetails.Visible = true;
        }

        protected void RefIDValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
                ShowNotification(false);
            }
            else
            {
                if (CheckIfInDatabase(args.Value))
                {
                    args.IsValid = true;

                    ShowEmployeeDetailsTable();
                    AssignProperties(GetValueFromGridView());
                    

                    AddOffset();

                }
                else
                {
                    args.IsValid = false;
                    ShowNotification(false);
                }
            }
        }

        private void AddToDatabase()
        {
            Employee employee = GetValueFromGridView();
            EditDatabase(employee.id);

            ExtensionMethods.ClearTextBoxes(Page);
            ShowNotification(true);
        }

        protected void ApplyChangeBtn_Click(object sender, EventArgs e)
        {
            if (fileuploadPP.PostedFile.FileName == "")
            {
                AddToDatabase();
            }
        }

        protected void UploadPicValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (fileuploadPP.PostedFile == null)
                return;
            
            if (fileuploadPP.PostedFile.FileName != "")
            {
                if (fileuploadPP.FileName.Contains(".png")
                    || fileuploadPP.FileName.Contains(".jpg"))
                {  
                        args.IsValid = true;
                        AddToDatabase();
                }
                else
                {
                    args.IsValid = false;
                    ShowNotification(false);
                }
            }
        }
    }
}