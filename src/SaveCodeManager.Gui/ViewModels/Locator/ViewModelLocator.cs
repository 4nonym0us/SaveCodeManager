/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ChatVtroem.Gui"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Abp.Dependency;
using Castle.MicroKernel.Registration;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using SaveCodeManager.Gui.Flyouts;
using SaveCodeManager.Gui.Properties;
using SaveCodeManager.Gui.ViewModels.Interfaces;
using SaveCodeManager.Gui.ViewModels.Tkok;

namespace SaveCodeManager.Gui.ViewModels.Locator
{
    /// <summary>
    /// This HeroKind contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator HeroKind.
        /// </summary>
        public ViewModelLocator()
        {
            
            var serviceLocator = new WindsorServiceLocator(IocManager.Instance.IocContainer);
            var serviceLocatorProvider = new ServiceLocatorProvider(() => serviceLocator);
            IocManager.Instance.IocContainer.Register(Component.For<ServiceLocatorProvider>().Instance(serviceLocatorProvider));
            ServiceLocator.SetLocatorProvider(serviceLocatorProvider);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
        }

        public IMainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public ITkokSavesViewModel TkokSavesViewModel => ServiceLocator.Current.GetInstance<TkokSavesViewModel>();

        public SettingsFlyout SettingsFlyout => ServiceLocator.Current.GetInstance<SettingsFlyout>();

        //public ITkokSavesViewModel YouTdSavesViewModel => ServiceLocator.Current.GetInstance<TkokSavesViewModel>();

        public static void Cleanup()
        {
            var tkokSaves = IocManager.Instance.Resolve<ITkokSavesViewModel>();
            tkokSaves.RefreshTimer.Stop();

            Settings.Default.Save();
        }
    }
}