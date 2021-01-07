/*
* FILE : MainWindow.xaml.cs
* PROJECT : PROG2121 - Assignment #2
* PROGRAMMER : Janeth Santos
* FIRST VERSION : September 27, 2020
* DESCRIPTION :
* The purpose of this file is to contain the Logic code for the Main Program Window 
* producing functionality to the drop up menu for new, open, save and close a .txt file,
* also has a dark mode and displays the count of the characters in a status bar at the bottom of the screen 
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///     
    public partial class MainWindow : Window
    {
        bool ItsSaved = false;          //represents if the file is saved
        string CurrentFile = "";        // Store name of current file open
        
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //-------------- ------------  New File Command ----------------------------------------
        //Name	: SaveAsCommandBinding
        //Purpose : Command handlers to create a NEW txt file and save changes before hand
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Do you want to save changes?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                //instanciate the object
                System.Windows.Forms.SaveFileDialog SaveFile = new System.Windows.Forms.SaveFileDialog();

                //filter save only .txt files            
                SaveFile.DefaultExt = ".txt";
                SaveFile.FileName = " Save Text File";
                SaveFile.Filter = "Text documents (*.txt)|*.txt";

                //display the open window
                if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //display content of file in text editor
                    File.WriteAllText(SaveFile.FileName, MainTextEditor.Text);
                    ItsSaved = false;
                }

                

                MainTextEditor.Text = " ";
            }
            else
            {
                MainTextEditor.Text = " ";
            }
            CurrentFile = "";
        }


        //-------------- ------------  OPEN Command Binding ----------------------------------------
        //Name	: OpenCommandBindings
        //Purpose : Command handlers to OPEN a txt file
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void OpenCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            bool NotCancel = true;

            //instanciate the object
            System.Windows.Forms.OpenFileDialog OpenFile = new System.Windows.Forms.OpenFileDialog();

            //filter for only .txt file extension
            OpenFile.DefaultExt = ".txt";
            OpenFile.FileName = " Select Text File";
            OpenFile.Filter = "Text documents (*.txt)|*.txt";

            if (ItsSaved == true)
            {
                MessageBoxResult MessageResult = System.Windows.MessageBox.Show("Do you want to save changes?", "Question",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
                if ( MessageResult == MessageBoxResult.Yes)
                {
                    //instanciate the object
                    System.Windows.Forms.SaveFileDialog SaveFile = new System.Windows.Forms.SaveFileDialog();

                    //filter save only .txt files            
                    SaveFile.DefaultExt = ".txt";
                    SaveFile.FileName = " Save Text File";
                    SaveFile.Filter = "Text documents (*.txt)|*.txt";

                    //display the open window
                    if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //display content of file in text editor
                        File.WriteAllText(SaveFile.FileName, MainTextEditor.Text);
                        ItsSaved = false;
                    }
                    
                }
                else if(MessageResult == MessageBoxResult.Cancel)
                {
                    NotCancel = false;
                }
                
            }
           
            if(NotCancel == true)
            {
                //display the open window
                if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //display content of file in text editor
                    MainTextEditor.Text = File.ReadAllText(OpenFile.FileName);
                    CurrentFile = System.IO.Path.GetFileName(OpenFile.FileName);
                }
            }
            

        }


        //-------------- ------------  Save As Command Binding ----------------------------------------
        //Name	: SaveAsCommandBinding
        //Purpose : Command handlers to SAVE a txt file
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void SaveAsCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ItsSaved == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //instanciate the object
            System.Windows.Forms.SaveFileDialog SaveFile = new System.Windows.Forms.SaveFileDialog();

            //filter save only .txt files            
            SaveFile.DefaultExt = ".txt";
            SaveFile.FileName = " Select Text File";
            SaveFile.Filter = "Text documents (*.txt)|*.txt";

            //display the open window
            if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //display content of file in text editor
                File.WriteAllText(SaveFile.FileName, MainTextEditor.Text);
                ItsSaved = false;
                CurrentFile = System.IO.Path.GetFileName(SaveFile.FileName);
            }

            
        }

        private void MainTextEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            ItsSaved = true;
        }


        //-------------- ------------  Closing from Menu Item ----------------------------------------
        //Name	: Close command handlers
        //Purpose : Prompts user to save file before closing the program from the drop down menu
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            //instanciate the closebox object
            ClosingWindow CloseBox = new ClosingWindow();
            CloseBox.Owner = this;

            //display the window
            CloseBox.ShowDialog();


        }

        //-------------- ------------  About Box ----------------------------------------
        //Name	: HelpAbout_Click
        //Purpose : Handler for about menu item in drop down menu, displays info about the program
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void HelpAbout_Click(object sender, RoutedEventArgs e)
        {
            //instanciate the closebox object
            About AboutBox = new About();
            AboutBox.Owner = this;

            //display the window
            AboutBox.ShowDialog();
        }


        //-------------- ------------  Status bar count  ----------------------------------------
        //Name	: MainTextEditor_TextChanged
        //Purpose : to update the current count of lines, characters and file name in the document
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void MainTextEditor_TextChanged(object sender, RoutedEventArgs e)
        {
            //get the total count of all characters
            int TotalCharCount = MainTextEditor.Text.Length;

            //gets the current row (line) of the cursor position, add 1 since count starts at 0
            int CurrentLine = MainTextEditor.GetLineIndexFromCharacterIndex(MainTextEditor.CaretIndex);

            //gets initial value of current Line
            int FirstCharOfLine = MainTextEditor.GetCharacterIndexFromLineIndex(CurrentLine);
            
            // calculation to current char count for cursor in current line
            int LineCharCount = MainTextEditor.CaretIndex - FirstCharOfLine;
         
           //Display info in status bar
            TbCharCount.Text = "Line: " + (CurrentLine + 1) + ", Char: " + 
                LineCharCount + "\t\t\t Total chars: " + TotalCharCount + "\t\t\t Filename: "+ CurrentFile  ;
        }


        //-------------- ------------  Dark mode ----------------------------------------
        //Name	: DarkModeMenu_Click
        //Purpose : handler that changes the colors of the window between the original colors or dark mode 
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void DarkModeMenu_Click(object sender, RoutedEventArgs e)
        {
            if(TopMenu.Background == Brushes.WhiteSmoke)
            {
                TopMenu.Background = Brushes.Black;             //top menu
                TopMenu.Foreground = Brushes.White;             //top menu font
                FileNew.Background = Brushes.Black;             //file new
                FileOpen.Background = Brushes.Black;            //Open
                FileSaveAs.Background = Brushes.Black;          //SaveAs
                FileClose.Background = Brushes.Black;           //Close
                DarkModeMenu.Background = Brushes.Black;        //Dark mode
                HelpAbout.Background = Brushes.Black;           //Help About                
                StatusBarBottom.Background = Brushes.Black;     //status bar bottom
                StatusBarBottom.Foreground = Brushes.White;     // change font white status bar
                MainTextEditor.Foreground = Brushes.White;      // change font white Main text editor
                MainTextEditor.Background = Brushes.Black;      // Change background of text editor
            }
            else
            {
                TopMenu.Background = Brushes.WhiteSmoke;            //top menu
                TopMenu.Foreground = Brushes.Black;                 //top menu font
                FileNew.Background = Brushes.WhiteSmoke;            //file new
                FileOpen.Background = Brushes.WhiteSmoke;            //Open
                FileSaveAs.Background = Brushes.WhiteSmoke;          //SaveAs
                FileClose.Background = Brushes.WhiteSmoke;           //Close
                DarkModeMenu.Background = Brushes.WhiteSmoke;        //Dark mode
                HelpAbout.Background = Brushes.WhiteSmoke;           //Help About                
                StatusBarBottom.Background = Brushes.WhiteSmoke;     //status bar bottom
                StatusBarBottom.Foreground = Brushes.Black;          // change font white status bar
                MainTextEditor.Foreground = Brushes.Black;           // change font white Main text editor
                MainTextEditor.Background = Brushes.WhiteSmoke;      // Change background of text editor
            }

        }
                   


        //---------------------------  Closing Program Window Tool bar ----------------------------------------
        //Name	: MainWindowClosing
        //Purpose : Prompts user to save file before closing the program from the toolbar 
        //Inputs	: Object , RoutedEventsArgs
        //Outputs	: NONE
        //Returns	: Void
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ItsSaved != true)
            { 
                if (System.Windows.MessageBox.Show("Do you want to save changes?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    //instanciate the object
                    System.Windows.Forms.SaveFileDialog SaveFile = new System.Windows.Forms.SaveFileDialog();

                    //filter save only .txt files            
                    SaveFile.DefaultExt = ".txt";
                    SaveFile.FileName = " Save Text File";
                    SaveFile.Filter = "Text documents (*.txt)|*.txt";

                    //display the open window
                    if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //display content of file in text editor
                        File.WriteAllText(SaveFile.FileName, MainTextEditor.Text);
                        ItsSaved = false;
                    }

                    

                     App.Current.Shutdown();
                }
                
            }
            else
            {
                App.Current.Shutdown();
            }
        }
    }
}
