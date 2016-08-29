using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;

namespace SaveCodeManager.Gui.ViewModels.Interfaces
{
    public interface ISavesViewModel<TViewModel>
        where TViewModel : ISaveCodeViewModel
    {
        ObservableCollection<TViewModel> SaveCodes { get; set; }

        Task RefreshSaveCodes();

        Timer RefreshTimer { get; set; }
    }
}