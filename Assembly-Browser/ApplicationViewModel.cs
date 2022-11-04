using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Assembly_Browser
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;
        
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                       (openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               if (dialogService.OpenFileDialog() == true)
                               {
                                   var assemblyTree = fileService.Open(dialogService.FilePath);
                                   foreach (var type in assemblyTree)
                                   {
                                       
                                   }
                                   dialogService.ShowMessage("Файл открыт");
                               }
                           }
                           catch (Exception ex)
                           {
                               dialogService.ShowMessage(ex.Message);
                           }
                       }));
            }
            
        }
        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
        }
 
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}