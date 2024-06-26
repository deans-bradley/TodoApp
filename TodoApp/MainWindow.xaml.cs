﻿using System.Windows;
using TodoApp.ViewModels;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new TodoViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
        }
    }
}