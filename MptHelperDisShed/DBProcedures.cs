using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MptHelperDisShed
{
    class DBProcedures
    {
        private SqlCommand command = new SqlCommand("", DBConnection.Connection);
        private void commandConfig(string config)
        {
            command.CommandType =
                System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        //Процедуры Distribution
        public void spdistribution_insert(Int32 priority, Int32 territory_аudiences_id, Int32 NLP_ID)
        {
            commandConfig("distribution_insert");
            command.Parameters.AddWithValue("@priority", priority);
            command.Parameters.AddWithValue("@territory_аudiences_id", territory_аudiences_id);
            command.Parameters.AddWithValue("@NLP_ID", NLP_ID);
            DBConnection.Connection.Open();
            command.ExecuteNonQuery();
            DBConnection.Connection.Close();
        }

        public void spdistribution_Update(Int32 ID_distribution, Int32 priority, Int32 territory_аudiences_id, Int32 NLP_ID)
        {
            commandConfig("distribution_Update");
            command.Parameters.AddWithValue("@ID_distribution", ID_distribution);
            command.Parameters.AddWithValue("@priority", priority);
            command.Parameters.AddWithValue("@territory_аudiences_id", territory_аudiences_id);
            command.Parameters.AddWithValue("@NLP_ID", NLP_ID);
            DBConnection.Connection.Open();
            command.ExecuteNonQuery();
            DBConnection.Connection.Close();
        }

        public void spdistribution_delete(Int32 ID_distribution)
        {
            commandConfig("distribution_Delete");
            command.Parameters.AddWithValue("@ID_distribution", ID_distribution);
            DBConnection.Connection.Open();
            command.ExecuteNonQuery();
            DBConnection.Connection.Close();
        }
    }
}
