using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Views.Windows.Components;
using System;
using System.Windows;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Components
{
    public class CustomMessageBoxViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private Visibility _yesButtonVisibility = Visibility.Collapsed;
        public Visibility YesButtonVisibility
        {
            get => _yesButtonVisibility;
            set => SetProperty(ref _yesButtonVisibility, value);
        }

        private Visibility _noButtonVisibility = Visibility.Collapsed;
        public Visibility NoButtonVisibility
        {
            get => _noButtonVisibility;
            set => SetProperty(ref _noButtonVisibility, value);
        }

        private Visibility _cancelButtonVisibility = Visibility.Collapsed;
        public Visibility CancelButtonVisibility
        {
            get => _cancelButtonVisibility;
            set => SetProperty(ref _cancelButtonVisibility, value);
        }

        private Visibility _okButtonVisibility = Visibility.Collapsed;
        public Visibility OKButtonVisibility
        {
            get => _okButtonVisibility;
            set => SetProperty(ref _okButtonVisibility, value);
        }

        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand OKCommand { get; }

        public MessageBoxResult Result { get; private set; }

        private CustomMessageBox messageBox;


        public CustomMessageBox MessageBox
        {
            get => messageBox;
            set => SetProperty(ref messageBox, value);
        }

        public CustomMessageBoxViewModel()
        {
            YesCommand = new RelayCommand(_ => SetResultAndClose(MessageBoxResult.Yes), _ => true);
            NoCommand = new RelayCommand(_ => SetResultAndClose(MessageBoxResult.No), _ => true);
            CancelCommand = new RelayCommand(_ => SetResultAndClose(MessageBoxResult.Cancel), _ => true);
            OKCommand = new RelayCommand(_ => SetResultAndClose(MessageBoxResult.OK), _ => true);
        }

        private void SetResultAndClose(MessageBoxResult result)
        {
            Result = result;
            CloseDialog();
        }

        private void CloseDialog()
        {
            if(MessageBox != null)
            {
                MessageBox.DialogResult = true;
                MessageBox.Close();
            }
        }

        public void SetButtonVisibility(MessageBoxButton buttons)
        {
            YesButtonVisibility = Visibility.Collapsed;
            NoButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            OKButtonVisibility = Visibility.Collapsed;

            switch (buttons)
            {
                case MessageBoxButton.YesNo:
                    YesButtonVisibility = Visibility.Visible;
                    NoButtonVisibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    YesButtonVisibility = Visibility.Visible;
                    NoButtonVisibility = Visibility.Visible;
                    CancelButtonVisibility = Visibility.Visible;
                    break;
                case MessageBoxButton.OK:
                    OKButtonVisibility = Visibility.Visible;
                    break;
                case MessageBoxButton.OKCancel:
                    OKButtonVisibility = Visibility.Visible;
                    CancelButtonVisibility = Visibility.Visible;
                    break;
            }
        }
    }
}