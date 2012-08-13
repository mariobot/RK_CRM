using System;
using System.Windows.Forms;

namespace rkcrm
{
    class ListViewItemComparer : System.Collections.IComparer
    {
        private int column_index;
        private SortOrder order;

        public ListViewItemComparer(int index, SortOrder order)
        {
            column_index = index;
            this.order = order;
        }
        
        #region IComparer Members

        public int Compare(object x, object y)
        {
            int value;
            ListViewItem x_item = (ListViewItem)x;
            ListViewItem y_item = (ListViewItem)y;

            try
            {
                //first try to convert the object data to datetime type
                DateTime firstDate = DateTime.Parse(x_item.SubItems[column_index].Text);
                DateTime secondDate = DateTime.Parse(y_item.SubItems[column_index].Text);

                value = DateTime.Compare(firstDate, secondDate);
            }
            catch
            {
                try
                {
                    //Next try to convert the object date to decimal type
                    decimal firstDec = decimal.Parse(x_item.SubItems[column_index].Text.Trim('$'));
                    decimal secondDec = decimal.Parse(y_item.SubItems[column_index].Text.Trim('$'));

                    value = decimal.Compare(firstDec, secondDec);
                }
                catch
                {
                    //lastly convert the object data to string type
                    value = string.Compare(x_item.SubItems[column_index].Text.Trim('$'), y_item.SubItems[column_index].Text.Trim('$'));
                }
            }

            if (order == SortOrder.Descending)
                value *= -1;

            return value;
        }

        #endregion

    }
}
