using System.Windows;
using Abp;
using Castle.Facilities.Logging;
using SaveCodeManager.Gui.Properties;
using SaveCodeManager.Gui.ViewModels.Locator;

namespace SaveCodeManager.Gui
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly AbpBootstrapper _bootstrapper;
        private Views.MainWindow _mainWindow;

        public App()
        {
            _bootstrapper = AbpBootstrapper.Create<SaveCodeManagerGuiModule>();
            _bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper.Initialize();

            _mainWindow = _bootstrapper.IocManager.Resolve<Views.MainWindow>();

            // If user runs program for first time he must set the war3path
            if (string.IsNullOrWhiteSpace(Settings.Default.War3Path))
            {
                _mainWindow.SettingsFlyout.IsFirstStart = true;
                _mainWindow.SettingsFlyout.Width = _mainWindow.Width;
                _mainWindow.SettingsFlyout.IsOpen = true;
            }
            _mainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ViewModelLocator.Cleanup();

            _bootstrapper.IocManager.Release(_mainWindow);
            _bootstrapper.Dispose();
        }
    }
}
