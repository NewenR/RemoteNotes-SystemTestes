using System;
using System.Configuration;
using NUnit.Framework;
using RemoteNotes.Service.Client.UAT.Helper;
using TechTalk.SpecFlow;
using NUnit.Framework;
namespace RemoteNote.Service.Client.UAT.Testers
{
    [Binding]
    public class UserTester
    {
        [When(@"I call user list")]
        public void WhenICallUserList()
        {
            try 
            {
                TestingContext.GetFrontServiceClient().GetAllUsers();
            }
            catch (Exception ex)
            {
                TestingContext.LastException = ex;
            }
        }
        
        [Then(@"I see user list")]
        public void ThenISeeUserList()
        {
            Assert.IsTrue(TestingContext.LastException == null);
        }
        
        [Then(@"I can create a new user")]
        public void ThenICanCreateANewUser()
        {
            try
            {
                TestingContext.GetFrontServiceClient().RegistrationUser(TestingContext.CreateTestUser());
            }
            catch (Exception ex)
            {
                TestingContext.LastException = ex;
            }
        }
        [Then(@"I can delete the new user")]
        public void ThenICanDeleteTheNewUser()
        {
            try
            {
                TestingContext.GetFrontServiceClient().DeleteUser(TestingContext.CreateTestUser().Id);
            }
            catch (Exception ex)
            {
                TestingContext.LastException = ex;
            }
        }
        [Then(@"I can change this user")]
        public void ThenICanChangeThisUser()
        {
            try
            {
                TestingContext.GetFrontServiceClient().UpdateUserAsync(TestingContext.CreateTestChangedUser());
            }
            catch (Exception ex)
            {
                TestingContext.LastException = ex;
            }
            Assert.IsTrue(TestingContext.LastException == null);
        }
    }
}
