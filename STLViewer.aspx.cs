using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STL
{
    public partial class STLViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected string StlUrl
        {
            get { return "https://Statusdent.com/StatusPhoto/יבגני_ביליק00003289970101.stl"; }
        }
    }
}