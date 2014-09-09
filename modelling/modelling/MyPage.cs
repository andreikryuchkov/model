﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace modelling
{
    public partial class MyPage : Page
    {

        public SqlCommand baseConnect()
        {
            SqlConnection c = new SqlConnection();
            SqlCommand q = new SqlCommand();
            c.ConnectionString = (new config()).dataBaseConnectionString;
            c.Open();
            q.Connection = c;
            return q;
        }

    }

    public partial class MyMasterPage : MasterPage
    {

        public SqlCommand baseConnect()
        {
            SqlConnection c = new SqlConnection();
            SqlCommand q = new SqlCommand();
            c.ConnectionString = (new config()).dataBaseConnectionString;
            c.Open();
            q.Connection = c;
            return q;
        }

    }
}