using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIdentity
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    ListItem listItem = new ListItem("Admin");
            //    ListItem listItem1 = new ListItem("Normal");
            //    DropDownList1.Items.Add(listItem);
            //    DropDownList1.Items.Add(listItem1);
            //}
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {

            if (Password2.Value != ConfirmPassword2.Value)
            {
                StatusMessage.Text = "Password is not identical";
                return;
            }

            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser()
            {
                UserName = Username2.Value
            };
           
            IdentityResult result = manager.Create(user, Password2.Value);

            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            
            
            if (!roleManager.RoleExists(DropDownList1.SelectedValue))
            roleManager.Create(new IdentityRole(DropDownList1.SelectedValue));

            if (result.Succeeded)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                //authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                manager.AddToRole(user.Id, DropDownList1.SelectedValue.ToString());

                Response.Redirect("~/Pages/Login.aspx");
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }


        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Login.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList1.BackColor = System.Drawing.Color.FromArgb(0, DropDownList1.BackColor.R, DropDownList1.BackColor.G, DropDownList1.BackColor.B);
        }
    }
}