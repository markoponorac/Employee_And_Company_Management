﻿using Employee_And_Company_Management.ViewModels;
using Employee_And_Company_Management.ViewModels.Admin;
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

namespace Employee_And_Company_Management.Views.Controls.Admin
{
    /// <summary>
    /// Interaction logic for QualificationControl.xaml
    /// </summary>
    public partial class QualificationControl : UserControl
    {
        public QualificationControl()
        {
            InitializeComponent();
            var viewModel = new QualificationAdminViewModel();
            DataContext = viewModel;    
        }
    }
}
