using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
namespace badpj_integration_trial4
{
    public class Manager
    {
        private string _managerID = null;
        private string _Name = "";
        private string _MallName = "";
        private string _Password = "";

        string _connStr = ConfigurationManager.ConnectionStrings["CrowdfeedDTB"].ConnectionString;

        public Manager(string managerID, string name, string mallName, string password)
        {
            _managerID = managerID;
            _Name = name;
            _MallName = mallName;
            _Password = password;
        }

        public Manager()
        {
        }

        public string Manager_ID
        {
            get { return _managerID; }
            set { _managerID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Mall_Name
        {
            get { return _MallName; }
            set { _MallName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }


        public Manager getManager(string managerID)
        {

            Manager managerDetail = null;

            string Name, MallName, Password;

            string queryStr = "SELECT * FROM Managers WHERE Manager_ID = @managerID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@managerID", managerID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Name = dr["Name"].ToString();
                MallName = dr["Mall_Name"].ToString();
                Password = ConvertToEncrypt(dr["Password"].ToString());

                managerDetail = new Manager(managerID, Name, MallName, Password);
            }
            else
            {
                managerDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return managerDetail;
        }

        public List<Manager> getManagerAll()
        {
            List<Manager> managerList = new List<Manager>();

            string Name, MallName, Password, managerID;

            string queryStr = "SELECT * FROM Managers Order By Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                managerID = dr["Manager_ID"].ToString();
                Name = dr["Name"].ToString();
                MallName = dr["Mall_Name"].ToString();
                Password = ConvertToEncrypt(dr["Password"].ToString());
                Manager a = new Manager(managerID, Name, MallName, Password);
                managerList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return managerList;
        }
        public int ManagerInsert()
        {

            int result = 0;

            string queryStr = "INSERT INTO Managers(Manager_ID, Name, Mall_Name, Password) "
                            + " VALUES (@Manager_ID, @Name, @MallName, @Password) ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Manager_ID", this.Manager_ID);
            cmd.Parameters.AddWithValue("@Name", this.Name);
            cmd.Parameters.AddWithValue("@MallName", this.Mall_Name);
            cmd.Parameters.AddWithValue("@Password", this.Password);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

        public int ManagerDelete(string ID)
        {
            string queryStr = "DELETE FROM Managers WHERE Manager_ID=@ID";
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

        public int ManagerUpdate(string Id, string Name, string MallName, string Password)
        {
            {
                string queryStr = "UPDATE Managers SET" +
                   " Name = @Name," + " Mall_Name = @MallName," + " Password = @Password" +
                    " WHERE Manager_ID = @managerID";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@managerID", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@MallName", MallName);
                cmd.Parameters.AddWithValue("@Password", Password);

                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;
            }//end Update
        }

        public static string Key = "adef@@kfxcbv@";

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}