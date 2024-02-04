using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace project1.Models
{
    public class DataLayer
    {
        static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["Connstr"].ConnectionString;
        System.Data.SqlClient.SqlDataReader dr;

        public int create_employee(emplyeename model)

        {
            int ErrorCode = 0;
            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("SP_create_employee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name_of_employee", SqlDbType.Int).Value = model.name_of_employee;
                    cmd.Parameters.Add("@login_id", SqlDbType.VarChar).Value = model.login_id;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = model.password;
                    cmd.Parameters.Add("@ErrorCode", SqlDbType.Int).Value = 0;

                    con.Open();

                    cmd.ExecuteNonQuery();
                    

                }
            }
            return ErrorCode;

        }

        public DataTable GetAllEmployee(int EMPId)
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connstr))
            {
                using (var cmd = new SqlCommand("GetAllemployee", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);

                    throw new NotImplementedException();


                }
                return dt;
            }

        }
    }


}