using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

//namespace Addressbook
//{
    public class DatabaseConfig
    {
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.ToString();
    }
//}