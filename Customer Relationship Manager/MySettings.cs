
namespace rkcrm
{
    static class MySettings
    {

        #region Variables

        private static string strAppTitle = "R&K Customer Relationship Manager";
        private static string strServer = Properties.Settings.Default.Server;
        private static string strUserName = "app_user";
        private static string strPassword = "rk1234";
        private static string strLiveDatabase = Properties.Settings.Default.Database;
        private static string strDemoDatabase = Properties.Settings.Default.DemoDatabase;
        private static string strPrototypeDatabase = Properties.Settings.Default.PrototypeDatabase;
        private static applicationMode appMode = Properties.Settings.Default.IsPrototype ? applicationMode.Prototype : applicationMode.Live;
		private static string strReportsPath = Properties.Settings.Default.ReportsPath;
		private static int intMaxConnectionPool = Properties.Settings.Default.MaxConnectionPool;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the application
        /// </summary>
        static public string AppTitle
        {
            get {
                if (appMode == applicationMode.Prototype)
                {
                    return strAppTitle + " - Prototype";
                }
                else if (appMode == applicationMode.Demonstration)
                {
                    return strAppTitle + " - Demonstration Mode";
                }
                else
                {
                    return strAppTitle;
                }
            }
        }

        /// <summary>
        /// Gets the name of the database with dumby data
        /// </summary>
        static public string DemoDatabase
        {
            get { return strDemoDatabase; }
        }

        /// <summary>
        /// Gets the name of the database with live data
        /// </summary>
        static public string LiveDatabase
        {
            get { return strLiveDatabase; }
        }

        /// <summary>
        /// Gets or sets the functioning mode that the application is currently in
        /// </summary>
        static public applicationMode Mode
        {
            get { return appMode; }
            set { appMode = value; }
        }

        /// <summary>
        /// Gets the password used to connect to the database
        /// </summary>
        static public string Password
        {
            get { return strPassword; }
        }

        /// <summary>
        /// Gets the name of the database that may have an architecture incosistent with the live database
        /// </summary>
        static public string PrototypeDatabase
        {
            get { return strPrototypeDatabase; }
        }

        /// <summary>
        /// Gets the name of the server that the database resides on
        /// </summary>
        static public string Server
        {
            get { return strServer; }
        }

        /// <summary>
        /// Gets the user name used to access the database
        /// </summary>
        static public string UserName
        {
            get { return strUserName; }
        }

		/// <summary>
		/// Gets the full path where the report files are stored
		/// </summary>
		static public string ReportsPath
		{
			get { return strReportsPath; }
		}

		/// <summary>
		/// Gets the maximum number of database connections that a user can have.
		/// </summary>
		static public int MaxConnetionPool
		{
			get { return intMaxConnectionPool; }
		}

        #endregion

        #region Enumerations

        public enum applicationMode {Live, Demonstration, Prototype};

        #endregion

    }
}
