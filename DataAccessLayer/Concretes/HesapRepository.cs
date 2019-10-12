using BankApp.Abstraction;
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
    public class HesapRepository : IRepository<Hesap>, IDisposable
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
        public HesapRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Hesap entity)
        {
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO [dbo].[tblHesap] ");
                query.Append(" ([MusteriID],[Bakiye],[EkNo],[HesapNo],[Durum])");
                query.Append("VALUES ");
                query.Append(
                    "( @MusteriID, @Bakiye, @EkNo, @HesapNo, @Durum ) ");


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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblHesap] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);
                        DBHelper.AddParameter(dbCommand, "@Bakiye", entity.Bakiye);
                        DBHelper.AddParameter(dbCommand, "@EkNo", entity.EkNo);
                        DBHelper.AddParameter(dbCommand, "@HesapNo", entity.HesapNo);
                        DBHelper.AddParameter(dbCommand, "@Durum", entity.Durum);

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
                throw new Exception("HesapRepository:Ekleme Hatası", ex);
            }
        }

        public bool Guncelle(Hesap entity)
        {
            _rowsAffected = 0;


            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblHesap] ");
                query.Append("SET [MusteriID] = @MusteriID, [Bakiye] = @Bakiye, [EkNo]=@EkNo, [HesapNo]=@HesapNo, [Durum]=@Durum");
                query.Append("WHERE ");
                query.Append(" [HesapID] = @HesapID ");


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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblHesap] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        DBHelper.AddParameter(dbCommand, "@HesapID", entity.HesapID);

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);
                        DBHelper.AddParameter(dbCommand, "@Bakiye", entity.Bakiye);
                        DBHelper.AddParameter(dbCommand, "@EkNo", entity.EkNo);
                        DBHelper.AddParameter(dbCommand, "@HesapNo", entity.HesapNo);
                        DBHelper.AddParameter(dbCommand, "@Durum", entity.Durum);


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
                throw new Exception("HesapRepository:Güncelleme Hatası", ex);
            }
        }


        public Hesap IdSec(int id)
        {
            _rowsAffected = 0;

            Hesap Hesap = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[MusteriID], [Bakiye], [EkNo], [HesapNo], [Durum]");
                query.Append("FROM [dbo].[tblHesap] ");
                query.Append("WHERE ");
                query.Append("[HesapID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblHesap] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", id);

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
                                    var entity = new Hesap();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.Bakiye = reader.GetDecimal(1);
                                    entity.EkNo = reader.GetInt32(2);
                                    entity.HesapNo = reader.GetInt32(3);
                                    entity.Durum = reader.GetBoolean(4);



                                    Hesap = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Hesap;
            }
            catch (Exception ex)
            {

                throw new Exception("HesapRepository:ID ile Seçim Hatası", ex);
            }
        }

        public IList<Hesap> HepsiniSec()
        {
            throw new NotImplementedException();
        }

        public bool IdSil(int id)
        {
            throw new NotImplementedException();
        }


    }
}
