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

namespace Employee_And_Company_Management.Views.Windows.Components
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public Visibility YesButtonVisibility { get; set; } = Visibility.Collapsed;
        public Visibility NoButtonVisibility { get; set; } = Visibility.Collapsed;
        public Visibility CancelButtonVisibility { get; set; } = Visibility.Collapsed;

        public CustomMessageBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = null;
            Close();
        }

        public static bool? Show(string title, string message, MessageBoxButton buttons)
        {
            var messageBox = new CustomMessageBox
            {
                Title = title,
                Message = message
            };

            switch (buttons)
            {
                case MessageBoxButton.YesNo:
                    messageBox.YesButtonVisibility = Visibility.Visible;
                    messageBox.NoButtonVisibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    messageBox.YesButtonVisibility = Visibility.Visible;
                    messageBox.NoButtonVisibility = Visibility.Visible;
                    messageBox.CancelButtonVisibility = Visibility.Visible;
                    break;
                case MessageBoxButton.OK:
                    messageBox.YesButtonVisibility = Visibility.Visible;
                    break;
            }

            return messageBox.ShowDialog();
        }
    }

    public enum MessageBoxButton
    {
        YesNo,
        YesNoCancel,
        OK
    }
}
