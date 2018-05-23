using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectedMenuItem();
            }
        }

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
    }
}