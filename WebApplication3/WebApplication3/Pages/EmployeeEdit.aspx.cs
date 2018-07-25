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
            InitValidators();
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
                    if (UserControlEdit.InputName.Text != "")
                        data.Name = UserControlEdit.InputName.Text;

                    if (UserControlEdit.InputIC.Text != "")
                        data.IC = UserControlEdit.InputIC.Text;

                    if (UserControlEdit.InputPhone.Text != "")
                        data.Phone = UserControlEdit.InputPhone.Text;

                    if (UserControlEdit.InputSalary.Text != "")
                        data.JobTable.Job_Salary = decimal.Parse(UserControlEdit.InputSalary.Text);

                    data.JobTable.Job_GroupId = UserControlEdit.InputJob.Text;
                    var j_data = (from jtable in myEntities.JobPositionTables
                                  where jtable.JobPosition_ID.ToString() == data.JobTable.Job_GroupId
                                  select jtable).Single();
                    data.JobTable.Job_Title = j_data.Job_Title;


                    data.DepartmentTable.Department_GroupId = UserControlEdit.InputDepartment.Text;
                    var d_data = (from dtable in myEntities.DepartmentPositionTables
                                  where dtable.DepartmentPos_Id.ToString() == data.DepartmentTable.Department_GroupId
                                  select dtable).Single();
                    data.DepartmentTable.Department_Name = d_data.Department_Name;

                    if (UserControlEdit.InputPicture.PostedFile.FileName != "")
                    data.ProfilePicture = UserControlEdit.InputPicture.FileBytes;

                    myEntities.SaveChanges();

                    FieldInformationDB.CreateFieldInformation(TypeOfUpdate.Modify,
                        DateTime.Now, "Employee: " + data.Name + " has been edited",
                        HttpContext.Current.User.Identity.Name);

                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    PanelDetails.Visible = false;
                }
            }
        }

        public bool CheckIfInDatabase<T>(T s)
        {
            ShowNotification(false);

            using (HRDatabaseEntities myEntities = new HRDatabaseEntities())
            {
                var reviews = from HRTable in myEntities.HRTables
                              where HRTable.Id.ToString().ToLower() == s.ToString().ToLower() ||
                              HRTable.Phone.ToLower() == s.ToString().ToLower() || 
                              HRTable.Name.ToLower() == s.ToString().ToLower() ||
                              HRTable.IC.ToLower() == s.ToString().ToLower() || 
                              HRTable.JobTable.Job_Title.ToLower() == s.ToString().ToLower() ||
                              HRTable.DepartmentTable.Department_Name.ToLower() == s.ToString().ToLower()
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
                    UserControlEdit.InputJob.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < data.Count(); i++)
                {
                    ListItem listItem = new ListItem(data.ToList()[i].Job_Title);
                    UserControlEdit.InputJob.Items.Add(listItem);
                }

                if (data2.Count() <= 0)
                {
                    ListItem listItem = new ListItem("None");
                    UserControlEdit.InputDepartment.Items.Add(listItem);
                    return;
                }

                for (int i = 0; i < data2.Count(); i++)
                {
                    ListItem listItem = new ListItem(data2.ToList()[i].Department_Name);
                    UserControlEdit.InputDepartment.Items.Add(listItem);
                }
            }
        }


        private void InitValidators()
        {
            UserControlEdit.RequiredFieldValidator_Name.Enabled = false;
            UserControlEdit.RequiredFieldValidator_IC.Enabled = false;
            UserControlEdit.RequiredFieldValidator_Phone.Enabled = false;

            UploadPicValidator.ControlToValidate = UserControlEdit.InputPicture.ID;
            UserControlEdit.InputPicture.Controls.Add(new LiteralControl("<br />"));
            UserControlEdit.InputPicture.Controls.Add(UploadPicValidator);
        }

        private void AddOffset()
        {
            RefIDText.Style.Add("margin-bottom", "30px");
        }

        private void AssignProperties(Employee e)
        {
            UserControlEdit.InputName.Text = e.Name.Replace(" ", string.Empty);
            UserControlEdit.InputIC.Text = e.IC.Replace(" ", string.Empty);
            UserControlEdit.InputPhone.Text = e.Phone.Replace(" ", string.Empty);
            UserControlEdit.InputSalary.Text = e.JobSalary.Replace(" ", string.Empty);

            Session["Employee"] = e;
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int s = int.Parse(GridView1.Rows[e.NewSelectedIndex].Cells[1].Text);

            using (var myEntities = new HRDatabaseEntities())
            {
                var data = (from p in myEntities.HRTables
                            where p.Id == s
                            select p).Single();

                Employee em = new Employee(data.Name, data.Phone, data.IC, data.JobTable.Job_Title,
                    data.JobTable.Job_Salary.ToString(), data.JobTable.Job_JoinDate, data.DepartmentTable.Department_Name,
                    data.ProfilePicture, data.Id, data.Job_ID, data.Department_ID);

                AssignProperties(em);
            }

            ShowEmployeeDetailsTable();      
            AddOffset();
        }

        protected void RefIDValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
                ShowNotification(false);

                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
                if (CheckIfInDatabase(args.Value))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    ShowNotification(false);

                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }

        private void AddToDatabase()
        {
            Employee e = (Employee)Session["Employee"];
            EditDatabase(e.id);

            ExtensionMethods.ClearTextBoxes(Page);
            ShowNotification(true);
        }

        protected void ApplyChangeBtn_Click(object sender, EventArgs e)
        {
            if (UserControlEdit.InputPicture.PostedFile.FileName == "")
            {
                AddToDatabase();
            }
        }

        protected void UploadPicValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (UserControlEdit.InputPicture.PostedFile == null)
                return;
            
            if (UserControlEdit.InputPicture.PostedFile.FileName != "")
            {
                if (UserControlEdit.InputPicture.FileName.Contains(".png")
                    || UserControlEdit.InputPicture.FileName.Contains(".jpg"))
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