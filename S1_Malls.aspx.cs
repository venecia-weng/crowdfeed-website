using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace badpj_integration_trial4
{
    public partial class S1_Malls : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;

        Mall aMall = new Mall();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Mall> mallList = new List<Mall>();
            mallList = aMall.getMallAll();
            MallInfoRepeater.DataSource = mallList;
            MallInfoRepeater.DataBind();
        }
    }
}