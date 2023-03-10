using OneOfTest;



ProcessedOrder[] ProcessOrders(Order[] orders)
{
    var processedOrders = new List<ProcessedOrder>();
    foreach (var order in orders)
    {
        if (string.IsNullOrEmpty(order.ContactNumber))
        {
            processedOrders.Add(new InvalidOrder(order));
        }
        else
        {
            processedOrders.Add(new ValidOrder(order));
        }
    }

    return processedOrders.ToArray();
}

// changed from the article to show how one might want to do nothing in certain scenarios like a valid order
void LogInvalidOrders(ProcessedOrder[] processedOrders)
{
    foreach (var order in processedOrders)
    {
        order.Switch(
            validOrder =>
                Console.WriteLine(
                    $"Invalid Order, Id : {validOrder.Order.Id}, Contact : {validOrder.Order.ContactNumber}"),
            _ => { });

    }
}
Order[] inputOrders = { new (1, "123456"), new (2, "")};

var processedOrders = ProcessOrders(inputOrders);

LogInvalidOrders(processedOrders);