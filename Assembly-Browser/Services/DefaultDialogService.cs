using System.Windows;
using Interfaces;
using Microsoft.Win32;

namespace Services
{
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == false)
                return false;
            FilePath = openFileDialog.FileName;
            return true;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}