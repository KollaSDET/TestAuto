using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace bddUItests
{
    class DataSourceParser
    {
        
        public static ConfigSetting populateLogin() 
        { 
            string Loginjson = File.ReadAllText(@""); 
            ConfigSetting login = (ConfigSetting)JsonConvert.DeserializeObject(Loginjson); 
            return login; 
        }
    }
}
