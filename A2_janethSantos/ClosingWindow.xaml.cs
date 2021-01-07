/*
* FILE : Main.xaml.cs
* PROJECT : PROG2121 - Assignment #2
* PROGRAMMER : Janeth Santos
* FIRST VERSION : September 27, 2020
* DESCRIPTION :
* The purpose of this file is to contain the Logic code for the Close Window Class
*/
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Forms;

namespace A2_janethSantos
{
    /// <summary>
    /// Interaction logic for ClosingWindow.xaml
    /// </summary>
    public partial class ClosingWindow : Window
    {
        public ClosingWindow()
        {
            InitializeComponent();
            
         }


        //Name	: CloseCancelSaveBtn_Click
        //Purpose : handler that closes the window message without saving changes in file 
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void CloseCancelSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //closes the window
            this.Close();
        }

        //Name	: CloseNoSaveBtn_Click
        //Purpose : handler that closes the program without saving changes in file 
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void CloseNoSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Close Application
            App.Current.Shutdown();
        }

        //Name	: CloseSaveBtn_Click
        //Purpose : handler that closes the program with saving changes in file 
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void CloseSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog save = new System.Windows.Forms.SaveFileDialog();

            //filter save only .txt files            
            save.DefaultExt = ".txt";
            save.FileName = " Select Text File";
            save.Filter = "Text documents (*.txt)|*.txt";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //instanciate a copy of mainWindow with current values
                MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

                //display content of file in text editor
                File.WriteAllText(save.FileName, main.MainTextEditor.Text);
                
                App.Current.Shutdown();
            }


        }
    }
}
