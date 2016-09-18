using System;
using Android.App;
using Android.Content;
using Popthatpill.Droid;
using Android.Provider;
using Xamarin.Forms;
using Android.OS;

[assembly: Dependency(typeof(Calendar_Android))]
namespace Popthatpill.Droid
{
    [Service(Name = "com.myapp.CalendarSyncAdapter", Exported = true, Process = ":cal")]
    [IntentFilter(new[] { "android.content.SyncAdapter" })]
    [MetaData("android.content.SyncAdapter", Resource = "@xml/syncadapter")]

    public class Calendar_Android : Java.Lang.Object, ICalendar
    {
        public Activity EventActivity { get; private set; }
        public Bundle PillId { get; private set; }

        public void PoppillReminder(int _ID, string _name, string _day, int _count, TimeSpan _time)
        {

            //long eventID = _ID;
            TimeSpan Time = _time;
            string Day = _day;
            string Title = Day;
            int Count = _count;
            string PillName = _name;

            this.EventActivity = new Activity();

            string day = GetDay(ref Day);

            long msTime = Time.Hours * 60 * 60 * 1000 +
                           Time.Minutes * 60 * 1000 +
                           Time.Seconds * 1000;

            

            var epoch = (DateTime.Today - new DateTime(1970, 1, 1)).TotalMilliseconds;

            var correctBrisbantime = (epoch + msTime) - (10*60*60*1000);

            Console.WriteLine(correctBrisbantime);


            //Intent intent = new Intent(Intent.ActionInsert);
            Intent intent = new Intent(Intent.ActionInsert, ContentUris.WithAppendedId(CalendarContract.Events.ContentUri, (long)PillId));

            intent.SetData(CalendarContract.Events.ContentUri);
            intent.PutExtra(CalendarContract.EventsColumns.CalendarId, 1);
            intent.PutExtra(CalendarContract.EventsColumns.Exdate, correctBrisbantime);
            intent.PutExtra(CalendarContract.EventsColumns.HasExtendedProperties, 1);
            intent.PutExtra(CalendarContract.ExtraEventBeginTime, correctBrisbantime);
            intent.PutExtra(CalendarContract.EventsColumns.EventTimezone, "UTC");
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, correctBrisbantime);
            intent.PutExtra(CalendarContract.EventsColumns.Rrule, "FREQ=WEEKLY;WKST=SU;BYDAY=" + day);
            intent.PutExtra(CalendarContract.EventsColumns.HasAlarm, 1);
            intent.PutExtra(CalendarContract.EventsColumns.Title, "Take your " + Title + "                            Take " + Count + "pill / s of the name " + PillName);
            intent.PutExtra(CalendarContract.EventsColumns.Description, "Take " + Count + "pill/s of the name " + PillName);

            // Add Alarm reminder
            intent.PutExtra(CalendarContract.EventsColumns.Availability, (int)EventsAvailability.Busy);
            intent.PutExtra(CalendarContract.RemindersColumns.EventId, PillId);
            intent.PutExtra(CalendarContract.RemindersColumns.Minutes, 10);


            Forms.Context.StartActivity(intent); 
            

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