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

namespace CrySecAdminPanel.Views.UserControls
{
    /// <summary>
    /// Lógica de interacción para GroupCard.xaml
    /// </summary>
    public partial class GroupCard : UserControl
    {
        public GroupCard()
        {
            InitializeComponent();
        }

        private void EnterEditMode(object sender, RoutedEventArgs e)
        {
            textName.Visibility= Visibility.Collapsed;
            inputName.Text = textName.Text;
            inputName.Visibility = Visibility.Visible;
        }
    }
}
