﻿using Employee_And_Company_Management.ViewModels.Companies;
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

namespace Employee_And_Company_Management.Views.Windows.Companies
{
    /// <summary>
    /// Interaction logic for DissmisEmploymentWindow.xaml
    /// </summary>
    public partial class DissmisEmploymentWindow : Window
    {
        public DissmisEmploymentWindow(EmployeeCompanyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
