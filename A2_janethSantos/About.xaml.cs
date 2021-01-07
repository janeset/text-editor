/*
* FILE : Main.xaml.cs
* PROJECT : PROG2121 - Assignment #2
* PROGRAMMER : Janeth Santos
* FIRST VERSION : September 27, 2020
* DESCRIPTION :
* The purpose of this file is to contain the Logic code for the About window class  
*/
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

namespace A2_janethSantos
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        //Display Box
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
