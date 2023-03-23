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
using Prism.Services.Dialogs;

namespace WpfApp1.Views
{
    /// <summary>
    /// Dialog1.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog1 :Window, IDialogWindow
    {

        public IDialogResult Result
        {
            get; set;
        }



        public Dialog1()
        {
            InitializeComponent();
        }
    }
}
