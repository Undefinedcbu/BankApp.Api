using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Text;

namespace Commons.Concretes
{
   public static class DBHelper
    {
      
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public static string GetConnectionProvider()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ProviderName;
        }




        /* public int AddParameter(string name, object value)
         {
             DbParameter parm = _factory.CreateParameter();
             parm.ParameterName = name;
             parm.Value = value;
             return command.Parameters.Add(parm);
         }
         public int AddParameter(DbParameter parameter)
         {
             return command.Parameters.Add(parameter);
         }*/

        public static void AddParameter(DbCommand command, string paramName, object value)
        {
            if (command == null)
                throw new ArgumentNullException("command", "The AddParameter's Command value is null.");

            try
            {
                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = paramName;   
                parameter.Value = value ?? DBNull.Value;
                command.Parameters.Add(parameter);
            }
            catch (Exception ex)
            {
                
                throw new Exception("DBHelper::AddParameter::Error occured.", ex);
            }
        }

    }
}
