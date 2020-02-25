using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class ParentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ToString();

        public SqlConnection Connection { get; set; }
        public string Query { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public ParentGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}