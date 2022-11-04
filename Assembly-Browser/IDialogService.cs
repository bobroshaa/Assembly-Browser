namespace Assembly_Browser
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        string FilePath { get; set; }   
        bool OpenFileDialog();
    }
}