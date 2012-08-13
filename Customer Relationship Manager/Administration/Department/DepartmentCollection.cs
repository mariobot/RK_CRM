using System;
using System.Collections.ObjectModel;

namespace rkcrm.Administration.Department
{
    class DepartmentCollection : Collection<Department>
    {
        #region Methods

        public void Add(int DepartmentID)
        {
            try
            {
                using (DepartmentController theController = new DepartmentController())
                {
                    base.Add(theController.GetDepartment(DepartmentID));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        #endregion
    }
}
