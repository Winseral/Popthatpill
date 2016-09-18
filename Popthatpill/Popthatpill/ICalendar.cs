using System;

namespace Popthatpill
{
    public interface ICalendar
    {
        void PoppillReminder(int _ID, string _name, string _day, int _count, TimeSpan _time);
    }
}
