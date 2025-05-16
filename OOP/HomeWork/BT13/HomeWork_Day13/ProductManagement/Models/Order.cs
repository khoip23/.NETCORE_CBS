public class Order
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerName { get; set; }
    public bool IsDelivered { get; set; }
}
