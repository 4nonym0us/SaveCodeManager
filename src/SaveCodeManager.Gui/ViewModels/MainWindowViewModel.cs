using Abp.Dependency;
using GalaSoft.MvvmLight;
using PropertyChanged;
using SaveCodeManager.Gui.ViewModels.Interfaces;

namespace SaveCodeManager.Gui.ViewModels
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public MainWindowViewModel(IIocManager iocManager)
        {
        }

        //[OnCommand(nameof(EditSettings) + "Command")]
        //public void EditSettings()
        //{
        //    MessageBox.Show("Test");
        //}
    }
}