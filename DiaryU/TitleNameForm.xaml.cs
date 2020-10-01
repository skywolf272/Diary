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
using System.Windows.Shapes;

namespace DiaryU
{
    /// <summary>
    /// Логика взаимодействия для TitleNameForm.xaml
    /// </summary>
    public partial class TitleNameForm : Window
    {
        public TitleNameForm()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string title_Name
        {
            get { return titleName.Text; }
        }

        public string date_time
        {
            get { return date_time; }
        }
    }
}
