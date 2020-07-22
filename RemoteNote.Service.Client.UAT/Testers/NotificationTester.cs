using System;
using System.Configuration;
using NUnit.Framework;
using RemoteNotes.Service.Client.UAT.Helper;
using TechTalk.SpecFlow;
using NUnit.Framework;
namespace RemoteNote.Service.Client.UAT.Testers
{
    [Binding]
    public class NotificationTester
    {
        [Then(@"I can get a notification")]
        public void ThenICanGetANotification()
        {
            try
            {
                //TestingContext.GetFrontServiceClient()
            }
            catch (Exception ex)
            {
                TestingContext.LastException = ex;
            }
        }
    }
}
