namespace Assembly_Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new AssemblyFileService());
        }
    }
}