namespace State
{
    public class Order
    {
        public Order()
        {
            State = new OrderDraftState(this);
        }
        public IOrderState State { get; internal set; }

        public List<OrderLine> Lines { get; private set; } = new();

        //public void SetState(OrderState newState)
        //{
        //    if(State == OrderState.Draft && newState != OrderState.Confirmed ||
        //        State == OrderState.Confirmed && newState != OrderState.Canceled && newState != OrderState.UnderProcessing ||
        //        State == OrderState.UnderProcessing && newState != OrderState.Shipped ||
        //        State == OrderState.Shipped && newState != OrderState.Delivered ||
        //        State == OrderState.Delivered && newState != OrderState.Returned
        //        )
        //    {
        //        throw new InvalidOperationException($"Moving from state `{State}` to state `{newState}` is not supported");
        //    }

        //    State = newState;
        //}

        public void Cancel()
        {
            State.Cancel();
        }

        public void Confirm()
        {
            State.Confirm();
        }

        public void Deliver()
        {
            State.Deliver();
        }

        public void Process()
        {
            State.Process();
        }

        public void Return()
        {
            State.Return();
        }

        public void Ship()
        {
            State.Ship();
        }
    }

    public enum OrderState
    {
        Draft,
        Confirmed,
        Canceled,
        UnderProcessing,
        Shipped,
        Delivered,
        Returned,
    }

    public class OrderLine
    {
        public int ProductId { get; set; }

        public double Quantity { get; set; }

        public double UnitPrice { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }

    public class ProductDataReader
    {
        public IEnumerable<Product> GetProducts()
        {
            return new[]
            {
                new Product {Id = 1, Name = "Laptop", UnitPrice = 10000},
                new Product {Id = 2, Name = "LCD", UnitPrice = 200},
                new Product {Id = 3, Name = "Keyboard", UnitPrice = 150},
                new Product {Id = 4, Name = "Mouse", UnitPrice = 100},
            };
        }
    }

    public interface IOrderState
    {
        void Confirm();
        void Cancel();
        void Process();
        void Ship();
        void Deliver();
        void Return();
    }

    public class OrderCanceledState : IOrderState
    {
        public readonly Order _order;

        public OrderCanceledState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Confirm()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            throw new NotImplementedException();
        }

        public void Ship()
        {
            throw new NotImplementedException();
        }
    }

    public class OrderConfirmedState : IOrderState
    {
        public readonly Order _order;

        public OrderConfirmedState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            _order.State = new OrderCanceledState(_order);
        }

        public void Confirm()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            _order.State = new OrderProcessedState(_order);
        }

        public void Return()
        {
            throw new NotImplementedException();
        }

        public void Ship()
        {
            throw new NotImplementedException();
        }
    }

    public class OrderProcessedState : IOrderState
    {
        public readonly Order _order;

        public OrderProcessedState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Confirm()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            throw new NotImplementedException();
        }

        public void Ship()
        {
            _order.State = new OrderShippedState(_order);
        }
    }

    public class OrderShippedState : IOrderState
    {
        public readonly Order _order;

        public OrderShippedState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Confirm()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            _order.State = new OrderDeliveredState(_order);
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            _order.State = new OrderReturnededState(_order);
        }

        public void Ship()
        {
            throw new NotImplementedException();
        }
    }

    public class OrderDeliveredState : IOrderState
    {
        public readonly Order _order;

        public OrderDeliveredState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Confirm()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            _order.State = new OrderReturnededState(_order);
        }

        public void Ship()
        {
            throw new NotImplementedException();
        }
    }

    public class OrderReturnededState : IOrderState
    {
        public readonly Order _order;

        public OrderReturnededState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Confirm()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            throw new NotImplementedException();
        }

        public void Ship()
        {
            throw new NotImplementedException();
        }
    }

    public class OrderDraftState : IOrderState
    {
        public readonly Order _order;

        public OrderDraftState(Order order)
        {
            _order = order;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Confirm()
        {
            _order.State = new OrderConfirmedState(_order);
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Return()
        {
            throw new NotImplementedException();
        }

        public void Ship()
        {
            throw new NotImplementedException();
        }
    }
}
