using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocViewer_SqlServerEdition.Model
{    
    class SqlAdapter
    {
        string CONNECTION_STRING;

        public SqlAdapter(UserSettings userSettings)
        {
            CONNECTION_STRING = userSettings.SqlConnectionString;
        }

        
        public void PullInstructionFromSql(string partNumber, ref Document document)
        {
            string _query = "SELECT " + partNumber + " FROM PaintingInstructions";

            DataTable dataTable = new DataTable();

            // ToDo : Code connection to database and extaction of proper document
            SqlConnection SqlConn = new SqlConnection(CONNECTION_STRING);
            SqlCommand SqlCmd = new SqlCommand(_query, SqlConn);
            SqlConn.Open();

            SqlDataAdapter dA = new SqlDataAdapter();
            dA.Fill(dataTable);
            SqlConn.Close();
            dA.Dispose();

           foreach( DataRow dr in dataTable.Rows)
            {
                document.Id = Convert.ToInt32(dr["Id"]);
                document.PartNumber = Convert.ToString(dr["PartNumber"]);
                document.PartDescription = Convert.ToString(dr["PartDescritpion"]);
                document.LoadingDocumentName = Convert.ToString(dr["DocumentLoadingArea"]);
                document.UnloadingDocumentName = Convert.ToString(dr["DocumentUnloadingArea"]);

            }

        }

    }
}
