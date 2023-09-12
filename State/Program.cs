using State;

var products = new ProductDataReader().GetProducts();

while(true)
{
	Console.WriteLine("Item list:");
	foreach(var product in products)
		Console.WriteLine($"\t{product.Id}. {product.Name} ({product.UnitPrice:0.00})");
	Console.WriteLine();

	Order order = new();
	Console.WriteLine($"Order State: {order.State}");

	while(true)
	{
		Console.WriteLine("Enter product ID (0 for completing the order).");
		int productId;
		int.TryParse(Console.ReadLine(), out productId);

		if(productId == 0)
			break;

		Console.WriteLine("Enter product Quantity: ");
		double quantity;
		double.TryParse(Console.ReadLine(), out quantity);
		var product = products.FirstOrDefault(x => x.Id == productId);

		order.Lines.Add(new OrderLine { ProductId = productId, Quantity = quantity, UnitPrice = product.UnitPrice });
	}

	while(true)
	{
		Console.WriteLine("Select Action:");
		Console.WriteLine("\t1. Confirm");
		Console.WriteLine("\t2. Cancel");
		Console.WriteLine("\t3. Process");
		Console.WriteLine("\t4. Ship");
		Console.WriteLine("\t5. Deliver");
		Console.WriteLine("\t6. Return");
		Console.WriteLine("\t0. Exit");
		try
		{
			var action = int.Parse(Console.ReadLine());
			if(action == 0)
				break;

			var orderState = (OrderState)action;
			switch(orderState)
			{
				case OrderState.Confirmed:
					order.Confirm();
					break;
				case OrderState.Canceled:
					order.Cancel();
					break;
				case OrderState.UnderProcessing:
					order.Process();
					break;
				case OrderState.Shipped:
					order.Ship();
					break;
				case OrderState.Delivered:
					order.Deliver();
					break;
				case OrderState.Returned:
					order.Return();
					break;
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Order state changed to {order.State}");
			Console.ForegroundColor = ConsoleColor.White;
		}
		catch(Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex.Message);
			Console.ForegroundColor = ConsoleColor.White;
		}


	}
}