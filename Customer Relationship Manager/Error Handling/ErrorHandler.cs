using System;
using System.Net.Mail;

namespace rkcrm.Error_Handling
{
    /// <summary>
    /// This class is used to handle any and all exceptions experinced by users.
    /// All exceptions are stored in the database as well as emailed to concerned parties.
    /// </summary>
    static class ErrorHandler
    {

        #region Methods

        static private void sendEmail(Exception theException)
        {
            SmtpClient theClient = new SmtpClient("Young");
            MailMessage theMessage = new MailMessage(thisUser.EmailAddress, "tylerh@randkaz.com");

            try
            {
                theMessage.Subject = "[CRM] Application Exception";
                theMessage.Body = "MESSAGE:\r\n" + theException.Message + "\r\n\r\nTARGET SITE:\r\n" + theException.TargetSite + "\r\n\r\nSTACK TRACE:\r\n" +
                    theException.StackTrace + "\r\n\r\nComputer: " + Environment.MachineName;

				if (theException.InnerException != null)
					theMessage.Body += "\r\n\r\nINNER EXCEPTION:\r\n" + theException.InnerException.Message + "\r\n\r\nINNER TARGET SITE:\r\n" + 
						theException.InnerException.TargetSite + "\r\n\r\nINNER STACK TRACE:\r\n" + theException.InnerException.StackTrace;

                theClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                theClient.Send(theMessage);
            }
            catch (SmtpFailedRecipientException e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message + "\r\n\r\nTARGET SITE: " + e1.TargetSite + "\r\n\r\nPROCEDURE: sendMail", MySettings.AppTitle);
            }
            catch (SmtpException e2)
            {
                System.Windows.Forms.MessageBox.Show(e2.Message + "\r\n\r\nTARGET SITE: " + e2.TargetSite + "\r\n\r\nPROCEDURE: sendMail", MySettings.AppTitle);
            }
        }

        static public void ProcessException(Exception exceptionThrown, bool isRecoverable)
        {
			using (ErrorController theController = new ErrorController())
			{
				theController.logException(exceptionThrown);
			}

            if (!isRecoverable)
                sendEmail(exceptionThrown);

            System.Windows.Forms.MessageBox.Show(exceptionThrown.Message);
		}

        #endregion

        #region Constructor
        #endregion
    }
}
