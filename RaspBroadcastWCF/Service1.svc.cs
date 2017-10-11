using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RaspBroadcastWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private const string ConnectionString = "Data Source = dittessqlserver.database.windows.net;Initial Catalog = SchoolDB;Persist Security Info = False;User ID = ditteak; Password = Ditte1234;MultipleActiveResultSets = False;Encrypt = True;TrustServerCertificate = False;Connection Timeout = 30";

        public string AddDACData(string StringText)
        {
            const string insertData = "insert into RaspString (StringText) values (@data)";

            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertData, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue(@StringText, StringText);
                    return StringText;
                }
            }
            
        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

    }
}
