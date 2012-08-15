using rkcrm.Administration.Department;
using rkcrm.Administration.Job_Title;
using rkcrm.Administration.Location;
using rkcrm.Administration.Role;
using rkcrm.Administration.User;
using System.Collections.Generic;

namespace rkcrm
{
	static class thisUser
	{

		#region Vairable

        static private User theUser;

		#endregion


		#region Properties

		/// <summary>
		/// Gets or sets the id of the department that the user is assigned too
		/// </summary>
		static public DepartmentCollection Departments
		{
            get { return theUser.Departments; }
		}

		/// <summary>
		/// Gets or sets the email address of the user
		/// </summary>
		static public string EmailAddress
		{
            get { return theUser.EmailAddress; }
            set { theUser.EmailAddress = value; }
		}

		/// <summary>
		/// Gets or sets the first name of the user
		/// </summary>
		static public string FirstName
		{
            get { return theUser.FirstName; }
            set { theUser.FirstName = value; }
		}

		/// <summary>
		/// Gets the concatination of the first and last name
		/// </summary>
		static public string FullName
		{
            get { return theUser.FirstName + " " + theUser.LastName; }
		}

		/// <summary>
		/// Gets the ID of the user. There is now direct way to modify a users ID.
		/// </summary>
		static public int ID
		{
            get { return theUser.ID; }
		}

		/// <summary>
		/// Gets the user's job title
		/// </summary>
		static public JobTitle JobTitle
		{
            get { return theUser.JobTitle; }
		}

		/// <summary>
		/// Gets or sets the user's job title id 
		/// </summary>
		static public int JobTitleID
		{
			get { return theUser.JobTitleID; }
			set { theUser.JobTitleID = value; }
		}

		/// <summary>
		/// Gets or sets the last name of the user
		/// </summary>
		static public string LastName
		{
            get { return theUser.LastName; }
            set { theUser.LastName = value; }
		}

		/// <summary>
		/// Gets the loaction id of the user
		/// </summary>
		static public Location Location
		{
            get { return theUser.Location; }
		}

		/// <summary>
		/// Gets or sets the loaction of the user
		/// </summary>
		static public int LocationID
		{
			get { return theUser.LocationID; }
			set { theUser.LocationID = value; }
		}

		/// <summary>
		/// Gets or sets the user name
		/// </summary>
		static public string Name
		{
            get { return theUser.UserName; }
		}

		/// <summary>
		/// Gets the role of the user
		/// </summary>
		static public Role Role
		{
            get { return theUser.Role; }
		}

		/// <summary>
		/// Gets or sets the role of the user
		/// </summary>
		static public int RoleID
		{
			get { return theUser.RoleID; }
			set { theUser.RoleID = value; }
		}

		/// <summary>
		/// Gets or sets a value that determines if the user will receive cross lead notifications
		/// </summary>
		static public bool ReceivesCrossLeads
		{
            get { return theUser.ReceiveCrossLeads; }
            set { theUser.ReceiveCrossLeads = value; }
		}

		/// <summary>
		/// Gets or sets a value that determines if the uers sees the follow up window when the application is started
		/// </summary>
		static public bool ShowReminders
		{
            get { return theUser.ShowReminders; }
            set { theUser.ShowReminders = value; }
		}


		static public Department HomeDepartment
		{
			get { return theUser.HomeDepartment; }
			set { theUser.HomeDepartment = value; }
		}


		static public User MyUser
		{
			get { return theUser; }
		}


		static public HashSet<int> MyTasks
		{
			get { return theUser.MyTasks; }
		}

		#endregion


        #region Methods

        public static void Refresh()
        {
            using (UserController theController = new UserController())
            {
                theUser.Departments.Clear();
                theUser.Departments = null;

                theUser = theController.GetUser(System.Environment.UserName);
            }
        }

        public static new string ToString()
        {
            return theUser.ToString();
        }

        #endregion


        #region Constructor

        static thisUser()
		{
            using (UserController theController = new UserController())
            {
                theUser = theController.GetUser(System.Environment.UserName);
            }
        }

		#endregion
	}
}
