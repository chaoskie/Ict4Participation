using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Layer.Enums;

namespace Admin_Layer.Comparers
{
    public class IQuestiondetailsUrgencyComparer : IComparer<Questiondetails>
    {
        int IComparer<Questiondetails>.Compare(Questiondetails x, Questiondetails y)
        {
            Status statusx;
            Enum.TryParse(x.Status, out statusx);
            Status statusy;
            Enum.TryParse(y.Status, out statusy);

            int returnable = 0;

            //Sort on urgency
            if (returnable == 0)
            {
                //-1 = x is false, y is true
                //0 = x is y
                //1 =x is true, y is false
                returnable = -x.Urgent.CompareTo(y.Urgent);
            }

            //Sort on status
            if (returnable == 0)
            {
                returnable = -((int)statusy).CompareTo((int)statusx);
            }

            //Sort on date
            if (returnable == 0)
            {
                if (x.StartDate != null || y.StartDate != null)
                {
                    returnable = DateTime.Compare((DateTime)x.StartDate, (DateTime)y.StartDate);
                }
            }

            //Sort on title
            if (returnable == 0)
            {
                returnable = x.Title.CompareTo(y.Title);
            }

            return returnable;
        }
    }
}
