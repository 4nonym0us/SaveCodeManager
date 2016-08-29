using System.Collections.ObjectModel;
using System.Timers;
using Commander;
using GalaSoft.MvvmLight;
using PropertyChanged;
using SaveCodeManager.Core.Saves;
using SaveCodeManager.Core.Services;

namespace SaveCodeManager.Gui.ViewModels.Interfaces
{
    public interface ISavesViewModel<TViewModel>
        where TViewModel : ISaveCodeViewModel
    {
        ObservableCollection<TViewModel> SaveCodes { get; set; }

        void RefreshSaveCodes();

        Timer RefreshTimer { get; set; }
    }

    [ImplementPropertyChanged]
    public abstract class SavesViewModelBase<TViewModel> : ViewModelBase, ISavesViewModel<TViewModel>
        where TViewModel : ISaveCodeViewModel
    {
        public ObservableCollection<TViewModel> SaveCodes { get; set; }

        protected ISaveCodesLoader<ISaveCode> Loader { get; set; }

        [OnCommand(nameof(RefreshSaveCodes) + "Command")]
        public void RefreshSaveCodes()
        {
            throw new System.NotImplementedException();
        }

        public Timer RefreshTimer { get; set; }
    }
}