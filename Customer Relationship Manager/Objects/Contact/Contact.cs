using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using rkcrm.Administration.Contact_Title;
using rkcrm.Base_Classes;

namespace rkcrm.Objects.Contact
{
	class Contact : ObjectBase
	{

		#region Variables

		private int intContactID;
		private int intCustomerID;
		private string strFirstName;
		private string strLastName;
		private string strEmail;
		private int intTitleID;
		private bool bolIsSubscriber;
		private bool bolIsArchived;
		private List<Phone_Number.PhoneNumber> lstMyPhoneNumbers;

		#endregion


		#region Properties

		[Category("System")]
		[Description("The ID used to uniquely identify a contact")]
		[ReadOnly(true)]
		public int ID
		{
			get { return intContactID; }
		}

		[Browsable(false)]
		public string FullName
		{
			get { return strFirstName + " " + strLastName; }
		}

		[Category("General")]
		[DisplayName("First Name")]
		public string FirstName
		{
			get { return strFirstName; }
			set { strFirstName = value; }
		}

		[Category("General")]
		[DisplayName("Last Name")]
		public string LastName
		{
			get { return strLastName; }
			set { strLastName = value; }
		}

		[Category("General")]
		public string Email
		{
			get { return strEmail; }
			set { strEmail = value; }
		}

		[Category("General")]
		[DisplayName("Title ID")]
		[Description("The contact's title within thier own organization. References the \"ref_contact_titles\" table in the database")]
		public int TitleID
		{
			get { return intTitleID; }
			set { intTitleID = value; }
		}

		[Category("Misc")]
		[DisplayName("Is Subscriber")]
		[Description("Determines whether this contact will receive an R&K newsletter via email")]
		public bool IsSubscriber
		{
			get { return bolIsSubscriber; }
			set { bolIsSubscriber = value; }
		}

		[Category("System")]
		[DisplayName("Is Archived")]
		public bool IsArchived
		{
			get { return bolIsArchived; }
			set { bolIsArchived = value; }
		}

		[Category("Phone Numbers")]
		[DisplayName("My Phone Numbers")]
		[Description("A list of phone numbers associated with this contact")]
		public List<Phone_Number.PhoneNumber> MyPhoneNumbers
		{
			get { return lstMyPhoneNumbers; }
		}

		[Category("General")]
		[ReadOnly(true)]
		[DisplayName("Customer ID")]
		[Description("The ID of the customer that this contact is associated with")]
		public int CustomerID
		{
			get { return intCustomerID; }
			set { intCustomerID = value; }
		}

		public new string ToString()
		{
			string result = string.Empty;
			int index = 0;

			result += "Contact ID: " + this.ID + "/r/n";
			result += "Customer ID: " + this.CustomerID + "/r/n";
			result += "Name: " + this.FullName + "/r/n";
			result += "Email: " + this.Email + "/r/n";
			result += "Title ID: " + this.TitleID + "/r/n";
			result += "Is Subscriber: " + this.IsSubscriber.ToString() + "/r/n";
			result += "Is Archived: " + this.bolIsArchived.ToString() + "/r/n";
			result += base.ToString();
			result += "/r/n";

			foreach (Phone_Number.PhoneNumber phone in MyPhoneNumbers)
			{
				result += "Phone Number " + index + " ID: " + phone.ID + "/r/n";
				result += "Phone Number " + index + ": " + phone.Number + "/r/n";
				result += "Phone Type " + index + " ID: " + phone.TypeID + "/r/n";
				result += "Extension " + index + ": " + phone.Extension + "/r/n";
				result += "Is Perferred: " + phone.IsPerferred + "/r/n";
				result += "/r/n";
				index++;
			}

			return result;
		}

		#endregion


		#region Methods

		public ContactTitle GetTitle()
		{
			ContactTitle myTitle = null;

			if (intTitleID > 0)
			{
				using (ContactTitleController theController = new ContactTitleController())
				{
					myTitle = theController.GetTitle(intTitleID);
				}
			}

			// Since this field can be null, the Contact Boundary needs something to compare against
			if (myTitle == null)
				return new ContactTitle();
			else
				return myTitle;
		}

		public Customer.Customer GetCustomer()
		{
			Customer.Customer myCustomer = null;

			if (intCustomerID > 0)
			{
				using (Customer.CustomerController theController = new Customer.CustomerController())
				{
					myCustomer = theController.GetCustomer(intCustomerID);
				}
			}

			return myCustomer;
		}

		#endregion


		#region Constructors

		public Contact(DataSet ContactData)
			: base()
		{
			DataRow theContact = ContactData.Tables[0].Rows[0];

			bolIsArchived = Convert.ToBoolean(theContact["is_archived"]);
			bolIsSubscriber = Convert.ToBoolean(theContact["is_subscriber"]);
			intContactID = Convert.ToInt32(theContact["contact_id"]);
			intCustomerID = Convert.ToInt32(theContact["customer_id"]);
			intTitleID = theContact["title_id"] == DBNull.Value ? 0 : Convert.ToInt32(theContact["title_id"]);
			strEmail = theContact["email_address"].ToString();
			strFirstName = theContact["first_name"].ToString();
			strLastName = theContact["last_name"].ToString();

			lstMyPhoneNumbers = new List<Phone_Number.PhoneNumber>();
			foreach (DataRow oRow in ContactData.Tables[1].Rows)
				lstMyPhoneNumbers.Add(new Phone_Number.PhoneNumber(oRow));

			intCreatorID = Convert.ToInt32(theContact["creator_id"]);
			datCreated = Convert.ToDateTime(theContact["created"]);
			intUpdaterID = Convert.ToInt32(theContact["updater_id"]);
			datUpdated = Convert.ToDateTime(theContact["updated"]);
		}

		public Contact()
			: base()
		{
			bolIsSubscriber = true;
			intContactID = 0;
			intCustomerID = 0;
			intTitleID = 0;
			strEmail = string.Empty;
			strFirstName = string.Empty;
			strLastName = string.Empty;
			lstMyPhoneNumbers = new List<Phone_Number.PhoneNumber>();
		}

		#endregion

	}
}
