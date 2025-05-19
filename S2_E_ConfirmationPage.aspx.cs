using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class S2_E_ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionPart1 transac = new TransactionPart1();
            string transac_id = Session["transac_id"].ToString();
            TransactionPart1 transac_info = transac.getTransaction(transac_id);
            lbl_TransactionID.Text = transac_info.Transaction_ID.ToString();
        }
    }
}