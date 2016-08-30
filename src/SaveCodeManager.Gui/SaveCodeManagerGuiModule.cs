using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using SaveCodeManager.Gui.Flyouts;
using SaveCodeManager.Gui.ViewModels;
using SaveCodeManager.Gui.ViewModels.Interfaces;
using SaveCodeManager.Gui.ViewModels.Tkok;

namespace SaveCodeManager.Gui
{
    [DependsOn(typeof(SaveCodeManagerCoreModule))]
    public class SaveCodeManagerGuiModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Views
            IocManager.RegisterIfNot<Views.MainWindow>();
            IocManager.RegisterIfNot<Views.TkokSaves>();

            // Flyouts
            IocManager.RegisterIfNot<SettingsFlyout>();

            // ViewModels
            IocManager.RegisterIfNot<IMainWindowViewModel, MainWindowViewModel>();
            IocManager.RegisterIfNot<ITkokSavesViewModel, TkokSavesViewModel>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
