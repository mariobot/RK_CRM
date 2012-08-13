using System;
using System.Data;
using System.ComponentModel;
using rkcrm.Administration.Customer_Type;
using rkcrm.Administration.ZipCode;
using rkcrm.Base_Classes;
using rkcrm.Objects.Phone_Number;

namespace rkcrm.Objects.Customer
{
	/// <summary>
	/// Represents customer data in the database
	/// </summary>
	class Customer : ObjectBase
	{

		#region Variables

		private int intID;
		private string strName;
		private string strAddress;
		private int intZipcode;
		private string strCity;
		private string strState;
		private string strApt;
		private int intTypeID;
		private string strFalconID;
		private string strTermsCode;
		private DateTime datFirstSale;
		private DateTime datLastSale;
		private DateTime datTaxIDExpiration;
		private DateTime datCreditCardExpiration;
		private bool bolCannotCrossLead;
		private string strPhoneNumber;

		#endregion


		#region Properties

		/// <summary>
		/// Gets the ID of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("System")]
		[Description("The ID used to uniquely identify a customer")]
		[ReadOnly(true)]
		public int ID
		{
			get { return intID; }
			set { intID = value; }
		}

		/// <summary>
		/// Gets or sets the name of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("General")]
		[Description("This could be the name of a person or a business")]
		public string Name
		{
			get { return strName; }
			set { strName = value; }
		}

		/// <summary>
		/// Gets or sets the address of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Address")]
		[Description("The invoice is sent to this address")]
		public string Address
		{
			get { return strAddress; }
			set { strAddress = value; }
		}

		/// <summary>
		/// Gets ot sets the Zip code of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Address")]
		[DisplayName("Zip Code")]
		public int ZipCode
		{
			get { return intZipcode; }
			set { intZipcode = value; }
		}

		/// <summary>
		/// Gets ot sets the City of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Address")]
		public string City
		{
			get { return strCity; }
			set { strCity = value; }
		}

		/// <summary>
		/// Gets ot sets the State of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Address")]
		public string State
		{
			get { return strState; }
			set { strState = value; }
		}

		/// <summary>
		/// Gets or sets the apartment/building/suite number for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Address")]
		public string AptLotSte
		{
			get { return strApt; }
			set { strApt = value; }
		}

		/// <summary>
		/// Gets or sets the Customer type of this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("General")]
		[Description("The customer type ID")]
		[DisplayName("Customer Type ID")]
		public int TypeID
		{
			get { return intTypeID; }
			set { intTypeID = value; }
		}

		/// <summary>
		/// Gets the falcon alpha-numberic id for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Accounting")]
		[Description("The ID from the Falcon accounting software")]
		[DisplayName("Falcon ID")]
		public string FalconID
		{
			get { return strFalconID; }
			set { strFalconID = value; }
		}

		/// <summary>
		/// Gets the terms code for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Accounting")]
		[DisplayName("Terms Code")]
		public string TermsCode
		{
			get { return strTermsCode; }
		}

		/// <summary>
		/// Gets the first sale date for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Accounting")]
		[Description("The date of the customers first sale")]
		[DisplayName("First Sale")]
		public DateTime FirstSale
		{
			get { return datFirstSale; }
		}

		/// <summary>
		/// Gets the date that this rkcrm.Objects.Customer.Customer's last purchase
		/// </summary>
		[Category("Accounting")]
		[Description("The date of the customers most recent sale")]
		[DisplayName("Last Sale")]
		public DateTime LastSale
		{
			get { return datLastSale; }
		}

		/// <summary>
		/// Gets or set the date when the tax exempt certificate expires for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Accounting")]
		[Description("The date when the customer's tax exemption file expires")]
		[DisplayName("Tax Exemption Expiration")]
		public DateTime TaxIDExpiration
		{
			get { return datTaxIDExpiration; }
			set { datTaxIDExpiration = value; }
		}

		/// <summary>
		/// Gets or sets the date when the credit card expires for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("Accounting")]
		[Description("The date when the customer's credit card on file expires")]
		[DisplayName("Credit Card Expiration")]
		public DateTime CreditCardExpiration
		{
			get { return datCreditCardExpiration; }
			set { datCreditCardExpiration = value; }
		}

		/// <summary>
		/// Gets or sets a value that detemines whether this rkcrm.Objects.Customer.Customer is able to be cross led
		/// </summary>
		[Category("General")]
		[Description("When true, prevents any sales rep from receiving compensation for cross leading a project owned by this customer")]
		[DisplayName("Cannot Cross Lead")]
		public bool CannotCrossLead
		{
			get { return bolCannotCrossLead; }
			set { bolCannotCrossLead = value; }
		}

		/// <summary>
		/// Gets or sets the phone number for this rkcrm.Objects.Customer.Customer
		/// </summary>
		[Category("General")]
		[DisplayName("Phone Number")]
		public string PhoneNumber
		{
			get { return strPhoneNumber; }
			set { strPhoneNumber = value; }
		}

		#endregion


		#region Methods

		public CustomerType GetCustomerType()
		{
			if (intTypeID > 0)
				using (CustomerTypeController theController = new CustomerTypeController())
				{
					return theController.GetCustomerType(intTypeID);
				}
			else
				return new CustomerType();
		}

		public PhoneNumber GetPhoneNumber()
		{
			PhoneNumber clsPhoneNumber = null;
			if (!string.IsNullOrEmpty(strPhoneNumber) && clsPhoneNumber == null)
				using (PhoneNumberController theController = new PhoneNumberController())
				{
					clsPhoneNumber = theController.GetPhoneNumber(strPhoneNumber);
				}
			return clsPhoneNumber;
		}

		public ZipCode GetZipCode()
		{
			ZipCode clsZipCode = null;
			if (intZipcode > 0 && clsZipCode == null)
				using (ZipcodeController theController = new ZipcodeController())
				{
					clsZipCode = theController.GetZipCode(intZipcode, false);
				}
			return clsZipCode;
		}

		public Project.Project GetGeneralNotesProject()
		{
			Project.Project theProject;

			using (Project.ProjectController theController = new rkcrm.Objects.Project.ProjectController())
			{
				theProject = theController.GeneralNotes(intID);
			}

			return theProject;
		}

		public new string ToString()
		{
			string result = string.Empty;

			result += "Customer ID: " + this.ID + "\r\n";
			result += "Customer Name: " + this.Name + "\r\n";
			result += "Address: " + this.Address + "\r\n";
			result += "Zip Code: " + this.ZipCode + "\r\n";
			result += "Apt/Lot/Ste: " + this.AptLotSte + "\r\n";
			result += "Customer Type: " + this.GetCustomerType().Name + ", " + this.TypeID + "\r\n";
			result += "Falcon #: " + this.FalconID + "\r\n";
			result += "Terms Code: " + this.TermsCode + "\r\n";
			result += "First Sale: " + this.FirstSale.ToShortDateString() + "\r\n";
			result += "Last Sale: " + this.LastSale.ToShortDateString() + "\r\n";
			result += "Tax Excemption Expiration: " + this.TaxIDExpiration.ToShortDateString() + "\r\n";
			result += "Credit Card Expiration: " + this.CreditCardExpiration.ToShortDateString() + "\r\n";
			result += "Cannot Cross Lead: " + this.CannotCrossLead.ToString() + "\r\n";
			result += "Phone Number: " + this.PhoneNumber + "\r\n";

			return result;
		}

		#endregion


		#region Constructors

		/// <summary>
		/// Creates a new rkcrm.Objects.Customer.Customer based on the data provided in the System.Data.DataRow
		/// </summary>
		/// <param name="CustomerData"></param>
		public Customer(DataRow CustomerData)
			: base()
		{
			try
			{

				intID = Convert.ToInt32(CustomerData["customer_id"]);
				strName = CustomerData["name"].ToString();
				strAddress = CustomerData["address"].ToString();
				intZipcode = (CustomerData["zip_code"] == DBNull.Value ? 0 : Convert.ToInt32(CustomerData["zip_code"]));
				strState = CustomerData["city"].ToString();
				strState = CustomerData["state"].ToString();
				strApt = CustomerData["apt_lot_ste"].ToString();
				intTypeID = Convert.ToInt32(CustomerData["type_id"]);
				strFalconID = CustomerData["falcon_id"].ToString();
				strTermsCode = CustomerData["terms_code"].ToString();
				datFirstSale = (CustomerData["first_sale"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(CustomerData["first_sale"]));
				datLastSale = (CustomerData["last_sale"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(CustomerData["last_sale"]));
				datTaxIDExpiration = (CustomerData["tax_id_expiration"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(CustomerData["tax_id_expiration"]));
				datCreditCardExpiration = (CustomerData["creditcard_expiration"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(CustomerData["creditcard_expiration"]));
				bolCannotCrossLead = Convert.ToBoolean(CustomerData["cannot_cross_lead"]);
				strPhoneNumber = CustomerData["phone_number"].ToString();
				intCreatorID = Convert.ToInt32(CustomerData["creator_id"]);
				datCreated = Convert.ToDateTime(CustomerData["created"]);
				intUpdaterID = Convert.ToInt32(CustomerData["updater_id"]);
				datUpdated = Convert.ToDateTime(CustomerData["updated"]);

			}
			catch (Exception e)
			{
				Error_Handling.ErrorHandler.ProcessException(e, false);
			}
		}

		/// <summary>
		/// Creates a rkcrm.Objects.Customer.Customer with defualt values
		/// </summary>
		public Customer()
			: base()
		{
			intID = 0;
			strName = string.Empty;
			strAddress = string.Empty;
			strCity = string.Empty;
			strState = string.Empty;
			intZipcode = 0;
			strApt = string.Empty;
			intTypeID = 0;
			strFalconID = string.Empty;
			strTermsCode = string.Empty;
			datFirstSale = DateTime.MinValue;
			datLastSale = DateTime.MinValue;
			datTaxIDExpiration = DateTime.MinValue;
			datCreditCardExpiration = DateTime.MinValue;
			bolCannotCrossLead = false;
		}

		#endregion

	}
}
