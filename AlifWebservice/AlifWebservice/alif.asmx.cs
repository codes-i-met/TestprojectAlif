using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dapper;
using Newtonsoft;
using System.Data.SqlClient;
using System.Configuration;
using AlifWebservice.Model;

using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace AlifWebservice
{
    /// <summary>
    /// Summary description for alif
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class alif : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
            
        }

          [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)] 
        public void   GetAllUsers()
        {
           List<User_Details> userdetails = new List<User_Details>  ();
              using (var sqlConnection = new SqlConnection(Connection.GetConnectionSql()))
                {
                   sqlConnection.Open();
                  userdetails = sqlConnection.Query<User_Details>("UserDetailsGetAll",null,System.Data.CommandType.StoredProcedure).ToList();
                   sqlConnection.Close(); 
                }            
              Context.Response.Clear();
              Context.Response.ContentType = "application/json";
              Context.Response.Write(JsonHelper.ToJson(userdetails));
               
        }
        [WebMethod]
          public void  SaveOrUpdateUser (string  userJson)
          {
              User_Details userDetails = (User_Details)Newtonsoft.Json.JsonConvert.DeserializeObject(userJson, typeof(User_Details));
              Status status = new Status();
              int User_Detial_ID;
              using (var sqlConnection = new SqlConnection(Connection.GetConnectionSql()))
              {
                  sqlConnection.Open();            

                  var parameters = new DynamicParameters();
                  parameters.Add("@User_Details_ID",userDetails.User_Details_ID,System.Data.DbType.Int32,System.Data.ParameterDirection.Input,null );
                  parameters.Add("@Name", userDetails.Name, System.Data.DbType.String, System.Data.ParameterDirection.Input, null);
                  parameters.Add("@Adress", userDetails.Adress, System.Data.DbType.String, System.Data.ParameterDirection.Input, null);
                  parameters.Add("@Contact_No", userDetails.Contact_No, System.Data.DbType.String, System.Data.ParameterDirection.Input, null);
                  parameters.Add("@Email_ID", userDetails.Email_ID, System.Data.DbType.String, System.Data.ParameterDirection.Input, null);
                  parameters.Add("@Password", userDetails.Password, System.Data.DbType.String, System.Data.ParameterDirection.Input, null);
                  parameters.Add("@User_ID",0, System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue,null);
                  User_Detial_ID = sqlConnection.Execute("UserRegistration", parameters, System.Data.CommandType.StoredProcedure);
                  User_Detial_ID = parameters.Get<int>("@User_ID");
                  sqlConnection.Close();
                  if (User_Detial_ID > 0)
                  {
                      status.Sucess = 1;
                      status.id = User_Detial_ID;
                  }
                  else
                      status.Sucess = 0;
                  Context.Response.Clear();
                  Context.Response.ContentType = "application/json";
                  Context.Response.Write(JsonHelper.ToJson(status)); 
                 

              }

          }
        [WebMethod]
        public void  DeleteUser(int userID)
        {
            int User_Deleted;
            Status status = new Status();
            using (var sqlConnection = new SqlConnection(Connection.GetConnectionSql()))
            {
                sqlConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@User_Details_ID", userID, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, null);
                parameters.Add("@User_Deleted", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, null);

                User_Deleted = sqlConnection.Execute("DeleteUser", parameters, System.Data.CommandType.StoredProcedure);
                User_Deleted = parameters.Get<int>("@User_Deleted");
                sqlConnection.Close();
                if (User_Deleted > 0)
                {
                    status.Sucess = 1;
                    status.id = userID;
                    
                }
                else
                    status.Sucess = 0;
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JsonHelper.ToJson(status));               

            }

        }
    }
    public class JsonHelper
    {
        /// <summary>
        /// Convert Object to Json String
        /// </summary>
        /// <param name="obj">The object to convert</param>
        /// <returns>Json representation of the Object in string</returns>
        public static string ToJson(object obj)
        {
          
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }

    public static class Connection
    {
      public static string  GetConnectionSql()
        {
            string cnnString = string.Empty;
            try
            {
                
                 cnnString = ConfigurationSettings.AppSettings["ConnectionString"];
              
                
            }
            catch (Exception ex)
            {

            }
            return cnnString;
        }
    }
     
}
