using Employee_And_Company_Management.ViewModels;
using Employee_And_Company_Management.ViewModels.Components;
using System.Windows;

namespace Employee_And_Company_Management.Views.Windows.Components
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public static MessageBoxResult Show(string message, string title, MessageBoxButton buttons)
        {
            var viewModel = new CustomMessageBoxViewModel
            {
                Title = title,
                Message = message
            };
            viewModel.SetButtonVisibility(buttons);

            var messageBox = new CustomMessageBox
            {
                DataContext = viewModel
            };

            viewModel.MessageBox= messageBox;

            bool? dialogResult = messageBox.ShowDialog();

            return dialogResult == true ? viewModel.Result : MessageBoxResult.Cancel;
        }
    }
}