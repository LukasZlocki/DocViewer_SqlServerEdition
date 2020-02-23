using DocViewer_SqlServerEdition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocViewer_SqlServerEdition
{
    /// <summary>
    /// DocViewer SqlServer Edition
    /// by
    /// lzlocki
    /// AD : 2020
    /// </summary>
    public partial class MainWindow : Window
    {
        UserSettings UserSettings;

        public MainWindow()
        {
            InitializeComponent();

            // Load user settings from file
            UserSettings = new UserSettings();
            IOSettingsAdapter IoAdapter = new IOSettingsAdapter();
            IoAdapter.LoadSettings(ref UserSettings);          
        }

        #region BUTTONS
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            string _partNumber = "";

            Document Instruction = new Document();
            _partNumber = txtBoxID.Text;

            // Load instruction from database
            LoadDocuments(_partNumber, ref Instruction, UserSettings);

            // Show instruction on user screen
            ShowInstructionOnScreen(Instruction, UserSettings);
            
        }
        #endregion


        #region Load & show document
        // Load instruction from database
        private void LoadDocuments(string partNb, ref Document instruction, UserSettings settings )
        {
            SqlAdapter sqlAdapter = new SqlAdapter(settings);
            sqlAdapter.PullInstructionFromSql(partNb, ref instruction);
        }

        // Show instruction on user screen
        private void ShowInstructionOnScreen(Document instruction, UserSettings userSettings)
        {
            string resourcesPathLoadingZone = userSettings.ResourcesPath + "\\" + instruction.LoadingDocumentName + UserSettings.InstructionFileExtension;
            string resourcesPathUnloadingZone = userSettings.ResourcesPath + "\\" + instruction.UnloadingDocumentName + UserSettings.InstructionFileExtension;
            string resourcePath = "";

            // Set resurces path according to user settings - loading / unloading area
            if (userSettings.IsLoadingStation == true) 
            {
                resourcePath = resourcesPathLoadingZone;
            }
            else
            {
                resourcePath = resourcesPathUnloadingZone;
            }

            try
            {
                ImageSource imagesource = new BitmapImage(new Uri(resourcePath));
                ImageShow.Source = imagesource;
            }
            catch
            {
                // ToDo : Code showing "document not awailable on screen" - new method to handle errors is needed.
            }                                 
        }
        #endregion


        #region Window menu - user settings

        private void SettingsWindowRun(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        #endregion


    }
}
