using FactoryMethod;

#region First Example
var factories = new List<DiscountFactory> { new CountryDiscountFactory("EG"), new CodeDiscountFactory(Guid.NewGuid()) };

foreach(var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage is {discountService.DiscountPercentage} and it comers from {discountService}");
}

#endregion

#region Second Example
Console.WriteLine("Please enter your bank number");
var bankNumber = Console.ReadLine();
var bankCode = bankNumber.Substring(0, 6);

var bankFactory = new BankFactory(bankCode);
var bank = bankFactory.CreateBank();

Console.WriteLine(bank.Withdraw());
#endregion