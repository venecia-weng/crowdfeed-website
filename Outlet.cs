using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace badpj_integration_trial4
{
    public class Outlet
    {
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        private int _mallID = 0;
        private string _outletName = "";
        private string _outletCode = "";
        private int _outletSeatNo = 0;
        private string _outletImage = "";

        public Outlet()
        {
        }

        public Outlet(int mallID, string outletName, string outletCode, int outletSeatNo, string outletImage)
        {
            _mallID = mallID;
            _outletName = outletName;
            _outletCode = outletCode;
            _outletSeatNo = outletSeatNo;
            _outletImage = outletImage;
        }

        public Outlet(string outletName, string outletCode, int outletSeatNo, string outletImage)
            : this(0, outletName, outletCode, outletSeatNo, outletImage)
        {
        }

        public Outlet(int mallID)
            : this(mallID, "", "", 0, "")
        {
        }

        public int Mall_ID
        {
            get { return _mallID; }
            set { _mallID = value; }
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

        public List<Outlet> getOutlet(int mall_ID)
        {

            List<Outlet> outletDetail = new List<Outlet>();

            string outlet_Name, outlet_Code, outlet_Image;
            int outlet_SeatNo;

            string queryStr = "SELECT * FROM Outlets WHERE Mall_ID = @Mall_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", mall_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                mall_ID = int.Parse(dr["Mall_ID"].ToString());
                outlet_Name = dr["Outlet_Name"].ToString();
                outlet_Code = dr["Outlet_Code"].ToString();
                outlet_SeatNo = int.Parse(dr["Outlet_SeatNo"].ToString());
                outlet_Image = dr["Outlet_Image"].ToString();
                Outlet a = new Outlet(mall_ID, outlet_Name, outlet_Code, outlet_SeatNo, outlet_Image);
                outletDetail.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return outletDetail;
        }

        public List<Outlet> getOutletAll()
        {
            List<Outlet> outletList = new List<Outlet>();

            string outlet_Name, outlet_Code, outlet_Image;
            int mall_ID, outlet_SeatNo;

            string queryStr = "SELECT * FROM Outlets Order By Mall_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                mall_ID = int.Parse(dr["Mall_ID"].ToString());
                outlet_Name = dr["Outlet_Name"].ToString();
                outlet_Code = dr["Outlet_Code"].ToString();
                outlet_SeatNo = int.Parse(dr["Outlet_SeatNo"].ToString());
                outlet_Image = dr["Outlet_Image"].ToString();
                Outlet a = new Outlet(mall_ID, outlet_Name, outlet_Code, outlet_SeatNo, outlet_Image);
                outletList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return outletList;
        }

        public int OutletInsert()
        {
            int result = 0;

            string queryStr = "SET IDENTITY_INSERT Outlets ON; " +
                      "INSERT INTO Outlets(Mall_ID, Outlet_Name, Outlet_Code, Outlet_SeatNo, Outlet_Image)" +
                      " values (@Mall_ID, @Outlet_Name, @Outlet_Code, @Outlet_SeatNo, @Outlet_Image); " +
                      "SET IDENTITY_INSERT Outlets OFF;";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", this.Mall_ID);
            cmd.Parameters.AddWithValue("@Outlet_Name", this.Outlet_Name);
            cmd.Parameters.AddWithValue("@Outlet_Code", this.Outlet_Code);
            cmd.Parameters.AddWithValue("@Outlet_SeatNo", this.Outlet_SeatNo);
            cmd.Parameters.AddWithValue("@Outlet_Image", this.Outlet_Image);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int OutletDelete(string Mall_ID, string Outlet_Name)
        {
            string queryStr = "DELETE FROM Outlets WHERE Mall_ID=@Mall_ID AND Outlet_Name=@Outlet_Name";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", Mall_ID);
            cmd.Parameters.AddWithValue("@Outlet_Name", Outlet_Name);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete

        public int OutletUpdate(string Mall_ID, string Outlet_Name, string Outlet_Code, int Outlet_SeatNo)
        {
            string queryStr = "UPDATE Outlets SET" + " Outlet_Code = @Outlet_Code, " + " Outlet_SeatNo = @Outlet_SeatNo " + " WHERE Mall_ID=@Mall_ID AND Outlet_Name=@Outlet_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", Mall_ID);
            cmd.Parameters.AddWithValue("@Outlet_Name", Outlet_Name);
            cmd.Parameters.AddWithValue("@Outlet_Code", Outlet_Code);
            cmd.Parameters.AddWithValue("@Outlet_SeatNo", Outlet_SeatNo);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

        public int OutletDeleteByMallID(string mallID)
        {
            string queryStr = "DELETE FROM Outlets WHERE Mall_ID=@Mall_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Mall_ID", Mall_ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;
        }
    }

}