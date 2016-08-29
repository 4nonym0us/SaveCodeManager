using System.Windows;
using Commander;
using GalaSoft.MvvmLight;
using Microsoft.Win32;
using PropertyChanged;
using SaveCodeManager.Gui.Properties;

namespace SaveCodeManager.Gui.ViewModels
{
    [ImplementPropertyChanged]
    public class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        public string War3Path { get; set; }

        public int RefreshInterval { get; set; }

        public SettingsViewModel()
        {
            War3Path = Settings.Default.War3Path;
            RefreshInterval = Settings.Default.RefreshInterval;
        }

        [OnCommand(nameof(SaveSettings) + "Command")]
        public void SaveSettings()
        {
            Settings.Default["War3Path"] = War3Path;
            Settings.Default["RefreshInterval"] = RefreshInterval;
            Settings.Default.Save();
        }

        [OnCommand(nameof(OpenFIleDialog) + "Command")]
        public void OpenFIleDialog()
        {
            var ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "war3.exe";

            if (ofd.ShowDialog() == true)
            {
                MessageBox.Show(ofd.FileName);
            }

            War3Path = ofd.FileName;
        }
    }
}
