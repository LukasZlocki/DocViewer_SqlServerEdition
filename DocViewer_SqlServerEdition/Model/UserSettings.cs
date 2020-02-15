using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocViewer_SqlServerEdition.Model
{
    class UserSettings
    {
        public bool IsLoadingStation { get; set; }
        public string  ResourcesPath { get; set; }
        public string SqlConnectionString { get; set; }
        
    }
}
