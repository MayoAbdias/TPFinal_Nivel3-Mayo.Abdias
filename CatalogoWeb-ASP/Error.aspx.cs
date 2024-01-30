using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb_ASP
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["error"] != null)
                {
                    lblMensaje.Text = Session["error"].ToString();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
           
        }
    }
}