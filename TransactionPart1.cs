using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace badpj_integration_trial4
{
    public class TransactionPart1
    {
        //Private string _connStr = Properties.Settings.Default.DBConnStr;

        //System.Configuration.ConnectionStringSettings _connStr;
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        private string _transacID = null;
        private string _transacManager = string.Empty;
        private string _transacBizEmail = ""; // this is another way to specify empty string
        private string _transacMall = "";
        private int _transacOutletsNo = 0;
        private int _transacSensorsNo = 0;

        // Default constructor
        public TransactionPart1()
        {
        }

        // Constructor that take in all data required to build a Product object
        public TransactionPart1(string transacID, string transacManager, string transacBizEmail,
                       string transacMall, int transacOutletsNo, int transacSensorsNo)
        {
            _transacID = transacID;
            _transacManager = transacManager;
            _transacBizEmail = transacBizEmail;
            _transacMall = transacMall;
            _transacOutletsNo = transacOutletsNo;
            _transacSensorsNo = transacSensorsNo;
        }

        // Constructor that take in all except product ID
        public TransactionPart1(string transacManager,
               string transacBizEmail, string transacMall, int transacOutletsNo, int transacSensorsNo)
            : this(null, transacManager, transacBizEmail, transacMall, transacOutletsNo, transacSensorsNo)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public TransactionPart1(string transacID)
            : this(transacID, "", "", "", 0, 0)
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
        public string Transaction_Manager
        {
            get { return _transacManager; }
            set { _transacManager = value; }
        }
        public string Transaction_BizEmail
        {
            get { return _transacBizEmail; }
            set { _transacBizEmail = value; }
        }
        public string Transaction_Mall
        {
            get { return _transacMall; }
            set { _transacMall = value; }
        }
        public int Transaction_OutletsNo
        {
            get { return _transacOutletsNo; }
            set { _transacOutletsNo = value; }
        }
        public int Transaction_SensorsNo
        {
            get { return _transacSensorsNo; }
            set { _transacSensorsNo = value; }
        }

        //Below as the Class methods for some DB operations. 
        public TransactionPart1 getTransaction(string transacID)
        {

            TransactionPart1 transacDetail = null;

            string transac_Manager, transacBizEmail, transacMall;
            int transacOutletsNo, transacSensorsNo;

            string queryStr = "SELECT * FROM Transactions_Part1 WHERE Transaction_ID = @TransacID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@TransacID", transacID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                transac_Manager = dr["Transaction_Manager"].ToString();
                transacBizEmail = dr["Transaction_BizEmail "].ToString();
                transacMall = dr["Transaction_Mall"].ToString();
                transacOutletsNo = int.Parse(dr["Transaction_OutletsNo"].ToString());
                transacSensorsNo = int.Parse(dr["Transaction_SensorsNo"].ToString());

                transacDetail = new TransactionPart1(transacID, transac_Manager, transacBizEmail, transacMall, transacOutletsNo, transacSensorsNo);
            }
            else
            {
                transacDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return transacDetail;
        }

        public List<TransactionPart1> getTransactionAll()
        {
            List<TransactionPart1> transacList = new List<TransactionPart1>();

            string transac_Manager, transacBizEmail, transacMall, transac_ID;
            int transacOutletsNo, transacSensorsNo;

            string queryStr = "SELECT * FROM Transactions_Part1 Order By Transaction_Manager";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                transac_ID = dr["Transaction_ID"].ToString();
                transac_Manager = dr["Transaction_Manager"].ToString();
                transacBizEmail = dr["Transaction_BizEmail "].ToString();
                transacMall = dr["Transaction_Mall"].ToString();
                transacOutletsNo = int.Parse(dr["Transaction_OutletsNo"].ToString());
                transacSensorsNo = int.Parse(dr["Transaction_SensorsNo"].ToString());
                TransactionPart1 a = new TransactionPart1(transac_ID, transac_Manager, transacBizEmail, transacMall, transacOutletsNo, transacSensorsNo);
                transacList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return transacList;
        }

        public int S1_E_TransactionInsert()
        {
            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Transactions_Part1(Transaction_ID, Transaction_Manager, Transaction_BizEmail, Transaction_Mall, Transaction_OutletsNo , Transaction_SensorsNo)"
        + " values (@Transaction_ID,@Transaction_Manager, @Transaction_BizEmail, @Transaction_Mall, @Transaction_OutletsNo, @Transaction_SensorsNo)";
            //+ "values (@Transaction_ID, @Transaction_Manager, @Transaction_BizEmail, @Transaction_Mall, @Transaction_OutletsNo,@Transaction_SensorsNo)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Transaction_ID", this.Transaction_ID);
            cmd.Parameters.AddWithValue("@Transaction_Manager", this.Transaction_Manager);
            cmd.Parameters.AddWithValue("@Transaction_BizEmail ", this.Transaction_BizEmail);
            cmd.Parameters.AddWithValue("@Transaction_Mall", this.Transaction_Mall);
            cmd.Parameters.AddWithValue("@Transaction_OutletsNo", this.Transaction_OutletsNo);
            cmd.Parameters.AddWithValue("@Transaction_SensorsNo", this.Transaction_SensorsNo);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;


        }//end Insert

        public int TransactionDelete(string ID)
        {
            string queryStr = "DELETE FROM Transactions_Part1 WHERE Transaction_ID=@ID";
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

        public int TransactionUpdate(string pId, string pManager, string pBizEmail, string pMall, int pOutletsNo, int pSensorsNo)
        {
            string queryStr = "UPDATE Transactions_Part1 SET" +
           //" Transaction_ID = @transactionID, " +
           " Transaction_Manager = @transactionManager, " +
           " Transaction_BizEmail = @transactionBizEmail, " +
           " Transaction_Mall = @transactionMall, " +
           " Transaction_OutletsNo = @transactionOutletsNo, " +
           " Transaction_SensorsNo  = @transactionSensorsNo " +
           " WHERE Transaction_ID = @transactionID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@transactionID", pId);
            cmd.Parameters.AddWithValue("@transactionManager", pManager);
            cmd.Parameters.AddWithValue("@transactionBizEmail", pBizEmail);
            cmd.Parameters.AddWithValue("@transactionMall", pMall);
            cmd.Parameters.AddWithValue("@transactionOutletsNo", pOutletsNo);
            cmd.Parameters.AddWithValue("@transactionSensorsNo", pSensorsNo);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;

        }//end Update

    }
}