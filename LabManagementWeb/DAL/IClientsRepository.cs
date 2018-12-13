using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.DAL
{
    public interface IClientsRepository : IDisposable
    {
        IEnumerable<Client> GetClients();
        Client GetClientByID(int? clientID);
        void InsertClient(Client client);
        void DeleteClient(int clientID);
        void UpdateClient(Client client);
        void Save();
    }
}