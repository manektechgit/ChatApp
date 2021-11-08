using DotNetCoreMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Repository
{
    public class AuthenticationRepository
    {
        public int Registration(UserRegister Register)
        {
            UserRegister objUsers = new Models.UserRegister();
            DataTable dtUser = new DataTable();
            int ResultCode = -1;
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@UserName", Register.UserName);
            objParameter[1] = new SqlParameter("@Email", Register.Email);
            string HashPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Register.Password));
            objParameter[2] = new SqlParameter("@Password", HashPassword);
            objParameter[3] = new SqlParameter("@Mobile", Register.MobileNumber);

            Common.SqlHelper.Fill(dtUser, "[UserRegister]", objParameter);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }

            
        }


        public UserLogin UserLogin(string Email, string Password)
        {

            UserLogin objUsers = new UserLogin();
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@email", Email);
            string HashPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Password));
            objParameter[1] = new SqlParameter("@password", HashPassword);
            Common.SqlHelper.Fill(dtUser, "[UserLogin]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    objUsers.UserId = Convert.ToInt32(row["UserId"]);
                    objUsers.Email = Convert.ToString(row["Email"]);
                    objUsers.UserName = Convert.ToString(row["UserName"]);
                    objUsers.Password = Convert.ToString(row["Password"]);
                    objUsers.MobileNumber = Convert.ToString(row["Mobile"]);
                    objUsers.Facebook = row["Facebook"] is DBNull?"": Convert.ToString(row["Facebook"]);
                    objUsers.Twitter = row["Twitter"] is DBNull ? "" : Convert.ToString(row["Twitter"]);
                    objUsers.Instagram = row["Instagram"] is DBNull ? "" : Convert.ToString(row["Instagram"]);
                    objUsers.Snapchat   = row["Snapchat"] is DBNull ? "" : Convert.ToString(row["Snapchat"]);
                    objUsers.ProfileImage   = row["ProfileImage"] is DBNull ? "" : Convert.ToString(row["ProfileImage"]);
                }
            }
            return objUsers;
        }
        public int UserLogout(string UserId)
        {
            DataTable dtUser = new DataTable(); int ResultCode = -1;
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtUser, "[UserLogout]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }

        internal int SaveUserInfo(UserLogin saveUInfo)
        {
            throw new NotImplementedException();
        }
    }
}
