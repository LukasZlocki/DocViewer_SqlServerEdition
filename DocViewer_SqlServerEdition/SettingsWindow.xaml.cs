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
using System.Windows.Shapes;

namespace DocViewer_SqlServerEdition
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        UserSettings UserSettings = new UserSettings();
        public SettingsWindow()
        {
            InitializeComponent();

            LoadUserSettings(ref UserSettings);
            ShowSettingsOnScreen(UserSettings);            
        }

        // Savr changes to file and close window
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            // store resurce path
            UserSettings.ResourcesPath = txtPathDocs.Text;

            IOSettingsAdapter IoSettingAdapter = new IOSettingsAdapter();
            IoSettingAdapter.SaveSettings(UserSettings);
            this.Close();
        }


        private void LoadUserSettings(ref UserSettings userSettings)
        {
            IOSettingsAdapter IoSettingsAdapter = new IOSettingsAdapter();
            IoSettingsAdapter.LoadSettings(ref UserSettings);
        }

        private void ShowSettingsOnScreen(UserSettings userSetings)
        {
            txtPathDocs.Text = userSetings.ResourcesPath;
            radiobtnEnabledLoadingStation.IsChecked = userSetings.IsLoadingStation;
            radiobtnEnabledUnLoadingStation.IsChecked = (!userSetings.IsLoadingStation);
        }

        #region Radiobuttons 
        private void RadiobtnEnabledLoadingStation_Checked(object sender, RoutedEventArgs e)
        {
            UserSettings.IsLoadingStation = true;
        }

        private void RadiobtnEnabledUnLoadingStation_Checked(object sender, RoutedEventArgs e)
        {
            UserSettings.IsLoadingStation = false;
        }
        #endregion
    }
}
