using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class Order
    {
        public Guid ID { get; private set; }
        public DateTime placedOn { get; private set; }
        public DateTime deliverOn { get; private set; }

        private static Random rng = new Random();

        public Order GenerateOrder()
        {
            Order order = new Order();
            order.ID = Guid.NewGuid();
            order.placedOn = DateTime.Now.AddDays(rng.Next(-5, 0));
            order.deliverOn = order.placedOn.AddDays(rng.Next(0, 6));
            return order;
        }

        public override string ToString()
        {
            return $"Order ID : {ID}\tPlaced On : {placedOn}\tDeliver By : {deliverOn}";
        }
    }
}
