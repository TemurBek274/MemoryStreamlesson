namespace MemoryStreamlesson
{
    internal class Order
    {
       
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; }
        
    }
}
