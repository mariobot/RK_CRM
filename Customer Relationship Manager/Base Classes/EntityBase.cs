using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace rkcrm.Base_Classes
{
    abstract class EntityBase: IDisposable
    {
        #region Variables

        private bool disposed = false;
        protected string SQL = string.Empty;
        protected MySqlConnection Connection;
        protected MySqlCommand Command;
        protected MySqlDataAdapter DataAdapter;
        //protected MySqlDataReader DataReader;

        #endregion

        #region Methods

        /// <summary>
        /// Adds a parameter to the parameteres collection of the command object
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="Size"></param>
        /// <param name="Value"></param>
        protected void AddParameter(string Name, MySqlDbType Type, int Size, object Value)
        {
            try
            {
                Command.Parameters.Add(Name, Type, Size).Value = Value;
                Command.Parameters[Name].Direction = ParameterDirection.Input;
            }
            catch(MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Closes the connection to the MySQL server
        /// </summary>
        private void CloseConnection()
        {
            Connection.Close();
        }

        /// <summary>
        /// Executes a stored procedure based on the name in the SQL object
        /// </summary>
        /// <returns>The number of rows affected by the stored procedure</returns>
        protected int ExecuteStoredProcedure()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    OpenConnection();

                return Command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
            }
        }

        /// <summary>
        /// Fills a dataset object with data
        /// </summary>
        /// <param name="oDataSet"></param>
        protected void FillDataSet(DataSet oDataSet)
        {
            try
            {
                InitializeAdapter();
                DataAdapter.Fill(oDataSet);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
                DataAdapter.Dispose();
                DataAdapter = null;
            }
        }

        /// <summary>
        /// Fills a dataset object with data
        /// </summary>
        /// <param name="oDataSet"></param>
        protected void FillDataSet(DataSet oDataSet, string TableName)
        {
            try
            {
                InitializeAdapter();
                DataAdapter.Fill(oDataSet, TableName);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
                DataAdapter.Dispose();
                DataAdapter = null;
            }
        }

        /// <summary>
        /// Fills a datatable object with data
        /// </summary>
        /// <param name="oDataSet"></param>
        protected void FillDataTable(DataTable oDataTable)
        {
            try
            {
                InitializeAdapter();
                DataAdapter.Fill(oDataTable);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                Command.Dispose();
                Command = null;
                DataAdapter.Dispose();
                DataAdapter = null;
			}
        }

        /// <summary>
        /// Gets the name of the database to use based on the current mode of the application
        /// </summary>
        /// <returns></returns>
        private string GetDatabase()
        {
            if (MySettings.Mode == MySettings.applicationMode.Prototype)
                return MySettings.PrototypeDatabase;
            else if (MySettings.Mode == MySettings.applicationMode.Demonstration)
                return MySettings.DemoDatabase;
            else
                return MySettings.LiveDatabase;
        }

        /// <summary>
        /// Initializes the data adapter object
        /// </summary>
        private void InitializeAdapter()
        {
            try
            {
                DataAdapter = new MySqlDataAdapter(Command);
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Creates a new command based on the SQL statement and connection string provided
        /// </summary>
        protected void InitializeCommand()
        {
			OpenConnection();

			if (Command != null && !string.IsNullOrEmpty(SQL))
			{
				Command.Dispose();
				Command = null;
			}

            if (Command == null)
            {
                try
                {
                    Command = new MySqlCommand(SQL, Connection);

                    if (!SQL.ToUpper().StartsWith("SELECT ") && 
                        !SQL.ToUpper().StartsWith("INSERT ") &&
                        !SQL.ToUpper().StartsWith("UPDATE ") &&
						!SQL.ToUpper().StartsWith("DELETE ") &&
						!SQL.ToUpper().StartsWith("SET "))
                        Command.CommandType = CommandType.StoredProcedure;
                }
                catch (MySqlException e)
                {
                    throw new System.Exception(e.Message, e.InnerException);
                }
            }
        }

        /// <summary>
        /// Opens a connection to the MySQL server based on the connection string provided
        /// </summary>
        protected void OpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
            }
            catch (MySqlException e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e1)
            {
                throw new System.Exception(e1.Message, e1.InnerException);
            }
        }

		/// <summary>
		/// Returns a string that allows for punctuation marks
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		protected string BuildSafeString(string input)
		{
			string safeString = string.Empty;

			foreach (char oChar in input.ToCharArray())
				if (char.IsPunctuation(oChar))
					safeString += "\\" + oChar;
				else
					safeString += oChar;

			return safeString.ToUpper();
		}

		private MySqlConnection GetConnection()
		{
			return new MySqlConnection("server=" + MySettings.Server +
											 ";Uid=" + MySettings.UserName +
											 ";Pwd=" + MySettings.Password +
											 ";database=" + GetDatabase() +
											 ";Max Pool Size=" + MySettings.MaxConnetionPool +
											 ";Pooling=True; Connection Timeout=5");
		}

        #endregion

        #region Constructors/Destructors

        public EntityBase()
        {
			Connection = GetConnection();
        }

        ~EntityBase()
        {
            Dispose(false);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (this.DataAdapter != null)
            {
                this.DataAdapter.Dispose();
                this.DataAdapter = null;
            }
            if (this.Command != null)
            {
                Command.Dispose();
                Command = null;
            }
            if (this.Connection != null)
            {
                this.Connection.Close();
                this.Connection.Dispose();
                this.Connection = null;
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }

            disposed = true;
        }

        #endregion

    }
}
