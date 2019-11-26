namespace Inventory.Core.Services
{
    public interface ILoginService
    {
        double TipAmount(double subTotal, int generosity);
    }
}