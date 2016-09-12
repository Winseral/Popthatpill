using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popthatpill
{
    public interface ICalendar
    {
        void PoppillReminder(int _ID, string _name, string _day, int _count, TimeSpan _time);
    }
}
