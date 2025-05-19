using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace badpj_integration_trial4
{
    public partial class S3_E_TransactionView : System.Web.UI.Page
    {
        TransactionPart1 aTransac = new TransactionPart1();

        TransactionPart2 aPurch = new TransactionPart2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<TransactionPart1> transacList = new List<TransactionPart1>();
            transacList = aTransac.getTransactionAll();
            gvTransaction_Part1.DataSource = transacList;
            gvTransaction_Part1.DataBind();

            List<TransactionPart2> purchList = new List<TransactionPart2>();
            purchList = aPurch.getPurchaseAll();
            gvTransaction_Part2.DataSource = purchList;
            gvTransaction_Part2.DataBind();
        }

        protected void gvTransaction_Part1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTransaction_Part1.SelectedRow;

            string transacID = row.Cells[0].Text;
        }

        protected void gvTransaction_Part1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            TransactionPart1 transac = new TransactionPart1();
            string categoryID = gvTransaction_Part1.DataKeys[e.RowIndex].Value.ToString();
            result = transac.TransactionDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Transaction Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Transaction Removal NOT successfully');</script>");
            }

            Response.Redirect("S3_E_TransactionView.aspx");

        }

        protected void gvTransaction_Part2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTransaction_Part2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            TransactionPart2 transac = new TransactionPart2();
            string categoryID = gvTransaction_Part2.DataKeys[e.RowIndex].Value.ToString();
            result = transac.TransactionDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Transaction Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Transaction Removal NOT successfully');</script>");
            }

            Response.Redirect("S3_E_TransactionView.aspx");
        }

        protected void gvTransaction_Part1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTransaction_Part1.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvTransaction_Part1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTransaction_Part1.EditIndex = -1;
            bind();
        }

        protected void gvTransaction_Part1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TransactionPart1 transac = new TransactionPart1();
            GridViewRow row = (GridViewRow)gvTransaction_Part1.Rows[e.RowIndex];
            string id = gvTransaction_Part1.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tmanager = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tbizemail = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tmall = ((TextBox)row.Cells[3].Controls[0]).Text;
            string toutletsno = ((TextBox)row.Cells[4].Controls[0]).Text;
            string tsensorsno = ((TextBox)row.Cells[5].Controls[0]).Text;

            result = transac.TransactionUpdate(tid, tmanager, tbizemail, tmall, int.Parse(toutletsno), int.Parse(tsensorsno));
            if (result > 0)
            {
                Response.Write("<script>alert('Product updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product NOT updated');</script>");
            }
            gvTransaction_Part1.EditIndex = -1;
            bind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchField = ddlSearchField.SelectedValue;
            List<TransactionPart1> filteredTransactions = new List<TransactionPart1>();

            List<TransactionPart1> allTransactions = aTransac.getTransactionAll();
            foreach (TransactionPart1 transaction in allTransactions)
            {
                if (transaction.GetType().GetProperty(searchField).GetValue(transaction, null).ToString().Contains(searchText))
                {
                    filteredTransactions.Add(transaction);
                }

                if (filteredTransactions.Count == 0)
                {
                    lblMessage.Text = "No transactions were found that match the search criteria.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }

                else
                {
                    gvTransaction_Part1.DataSource = filteredTransactions;
                    gvTransaction_Part1.DataBind();
                }
            }
            gvTransaction_Part1.DataSource = filteredTransactions;
            gvTransaction_Part1.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("S3_E_TransactionView.aspx");

        }
    }



}