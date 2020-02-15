﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DocViewer_SqlServerEdition.Model
{
    class IOSettingsAdapter
    {
        // ToDo : Code writing / loading user settings


        public void LoadSettings(ref UserSettings userSettings)
        {
            string _line = "";
            int _counter = 0;

            try
            {
                using (StreamReader sr = new StreamReader("userSettings.txt"))
                {
                    do
                    {
                        if (_counter == 1) { userSettings.IsLoadingStation = Convert.ToBoolean(_line); }
                        if (_counter == 2) { userSettings.ResourcesPath = Convert.ToString(_line); }
                        if (_counter == 3) { userSettings.SqlConnectionString = Convert.ToString(_line); }
                        _counter++;
                    } while ((_line = sr.ReadLine()) != null);
                }
                    

                
            }
            catch (Exception e)
            {
                MessageBox.Show("Brak poprawnej sciezki do pliku lub brak pliku " + e.Message);
            }

        }

        public void SaveSettings(UserSettings userSettings)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("userSettings.ini"))
                {
                    sw.WriteLine(Convert.ToString(userSettings.IsLoadingStation));
                    sw.WriteLine(Convert.ToString(userSettings.ResourcesPath));
                    sw.WriteLine(Convert.ToString(userSettings.SqlConnectionString));
                }
            } 
            catch
            {
                MessageBox.Show("Cos poszlo nie tak ... brak zapisu");
            }
        }


    }
}
