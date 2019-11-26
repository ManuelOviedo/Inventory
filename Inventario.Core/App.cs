using MvvmCross;
using MvvmCross.ViewModels;
using Inventario.Core.Services;
using Inventario.Core.ViewModels;

namespace Inventario.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Mvx.IoCProvider.RegisterType<ICalculationService, CalculationService>();
            //RegisterAppStart<TipViewModel>();
        }
    }
}