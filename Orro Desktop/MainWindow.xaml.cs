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
using Engine;
using Engine.Devices;
using Engine.Interfaces;

namespace Orro_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var items = new List<IDevice>
            {
                new TP_Link_Kasa(new System.Net.IPEndPoint(1921681110, 9999), new XOREncryption(), new UDPConnection(), "Test bulb")
            }; 
            deviceListView.ItemsSource = items;
        }
    }
}
