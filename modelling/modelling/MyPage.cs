using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace modelling
{
    public class ClassToWorckWhithSQL 
    {
        public SqlCommand baseConnect()
        {
            SqlCommand q = new SqlCommand();
            SqlConnection c = new SqlConnection((new config()).dataBaseConnectionString);
            c.Open();
            q.Connection = c;
            return q;
        }

        public SqlCommand SqlCommand 
        {
            get 
            {
                if (TextCommand != null || TextCommand != "")
                {
                    SqlCommand q = new SqlCommand();
                    q = baseConnect();
                    q.CommandText = TextCommand;
                    return q;
                }
                else 
                {
                    return null;
                }
            }
        }

        private string textCommand;
        public string TextCommand 
        {
            get { return textCommand; }
            set 
            {
                if (value != textCommand) 
                {
                    textCommand = value;
                }
            }
        }

        public SqlDataReader ExecuteReader
        {
            get { return SqlCommand.ExecuteReader(); }
        }

        public bool ExecuteNonQuery
        {
            get { SqlCommand.ExecuteNonQuery(); return true; }
        }
    }
}