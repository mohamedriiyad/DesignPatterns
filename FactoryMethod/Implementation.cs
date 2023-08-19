namespace FactoryMethod
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryCode;

        public override int DiscountPercentage
        {
            get
            {
                if(_countryCode == "EG")
                {
                    return 20;
                }

                return 10;
            }
        }

        public CountryDiscountService(string countryCode)
        {
            _countryCode = countryCode;
        }
    }

    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public override int DiscountPercentage
        {
            get
            {
                return 15;
            }
        }

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }

    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _country;

        public CountryDiscountFactory(string country)
        {
            _country = country;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_country);
        }
    }
}
