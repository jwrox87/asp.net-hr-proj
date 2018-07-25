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
            //Ensure that cache is reset each time
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            //If no login id available, keep redirecting to login page
            if (Session["LoginId"] == null)
                Response.Redirect("~/Pages/Login.aspx");

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
                }
            }
        }

        //Sign out event
        protected void Sign_Out(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            Session.Clear();

            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}