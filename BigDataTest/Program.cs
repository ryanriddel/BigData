using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Google.Cloud.BigQuery.V2;
using System;
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using Google.Apis.Services;

using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;

namespace BigDataTest
{
    static class Program
    {

        static int Main(string[] args)
        {




            string projectID = "marketdatastorage";

            BigQueryClient client = BigQueryClient.Create(projectID);
            
            BigQueryDataset dataset = client.GetDataset("Test_Dataset");
           /* TableSchemaBuilder build = new TableSchemaBuilder();
            TableFieldSchema field = new TableFieldSchema();
            field.Name = "name";
            field.Type = "STRING";
            field.ETag = "RETA";

            build.Add(field);
            dataset.GetTable("RARA");*/

            BigQueryTable table = client.GetTable(projectID, "Test_Dataset", "RARA");

            TableReference tref = table.Reference;
            
            for (int i = 0; i < 50; i++)
            {
                BigQueryInsertRow newRow = new BigQueryInsertRow();
                newRow.Add("name", DateTime.Now.Ticks.ToString());
                table.InsertRow(newRow);

                ListRowsOptions options = new ListRowsOptions();
                IEnumerable<TableDataList> list1 = table.ListRows().AsRawResponses();

            }

            BigQueryCommand cmd = new BigQueryCommand("SELECT * FROM RARA");


            Console.WriteLine("END");
            return 1;
        }
        

    }
}
