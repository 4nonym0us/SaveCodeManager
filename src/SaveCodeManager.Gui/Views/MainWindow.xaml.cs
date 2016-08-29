using SaveCodeManager.Gui.ViewModels;
using SaveCodeManager.Gui.ViewModels.Interfaces;

namespace SaveCodeManager.Gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindowWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        //private IMainWindowViewModel _viewModel;

        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;

            InitializeComponent();
        }
    }
}
