using System.Collections.Generic;
using System.Linq;

namespace side.winder.Domain.Orders
{
    public class Orders{
        public int id {get; set;}
        public List<OrderItem> Items {get; set;}
        public DateTime CreatedDate {get; set;}
        public decimal TotalPrice => Items.Sum(i => i.Price);
    }
}