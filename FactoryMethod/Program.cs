using FactoryMethod;

var factories = new List<DiscountFactory> { new CountryDiscountFactory("EG"), new CodeDiscountFactory(Guid.NewGuid()) };

foreach(var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage is {discountService.DiscountPercentage} and it comers from {discountService}");
}