using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace badpj_integration_trial4
{
    public class Mall
    {
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        private int _mallID = 0;
        private string _mallName = "";
        private string _mallLocation = "";
        private string _mallImage = "";

        public Mall()
        {
        }

        public Mall(int mallID, string mallName, string mallLocation, string mallImage)
        {
            _mallID = mallID;
            _mallName = mallName;
            _mallLocation = mallLocation;
            _mallImage = mallImage;
        }

        public Mall(string mallName, string mallLocation, string mallImage)
            : this(0, mallName, mallLocation, mallImage)
        {
        }

        public Mall(int mallID)
            : this(mallID, "", "", "")
        {
        }

        public int Mall_ID
        {
            get { return _mallID; }
            set { _mallID = value; }
        }
        public string Mall_Name
        {
            get { return _mallName; }
            set { _mallName = value; }
        }
        public string Mall_Location
        {
            get { return _mallLocation; }
            set { _mallLocation = value; }
        }
        public string Mall_Image
        {
            get { return _mallImage; }
            set { _mallImage = value; }
        }

        public Mall getMall(int mall_ID)
        {

            Mall mallDetail = null;

            string mall_Name, mall_Location, mall_Image;

            string queryStr = "SELECT * FROM Malls WHERE Mall_ID = @Mall_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", mall_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                mall_Name = dr["Mall_Name"].ToString();
                mall_Location = dr["Mall_Location"].ToString();
                mall_Image = dr["Mall_Image"].ToString();

                mallDetail = new Mall(mall_ID, mall_Name, mall_Location, mall_Image);
            }
            else
            {
                mallDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return mallDetail;
        }

        public List<Mall> getMallAll()
        {
            List<Mall> mallList = new List<Mall>();

            string mall_Name, mall_Location, mall_Image;
            int mall_ID;

            string queryStr = "SELECT * FROM Malls Order By Mall_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                mall_ID = int.Parse(dr["Mall_ID"].ToString());
                mall_Name = dr["Mall_Name"].ToString();
                mall_Location = dr["Mall_Location"].ToString();
                mall_Image = dr["Mall_Image"].ToString();
                Mall a = new Mall(mall_ID, mall_Name, mall_Location, mall_Image);
                mallList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return mallList;
        }

        public int MallInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Malls(Mall_Name, Mall_Location, Mall_Image)" + " values (@Mall_Name, @Mall_Location, @Mall_Image)";

            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@Mall_Name", this.Mall_Name);
                cmd.Parameters.AddWithValue("@Mall_Location", this.Mall_Location);
                cmd.Parameters.AddWithValue("@Mall_Image", this.Mall_Image);

                conn.Open();
                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                conn.Close();

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int MallDelete(string Mall_ID)
        {
            string queryStr = "DELETE FROM Malls WHERE Mall_ID=@Mall_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", Mall_ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete


        public int MallUpdate(string mId, string mName, string mLocation)
        {
            string queryStr = "UPDATE Malls SET" + " Mall_Name = @Mall_Name, " + " Mall_Location = @Mall_Location " + " WHERE Mall_ID = @Mall_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", mId);
            cmd.Parameters.AddWithValue("@Mall_Name", mName);
            cmd.Parameters.AddWithValue("@Mall_Location", mLocation);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

    }

}