using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_Layer.Comparers;

namespace Admin_Layer
{
    public class PrioritySorter
    {
        public static List<Questiondetails> OrderBy(List<Questiondetails> lqd, bool byTitle, bool byDate, bool byUrgency, bool byStatus)
        {
            if (!byDate && !byStatus && !byTitle && !byUrgency)
            {
                lqd.Sort(new IQuestiondetailsStatusComparer());
            }
            if (byTitle)
            {
                lqd.Sort(new IQuestiondetailsTitleComparer());
            }
            if (byDate)
            {
                lqd.Sort(new IQuestiondetailsDateComparer());
            }
            if (byUrgency)
            {
                lqd.Sort(new IQuestiondetailsUrgencyComparer());
            }
            if (byStatus)
            {
                lqd.Sort(new IQuestiondetailsStatusComparer());
            }
            return lqd;
        }
    }
}
