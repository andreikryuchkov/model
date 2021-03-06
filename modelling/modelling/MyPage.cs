﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;


namespace modelling
{

    public class ClassToWorckWhithSQL : INotifyPropertyChanged
    {
        public string GetMD5Hash(string input)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (var b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
        #region [ Initialise ]

        public ClassToWorckWhithSQL() 
        {
        }

        #endregion [ Initialise ]

        #region [ Property ]

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
                    OnPropertyChanged("TextCommand");
                }
            }
        }

        private SqlDataReader reader;
        public SqlDataReader Reader 
        {
            get { return reader; }
            set 
            {
                if (value != reader) 
                {
                    reader = value;
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

        #endregion [ Property ]

        #region [ Method ]

        public SqlCommand baseConnect()
        {
            SqlCommand q = new SqlCommand();
            SqlConnection c = new SqlConnection((new config()).dataBaseConnectionString);
            c.Open();
            q.Connection = c;
            return q;
        }

        
        public string GetStringValueReader(int num)
        {
            return Reader.GetValue(num).ToString();
        }

        private void makeReader() 
        {
            Reader = ExecuteReader;
        }

        #endregion [ Method ]

        #region [ Обработка событий ]

        #region [ System ]

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (e.PropertyName == "TextCommand")
            {
                OnTextCommandChanged();
            }
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion [ System ]

        #region [ Свои обработчики ]

        protected void OnTextCommandChanged() 
        {
            makeReader();
        }

        #endregion [ Свои обработчики ]

        #endregion [ Обработка событий ]
    }

}