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
        public string InstructionFileExtension { get; set; }
        public string SqlConnectionString { get; set; }

        //Constructor
        public UserSettings()
        {

        }
        // Constructor
        public UserSettings(bool isLoadingStation, string resourcePath, string instructionFileExtension, string sqlConnectoinString)
        {
            IsLoadingStation = isLoadingStation;
            ResourcesPath = resourcePath;
            InstructionFileExtension = instructionFileExtension;
            SqlConnectionString = sqlConnectoinString;
        }

    }
}
