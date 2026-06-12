using KursMVVM.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class ClientsPageService:IDBService<Client>
    {
        public async Task<List<Client>> get()
        {
            using (KursContext db=new KursContext())
            {
                var list = db.Clients.ToListAsync();
                if (list != null) return await list;
                return null!;
            }
        }
        public async Task Add(Client client)
        {
            using (KursContext db = new KursContext())
            {
                await db.Clients.AddAsync(client);
                await db.SaveChangesAsync();
            }
        }
        public async Task Edit(Client client)
        {
            using (KursContext db = new KursContext())
            {
                Client editClient=db.Clients.FirstOrDefault(p=>p.IdClient==client.IdClient)!;
                editClient.Surname= client.Surname;
                editClient.Address= client.Address;
                editClient.LastName= client.LastName;
                editClient.NumberDogovor= client.NumberDogovor;
                editClient.FirstName= client.FirstName;
                editClient.Phone= client.Phone;
                editClient.DataDogovor= client.DataDogovor;
                db.Clients.Update(editClient);
                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                using (KursContext db = new KursContext())
                {

                    Client deleteClient = db.Clients.FirstOrDefault(p => p.IdClient == id)!;
                    db.Clients.Remove(deleteClient);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var box = MessageBoxManager
                .GetMessageBoxStandard("Ошибка", ex.Message, ButtonEnum.Ok);
            }
        }
        public async Task<Client?> getById(int id)
        {
            using (KursContext db = new KursContext())
            {
                return await db.Clients.FirstOrDefaultAsync(p => p.IdClient == id);
            }
        }

    }
}
