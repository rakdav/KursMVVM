using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CsvHelper;
using CsvHelper.Configuration;
using KursMVVM.Models;
using KursMVVM.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class LoadCSVClient : ILoadInteface<Client>
    {
        ClientsPageService client=new ClientsPageService();
        public async Task LoadList(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    csv.Context.RegisterClassMap<ClientMap>();
                    var record = csv.GetRecord<Client>();
                    await client.Add(record);
                }
            }
        }
        public async Task Upload(string path,List<Client> list)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
            }
        }
    }
}
