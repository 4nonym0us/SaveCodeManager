using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Abp.Dependency;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using SaveCodeManager.Gui.Properties;
using SaveCodeManager.Gui.ViewModels.Tkok;

namespace SaveCodeManager.Gui.Flyouts
{
    /// <summary>
    /// Interaction logic for SettingsFlyout.xaml
    /// </summary>
    public partial class SettingsFlyout : INotifyPropertyChanged
    {
        private readonly IocManager _iocManager;

        public SettingsFlyout()
        {
            _iocManager = IocManager.Instance;
            War3Path = Settings.Default.War3Path;
            RefreshInterval = Settings.Default.RefreshInterval;

            InitializeComponent();
        }


        public string War3Path
        {
            get { return _war3Path; }
            set
            {
                if (_war3Path == value)
                {
                    return;
                }
                _war3Path = value;
                RaisePropertyChanged(nameof(War3Path));
            }
        }

        public int RefreshInterval
        {
            get { return _refreshInterval; }
            set
            {
                if (_refreshInterval == value)
                {
                    return;
                }
                _refreshInterval = value;
                RaisePropertyChanged(nameof(RefreshInterval));
            }
        }

        public bool IsFirstStart
        {
            get { return _isFirstStart; }
            set
            {

                if (_isFirstStart == value)
                {
                    return;
                }
                _isFirstStart = value;
                RaisePropertyChanged(nameof(IsFirstStart));
            }
        }


        private ICommand _saveSettingsCommand;

        public ICommand SaveSettingsCommand
        {
            get
            {
                return _saveSettingsCommand ?? (_saveSettingsCommand = new RelayCommand(() =>
                {
                    Settings.Default["War3Path"] = War3Path;
                    Settings.Default["RefreshInterval"] = RefreshInterval;
                    Settings.Default.Save();
                    IsFirstStart = false;
                }));
            }
        }

        private ICommand _openFileDialogCommand;
        private string _war3Path;
        private int _refreshInterval;
        private bool _isFirstStart;

        public ICommand OpenFileDialogCommand
        {
            get
            {
                return _openFileDialogCommand ?? (_openFileDialogCommand = new RelayCommand(() =>
                {
                    var ofd = new OpenFileDialog
                    {
                        CheckFileExists = true,
                        Filter = "Warcraft III executable file|war3.exe"
                    };

                    if (ofd.ShowDialog() == true)
                    {
                        War3Path = new FileInfo(ofd.FileName).DirectoryName;
                        if (IsFirstStart)
                        {
                            var welcomeMessageBox = FindChildControl<TextBlock>(this, "FirstStartTextBlock") as TextBlock;
                            if (welcomeMessageBox != null)
                            {
                                welcomeMessageBox.Text = "Great! Now you can adjust the Saves pooling timer (if needed) and press the 'Back' to start using the application.";
                            }

                            SaveSettingsCommand.Execute(null);
                            _iocManager.Resolve<ITkokSavesViewModel>().RefreshSaveCodes();

                            // Restore panel width to default (300) value
                            BeginAnimation(WidthProperty, new DoubleAnimation
                            {
                                To = 300,
                                Duration = TimeSpan.FromMilliseconds(1000)
                            });
                        }
                    }
                }));
            }
        }

        private DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement fe = child as FrameworkElement;
                // Not a framework element or is null
                if (fe == null) return null;

                if (child is T && fe.Name == ctrlName)
                {
                    // Found the control so return
                    return child;
                }
                else
                {
                    // Not found it - search children
                    DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
