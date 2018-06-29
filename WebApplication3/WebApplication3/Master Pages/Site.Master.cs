using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                if (HttpContext.Current.User.Identity.Name != null)
                    username_text.InnerText = "Welcome, " + HttpContext.Current.User.Identity.Name;
                else
                    username_text.InnerText = "None";

                //If user is not admin, disable menu items
                if (!HttpContext.Current.User.IsInRole("Admin"))
                {
                    manage_departments_link.Visible = false;
                    manage_positions_link.Visible = false;
                    employee_edit_link.Visible = false;
                    employee_list_link.Visible = false;

                    //manage_positions_link.Disabled = true;
                }
            }
        }

        //Sign out event
        protected void Sign_Out(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}