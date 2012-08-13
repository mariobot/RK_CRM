using System;
using rkcrm.Administration.User;
using System.ComponentModel;

namespace rkcrm.Base_Classes
{
    abstract class ObjectBase : IDisposable
    {

        #region Variables

        private bool disposed = false;
        protected int intCreatorID;
        protected DateTime datCreated;
        protected int intUpdaterID;
        protected DateTime datUpdated;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ID of the user that created this object
        /// </summary>
		[Category("System")]
		[Description("This is the user id of the user who created this object")]
		public int CreatorID
        {
			get { return intCreatorID; }
		}

        /// <summary>
        /// Gets the date and time when this object was created
        /// </summary>
		[Category("System")]
		[Description("This is the date and time when this object was created")]
		public DateTime Created
        {
            get { return datCreated; }
        }

        /// <summary>
        /// Gets the ID of the user that last upadted this object
        /// </summary>
		[Category("System")]
		[Description("This is the user id of the user who made the most recent change")]
		public int UpdaterID
        {
			get { return intUpdaterID; }
		}

        /// <summary>
        /// Gets the date and time when this object was last updated
        /// </summary>
		[Category("System")]
		[Description("This is the date and time of the most recent change")]
		public DateTime Updated
        {
            get { return datUpdated; }
        }

        #endregion


		#region Methods

		public User GetCreator()
		{
			User clsCreator = null;

			if (intCreatorID > 0)
				using (UserController theController = new UserController())
				{
					clsCreator = theController.GetUser(intCreatorID);
				}
			return clsCreator;
		}

		public User GetUpdater()
		{
			User clsUpdater = null;

			if (intUpdaterID > 0)
				using (UserController theController = new UserController())
				{
					clsUpdater = theController.GetUser(intUpdaterID);
				}
			return clsUpdater;
		}

		public new string ToString()
		{
			string result = string.Empty;

			result = "Created: " + this.Created.ToShortDateString() + "\r\n";
			result = "Created By :" + GetCreator().FullName + ", " + this.CreatorID + "\r\n";
			result = "Last Updated: " + this.Updated.ToShortDateString() + "\r\n";
			result = "Updated By :" + GetUpdater().FullName + ", " + this.UpdaterID + "\r\n";

			return result;
		}

		#endregion


        #region Constructors/Destructors

        public ObjectBase()
        {
			intCreatorID = 0;
			intUpdaterID = 0;
			datCreated = DateTime.Now;
			datUpdated = DateTime.Now;

        }

        ~ObjectBase()
        {
            Dispose(false);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
            }

            disposed = true;
        }

        #endregion

    }
}
