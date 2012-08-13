using System;
using System.Reflection;

namespace rkcrm
{
    static class ObjectFactory
    {

		/// <summary>
		/// Creates a new instance of an object based on the System.Type provided
		/// </summary>
		/// <param name="oType"></param>
		/// <returns></returns>
        public static object GetObject(Type oType)
        {
            try
            {
                return Activator.CreateInstance(oType);
            }
            catch (Exception e)
            {
                Error_Handling.ErrorHandler.ProcessException(e, false);
                return null;
            }
        }

		/// <summary>
		/// Creates an instance of an object based on the namespace and name of the object
		/// </summary>
		/// <param name="ObjectName"></param>
		/// <returns></returns>
		public static object GetObject(string ObjectName)
		{
			try
			{
				Assembly myAssembly = Assembly.GetExecutingAssembly();
				Type myType = myAssembly.GetType(ObjectName);

				return Activator.CreateInstance(myType);
			}
			catch (Exception e)
			{
                Error_Handling.ErrorHandler.ProcessException(e, false);
                return null;
			}
		}

    }
}
