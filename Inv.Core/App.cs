using MvvmCross;
using MvvmCross.ViewModels;
using Inventory.Core.Services;
using MvvmCross.IoC;

namespace Inventory.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Client")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // register the appstart object
            RegisterCustomAppStart<AppStart>();
            Mvx.IoCProvider.RegisterType<ILoginService, LoginService>();
            //RegisterAppStart<LoginViewModel>();
        }
    }
}
