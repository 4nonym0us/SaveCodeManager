using System.Reflection;
using Abp.Dependency;
using Commander;
using GalaSoft.MvvmLight;
using PropertyChanged;
using SaveCodeManager.Gui.ViewModels.Interfaces;
using Squirrel;

namespace SaveCodeManager.Gui.ViewModels
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public string AppVerion => Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        public string StatusBarText { get; set; }

        [OnCommand(nameof(OnWindowLoaded) + "Command")]
        public async void OnWindowLoaded()
        {
            //using (var mgr = new UpdateManager(@"E:\git\SaveCodeManager\Releases"))
            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/4nonym0us/SaveCodeManager"))
            {
                SquirrelAwareApp.HandleEvents(
                  onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                  onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                  onAppUninstall: v => mgr.RemoveShortcutForThisExe());

                await mgr.UpdateApp();
                await mgr.CreateUninstallerRegistryEntry();
            }
        }
    }
}