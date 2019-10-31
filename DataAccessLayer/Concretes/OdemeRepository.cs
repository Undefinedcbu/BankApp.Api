using Commons.Concretes;
using Models.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class OdemeRepository : IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected;
        private bool _bDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _dbProviderFactory = null;
                }

                _bDisposed = true;
            }
        }
        public OdemeRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }
        public Odeme AboneNoSec(string aboneNo)
        {
            _rowsAffected = 0;

            Odeme Odeme = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[Borc]");
                query.Append("FROM [dbo].[tblOdeme] ");
                query.Append("WHERE ");
                query.Append("[AboneNo] = @aboneNo ");


                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [tblOdeme] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@aboneNo", aboneNo);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Odeme();
                                    entity.Borc = reader.GetDecimal(1);
                                    Odeme = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Odeme;
            }
            catch (Exception ex)
            {

                throw new Exception("OdemeRepository:AboneNo ile Seçim Hatası", ex);
            }
        }
        public bool BorcOde(Odeme entity)
        {
            _rowsAffected = 0;


            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblOdeme] ");
                query.Append("SET [Borc]=@Borc");
                query.Append("WHERE ");
                query.Append(" [AboneNo] = @AboneNo ");


                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblOdeme] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        DBHelper.AddParameter(dbCommand, "@AboneNo", entity.AboneNo);

                        //Input Params

                        DBHelper.AddParameter(dbCommand, "@Borc", 0);


                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeRepository:Ödeme Hatası", ex);
            }
        }
    }
}
