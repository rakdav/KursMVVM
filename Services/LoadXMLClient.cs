using KursMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using System.Xml.Serialization;

namespace KursMVVM.Services
{
    public class LoadXMLClient : ILoadInteface<Client>
    {

        private ClientsPageService service = new ClientsPageService();

        public async Task LoadList(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Client[]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Client[]? newpeople = formatter.Deserialize(fs) as Client[];
                if (newpeople != null)
                {
                    foreach (Client person in newpeople)
                    {
                        service?.Add(person);
                    }
                }
            }
        }
        public  async Task Upload(string path,List<Client> list)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Client[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list.ToArray());
            }
        }
    }
}
