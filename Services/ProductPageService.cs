using KursMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class ProductPageService:IDBService<Product>
    {
        public Task Add(Product t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Product t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> get()
        {
            using (KursContext db = new KursContext())
            {
                var list = db.Products.ToListAsync();
                if (list != null) return await list;
                return null!;
            }
        }

        public Task<Product> getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
