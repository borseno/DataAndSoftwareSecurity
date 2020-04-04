﻿using System;
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
using static Program;
//using DES_Core;

namespace Lab1_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            var text = tbText.Text;
            var key = tbKey.Text;
            var isDecryption = true;

            tbOutput.Text = cryptography.encrypt(key, isDecryption, text);
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            var text = tbText.Text;
            var key = tbKey.Text;
            var isDecryption = false;

            tbOutput.Text = cryptography.encrypt(key, isDecryption, text);
        }
    }
}
