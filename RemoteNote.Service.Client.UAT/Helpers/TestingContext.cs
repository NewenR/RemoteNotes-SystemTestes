using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Client.Service;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.Service.Client.UAT.Helper
{
    public class TestingContext
    {
        public static Exception LastException { get; set; } = null;

        private static IServiceClient frontServiceClient;

        static TestingContext()
        {
            frontServiceClient = FrontClientCreator.Create();
        }

        public static void Clear()
        {
            LastException = null;
        }
        public static UserDTO CreateTestUser()
        {
            var hold = new UserDTO();
            hold.Account = new AccountDTO();
            hold.Login = "newLogin";
            hold.Password = "newPassword";
            return hold;
        }
        public static UserDTO CreateTestChangedUser()
        {
            var hold = new UserDTO();
            hold.Account = new AccountDTO();
            hold.Login = "newLoginChanged";
            hold.Password = "newPasswordChanged";
            return hold;
        }
        public static IServiceClient GetFrontServiceClient()
        {
            Clear();
            return frontServiceClient;
        }
    }
}

