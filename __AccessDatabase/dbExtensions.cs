using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

// this fixes extension methods in .NET 2.0 
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ExtensionAttribute : Attribute
    {
    }
}

namespace __AccessDatabase
{


    public static class dbExtensions
    {


        public static bool TableExists(this MySql.Data.MySqlClient.MySqlDataAdapter myAdapter, string tableName)
        {
            bool result = false;
            string bufferForOldConnection = myAdapter.SelectCommand.CommandText; // we want to return the object to its original connection, so we must push here, and then pop at the bottom.  

            // string strCheckTable = String.Format("IF OBJECT_ID('{0}', 'U') IS NOT NULL SELECT 'true' ELSE SELECT 'false'", tableName);

            string strCheckTable = String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}'", tableName);
            


            myAdapter.SelectCommand.CommandText = strCheckTable;

            try
            {
                myAdapter.SelectCommand.Connection.Open();

                Int64 queryResult = (Int64)myAdapter.SelectCommand.ExecuteScalar();

                if (queryResult > 0)
                    result = true;
                else
                    result = false;

                myAdapter.SelectCommand.Connection.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "\n\nAlso remember, don't try to use this extension on an adapter that's already open.");
            }
                myAdapter.SelectCommand.CommandText = bufferForOldConnection;   // pop
                return result;

        }

    }
}


