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
                SelectedMenuItem();

                if (HttpContext.Current.User.Identity.Name != null)
                    username_text.InnerText = "Welcome, " +HttpContext.Current.User.Identity.Name;
                else
                    username_text.InnerText = "None";

                //If user is not admin, disable menu items 
                if (!HttpContext.Current.User.IsInRole("Admin"))
                {
                    foreach (MenuItem mi in Menu1.Items)
                    {
                        if (mi.Text == "Manage Positions" ||
                            mi.Text == "Manage Departments" ||
                            mi.Text == "Edit Employee" ||
                            mi.Text == "Employee List"
                            )
                        {
                            mi.Enabled = false;
                            mi.Selected = false;
                            mi.Selectable = false;
                        }
                    }
                }
            }
        }

        //Show previously selected menu item
        private void SelectedMenuItem()
        {
            foreach (MenuItem mi in Menu1.Items)
            {
                string s = mi.NavigateUrl.ToLower();
                if (Request.Url.AbsoluteUri.ToLower().Contains(Page.ResolveUrl(s)))
                {
                    mi.Selected = true;
                }
            }
        }

        //Sign out event
        protected void Sign_Out(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}