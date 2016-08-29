
//Probably not needed until I make dynamic map loading
//using System;
//using System.Collections.ObjectModel;
//using System.Threading.Tasks;
//using System.Timers;
//using Commander;
//using GalaSoft.MvvmLight;
//using PropertyChanged;
//using SaveCodeManager.Core.Saves;
//using SaveCodeManager.Core.Services;

//namespace SaveCodeManager.Gui.ViewModels.Interfaces
//{
//    [ImplementPropertyChanged]
//    public abstract class SavesViewModelBase<TViewModel> : ViewModelBase, ISavesViewModel<TViewModel>
//        where TViewModel : ISaveCodeViewModel
//    {
//        protected ISaveCodesLoader<ISaveCode> Loader { get; set; }
//        public ObservableCollection<TViewModel> SaveCodes { get; set; }

//        [OnCommand(nameof(RefreshSaveCodes) + "Command")]
//        public Task RefreshSaveCodes()
//        {
//            throw new NotImplementedException("Custom RefreshSaveCodes method must be implemented.");
//        }

//        public Timer RefreshTimer { get; set; }
//    }
//}