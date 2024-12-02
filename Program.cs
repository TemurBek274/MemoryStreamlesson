using System.Text;
using System.Text.Json;

namespace MemoryStreamlesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order()
            {
                OrderId = 1,
                CustomerName = "Sherzod",
                TotalAmount = 23,
                Items = new List<OrderItem>
                {
                    new OrderItem()
                    {
                        ItemName = "novutbuk",
                        Quantily = 30,
                        Price = 5000000
                    },
                    new OrderItem()
                    {
                        ItemName = "Telefon",
                        Quantily = 25,
                        Price = 2100000
                    }
                }
            };

            var JsonOpshen = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(order, JsonOpshen);
            //Console.WriteLine(json);
            using (var memory =  new MemoryStream())
            {
                var buffer = Encoding.UTF8.GetBytes(json);
                //memory.Position = 0;
                memory.Write(buffer, 0, buffer.Length);
                var old = Encoding.UTF8.GetString(buffer);
                old = old.Replace("\"TotalAmount\": 23", "\"TotalAmount\": 22");

                var apdet = JsonSerializer.Deserialize<Order>(old);
                Console.WriteLine($"{apdet.OrderId}\n{apdet.CustomerName}\n{apdet.TotalAmount}");
                Console.WriteLine("Items: ");
                foreach (var item in apdet.Items)
                {
                    Console.WriteLine($"{item.ItemName}\n{item.Quantily}\n{item.Price}");
                }
            }
        }
    }

    
   
}
