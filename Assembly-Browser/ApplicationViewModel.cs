using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Assembly_Browser
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;
        public AssemblyBrowser assemblyBrowser;
        
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
                               if (dialogService.OpenFileDialog())
                               {
                                   var assembly = new AssemblyBrowser();
                                   assembly.Types = fileService.Open(dialogService.FilePath);
                                   foreach (var type in assembly.Types)
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
        private List<Node> _types;
        public List<Node> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                OnPropertyChanged("Types");
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