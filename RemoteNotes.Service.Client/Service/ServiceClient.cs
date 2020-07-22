using RemoteNotes.Service.Client.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Domain.DTO;
using RemoteNotes.Service.Domain.Helpers;
using Microsoft.AspNetCore.SignalR.Client;
using RemoteNotes.Service.Domain.Notification;

namespace RemoteNotes.Service.Client.Service
{
    public class ServiceClient : IServiceClient
    {
        private ServiceEnvironment serviceEnvironment;
        private SystemConnectionController systemConnectionController;
        private SystemUserController systemUserController;
        private SystemNoteController systemNoteController;

        public ServiceClient()
        {
            this.ConfigureServiceSettings();
            this.ConfigureOperationControllers(serviceEnvironment);
            this.ConfigureSubscriptions(serviceEnvironment);
        }

        private void ConfigureServiceSettings()
        {
            this.serviceEnvironment = new ServiceEnvironment();
            this.serviceEnvironment.HubName = "ServerHub";
            this.serviceEnvironment.ConnectionTimeout = new TimeSpan(0, 1, 0);
        }

        private void ConfigureOperationControllers(ServiceEnvironment serviceEnvironment)
        {
            this.systemConnectionController = new SystemConnectionController(serviceEnvironment);
            this.systemUserController = new SystemUserController(serviceEnvironment);
            this.systemNoteController = new SystemNoteController(serviceEnvironment);
        }

        public void ConfigureSubscriptions(ServiceEnvironment serviceEnvironment)
        {
            serviceEnvironment.Connection.On<MessageDTO>("notifyAll", message => {
                Console.WriteLine("Received message - " + message.SenderName + " " + message.Text);
            });
        }

        public async Task ConnectAsync(string address)
        {
            await this.systemConnectionController.ConnectAsync(address);
        }

        public void Connect(string address)
        {
            this.systemConnectionController.Connect(address);
        }

        public void Disconnect()
        {
            this.systemConnectionController.Disconnect();
        }

        public UserDTO Login(string login, string password)
        {
            return this.systemUserController.Login(login, password).Result;
        }

        public List<UserDTO> GetAllUsers()
        {
            return this.systemUserController.GetAllUsersAsync().Result;
        }

        public UserDTO RegistrationUser(UserDTO user)
        {
            return this.systemUserController.RegistrationUser(user).Result;
        }

        public Task Logout()
        {
            return this.systemUserController.Logout();
        }

        public UserDTO UpdateUserAsync(UserDTO user)
        {
            return this.systemUserController.UpdateUserAsync(user).Result;
        }

        public List<NoteDTO> GetNotes(int accountId)
        {
            return this.systemNoteController.GetNotes(accountId).Result;
        }

        public NoteDTO EditNote(NoteDTO note)
        {
            return this.systemNoteController.EditNote(note).Result;
        }

        public UserDTO ActivateUser(int userId)
        {
            return this.systemUserController.ActivateUser(userId).Result;
        }

        public UserDTO DeactivateUser(int userId)
        {
            return this.systemUserController.DeactivateUser(userId).Result;
        }

        public bool DeleteUser(int userId)
        {
            return this.systemUserController.DeleteUser(userId).Result;
        }

        public UserDTO ChangeUserStatus(int userId, bool userStatus)
        {
            return this.systemUserController.ChangeUserStatus(userId, userStatus).Result;
        }
    }
}
