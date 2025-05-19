using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class S3_A_MallDetails : System.Web.UI.Page
    {
        Mall mall = null;
        Outlet aOutlet = new Outlet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

            Mall aMall = new Mall();

            if (Request.QueryString["Mall_ID"] == null)
            {
                Response.Redirect("S3_A_MallView.aspx");
            }
            int mall_ID = Convert.ToInt32(Request.QueryString["Mall_ID"]);
            mall = aMall.getMall(mall_ID);

            lbl_MallName.Text = mall.Mall_Name;
            lbl_MallLocation.Text = mall.Mall_Location;
            img_MallImage.ImageUrl = "~\\Imgs\\" + mall.Mall_Image;

            lbl_MallID.Text = mall_ID.ToString();
        }

        protected void bind()
        {
            int mall_ID = Convert.ToInt32(Request.QueryString["Mall_ID"]);
            List<Outlet> outletList = new List<Outlet>();
            outletList = aOutlet.getOutlet(mall_ID);
            gvOutlet.DataSource = outletList;
            gvOutlet.DataBind();
        }

        protected void gvOutlet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOutlet.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvOutlet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Outlet outlet = new Outlet();
            string mallID = gvOutlet.DataKeys[e.RowIndex].Values[0].ToString();
            string outletName = gvOutlet.DataKeys[e.RowIndex].Values[1].ToString();
            result = outlet.OutletDelete(mallID, outletName);

            if (result > 0)
            {
                Response.Write("<script>alert('Outlet deleted successfully');</script>");
                gvOutlet.DataBind(); // Reload the data for the GridView
            }
            else
            {
                Response.Write("<script>alert('Outlet NOT deleted successfully');</script>");
            }

        }

        protected void gvOutlet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOutlet.EditIndex = -1;
            bind();
        }

        protected void gvOutlet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Outlet outlet = new Outlet();
            GridViewRow row = (GridViewRow)gvOutlet.Rows[e.RowIndex];
            string mID = gvOutlet.DataKeys[e.RowIndex].Values["Mall_ID"].ToString();
            string oName = gvOutlet.DataKeys[e.RowIndex].Values["Outlet_Name"].ToString();
            string mallID = ((TextBox)row.Cells[0].Controls[0]).Text;
            string outletName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string outletCode = ((TextBox)row.Cells[2].Controls[0]).Text;
            string outletSeatNo = ((TextBox)row.Cells[3].Controls[0]).Text;

            result = outlet.OutletUpdate(mallID, outletName, outletCode, int.Parse(outletSeatNo));
            if (result > 0)
            {
                Response.Write("<script>alert('Product updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product NOT updated');</script>");
            }
            gvOutlet.EditIndex = -1;
            bind();

        }
    }
}