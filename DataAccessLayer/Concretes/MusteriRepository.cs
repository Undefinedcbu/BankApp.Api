using BankApp.Abstraction;
using Commons.Concretes;
using Models.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace BankApp.Concretes
{
    public class MusteriRepository : IRepository<Musteri>, IDisposable
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
        public MusteriRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Musteri entity)
        {
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO [dbo].[tblMusteri] ");
                query.Append(" ([TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola])");
                query.Append("VALUES ");
                query.Append(
                    "( @TCKimlik, @Ad, @Soyad, @DogumTarihi, @Adres, @Telefon,@Email,@Parola ) ");


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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblMusteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@Parola", entity.Parola);
                    
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
                throw new Exception("MusteriRepository:Ekleme Hatası", ex);
            }
        }


        public bool Guncelle(Musteri entity)
        {
            _rowsAffected = 0;


            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblMusteri] ");
                query.Append("SET [TCKimlik] = @TCKimlik ,[Ad] = @Ad ,[Soyad]=@Soyad,[DogumTarihi]=@DogumTarihi,[Adres]=@Adres,[Telefon]=@Telefon,[Email]=@Email,[Parola]=@Parola ");
                query.Append("WHERE ");
                query.Append(" [MusteriID] = @MusteriID ");


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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tbl_Transactions] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@Anahtar", entity.Anahtar);
                        DBHelper.AddParameter(dbCommand, "@Parola", entity.Parola);
         

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
                throw new Exception("MusteriRepository:Güncelleme Hatası", ex);
            }
        }

        public IList<Musteri> HepsiniSec()
        {

            _rowsAffected = 0;

            IList<Musteri> Musterilar = new List<Musteri>();

            
            var query = new StringBuilder();
            query.Append("SELECT ");
            query.Append("[MusteriID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola],[Anahtar]");
            query.Append("FROM [dbo].[tblMusteri] ");


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
                            "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = commandText;

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
                                var entity = new Musteri();
                                entity.MusteriID = reader.GetInt32(0);
                                entity.TcKimlik = reader.GetString(1);
                                entity.Ad = reader.GetString(2);
                                entity.Soyad = reader.GetString(3);
                                entity.DogumTarihi = reader.GetDateTime(4).Date;
                                entity.Adres = reader.GetString(5);
                                entity.Telefon = reader.GetString(6);
                                entity.Email = reader.GetString(7);
                                entity.Parola = reader.GetString(8);
                                
                                
                 
                                Musterilar.Add(entity);
                            }
                        }
                    }


                }
            }
       
            return Musterilar;
           
        }

        public Musteri IdSec(int id)
        {

            _rowsAffected = 0;

            Musteri Musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[MusteriID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola],[Anahtar]");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[MusteriID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.Parola = reader.GetString(8);
                                    
                                        

                                    Musteri = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Musteri;
            }
            catch (Exception ex)
            {

                throw new Exception("MusteriRepository:ID ile Seçim Hatası", ex);
            }
        }

        public Musteri TCSec(string TCKN)
        {

            _rowsAffected = 0;

            Musteri Musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[MusteriID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola],[Anahtar]");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[TCKimlik] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", TCKN);

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.Parola = reader.GetString(8);



                                    Musteri = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Musteri;
            }
            catch (Exception ex)
            {

                throw new Exception("MusteriRepository:ID ile Seçim Hatası", ex);
            }
        }


        public Musteri MusteriAdSec(string MusteriAdi)
        {

            _rowsAffected = 0;

            Musteri Musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[MusteriID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola],[Anahtar]");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[MusteriAdi] = @MusteriAdi ");


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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@MusteriAdi", MusteriAdi);

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.Parola = reader.GetString(8);
                          
                                        
                                    Musteri = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Musteri;
            }
            catch (Exception ex)
            {

                throw new Exception("MusteriRepository:MusteriAdi ile Seçim Hatası", ex);
            }
        }

        public bool IdSil(int id)
        {

            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[MusteriID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", id);

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
                throw new Exception("MusteriRepository:Silme Hatası", ex);
            }
        }

        public Musteri Giris(string TCKimlik, string parola)
        {
            _rowsAffected = 0;
            Musteri Musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[MusteriID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola],[Anahtar]");
                query.Append("FROM [dbo].[tblMusteri]");
                query.Append("WHERE ");
                query.Append("[TCKimlik] = @TCKimlik AND [Parola]=@Parola ");

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
                                "dbCommand" + " The db SelectById command for entity [tbl_Transactions] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", TCKimlik);
                        DBHelper.AddParameter(dbCommand, "@Parola", parola);

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.Parola = reader.GetString(8);
                               
                                         Musteri = entity;
                                    break;
                                }
                            }

                        }
                    }

                }

                return Musteri;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository:Giriş Hatası", ex);
            }
        }

        public Musteri KeySec(string anahtar)
        {

            _rowsAffected = 0;

            Musteri Musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[MusteriID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[Parola],[Anahtar]");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[Anahtar] = @anahtar ");


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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@anahtar", anahtar);

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.Parola = reader.GetString(8);
                           
                                         Musteri = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Musteri;
            }
            catch (Exception ex)
            {

                throw new Exception("MusteriRepository:ID ile Seçim Hatası", ex);
            }
        }
    }
}
