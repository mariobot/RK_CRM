using System;
using System.Data;
using System.Windows.Forms;

namespace rkcrm.Base_Classes
{
	/// <summary>
	/// This object is used for collecting additional information about lead sources. 
	/// The main function that this object provides is a way for other object to retrieve the results.
	/// </summary>
	public partial class DetailFormBase : Form
	{

		#region Variables

		protected object objReturnValue;
		protected string strReturnString;
        private string strOriginalDetail;

		#endregion


		#region Properties

		public object ReturnValue
		{
			get { return objReturnValue; }
		}

		public string ReturnString
		{
			get { return strReturnString; }
		}

        public string OriginalDetail
        {
            get { return strOriginalDetail; }
            set
            {
                strOriginalDetail = value;
                OnOriginalDetailChanged(new EventArgs());
            }
        }

		#endregion


		#region Methods

		/// <summary>
		/// Determines whether the text in the combo box is found in the ObjectCollection
		/// </summary>
		/// <param name="oControl"></param>
		/// <returns></returns>
		protected bool IsSelectionValid(ComboBox oControl)
		{
			bool isFound = false;

			if (!string.IsNullOrEmpty(oControl.DisplayMember))
			{
				foreach (object oItem in oControl.Items)
					if (oControl.Text == ((DataRowView)oItem)[oControl.DisplayMember].ToString())
						isFound = true;
			}
			else
			{
				foreach (object oItem in oControl.Items)
					if (oControl.Text == oItem.ToString())
						isFound = true;
			}

			return isFound;
		}

		#endregion


		#region Constructor

		public DetailFormBase()
		{
			InitializeComponent();

			objReturnValue = null;
			strReturnString = string.Empty;

		}

		#endregion


        #region Events

        public event EventHandler OriginalDetailChanged;
        protected virtual void OnOriginalDetailChanged(EventArgs e)
        {
            EventHandler handler = OriginalDetailChanged;

            if (handler != null)
                handler(this, e);
        }

        #endregion

	}
}
