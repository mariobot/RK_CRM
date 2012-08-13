using System;
using System.Collections.Generic;

namespace rkcrm.Event_Arguments
{
	class ActivityStatusChangedEventArgs : EventArgs
	{
		private List<int> lstInactiveDepartments;
		private int intCustomerID;

		public int CustomerID
		{
			get { return intCustomerID; }
		}

		public List<int> InactiveDepartments
		{
			get { return lstInactiveDepartments; }
		}

		public ActivityStatusChangedEventArgs(int CustomerID, List<int> InactiveDepartments)
		{
			intCustomerID = CustomerID;
			lstInactiveDepartments = InactiveDepartments;
		}
	}
}
