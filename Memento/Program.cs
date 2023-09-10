using Memento;

var order = new Order { Id = 1, Name = "Order name" };
var orderMemento = order.SaveStateToMemento();

var careTaker = new CareTaker();
Console.WriteLine(careTaker.AddMemento(orderMemento));
order = new Order { Id = 2, Name = "Order name1" };
orderMemento = order.SaveStateToMemento();
Console.WriteLine(careTaker.AddMemento(orderMemento));

order.RestoreStateFromMemento(careTaker.GetOrderMemento(0));
Console.WriteLine(order.Name);
order.RestoreStateFromMemento(careTaker.GetOrderMemento(1));
Console.WriteLine(order.Name);