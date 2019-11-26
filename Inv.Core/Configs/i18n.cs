using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Core.Configs
{
    public class i18n
    {
        private static Languages _languages = new Languages();

        public static Dictionary<string, string> languages
        {
            get => _languages._languages;
        }
        public i18n()
        {
            foreach (KeyValuePair<string, string> lang in languages)
            {
                ResourceManager
                this[lang.Key] = 
            }
        }
    }
}
