using RemoteNotes.Service.Client.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Domain.DTO;

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
    }
}
