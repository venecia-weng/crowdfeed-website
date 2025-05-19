using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace badpj_integration_trial4
{
    public class TransactionPart2
    {
        //Private string _connStr = Properties.Settings.Default.DBConnStr;

        //System.Configuration.ConnectionStringSettings _connStr;
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        private string _transacID = null;
        private int _transacCardNo = 0;
        private string _transacExpiryDate = "";
        private int _transacCVC = 0;

        // Default constructor
        public TransactionPart2()
        {
        }

        // Constructor that take in all data required to build a Product object
        public TransactionPart2(string transacID, int transacCardNo, string transacExpiryDate,
                       int transacCVC)
        {
            _transacID = transacID;
            _transacCardNo = transacCardNo;
            _transacExpiryDate = transacExpiryDate;
            _transacCVC = transacCVC;
        }

        // Constructor that take in all except product ID
        public TransactionPart2(int transacCardNo, string transacExpiryDate,
                       int transacCVC)
            : this(null, transacCardNo, transacExpiryDate, transacCVC)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public TransactionPart2(string transacID)
            : this(transacID, 0, "", 0)
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string Transaction_ID
        {
            get { return _transacID; }
            set { _transacID = value; }
        }
        public int Transaction_CardNo
        {
            get { return _transacCardNo; }
            set { _transacCardNo = value; }
        }

        public string Transaction_ExpiryDate
        {
            get { return _transacExpiryDate; }
            set { _transacExpiryDate = value; }
        }

        public int Transaction_CVC
        {
            get { return _transacCVC; }
            set { _transacCVC = value; }
        }

        //Below as the Class methods for some DB operations. 
        public TransactionPart2 getPurchase(string transacID)
        {

            TransactionPart2 purchDetail = null;

            string transacExpiryDate;
            int transacCardNo, transacCVC;

            string queryStr = "SELECT * FROM Transactions_Part2 WHERE Transaction_ID = @TransacID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@TransacID", transacID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                transacCardNo = int.Parse(dr["Transaction_CardNo"].ToString());
                transacExpiryDate = dr["Transaction_Manager"].ToString();
                transacCVC = int.Parse(dr["Transaction_CVC"].ToString());

                purchDetail = new TransactionPart2(transacID, transacCardNo, transacExpiryDate, transacCVC);
            }
            else
            {
                purchDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return purchDetail;
        }

        public List<TransactionPart2> getPurchaseAll()
        {
            List<TransactionPart2> purchList = new List<TransactionPart2>();

            string transacExpiryDate, transac_ID;
            int transacCardNo, transacCVC;

            string queryStr = "SELECT * FROM Transactions_Part2 Order By Transaction_CardNo";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transac_ID = dr["Transaction_ID"].ToString();
                transacCardNo = int.Parse(dr["Transaction_CardNo"].ToString());
                transacExpiryDate = dr["Transaction_ExpiryDate"].ToString();
                transacCVC = int.Parse(dr["Transaction_CVC"].ToString());
                TransactionPart2 a = new TransactionPart2(transac_ID, transacCardNo, transacExpiryDate, transacCVC);
                purchList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return purchList;
        }

        public int S2_E_TransactionInsertPart2()
        {
            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Transactions_Part2(Transaction_ID, Transaction_CardNo, Transaction_ExpiryDate, Transaction_CVC)"
                + " values (@Transaction_ID,@Transaction_CardNo, @Transaction_ExpiryDate, @Transaction_CVC)";
            //+ "values (@Transaction_ID, @Transaction_CardNo, @Transaction_ExpiryDate, @Transaction_CVC)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Transaction_ID", this.Transaction_ID);
            cmd.Parameters.AddWithValue("@Transaction_CardNo", this.Transaction_CardNo);
            cmd.Parameters.AddWithValue("@Transaction_ExpiryDate", this.Transaction_ExpiryDate);
            cmd.Parameters.AddWithValue("@Transaction_CVC", this.Transaction_CVC);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;

        }//end Insert

        public int TransactionDelete(string ID)
        {
            string queryStr = "DELETE FROM Transactions_Part2 WHERE Transaction_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete

    }
}