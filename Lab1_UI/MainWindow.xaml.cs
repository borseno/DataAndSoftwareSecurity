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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var isDecryption = sender == Decrypt;

            var text = isDecryption ? tbText.Text : formatting.textToBinary(tbText.Text);
            var keyText = tbKey.Text;
            string key = await Task.Run(() => RawTextToSHAkey(keyText));            
            tbOutput.Text = await Task.Run(() => GetResult(text, key, isDecryption));
        }

        private string RawTextToSHAkey(string text)
        {
            return String.Concat(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes(text)).Take(64).Select(i => Convert.ToString(i, 2)));
        }       

        private string GetResult(IEnumerable<char> text, string key, bool isDecryption)
        {
            if (isDecryption)
            {
                return new string(formatting.binaryToText(cryptography.decryptDES(key, text)).ToArray());
            }
            else
            {
                return cryptography.encryptDES(key, text);
            }
        }
    }
}
