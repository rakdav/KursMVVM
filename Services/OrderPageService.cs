using KursMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class OrderPageService:IDBService<Order>
    {
        public async Task<List<Order>> get()
        {
            using (KursContext db = new KursContext())
            {
                var list = db.Orders.ToListAsync();
                if (list != null) return await list;
                return null!;
            }
        }
        public async Task Add(Order order)
        {
            using (KursContext db = new KursContext())
            {
                await db.Orders.AddAsync(order);
                await db.SaveChangesAsync();
            }
        }
        public async Task Edit(Order order)
        {
            using (KursContext db = new KursContext())
            {
                Order editOrder = db.Orders.FirstOrDefault(p => p.IdOrder == order.IdOrder)!;
                editOrder.IdProduct= order.IdProduct;
                editOrder.IdClient= order.IdClient;
                editOrder.Quantity= order.Quantity;
                db.Orders.Update(editOrder);
                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (KursContext db = new KursContext())
            {

                Order deleteOrder = db.Orders.FirstOrDefault(p => p.IdOrder == id)!;
                db.Orders.Remove(deleteOrder);
                await db.SaveChangesAsync();
            }
        }
        public async Task<Order?> getById(int id)
        {
            using (KursContext db = new KursContext())
            {
                return await db.Orders.FirstOrDefaultAsync(p => p.IdOrder == id);
            }
        }
    }
}
