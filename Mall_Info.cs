using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace badpj_integration_trial4
{
    public class Mall_Info
    {
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        private string _mallID = null;
        private string _mallName = "";
        private string _mallLocation = "";
        private string _mallImage = "";
        private string _outletName = "";
        private string _outletCode = "";
        private int _outletSeatNo = 0;
        private string _outletImage = "";

        // Default constructor
        public Mall_Info()
        {
        }

        // Constructor that take in all data required to build a Mall object
        public Mall_Info(string mallID, string mallName, string mallLocation, string mallImage, string outletName, string outletCode, int outletSeatNo, string outletImage)
        {
            _mallID = mallID;
            _mallName = mallName;
            _mallLocation = mallLocation;
            _mallImage = mallImage;
            _outletName = outletName;
            _outletCode = outletCode;
            _outletSeatNo = outletSeatNo;
            _outletImage = outletImage;
        }

        // Constructor that take in all except Mall ID
        public Mall_Info(string mallName, string mallLocation, string mallImage, string outletName, string outletCode, int outletSeatNo, string outletImage)
            : this(null, mallName, mallLocation, mallImage, outletName, outletCode, outletSeatNo, outletImage)
        {
        }

        // Constructor that take in only Mall ID. The other attributes will be set to empty or 0.
        public Mall_Info(string mallID)
            : this(mallID, "", "", "", "", "", 0, "")
        {
        }

        // Get/Set the attributes of the Mall object.
        // Note the attribute name (e.g. Mall_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string Mall_ID
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
        public string Outlet_Name
        {
            get { return _outletName; }
            set { _outletName = value; }
        }
        public string Outlet_Code
        {
            get { return _outletCode; }
            set { _outletCode = value; }
        }
        public int Outlet_SeatNo
        {
            get { return _outletSeatNo; }
            set { _outletSeatNo = value; }
        }
        public string Outlet_Image
        {
            get { return _outletImage; }
            set { _outletImage = value; }
        }

        //Below as the Class methods for some DB operations. 
        public Mall_Info getMall(string mall_ID)
        {

            Mall_Info mallDetail = null;

            string mall_Name, mall_Location, mall_Image, outlet_Name, outlet_Code, outlet_Image;
            int outlet_SeatNo;

            string queryStr = "SELECT * FROM Mall_Info WHERE Mall_ID = @MallID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@MallID", mall_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                mall_Name = dr["Mall_Name"].ToString();
                mall_Location = dr["Mall_Location"].ToString();
                mall_Image = dr["Mall_Image"].ToString();
                outlet_Name = dr["Outlet_Name"].ToString();
                outlet_Code = dr["Outlet_Code"].ToString();
                outlet_SeatNo = int.Parse(dr["Outlet_SeatNo"].ToString());
                outlet_Image = dr["Outlet_Image"].ToString();

                mallDetail = new Mall_Info(mall_ID, mall_Name, mall_Location, mall_Image, outlet_Name, outlet_SeatNo, outlet_Image);
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
        public List<Mall_Info> getMallAll()
        {
            List<Mall_Info> mallList = new List<Mall_Info>();

            string mall_ID, mall_Name, mall_Location, mall_Image, outlet_Name, outlet_Code, outlet_Image;
            int outlet_SeatNo;

            string queryStr = "SELECT * FROM Mall_Info Order By Mall_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                mall_ID = dr["Mall_ID"].ToString();
                mall_Name = dr["Mall_Name"].ToString();
                mall_Location = dr["Mall_Location"].ToString();
                mall_Image = dr["Mall_Location"].ToString();
                outlet_Name = dr["Outlet_Name"].ToString();
                outlet_Code = dr["Outlet_Code"].ToString();
                outlet_SeatNo = int.Parse(dr["Outlet_SeatNo"].ToString());
                outlet_Image = dr["Outlet_Image"].ToString();
                Mall_Info a = new Mall_Info(mall_ID, mall_Name, mall_Location, mall_Image, outlet_Name, outlet_Code, outlet_SeatNo, outlet_Image);
                mallList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return mallList;
        }

    }
}