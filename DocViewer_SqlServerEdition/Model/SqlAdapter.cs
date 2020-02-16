using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DocViewer_SqlServerEdition.Model
{    
    class SqlAdapter
    {
        string CONNECTION_STRING;

        // Constr
        public SqlAdapter(UserSettings userSettings)
        {
            CONNECTION_STRING = userSettings.SqlConnectionString;
        }

        // GET 
        public void PullInstructionFromSql(string partNumber, ref Document document)
        {          
            string _query = "SELECT * FROM PaintingInstructions WHERE PartNumber = '" + partNumber + "'";

            SqlConnection SqlConn = new SqlConnection(CONNECTION_STRING);
            SqlCommand SqlCmd = new SqlCommand(_query, SqlConn);
            SqlConn.Open();

            SqlDataReader reader = SqlCmd.ExecuteReader();
            while(reader.Read())
            {
                document.Id = reader.GetInt32(0);
                document.PartNumber = reader.GetString(1);
                document.PartDescription = reader.GetString(2);
                document.LoadingDocumentName = reader.GetString(3);
                document.UnloadingDocumentName = reader.GetString(4);
            }
            SqlConn.Close();
        }

    }
}
