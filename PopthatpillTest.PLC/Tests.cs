using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;


namespace PopthatpillTest.PLC
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Repl()
        {
            app.Repl();

        }
        [Test]
        public void TestMenuButton()
        {
            Func<AppQuery, AppQuery> MainMenuButtonQuery = e => e.Button("MenuButton");
            Func<AppQuery, AppQuery> CancelButtonQuery = e => e.Button("Cancel");
            Func<AppQuery, AppQuery> AboutButtonQuery = e => e.Text("About");

            app.WaitForElement(MainMenuButtonQuery, "Timed Out waiting for the main menu Button pressed");
            app.Tap(MainMenuButtonQuery);

            app.WaitForElement(CancelButtonQuery, "Timed Out waiting for the Cancel Button to be pressed");
            app.Tap(CancelButtonQuery);

            app.WaitForElement(MainMenuButtonQuery, "Timed Out waiting for the main menu Button pressed");
            app.Tap(MainMenuButtonQuery);

            app.WaitForElement(AboutButtonQuery, "Timed Out waiting for the About button to be pressed");
            app.Tap(AboutButtonQuery);

        }

        [Test]
        public void addnewpill()
        {
            Func<AppQuery, AppQuery> MorningSundayButtonQuery = e => e.Button("MSunday");
            Func<AppQuery, AppQuery> SearchBarQuery = e => e.Id("search_bar");
            Func<AppQuery, AppQuery> Searchtextvalue = e => e.Id("search_src_text");
            Func<AppQuery, AppQuery> Pillcountvalue = e => e.Marked("PILLCOUNT"); 
            Func<AppQuery, AppQuery> plusButtonQuery = e => e.Button("+");
            Func<AppQuery, AppQuery> minusButtonQuery = e => e.Button("-");
            Func<AppQuery, AppQuery> TimepickerButtonQuery = e => e.Text("12:00 AM");
            Func<AppQuery, AppQuery> TimepickerOKButtonQuery = e => e.Button("OK");
            Func<AppQuery, AppQuery> AddButtonQuery = e => e.Button("Add");


            app.WaitForElement(MorningSundayButtonQuery, "Timed Out waiting for the Morning Sunday Button pressed");
            app.Tap(MorningSundayButtonQuery);

            app.WaitForElement(SearchBarQuery, "Timed Out Wating for the Search Bar");
            app.Tap(SearchBarQuery);
            app.EnterText(c => c.Marked("search_bar"), new string('a', 5));
            
            app.WaitForElement(plusButtonQuery, "Timed Out Wating for Pill count +");
            app.Tap(plusButtonQuery);
            app.Tap(plusButtonQuery);
            app.Tap(plusButtonQuery);
            app.WaitForElement(minusButtonQuery, "Timed Out Wating for Pill count -");
            app.Tap(minusButtonQuery);
            app.Tap(minusButtonQuery);
            app.Tap(minusButtonQuery);
            app.Tap(minusButtonQuery);
           

            app.WaitForElement(TimepickerButtonQuery, "Timed Out Wating for Time Picker");
            app.Tap(TimepickerButtonQuery);
            app.Tap("1");
            app.WaitForElement(TimepickerOKButtonQuery, "Timed Out Waiting for the Time Picker OK button");
            app.Tap(TimepickerOKButtonQuery);



            //Set Strings aaaa in searchbar
            var addedvalue = app.Query(Searchtextvalue);

            //PillCount is 1
            var pillcount = app.Query(Pillcountvalue);

            Assert.AreEqual("aaaaa", addedvalue[0].Text, "The Search Bar has the incorrect string");
            Assert.AreEqual(pillcount[0].Text, "1", "The Pill Count was not 1");

            app.WaitForElement(AddButtonQuery, "Timed Out Waiting for ADD Button");
            app.Tap(AddButtonQuery);



        }


   
    }
}

