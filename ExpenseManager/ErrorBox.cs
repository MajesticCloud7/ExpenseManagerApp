using System.Windows;

namespace ExpenseManager
{
    public static class ErrorBox
    {
        private static readonly string Caption = "Error";
        private static readonly MessageBoxButton Button = MessageBoxButton.OK;
        private static readonly MessageBoxImage Image = MessageBoxImage.Error;

        public static void Show(string errorText)
        {
            MessageBox.Show(errorText, Caption, Button, Image);
        }
    }
}
