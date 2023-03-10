using OneOf;

namespace OneOfTest;

public class Order
{
    public int Id { get; set; }
    public string ContactNumber { get; set; }

    public Order(int id, string contactNumber)
    {
        Id = id;
        ContactNumber = contactNumber;
    }
}
public class ValidOrder
{
    public Order Order { get; }
    public ValidOrder(Order order)
    {
        Order = order;
    }
}
public class InvalidOrder
{
    public int Id { get; }
    public InvalidOrder(Order order)
    {
        Id = order.Id;
    }
}
[GenerateOneOf]
public partial class ProcessedOrder : OneOfBase<ValidOrder, InvalidOrder>
{}