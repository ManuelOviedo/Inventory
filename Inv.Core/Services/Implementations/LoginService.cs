namespace Inventory.Core.Services
{
    public class LoginService : ILoginService
    {
        public double TipAmount(double subTotal, int generosity)
        {
            return subTotal * ((double)generosity) / 100.0;
        }
    }
}