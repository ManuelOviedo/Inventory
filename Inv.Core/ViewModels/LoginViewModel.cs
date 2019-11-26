using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Inventory.Core.Services;

namespace Inventory.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly ILoginService _LoginService;
        private string _UserName;
        public Dictionary<string, string> LanguageCollection
        {
            get => languages;
        }

        public string CurrentLanguage
        {
            get => GetSetting();
            set
            {
                UpdateSetting(value);
                RaisePropertyChanged(() => CurrentLanguage);
            }
        }



            public LoginViewModel(ILoginService loginService)
        {
            _LoginService = loginService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            //UserName = "Oviedo!";
            //Recalculate();
        }

        public string WelcomeMessage => "Welcome";

        public string UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;
                RaisePropertyChanged(() => UserName);
                RaisePropertyChanged(() => WelcomeMessage); 
                //Recalculate();
            }
        }

        //private int _generosity;
        //public int Generosity
        //{
        //    get => _generosity;
        //    set
        //    {
        //        _generosity = value;
        //        RaisePropertyChanged(() => Generosity);

        //        Recalculate();
        //    }
        //}

        //private double _tip;
        //public double Tip
        //{
        //    get => _tip;
        //    set
        //    {
        //        _tip = value;
        //        RaisePropertyChanged(() => Tip);
        //    }
        //}

        //private void Rename()
        //{
        //    Tip = _LoginService.(UserName, Generosity);
        //}
    }
}