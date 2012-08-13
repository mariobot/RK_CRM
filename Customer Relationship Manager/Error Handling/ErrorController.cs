using System;
using rkcrm.Base_Classes;

namespace rkcrm.Error_Handling
{
    class ErrorController : EntityBase
    {
        #region

        public void logException(Exception theException)
        {
            try
            {
                SQL = "INSERT INTO `log_program_exceptions` (`receiver_id`, `received`, `version`, `message`, `target_site`, `stack_trace`) VALUES (" +
                      thisUser.ID + ", NOW(), \"" + System.Windows.Forms.Application.ProductVersion + "\", \"" + theException.Message + "\", \"" +
                      theException.TargetSite + "\", \"" + theException.StackTrace + "\");";
                InitializeCommand();
                OpenConnection();

                if (ExecuteStoredProcedure() == 0)
                    throw new Exception("The exception was not logged.");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        #endregion
    }
}
