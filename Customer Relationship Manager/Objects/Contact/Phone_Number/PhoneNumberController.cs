using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using rkcrm.Base_Classes;
using rkcrm.Error_Handling;

namespace rkcrm.Objects.Contact.Phone_Number
{
	class PhoneNumberController : EntityBase
	{

		internal bool DeleteAllPhoneNumbers(int ContactID)
		{
			try
			{
				SQL = "DELETE FROM `link_contact_phonenumbers` WHERE `contact_id` = " + ContactID + ";";
				InitializeCommand();
				OpenConnection();

				ExecuteStoredProcedure();

				return true;
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessException(e, false);
				return false;
			}
		}

		internal PhoneNumber InsertPhoneNumber(PhoneNumber oPhone)
		{
			throw new NotImplementedException();
		}

		internal bool UpdatePhoneNumber(PhoneNumber oPhone)
		{
			throw new NotImplementedException();
		}
	}
}
