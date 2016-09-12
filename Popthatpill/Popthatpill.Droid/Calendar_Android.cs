using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Java.Util;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Popthatpill.Droid;
using Android.Provider;
using Xamarin.Forms;
using Android.Support.V4.Content;
using Android;
using Android.Content.PM;
using static Android.Provider.CalendarContract;

[assembly: Dependency(typeof(Calendar_Android))]
namespace Popthatpill.Droid
{
    public class Calendar_Android : Java.Lang.Object, ICalendar
    {
        

        public void PoppillReminder(int _ID, string _name, string _day, int _count, TimeSpan _time)
        {
     
            long EventID = _ID;
            TimeSpan Time = _time;
            string Day = _day;
            string Title = Day;
            int Count = _count;
            string PillName = _name;

            string day = GetDay(ref Day);


            long msTime =  Time.Days * 24 * 60 * 60 * 1000 +
                           Time.Hours * 60 * 60 * 1000 +
                           Time.Minutes * 60 * 1000 +
                           Time.Seconds * 1000 +
                           Time.Milliseconds;

            var epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;


            // long startMillis = 0;
            /*Locale Locale1 = Locale.English;
            Calendar beginTime = Calendar.GetInstance(Locale1);
            beginTime.Set(2016, 9, 9, 7, 30);
            startMillis = beginTime.TimeInMillis;
            ;

            Intent intent = new Intent(Intent.ActionInsert);
            intent.SetType("vnd.android.cursor.item/event");
            intent.PutExtra("beginTime", startMillis);
            intent.PutExtra("allDay", false);
            intent.PutExtra("rrule", "BYDAY=" + day);
            //intent.putExtra("endTime", cal.getTimeInMillis()+60*60*1000);
            intent.PutExtra("title", "Take your " + Title);
            intent.PutExtra("Desciption", "Take " + Count + "pill/s of the name " + PillName);
            // intent.setType("vnd.android.cursor.item/reminder");
            //StartActivity(intent); */

            //var calendarsUri = CalendarContract.Calendars.ContentUri;

            var calID = CalendarColumns.IsPrimary + "=1";

                ContentValues eventValues = new ContentValues();
                eventValues.Put(Events.InterfaceConsts.CalendarId, calID);
                eventValues.Put(Events.InterfaceConsts.Dtstart, epoch + msTime);
                eventValues.Put(Events.InterfaceConsts.Duration, "dur-day");
                eventValues.Put(Events.InterfaceConsts.Rrule, "FREQ=WEEKLY;WKST=SU;BYDAY=" + day);
                eventValues.Put(Events.InterfaceConsts.Title, "Take your " + Title);
                eventValues.Put(Events.InterfaceConsts.Description, "Time to take " + Count + " " + PillName + " pill/s");
                eventValues.Put(Events.InterfaceConsts.EventTimezone, "UTC+10");
                eventValues.Put(Events.InterfaceConsts.HasAlarm, "1");
                //eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS(date.Year, date.Month, date.Day, (hour + 1), minute));

               
                var uri = Forms.Context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
                Console.WriteLine("Uri for new event: {0}", uri);

                //long eventID = long.Parse(uri.LastPathSegment);

                ContentValues reminderValues = new ContentValues();
                // reminderValues.Put(CalendarContract.Reminders.InterfaceConsts.CalendarId, calID);
                reminderValues.Put(Reminders.InterfaceConsts.EventId, EventID);
                reminderValues.Put(Reminders.InterfaceConsts.Method, (int)RemindersMethod.Alert);
                reminderValues.Put(Reminders.InterfaceConsts.Minutes, 1);

                var reminderUri = Forms.Context.ContentResolver.Insert(CalendarContract.Reminders.ContentUri, reminderValues);
                Console.WriteLine("Uri for new event: {0}", reminderUri);
        }

        private string GetDay(ref string day)
        {
            if (day == "Sunday Morning Pills" || day == "Sunday Night Pills")
            {
                day = "SU";
                return day;
            }
            

            if (day == "Monday Morning Pills" || day == "Monda Night Pills")
            {
                day = "MO";
                return day;
            }
           

            if (day == "Tuesday Morning Pills" || day == "Tuesday Night Pills")
            {
                day = "TU";
                return day;
            }
           

            if (day == "Wednesday Morning Pills" || day == "Wednesday Night Pills")
            {
                day = "WE";
                return day;
            }
            
            if (day == "Thursday Morning Pills" || day == "Thursday Night Pills")
            {
                day = "TH";
                return day;
            }
            
            if (day == "Friday Morning Pills" || day == "Friday Night Pills")
            {
                day = "FR";
                return day;
            }
            
            if (day == "Saturday Morning Pills" || day == "Saturday Night Pills")
            {
                day = "SA";
                return day;
            }
            return "";
            

        }


        /*public long GetDateTimeMS(int yr, int month, int day)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);


            c.Set(Calendar.DayOfMonth, 10);
           // c.Set(Calendar.HourOfDay, hr);
           // c.Set(Calendar.Minute, min);
            c.Set(Calendar.Month, Calendar.September);
            c.Set(Calendar.Year, 2016);

       
            return c.TimeInMillis;


        }*/

       
    }

}