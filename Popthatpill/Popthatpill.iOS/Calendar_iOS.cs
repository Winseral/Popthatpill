using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Popthatpill.iOS;
using Xamarin.Forms;
using EventKit;
using EventKitUI;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(Calendar_iOS))]
namespace Popthatpill.iOS
{
    public class Calendar_iOS : ICalendar
    {


        public void PoppillReminder(int _ID, string _name, string _day, int _count, TimeSpan _time)
        {
            long EventID = _ID;
            TimeSpan Time = _time;
            string Day = _day;
            string Title = Day;
            int Count = _count;
            string PillName = _name;
            int recurringday = 0;
            var Nowdtime = DateTime.Today;

            int day = GetDay(Day, Nowdtime, ref recurringday);

            Nowdtime = Nowdtime.AddDays(day);
            var Datewithtime = Nowdtime.Add(Time);

            NSDate newNSdatetime = ConvertDateTimeToNSDate(Datewithtime);
            NSDate nsEndDate = NSDate.DistantFuture;

            
            

            CalendarHelper.Current.EventStore.RequestAccess(EKEntityType.Event,
            (bool granted, NSError e) =>
            {
                if (granted)
                {
                    EKEvent newEvent = EKEvent.FromStore(CalendarHelper.Current.EventStore);
                    newEvent.AddRecurrenceRule(new EKRecurrenceRule(EKRecurrenceFrequency.Weekly, 1, EKRecurrenceEnd.FromEndDate(nsEndDate)));
                    newEvent.StartDate = newNSdatetime;
                    newEvent.Title = "Take your " + Title;
                    newEvent.Notes = "Time to take " + Count + " " + PillName + " pill/s";
                    newEvent.Calendar = CalendarHelper.Current.EventStore.DefaultCalendarForNewEvents;

                    NSError a;
                    try
                    {   // Save Note to Calendar to get UUID 
                        CalendarHelper.Current.EventStore.SaveEvent(newEvent, EKSpan.ThisEvent, true, out a);
                        if (a != null)
                        {
                            new UIAlertView("Issues saving Reminder", a.ToString(), null, "ok", null).Show();
                            return;
                        }
                        else
                        {   // Test: Show UUID 
                            new UIAlertView(newEvent.UUID, "The event has been saved", null, "ok", null).Show();
                            //ViewModel.DataManager.InsertCalID(e.PTPEvent.Id, e.PTPEvent.FilmId, newEvent.Eventidentifier);
                            // ViewModel.DataManager.InsertCalID(e.PTPEvent.Id, e.PTPEvent.FilmId, newEvent.UUID);

                        }

                    }
                    catch
                    {
                        new UIAlertView("Event", "Issues accessing the Calendar to save reminder", null, "ok", null).Show();
                    }



                }
                else
                {
                    new UIAlertView("Access Denied", "user Denied Access to Calendar Data", null, "ok", null).Show();
                }

            });
        }
        

        private class CalendarHelper
        {
            public static CalendarHelper Current
            {
                get { return current; }
            }
            private static CalendarHelper current;

            public EKEventStore EventStore
            {
                get { return eventStore; }
            }
            protected EKEventStore eventStore;

            static CalendarHelper()
            {
                current = new CalendarHelper();
            }
            protected CalendarHelper()
            {
                eventStore = new EKEventStore();
            }
        }

        private int GetDay(string day, DateTime today, ref int recurring)
        {
            if (day == "Sunday Morning Pills" || day == "Sunday Night Pills")
            {
                recurring = 0;
                return recurring;
            }


            if (day == "Monday Morning Pills" || day == "Monda Night Pills")
            {
                recurring = 1;
                return recurring;
            }


            if (day == "Tuesday Morning Pills" || day == "Tuesday Night Pills")
            {
                recurring = 2;
                return recurring;
            }


            if (day == "Wednesday Morning Pills" || day == "Wednesday Night Pills")
            {
                recurring = 3;
                return recurring;
            }

            if (day == "Thursday Morning Pills" || day == "Thursday Night Pills")
            {
                recurring = 4;
                return recurring;
            }

            if (day == "Friday Morning Pills" || day == "Friday Night Pills")
            {
                recurring = 5;
                return recurring;
            }

            if (day == "Saturday Morning Pills" || day == "Saturday Night Pills")
            {
                recurring = 6;
                return recurring;
            }
            return recurring;
        }

        public NSDate ConvertDateTimeToNSDate(DateTime date)
        {
            DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return NSDate.FromTimeIntervalSinceReferenceDate(
                (date - newDate).TotalSeconds);
        }

    }


}
