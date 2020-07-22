using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RemoteNotes.Service.Client.UAT.Helper;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.DTO;
using TechTalk.SpecFlow;
using NUnit.Framework;
namespace RemoteNotes.Service.Client.UAT.Enter
{
    [Binding]
    public partial class SystemEnterTester
    {
        public static UserDTO userInfo;

        /// <summary>
        /// The enter the system.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        [When("I enter the login: (.*) and password: (.*)")]
        public void EnterTheSystem(string login, string password)
        {
            // In the result we have assigned userInfo and his active accountInfo in User and Account contexts.
            userInfo = TestingContext.GetFrontServiceClient().Login("login", "pass");
            Thread.Sleep(100);
        }

        /// <summary>
        /// The exit the system.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        [When("I try to exit the system")]
        public void ExitTheSystem()
        {
            // In the result we have assigned userInfo and his active accountInfo in User and Account contexts.
            
            try
            {
                Task result = TestingContext.GetFrontServiceClient().Logout();
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                TestingContext.LastException = ex;
            }

            Assert.That(TestingContext.LastException == null);
        }
    }
}