namespace GlobalMart.Services
{
    public class PricingService : IPricingService
    {
        private const string CodeWinter = "WINTER25";
        private const string CodeFreeShip = "FREESHIP";

        private const decimal WinterDiscountRate = 0.15m;  
        private const decimal FreeShipDiscount = 5.00m;     

        public decimal CalculateFinalPrice(decimal basePrice, string? promoCode)
        {
            if (basePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(basePrice), "Base price cannot be negative.");

            var code = promoCode?.Trim().ToUpperInvariant();

            var finalPrice = code switch
            {
                CodeWinter   => basePrice * (1 - WinterDiscountRate),   
                CodeFreeShip => basePrice - FreeShipDiscount,           
                _            => basePrice                               
            };

            return Math.Max(0m, Math.Round(finalPrice, 2));
        }
    }
}
