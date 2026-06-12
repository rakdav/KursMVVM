using Avalonia.Controls.Notifications;
using KursMVVM.Models;
using KursMVVM.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class LoadJSONClient : ILoadInteface<Client>
    {
        private ClientsPageService service = new ClientsPageService();

        public async Task LoadList(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Client>? clients=await JsonSerializer.DeserializeAsync<List<Client>>(fs);
                foreach(Client client in clients!)
                {
                    service?.Add(client);
                }
            }
        }
        public async Task Upload(string path, List<Client> list)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Client>>(fs, list);
            }
        }
    }
}
