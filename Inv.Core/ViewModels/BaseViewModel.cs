using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Inventory.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private static Languages _languages = new Languages();

        public static Dictionary<string, string> languages
        {
            get => _languages._languages;
        }

        public void UpdateSetting(string value)
        {
            if (GetSetting() != value && languages.ContainsKey(value))
            {
                XMLCreation(value);
            }
        }

        public string GetSetting()
        {
            var lang = "en-US";
            try
            {
                XDocument xdoc = XDocument.Load("Settings.xml");
                var TempLang = xdoc.Elements("Languages")
                    .Select(x => x.Element("selected")).First();
                lang = TempLang.Attribute("value").Value;
            }
            catch (Exception)
            {
                XMLCreation(lang);
            }
            return lang;
        }

        private void XMLCreation(string value)
        {
            XElement settings = new XElement("Languages",
                    new XElement("selected",
                        new XAttribute("value", value)
                    )
                );
            settings.Save("Settings.xml");
        }

        protected BaseViewModel()
        {
        }

        // This method finds the day or returns an Exception if the day is not found
        private int GetRM(string index)
        {

            

            throw new System.ArgumentOutOfRangeException(, "testDay must be in the form \"Sun\", \"Mon\", etc");
        }


        public string this[string index] 
        {
            get
            {
                return (GetRM(index));
            }
        }
    }

    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        private static Languages _languages = new Languages();

        public static Dictionary<string, string> languages
        {
            get => _languages._languages;
        }

        private void UpdateSetting(string value)
        {
            if (GetSetting() != value && languages.ContainsKey(value))
            {
                XMLCreation(value);
            }
        }

        private string GetSetting()
        {
            var lang = "en-US";
            try
            {
                XDocument xdoc = XDocument.Load("Settings.xml");
                var TempLang = xdoc.Elements("Languages")
                    .Select(x => x.Element("selected")).First();
                lang = TempLang.Attribute("value").Value;
            }
            catch (Exception)
            {
                XMLCreation(lang);
            }
            return lang;
        }

        private void XMLCreation(string value)
        {
            XElement settings = new XElement("Languages",
                    new XElement("selected",
                        new XAttribute("value", value)
                    )
                );
            settings.Save("Settings.xml");
        }

        protected BaseViewModel()
        {
        }
    }
}
