using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Assembly_Browser
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IFileService _fileService;
        private readonly IDialogService _dialogService;
        private AssemblyBrowser _assemblyBrowser;
        
        public AssemblyBrowser Browser 
        {
            get => _assemblyBrowser;
            private set
            {
                _assemblyBrowser = value;
                OnPropertyChanged("Browser");
            }
        }
        
        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                       (_openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               if (_dialogService.OpenFileDialog())
                               {
                                   Browser = new AssemblyBrowser
                                   {
                                       Types = _fileService.Open(_dialogService.FilePath)
                                   };
                               }
                           }
                           catch (Exception ex)
                           {
                               _dialogService.ShowMessage(ex.Message);
                           }
                       }, _ => true));
            }
            
        }
        
        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
        }
 
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}