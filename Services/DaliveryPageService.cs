using KursMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class DaliveryPageService : IDBService<FactOrder>
    {
        public async Task Add(FactOrder t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(FactOrder t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FactOrder>> get()
        {
            using (KursContext db = new KursContext())
            {
                var list = db.FactOrders.ToListAsync();
                if (list != null) return await list;
                return null!;
            }
        }

        public async Task<FactOrder> getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
