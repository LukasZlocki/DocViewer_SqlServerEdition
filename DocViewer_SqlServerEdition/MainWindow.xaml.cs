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
    /// DocViewer SqlServer Eddition
    /// by
    /// lzlocki
    /// AD : 2020
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //ToDo : Code loading data from txt file
            UserSettings UserSettings = new UserSettings();
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
            LoadDocuments(_partNumber, ref Instruction);

            // Show instruction on user screen
            ShowInstructionOnScreen();
            
        }

        #endregion


        // Load instruction from database
        private void LoadDocuments(string partNb, ref Document instruction)
        {
            // ToDo : code loading instruction from sql server
            SqlAdapter sqlAdapter = new SqlAdapter();

        }

        // Show instruction on user screen
        private void ShowInstructionOnScreen()
        {
            // ToDo : code showing instruction on user screen

        }

    }
}
