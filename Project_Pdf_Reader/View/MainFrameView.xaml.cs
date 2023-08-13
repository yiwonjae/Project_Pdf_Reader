﻿using Project_Pdf_Reader.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Pdf_Reader.View
{
    /// <summary>
    /// MainFrameView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainFrameView : UserControl
    {
        public MainFrameView(MainFrameViewModel _VM)
        {
            InitializeComponent();

            this.DataContext = _VM;
        }


    }
}
