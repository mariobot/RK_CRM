using System;
using System.Data;
using rkcrm.Administration.Department;
using rkcrm.Base_Classes;

namespace rkcrm.Administration.User
{
    /// <summary>
    /// Represents user data in the rkcrm database
    /// </summary>
	class User : ObjectBase
	{

		#region Vairable

        private int intID;
        private string strUserName;
        private string strFirstName;
        private string strLastName;
        private string strEmail;
        private int intJobTitleID;
        private int intLocationID;
        private int intRoleID;
        private bool bolShowReminders;
        private bool bolReceiveCrossLeads;

		private Department.Department clsHome;
        private Job_Title.JobTitle clsJobTitle;
        private Location.Location clsLocation;
        private Role.Role clsRole;
        private DepartmentCollection lstDepartments;

		#endregion

		#region Properties

        /// <summary>
        /// Gets the ID of this user
        /// </summary>
        public int ID
        {
            get { return intID; }
        }

        /// <summary>
        /// Gets or sets the user name of this user
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// Gets or sets the first name of this user
        /// </summary>
        public string FirstName
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }

        /// <summary>
        /// Gets or sets the last name of this user
        /// </summary>
        public string LastName
        {
            get { return strLastName; }
            set { strLastName = value; }
        }

        /// <summary>
        /// Gets or sets the full name of this user
        /// </summary>
        public string FullName
        {
            get { return strFirstName + " " + strLastName; }
        }

        /// <summary>
        /// Gets or sets the email address of this user
        /// </summary>
        public string EmailAddress
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        /// <summary>
        /// Gets or sets the job title of this user
        /// </summary>
        public Job_Title.JobTitle JobTitle
        {
            get
            {
                if (intJobTitleID > 0 && clsJobTitle == null)
                    using (Job_Title.JobTitleController theController = new Job_Title.JobTitleController())
                    {
                        clsJobTitle = theController.GetJobTitle(intJobTitleID);
                    }
                return clsJobTitle;
            }

            set { clsJobTitle = value; }
        }

        /// <summary>
        /// Gets or sets the location of this user
        /// </summary>
        public Location.Location Location
        {
            get 
            {
                if (intLocationID > 0 && clsLocation == null)
                    using (Location.LocationController theController = new Location.LocationController())
                    {
                        clsLocation = theController.GetLocation(intLocationID);
                    }

                return clsLocation;
            }

            set { clsLocation = value; }
        }

        /// <summary>
        /// Gets or sets the role of this user
        /// </summary>
        public Role.Role Role
        {
            get
            {
                if (intRoleID > 0 && clsRole == null)
                    using (Role.RoleController theController = new Role.RoleController())
                    {
                        clsRole = theController.GetRole(intRoleID);
                    }
                return clsRole;
            }

            set { clsRole = value; }
        }

        /// <summary>
        /// Gets or sets the value that determines whether the reminder windows appears on start up 
        /// </summary>
        public bool ShowReminders
        {
            get { return bolShowReminders; }
            set { bolShowReminders = value; }
        }

        /// <summary>
        /// Gets or sets the value that determines whether this user recieves the cross lead emails
        /// </summary>
        public bool ReceiveCrossLeads
        {
            get { return bolReceiveCrossLeads; }
            set { bolReceiveCrossLeads = value; }
        }

		/// <summary>
		/// Gets or sets the departments that this user is assigned too
		/// </summary>
        public DepartmentCollection Departments
        {
            get
            {
                if (lstDepartments == null)
                    using (Department.DepartmentController theController = new Department.DepartmentController())
                    {
                        lstDepartments = theController.GetDepartments(intID);
                        
                    }
                return lstDepartments;
            }

            set { lstDepartments = value; }
        }

		/// <summary>
		/// Gets or sets the default department of this user
		/// </summary>
		public Department.Department HomeDepartment
		{
			get
			{
				if(intID > 0 && clsHome == null)
					using (DepartmentController theController = new DepartmentController())
					{
						clsHome = theController.GetHomeDepartment(intID);
					}
				return clsHome;
			}
			set { clsHome = value; }
		}

		#endregion

        public new string ToString()
        {
            string what = FullName + "; " + UserName + "; " + EmailAddress + "; " + JobTitle.ID + ", " + JobTitle.Name +
                "; " + Location.ID + ", " + Location.Name + "; " + Role.ID + ", " + Role.Name + "; Show Reminders: " + bolShowReminders +
                "; Receives Leads: " + ReceiveCrossLeads + ";\n\rDepartments: ";

            foreach (Department.Department oDept in Departments)
                what += oDept.ID + ", " + oDept.Name + "\n\r";

			what += base.ToString();

            return what;
        }

		#region Constructors/Destructors

        /// <summary>
        /// Creates a new user object based on the data provided
        /// </summary>
        /// <param name="UserData"></param>
        public User(DataRow UserData)
        {
            intID = Convert.ToInt32(UserData["user_id"]);
            intJobTitleID = Convert.ToInt32(UserData["job_title_id"]);
            intLocationID = Convert.ToInt32(UserData["location_id"]);
            intRoleID = Convert.ToInt32(UserData["role_id"]);
            strUserName = UserData["user_name"].ToString();
            strFirstName = UserData["first_name"].ToString();
            strLastName = UserData["last_name"].ToString();
            strEmail = UserData["email_address"].ToString();
            bolReceiveCrossLeads = Convert.ToBoolean(UserData["receives_crossleads"]);
            bolShowReminders = Convert.ToBoolean(UserData["show_reminders"]);
            intCreatorID = Convert.ToInt32(UserData["creator_id"]);
            datCreated = Convert.ToDateTime(UserData["created"]);
            intUpdaterID = Convert.ToInt32(UserData["updater_id"]);
            datUpdated = Convert.ToDateTime(UserData["updated"]);
        }

        /// <summary>
        /// Creates a new user object with default vaules
        /// </summary>
        public User()
            : base()
        {
            intID = 0;
            intJobTitleID = 0;
            intLocationID = 0;
            intRoleID = 0;
            bolReceiveCrossLeads = false;
            bolShowReminders = true;
        }

		#endregion

	}
}
