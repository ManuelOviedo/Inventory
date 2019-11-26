using System;
using System.Collections.Generic;

namespace Inventory.Core
{
    public static class Constants
    {
        public const string BaseUrl = "https://swapi.co/api";
        public const string RootFolderForResources = "Config/Langs";
        public const string GeneralNamespace = "Inventory";
    }

    public class Languages
    {

        public Dictionary<string, string> _languages = new Dictionary<string, string>()
        {
            ["en-US"] = "English",
            ["es-MX"] = "Español"
        };
    }
}       
